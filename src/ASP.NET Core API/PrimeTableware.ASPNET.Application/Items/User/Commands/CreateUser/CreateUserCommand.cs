using MediatR;

namespace PrimeTableware.ASPNET.Application.Items.User.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; } 
    }
}
