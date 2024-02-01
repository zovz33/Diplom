using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Application.Items.User.Commands.UpdateUser;

namespace Diplom.ASPNET.API.Models;

public class UpdateUserDto : IMapWith<UpdateUserCommand>
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string ProfileImage { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
            .ForMember(userCommand => userCommand.UserName, opt =>
                opt.MapFrom(userDto => userDto.UserName))
            .ForMember(userCommand => userCommand.PasswordHash, opt =>
                opt.MapFrom(userDto => userDto.PasswordHash))
            .ForMember(userCommand => userCommand.Email, opt =>
                opt.MapFrom(userDto => userDto.Email))
            .ForMember(userCommand => userCommand.RoleId, opt =>
                opt.MapFrom(userDto => userDto.RoleId))
            .ForMember(userCommand => userCommand.PhoneNumber, opt =>
                opt.MapFrom(userDto => userDto.PhoneNumber))
            .ForMember(userCommand => userCommand.FirstName, opt =>
                opt.MapFrom(userDto => userDto.FirstName))
            .ForMember(userCommand => userCommand.MiddleName, opt =>
                opt.MapFrom(userDto => userDto.MiddleName))
            .ForMember(userCommand => userCommand.LastName, opt =>
                opt.MapFrom(userDto => userDto.LastName))
            .ForMember(userCommand => userCommand.Gender, opt =>
                opt.MapFrom(userDto => userDto.Gender))
            .ForMember(userCommand => userCommand.Address, opt =>
                opt.MapFrom(userDto => userDto.Address))
            .ForMember(userCommand => userCommand.DateOfBirth, opt =>
                opt.MapFrom(userDto => userDto.DateOfBirth))
            .ForMember(userCommand => userCommand.ProfileImage, opt =>
                opt.MapFrom(userDto => userDto.ProfileImage));
    }
}