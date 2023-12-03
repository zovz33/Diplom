using Microsoft.AspNetCore.Identity;
using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Application
{
    public interface ITokenService
    {
        string CreateToken(User user, List<Role> role);
        string RefreshToken();
    }
}