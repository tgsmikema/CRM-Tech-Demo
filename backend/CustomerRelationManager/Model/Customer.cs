using System.ComponentModel.DataAnnotations;

namespace CustomerRelationManager.Model
{
    // model class for representing the data types
    public class Customer
    {
        // [Key] annotation means the key for the table after it is converted to SQL database table
        [Key]
        public int Id { get; set; }
        // [Required] annotation means it cannot receive a NULL value for the database entry.
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        // 'string?' means optional string field in the database, that can receive a NULL value.
        public string? Description  { get; set; } // optional field
        public string? PhoneNumber { get; set; } // optional field
        [Required]
        public DateTime CreatedDateAndTime { get; set; }
        [Required]
        public int CreatedByUserId { get; set; }


    }
}
