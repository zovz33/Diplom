using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.Application.Items.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; } 
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
    }
}
