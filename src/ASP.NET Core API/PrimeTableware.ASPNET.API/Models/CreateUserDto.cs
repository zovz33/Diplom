using AutoMapper;
using PrimeTableware.ASPNET.Application.Common.Mappings;
using PrimeTableware.ASPNET.Application.Items.User.Commands;

namespace PrimeTableware.ASPNET.API.Models
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPasswordHash { get; set; }
        public string Email { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userCommand => userCommand.UserName, opt =>
            opt.MapFrom(userDto => userDto.UserName))
                .ForMember(userCommand => userCommand.PasswordHash, opt =>
            opt.MapFrom(userDto => userDto.PasswordHash))
                .ForMember(userCommand => userCommand.ConfirmPasswordHash, opt =>
            opt.MapFrom(userDto => userDto.ConfirmPasswordHash)) // И эту строку
                .ForMember(userCommand => userCommand.Email, opt =>
            opt.MapFrom(userDto => userDto.Email));
        }

    }
}
