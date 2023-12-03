using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Items.Auth.Login;

namespace Diplom.ASPNET.API.Models.Auth
{
    public class AuthResponseDto : IMapWith<LoginResponseResult>
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
