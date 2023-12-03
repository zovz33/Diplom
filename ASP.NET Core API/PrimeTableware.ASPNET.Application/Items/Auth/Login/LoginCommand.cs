using MediatR;
using PrimeTableware.ASPNET.Application.Items.Auth.Login;

namespace PrimeTableware.ASPNET.Application.Items.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponseResult>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
