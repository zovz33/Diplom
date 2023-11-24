using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using PrimeTableware.ASPNET.API.Middleware;
using PrimeTableware.ASPNET.Application;
using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Application.Interfaces;
using PrimeTableware.ASPNET.Domain.Entities;
using PrimeTableware.ASPNET.Infrastructure.Data;
using PrimeTableware.ASPNET.Infrastructure.Identity;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace PrimeTableware.ASPNET.API
{
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
                MigrateDatabase(app);
                Configure(app);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка в Program.cs :" + ex.Message);
            }
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                        opt.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser<int>>(opt => 
                    opt.SignIn.RequireConfirmedAccount = true) // Обязательно подтвержденный аккаунт для входа
                        .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentityCore<User>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddApiEndpoints()
                .AddUserManager<UserManager<User>>();

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);



            //builder.Services.AddIdentityApiEndpoints<User>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

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
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "DIPLOM REST API", Version = "v1" });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
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
            app.MapIdentityApi<IdentityUser>();
            app.MapSwagger().RequireAuthorization();
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
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
        private static void MigrateDatabase(WebApplication app)
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
}