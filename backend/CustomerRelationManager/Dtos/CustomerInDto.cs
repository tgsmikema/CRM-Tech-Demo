namespace CustomerRelationManager.Model
{
    public class CustomerInDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string? Description  { get; set; } // optional field
        public string? PhoneNumber { get; set; } // optional field
        public int CreatedByUserId { get; set; }


    }
}
