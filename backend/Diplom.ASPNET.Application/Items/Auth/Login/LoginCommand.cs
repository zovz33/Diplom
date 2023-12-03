using MediatR;
using Diplom.ASPNET.Application.Items.Auth.Login;

namespace Diplom.ASPNET.Application.Items.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponseResult>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
