using MediatR;

namespace Diplom.ASPNET.Application.Items.Auth.Login;

public class LoginCommand : IRequest<LoginResponseResult>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}