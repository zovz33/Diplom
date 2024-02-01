using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Diplom.ASPNET.Application.Interfaces;
using Diplom.ASPNET.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Diplom.ASPNET.Infrastructure.Services.Identity;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _jwtKey;
    private readonly UserManager<User> _userManager;

    public TokenService(IConfiguration config, UserManager<User> userManager)
    {
        _config = config;
        _userManager = userManager;
        _jwtKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
    }

    public async Task<string> CreateJWT(User user)
    {
        var userClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.UserName),
            new(ClaimTypes.Email, user.Email),
            // new(ClaimTypes.GivenName, user.FirstName),
            // new(ClaimTypes.Surname, user.LastName)
        };

        var roles = await _userManager.GetRolesAsync(user);
        userClaims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var creadentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(userClaims),
            Expires = DateTime.UtcNow.AddDays(int.Parse(_config["JWT:ExpiresInDays"]!)),
            SigningCredentials = creadentials,
            Issuer = _config["JWT:Issuer"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var jwt = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(jwt);
    }
}