using System.ComponentModel.DataAnnotations;

namespace CustomerRelationManager.Model
{
    // model class for representing the data types
    public class UserLogin
    {
        // [Key] annotation means the key for the table after it is converted to SQL database table
        [Key]
        public int Id { get; set; }
        // [Required] annotation means it cannot receive a NULL value for the database entry.
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserType { get; set; }

    }
}
