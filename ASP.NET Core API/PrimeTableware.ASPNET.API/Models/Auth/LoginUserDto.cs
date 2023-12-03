using AutoMapper;
using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Application.Items.Auth.Commands.Login;
using PrimeTableware.ASPNET.Application.Items.User.Commands.CreateUser;
using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.API.Models.Auth
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
