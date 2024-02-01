using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Application.Interfaces;

public interface ITokenService
{
    Task<string> CreateJWT(User user);
}