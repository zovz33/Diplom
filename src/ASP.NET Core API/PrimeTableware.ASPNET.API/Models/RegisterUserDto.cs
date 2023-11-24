using AutoMapper;
using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Application.Items.Auth.Commands;
using PrimeTableware.ASPNET.Application.Items.Auth.Commands.Login;

namespace PrimeTableware.ASPNET.API.Models
{
    public class RegisterUserDto : IMapWith<LoginCommand>
    {

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
        public string Email { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterUserDto, LoginCommand>()
                .ForMember(registerCommand => registerCommand.UserName, opt =>
            opt.MapFrom(userDto => userDto.UserName))
                .ForMember(registerCommand => registerCommand.PasswordHash, opt =>
            opt.MapFrom(userDto => userDto.PasswordHash))
                .ForMember(registerCommand => registerCommand.ConfirmPasswordHash, opt =>
            opt.MapFrom(userDto => userDto.ConfirmPasswordHash)) // И эту строку
                .ForMember(registerCommand => registerCommand.Email, opt =>
            opt.MapFrom(userDto => userDto.Email));
        }

    }
}
