using System.ComponentModel.DataAnnotations;

namespace CustomerRelationManager.Model
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string? Description  { get; set; } // optional field
        public string? PhoneNumber { get; set; } // optional field
        [Required]
        public DateTime CreatedDateAndTime { get; set; }
        [Required]
        public int CreatedByUserId { get; set; }


    }
}
