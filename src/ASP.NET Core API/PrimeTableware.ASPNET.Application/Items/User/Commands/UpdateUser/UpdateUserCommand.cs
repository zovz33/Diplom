using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.Application.Items.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        [Required]
        public int Id { get; set; }
        public string UserName { get; set; } 
        public string PasswordHash { get; set; } 
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string MobilePhone { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string ProfileImage { get; set; }
    }
}
