using Diplom.ASPNET.Application.Common.Interfaces;
using MediatR;
using Serilog;

namespace Diplom.ASPNET.Application.Common.Behaviours;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUserService _currentUserService;

    public LoggingBehavior(ICurrentUserService currentUserService) =>
        _currentUserService = currentUserService;

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;

        Log.Information("User log: {Name} {@UserId}",
            requestName, userId);

        var response = await next();

        return response;
    }
}