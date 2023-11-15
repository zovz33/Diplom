using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using PrimeTableware.ASPNET.API.Middleware;
using PrimeTableware.ASPNET.Application;
using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Application.Interfaces;
using PrimeTableware.ASPNET.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace PrimeTableware.ASPNET.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                ConfigureServices(builder);
                var app = builder.Build();
                EnsureDatabaseCreated(app);
                MigrateDatabase(app);
                Configure(app);
                app.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка в Program.cs :" + ex.Message);
            }
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            var scope = builder.Services.BuildServiceProvider().CreateScope();

            builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            builder.Services.AddAuthorizationBuilder();
            ConfigureDatabase(builder);

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
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Clean Structured API", Version = "v1" });
            });
        }

        private static void ConfigureDatabase(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                        opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
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

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // middleware
            app.UseCustomExceptionHandler();

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            //  
            app.MapControllers();
        }
    }
}