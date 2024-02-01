using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Items.Auth.Login;

namespace Diplom.ASPNET.API.Models.Auth;

public class LoginDto : IMapWith<LoginCommand>
{
    [Required(ErrorMessage = "Ввод пароля обязателен")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Ввод пароля обязателен")]
    public string Password { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LoginDto, LoginCommand>()
            .ForMember(userCommand => userCommand.UserName, opt =>
                opt.MapFrom(userDto => userDto.UserName))
            .ForMember(userCommand => userCommand.Password, opt =>
                opt.MapFrom(userDto => userDto.Password));
    }
}