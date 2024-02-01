using System.Security.Claims;
using AutoMapper;
using Diplom.ASPNET.API.Controllers.Base;
using Diplom.ASPNET.API.Models.Auth;
using Diplom.ASPNET.Application.Items.Auth.Login;
using Diplom.ASPNET.Application.Items.Auth.RefreshToken;
using Diplom.ASPNET.Application.Items.Auth.Registartion;
using Diplom.ASPNET.Domain.Entities.Identity;
using Diplom.ASPNET.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.ASPNET.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthenticationController : BaseController
{
    private readonly IConfiguration _configuration;

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;

    public AuthenticationController(UserManager<User> userManager, RoleManager<Role> roleManager,
        IConfiguration configuration, IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _mapper = mapper;
    }

    [Authorize]
    [HttpGet("Refresh-token")]
    public async Task<ActionResult<RefreshResponseResult>> RefreshToken()
    {
        var command = new RefreshCommand { Email = User.FindFirst(ClaimTypes.Email)?.Value }; 
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPost("Login")]
    public async Task<ActionResult<LoginResponseResult>> Login([FromBody] LoginDto request)
    {
        var command = _mapper.Map<LoginCommand>(request);
        var result = await Mediator.Send(command);
        
        return Ok(result);
    }

    [HttpPost("Register")]
    public async Task<ActionResult<int>> Register([FromBody] RegisterDto request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var result = await Mediator.Send(command);


        return Ok(result);
    }

    #region Private Helper Methods
    
    //private async Task<bool> SendConfirmEMailAsync(User user)
    //{
    //    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
    //    token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
    //    var url = $"{_config["JWT:ClientUrl"]}/{_config["Email:ConfirmEmailPath"]}?token={token}&email={user.Email}";

    //    var body = $"<p>Hello: {user.FirstName} {user.LastName}</p>" +
    //        "<p>Please confirm your email address by clicking on the following link.</p>" +
    //        $"<p><a href=\"{url}\">Click here</a></p>" +
    //        "<p>Thank you,</p>" +
    //        $"<br>{_config["Email:ApplicationName"]}";

    //    var emailSend = new EmailSendDto(user.Email, "Confirm your email", body);

    //    return await _emailService.SendEmailAsync(emailSend);
    //}

    //private async Task<bool> SendForgotUsernameOrPasswordEmail(User user)
    //{
    //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    //    token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
    //    var url = $"{_config["JWT:ClientUrl"]}/{_config["Email:ResetPasswordPath"]}?token={token}&email={user.Email}";

    //    var body = $"<p>Hello: {user.FirstName} {user.LastName}</p>" +
    //       $"<p>Username: {user.UserName}.</p>" +
    //       "<p>In order to reset your password, please click on the following link.</p>" +
    //       $"<p><a href=\"{url}\">Click here</a></p>" +
    //       "<p>Thank you,</p>" +
    //       $"<br>{_config["Email:ApplicationName"]}";

    //    var emailSend = new EmailSendDto(user.Email, "Forgot username or password", body);

    //    return await _emailService.SendEmailAsync(emailSend);
    //}

    //private async Task<bool> FacebookValidatedAsync(string accessToken, string userId)
    //{
    //    var facebookKeys = _config["Facebook:AppId"] + "|" + _config["Facebook:AppSecret"];
    //    var fbResult = await _facebookHttpClient.GetFromJsonAsync<FacebookResultDto>($"debug_token?input_token={accessToken}&access_token={facebookKeys}");

    //    if (fbResult == null || fbResult.Data.Is_Valid == false || !fbResult.Data.User_Id.Equals(userId))
    //    {
    //        return false;
    //    }

    //    return true;
    //}

    //private async Task<bool> GoogleValidatedAsync(string accessToken, string userId)
    //{
    //    var payload = await GoogleJsonWebSignature.ValidateAsync(accessToken);

    //    if (!payload.Audience.Equals(_config["Google:ClientId"]))
    //    {
    //        return false;
    //    }

    //    if (!payload.Issuer.Equals("accounts.google.com") && !payload.Issuer.Equals("https://accounts.google.com"))
    //    {
    //        return false;
    //    }

    //    if (payload.ExpirationTimeSeconds == null)
    //    {
    //        return false;
    //    }

    //    DateTime now = DateTime.Now.ToUniversalTime();
    //    DateTime expiration = DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).DateTime;
    //    if (now > expiration)
    //    {
    //        return false;
    //    }

    //    if (!payload.Subject.Equals(userId))
    //    {
    //        return false;
    //    }

    //    return true;
    //}

    #endregion
}