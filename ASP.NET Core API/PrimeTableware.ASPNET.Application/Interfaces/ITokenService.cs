using Microsoft.AspNetCore.Identity;
using PrimeTableware.ASPNET.Domain.Entities.Identity;

namespace PrimeTableware.ASPNET.Application
{
    public interface ITokenService
    {
        string CreateToken(User user, List<Role> role);
        string RefreshToken();
    }
}