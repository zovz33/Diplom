using Diplom.ASPNET.Application.Common.Mappings;

namespace Diplom.ASPNET.Application.Items.Auth.Login;

public class LoginResponseResult : IMapWith<Domain.Entities.Identity.User>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string JWT { get; set; }
}