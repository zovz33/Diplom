using System.Security.Claims;
using MediatR;

namespace Diplom.ASPNET.Application.Items.Auth.RefreshToken;

public class RefreshCommand : IRequest<RefreshResponseResult>
{
    public string Email { get; set; } 
}