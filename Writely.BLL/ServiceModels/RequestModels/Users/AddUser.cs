namespace Writely.BLL.ServiceModels.RequestModels.Users
{
    public class AddUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
