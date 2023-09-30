using Microsoft.EntityFrameworkCore;
using PrimeTableware.ASPNET.Application;
using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Application.Interfaces;
using PrimeTableware.ASPNET.Infrastructure.Persistence;
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

            // Настройка контекста базы данных
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                     opt.UseSqlServer(builder.Configuration
                                .GetConnectionString("DbConnection")));

            // Настройка AutoMapper
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
            });

            // Добавление служб приложения и инфраструктуры
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            // Настройка контроллеров, CORS и Swagger
            builder.Services.AddControllers();
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

        private static void EnsureDatabaseCreated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    // Создание базы данных, если она еще не создана
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Произошла ошибка при создании базы данных.");
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
                    // Миграция базы данных
                    services.GetRequiredService<ApplicationDbContext>()
                            .Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Произошла ошибка при миграции базы данных.");
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

            // Настройка middleware
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            // Настройка контроллеров
            app.MapControllers();
        }
    }
}