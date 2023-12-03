using AutoMapper;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Diplom.ASPNET.API.Controllers.Base;
using Diplom.ASPNET.API.Models;
using Diplom.ASPNET.API.Models.Auth;
using Diplom.ASPNET.Application;
using Diplom.ASPNET.Application.Items.Auth.Commands.Login;
using Diplom.ASPNET.Application.Items.Auth.Login;
using Diplom.ASPNET.Application.Items.User.Commands.CreateUser;
using Diplom.ASPNET.Application.Items.User.Queries.GetUserById;
using Diplom.ASPNET.Domain.Entities.Identity;
using Diplom.ASPNET.Infrastructure;
using Diplom.ASPNET.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Diplom.ASPNET.API.Controllers
{
    [ApiController]
    [Route("[controller]"), AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthenticationController(UserManager<User> userManager, RoleManager<Role> roleManager, 
            IConfiguration configuration, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
            _tokenService = tokenService; 
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseResult>> Login([FromBody] LoginCommand request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<LoginCommand>(request);
            command.Email = request.Email;
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        //[HttpPost("register")]
        //public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequest request)
        //{
        //    if (!ModelState.IsValid) return BadRequest(request);

        //    var user = new ApplicationUser
        //    {
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        MiddleName = request.MiddleName,
        //        Email = request.Email,
        //        UserName = request.Email
        //    };
        //    var result = await _userManager.CreateAsync(user, request.Password);

        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //    if (!result.Succeeded) return BadRequest(request);

        //    var findUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

        //    if (findUser == null) throw new Exception($"User {request.Email} not found");

        //    await _userManager.AddToRoleAsync(findUser, RoleConsts.Member);

        //    return await Authenticate(new AuthRequest
        //    {
        //        Email = request.Email,
        //        Password = request.Password
        //    });
        //}

        //[HttpPost]
        //[Route("refresh-token")]
        //public async Task<IActionResult> RefreshToken(TokenModel? tokenModel)
        //{
        //    if (tokenModel is null)
        //    {
        //        return BadRequest("Invalid client request");
        //    }

        //    var accessToken = tokenModel.AccessToken;
        //    var refreshToken = tokenModel.RefreshToken;
        //    var principal = _configuration.GetPrincipalFromExpiredToken(accessToken);

        //    if (principal == null)
        //    {
        //        return BadRequest("Invalid access token or refresh token");
        //    }

        //    var username = principal.Identity!.Name;
        //    var user = await _userManager.FindByNameAsync(username!);

        //    if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        //    {
        //        return BadRequest("Invalid access token or refresh token");
        //    }

        //    var newAccessToken = _configuration.CreateToken(principal.Claims.ToList());
        //    var newRefreshToken = _configuration.GenerateRefreshToken();

        //    user.RefreshToken = newRefreshToken;
        //    await _userManager.UpdateAsync(user);

        //    return new ObjectResult(new
        //    {
        //        accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
        //        refreshToken = newRefreshToken
        //    });
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("revoke/{username}")]
        //public async Task<IActionResult> Revoke(string username)
        //{
        //    var user = await _userManager.FindByNameAsync(username);
        //    if (user == null) return BadRequest("Invalid user name");

        //    user.RefreshToken = null;
        //    await _userManager.UpdateAsync(user);

        //    return Ok();
        //}

        //[Authorize]
        //[HttpPost]
        //[Route("revoke-all")]
        //public async Task<IActionResult> RevokeAll()
        //{
        //    var users = _userManager.Users.ToList();
        //    foreach (var user in users)
        //    {
        //        user.RefreshToken = null;
        //        await _userManager.UpdateAsync(user);
        //    }

        //    return Ok();
        //}
    }
}

// Серб

//var command = new LoginCommand(request.Email);

//Results<string> tokenResult = await Sender.Send(
//    command,
//    cancellationToken);
//if (tokenResult.IsFailure) 
//{
//    return HandleFailure(tokenResult);
//}

//// 2

//var managedUser = await _userManager.FindByEmailAsync(request.Email);

//if (managedUser == null)
//{
//    return BadRequest("Пользователя не существует" + request.Email);
//}

//var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.PasswordHash);

//if (!isPasswordValid)
//{
//    return BadRequest("Bad credentials");
//}

//var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
//if (user is null)
//    return Unauthorized();

//var roleIds = await _context.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
//var roles = _context.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

//var accessToken = _tokenService.CreateToken(user, roles);
//user.RefreshToken = _configuration.GenerateRefreshToken();
//user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

//await _context.SaveChangesAsync();

//return Ok(new AuthResponseDto
//{
//    Username = user.UserName!,
//    Email = user.Email!,
//    Token = accessToken,
//    RefreshToken = user.RefreshToken
//});
