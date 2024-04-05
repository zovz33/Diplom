using System.Security.Claims;
using Diplom.ASPNET.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Diplom.ASPNET.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor) =>
        _httpContextAccessor = httpContextAccessor;

    public int UserId
    {
        get
        {
            var id = _httpContextAccessor.HttpContext?.User?
                .FindFirstValue(ClaimTypes.NameIdentifier);
        
            // Проверяем, что id не пуст и представляет собой целое число
            if (int.TryParse(id, out int userId))
                return userId;
            else
                return 0;
        }
    }
}