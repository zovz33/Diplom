using System.ComponentModel.DataAnnotations;

namespace PrimeTableware.ASPNET.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

    }
}
