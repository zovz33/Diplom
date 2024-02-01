using System.Reflection;
using System.Security.Claims;
using System.Text;
using Diplom.ASPNET.API.Middleware;
using Diplom.ASPNET.Application;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Interfaces;
using Diplom.ASPNET.Domain.Entities.Identity;
using Diplom.ASPNET.Infrastructure.Data;
using Diplom.ASPNET.Infrastructure.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Filters;

namespace Diplom.ASPNET.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        try
        {
            ConfigureServices(builder);
            var app = builder.Build();
            EnsureDatabaseCreated(app);
            //  UpdateDatabase(app);
            Configure(app);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка в Program.cs :" + ex.Message);
        }
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DbConnection")
                               ?? throw new InvalidOperationException("'DbConnection' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString).UseLazyLoadingProxies());

        builder.Services.AddScoped<ITokenService, TokenService>();


        builder.Services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<Role>>()
            .AddSignInManager<SignInManager<User>>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
            // блокировка на 5 минут после 5 неудачных попыток
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(0);
            options.Lockout.MaxFailedAccessAttempts = 555;
            options.Lockout.AllowedForNewUsers = true;
            // Нвстройки для пароля.
            options.Password.RequireDigit = false; // обязательно хотя-бы одно число в пароле
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;
            // Настройки для входа
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            // Настройки пользователя
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = true;
        });

        builder.Services.AddAuthorization(o =>
        {
            //options.AddPolicy("Client", policy => policy.RequireClaim(ClaimTypes.Email));
            //options.AddPolicy(
            //    "Admin",
            //    policy => policy.RequireClaim(ClaimTypes.Email).RequireClaim(ClaimTypes.Role, "Admin")
            //);

            //Для всех контроллеров без[Authorize]
            //o.FallbackPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme) 
            //    .Build();

            //Для контроллеров[Authorize] без каких-либо атрибутов
            o.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            //foreach (var permission in AppPermissions.GetAll())
            //{
            //    options.AddPolicy(permission,
            //        policy => policy.Requirements.Add(new PermissionRequirement(permission)));
            //}
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    (o =>
            //{
            //    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            .AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    SaveSigninToken = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    //ValidAudience = builder.Configuration["Jwt:Audience"], временно отключил в соответствии с курсом
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
                };
            });
        builder.Services.AddAuthorizationBuilder();

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
        });

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "DIPLOM REST API", Version = "v1" });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Введите JWT токен",
                Name = "Авторизация",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });
    }


    private static void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        // middleware

        app.MapSwagger().RequireAuthorization();
        app.UseCustomExceptionHandler();
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("AllowAll");

        app.MapControllers();
        app.Run();
    }

    private static void EnsureDatabaseCreated(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, $"Ошибка при создании базы данных: {ex.Message}");
            }
        }
    }

    private static void UpdateDatabase(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                services.GetRequiredService<ApplicationDbContext>()
                    .Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, $"Ошибка при миграции базы данных: {ex.Message}");
            }
        }
    }
}