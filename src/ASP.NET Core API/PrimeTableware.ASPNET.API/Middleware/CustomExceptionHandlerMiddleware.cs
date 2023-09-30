using PrimeTableware.ASPNET.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace PrimeTableware.ASPNET.API.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        // Следующий делегат в конвейере обработки запросов
        private readonly RequestDelegate _next;

        // Конструктор, который принимает следующий делегат в конвейере
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
            => _next = next;

        // Метод Invoke, который вызывается для каждого запроса
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            { 
                await HandleExceptionAsync(context, ex);
            }
        }

        // Метод для обработки исключений
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (ex)
            {
                case FluentValidation.ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            // Устанавливаем тип содержимого ответа и статус кода
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            // Если результат пуст, сериализуем сообщение об ошибке в JSON
            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = ex.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
