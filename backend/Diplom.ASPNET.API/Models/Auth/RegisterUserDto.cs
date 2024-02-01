using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Items.Auth.Login;
using Diplom.ASPNET.Application.Items.Auth.Registartion;

namespace Diplom.ASPNET.API.Models.Auth;

public class RegisterUserDto : IMapWith<LoginCommand>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterUserDto, RegisterCommand>()
            .ForMember(registerCommand => registerCommand.UserName, opt =>
        opt.MapFrom(userDto => userDto.UserName))
            .ForMember(registerCommand => registerCommand.Password, opt =>
        opt.MapFrom(userDto => userDto.Password))
            .ForMember(registerCommand => registerCommand.ConfirmPassword, opt =>
        opt.MapFrom(userDto => userDto.ConfirmPassword))
            .ForMember(registerCommand => registerCommand.Email, opt =>
        opt.MapFrom(userDto => userDto.Email));
    }
}