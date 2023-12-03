using Microsoft.Extensions.Configuration;
using Diplom.ASPNET.Application;
using Diplom.ASPNET.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Diplom.ASPNET.Infrastructure
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user, List<Role> roles)
        {
            var token = JwtBearerExtensions.CreateJwtToken(user.CreateClaims(roles), _configuration);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public string RefreshToken()
        {
            return _configuration.GenerateRefreshToken();
        }
    }
}