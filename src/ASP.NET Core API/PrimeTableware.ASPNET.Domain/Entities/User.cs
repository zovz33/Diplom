using Microsoft.AspNetCore.Identity;

namespace PrimeTableware.ASPNET.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; } 
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
