using Writely.DAL.Models.Users.Domain;

namespace Writely.BLL.ServiceModels.RequestModels.Users
{
    public class AddUserModel
    {
        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
    }
}
