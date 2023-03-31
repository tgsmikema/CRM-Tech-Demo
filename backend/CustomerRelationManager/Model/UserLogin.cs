using System.ComponentModel.DataAnnotations;

namespace CustomerRelationManager.Model
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }
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
