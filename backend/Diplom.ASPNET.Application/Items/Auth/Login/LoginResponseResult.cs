using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;

namespace Diplom.ASPNET.Application.Items.Auth.Login
{
    public class LoginResponseResult : IMapWith<Domain.Entities.Identity.User>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.Identity.User, LoginResponseResult>()
                .ForMember(LoginResponseResult => LoginResponseResult.Email,
                opt => opt.MapFrom(user => user.Email))
                .ForMember(LoginResponseResult => LoginResponseResult.UserName,
                opt => opt.MapFrom(user => user.UserName));
                //.ForMember(LoginResponseResult => LoginResponseResult.Token,
                //    opt => opt.MapFrom(user => user.RefreshToken))
                //.ForMember(LoginResponseResult => LoginResponseResult.RefreshToken,
                //    opt => opt.MapFrom(user => user.RefreshToken));
        }
    }
}
