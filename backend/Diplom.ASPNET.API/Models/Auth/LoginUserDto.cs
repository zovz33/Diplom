using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Items.Auth.Commands.Login;
using Diplom.ASPNET.Application.Items.User.Commands.CreateUser;
using System.ComponentModel.DataAnnotations;

namespace Diplom.ASPNET.API.Models.Auth
{
    public class LoginUserDto : IMapWith<LoginCommand>
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoginUserDto, LoginCommand>()
                .ForMember(userCommand => userCommand.Email, opt =>
            opt.MapFrom(userDto => userDto.Email))
                .ForMember(userCommand => userCommand.PasswordHash, opt =>
            opt.MapFrom(userDto => userDto.Password));
        }
    }
}
