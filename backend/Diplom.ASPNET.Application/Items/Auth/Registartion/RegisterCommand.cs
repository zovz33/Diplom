using MediatR;

namespace Diplom.ASPNET.Application.Items.Auth.Registartion;

public class RegisterCommand : IRequest<int>
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}