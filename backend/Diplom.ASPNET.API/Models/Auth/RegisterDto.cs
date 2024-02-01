using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Items.Auth.Registartion;

namespace Diplom.ASPNET.API.Models.Auth;

public class RegisterDto : IMapWith<RegisterCommand>
{
    [Required(ErrorMessage = "User Name is required")]
    public string UserName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }

    [Required(ErrorMessage = "ConfirmPassword is required")]
    public string ConfirmPassword { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RegisterDto, RegisterCommand>()
            .ForMember(command => command.UserName, opt =>
                opt.MapFrom(dto => dto.UserName))
            .ForMember(command => command.Email, opt =>
                opt.MapFrom(dto => dto.Email))
            .ForMember(command => command.Password, opt =>
                opt.MapFrom(dto => dto.Password))
            .ForMember(command => command.ConfirmPassword, opt =>
                opt.MapFrom(dto => dto.ConfirmPassword));
    }
}