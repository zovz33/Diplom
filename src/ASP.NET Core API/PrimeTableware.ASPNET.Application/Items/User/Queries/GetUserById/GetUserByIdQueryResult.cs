using AutoMapper;
using PrimeTableware.ASPNET.Application.Common.Mappings;

namespace PrimeTableware.ASPNET.Application.Items.User.Queries.GetUserById
{
    public class GetUserByIdQueryResult : IMapWith<Domain.Entities.User>
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
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
            profile.CreateMap<Domain.Entities.User, GetUserByIdQueryResult>()
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.UserName,
                opt => opt.MapFrom(user => user.UserName))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.PasswordHash,
                opt => opt.MapFrom(user => user.PasswordHash))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.Email,
                opt => opt.MapFrom(user => user.Email))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.PhoneNumber,
                opt => opt.MapFrom(user => user.PhoneNumber))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.FirstName,
                opt => opt.MapFrom(user => user.FirstName))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.MiddleName,
                opt => opt.MapFrom(user => user.MiddleName))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.LastName,
                opt => opt.MapFrom(user => user.LastName))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.Gender,
                opt => opt.MapFrom(user => user.Gender))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.Address,
                opt => opt.MapFrom(user => user.Address)) 
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.DateOfBirth,
                opt => opt.MapFrom(user => user.DateOfBirth))
                .ForMember(GetUserByIdQueryResult => GetUserByIdQueryResult.ProfileImage,
                opt => opt.MapFrom(user => user.ProfileImage));
        }

    }
}
