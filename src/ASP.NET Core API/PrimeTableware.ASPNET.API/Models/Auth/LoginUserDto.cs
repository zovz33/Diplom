using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.API.Models.Auth
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
