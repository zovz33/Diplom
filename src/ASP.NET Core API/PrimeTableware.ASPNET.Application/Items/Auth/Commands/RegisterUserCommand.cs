using MediatR;

namespace PrimeTableware.ASPNET.Application.Items.Auth.Commands
{
    public class RegisterUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
        public string Email { get; set; } 
    }
}
