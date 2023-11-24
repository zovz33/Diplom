using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrimeTableware.ASPNET.API.Models.Auth;
using PrimeTableware.ASPNET.Application.Items.User.Queries.GetUserById;
using PrimeTableware.ASPNET.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrimeTableware.ASPNET.API.Controllers
{
    [ApiController]
    [Route("api/[controller]"), Authorize]
    public class AuthenticateController : ControllerBase
    {
        //[HttpPost]
        //public async Task<ActionResult<RegisterUserDto>> RegisterUser(LoginUserDto user)
        //{ 
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<LoginUserDto>> LoginUser(int id)
        //{ 
        //}

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            // Get the user input
            var email = Request.Form["email"];
            var password = Request.Form["password"];

            // Authenticate the user
            var user = await userManager.FindByEmailAsync(email);
            if (user == null || !await userManager.CheckPasswordAsync(user, password))
            {
                return BadRequest("Invalid username or password.");
            }

            // Create a token for the user
            //var token = await userManager.GenerateUserTokenAsync(user);

            // Return the token
            return Ok(new {  });
        }

        //public async Task<IActionResult> ProtectedResource()
        //{
        //    // Get the token from the request
        //    var token = Request.Headers["Authorization"];

        //    // Validate the token
        //    //var claims = await userManager.ValidateTokenAsync(token);
        //    //if (claims == null)
        //    //{
        //    //    return Unauthorized("Invalid token.");
        //    //}

        //    // Return the protected resource
        //    return Ok("You are authorized to access this resource.");
        //}
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register()
        {

            //if (claims == null)
            //{
            //    return Unauthorized("Invalid token.");
            //}

            // Return the protected resource
            return Ok("You are authorized to access this resource.");
        }
    }
}