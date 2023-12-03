using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Application.Items.Auth.Login;

namespace PrimeTableware.ASPNET.API.Models.Auth
{
    public class AuthResponseDto : IMapWith<LoginResponseResult>
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
