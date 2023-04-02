namespace CustomerRelationManager.Dtos
{
    // Data Transfer Objects for mapping into or out of the original object to achieve
    // data encapsulation
    public class UserLoginOutDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
