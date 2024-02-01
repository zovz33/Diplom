using AutoMapper;
using Diplom.ASPNET.Application.Common.Mappings;
using Diplom.ASPNET.Domain.Entities.Identity;

namespace Diplom.ASPNET.Application.Lists.Queries.GetUserList;

public class UserLookupDto : IMapWith<User>
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string ProfileImage { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserLookupDto>()
            .ForMember(UserDto => UserDto.Id,
                opt => opt.MapFrom(user => user.Id))
            .ForMember(UserDto => UserDto.UserName,
                opt => opt.MapFrom(user => user.UserName))
            .ForMember(UserDto => UserDto.FirstName,
                opt => opt.MapFrom(user => user.FirstName))
            .ForMember(UserDto => UserDto.MiddleName,
                opt => opt.MapFrom(user => user.MiddleName))
            .ForMember(UserDto => UserDto.LastName,
                opt => opt.MapFrom(user => user.LastName))
            .ForMember(UserDto => UserDto.Gender,
                opt => opt.MapFrom(user => user.Gender))
            .ForMember(UserDto => UserDto.ProfileImage,
                opt => opt.MapFrom(user => user.ProfileImage))
            ;
    }
}