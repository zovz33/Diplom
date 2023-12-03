using FluentValidation;
using MediatR;

namespace Diplom.ASPNET.Application.Common.Behaviours
{
    // Класс ValidationBehavior реализует интерфейс IPipelineBehavior из MediatR.
    // Это позволяет ему встраиваться в конвейер обработки запросов MediatR.
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        // Список валидаторов для типа запроса TRequest.
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        // Конструктор получает все валидаторы для типа запроса TRequest через dependency injection.
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) =>
            _validators = validators;

        // Метод Handle вызывается при обработке запроса.
        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Создаем контекст валидации для текущего запроса.
            var context = new ValidationContext<TRequest>(request);

            // Получаем все ошибки валидации от всех валидаторов.
            var failures = _validators
                .Select(v => v.Validate(context))  // Применяем каждый валидатор к контексту.
                .SelectMany(result => result.Errors)  // Получаем все ошибки из результатов валидации.
                .Where(failure => failure != null)  // Фильтруем ненулевые ошибки.
                .ToList();

            // Если есть ошибки валидации, выбрасываем исключение.
            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            // Если нет ошибок, продолжаем обработку запроса.
            return await next();
        }

    }
}
