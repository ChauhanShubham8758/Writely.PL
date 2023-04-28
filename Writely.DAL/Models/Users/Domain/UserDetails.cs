using System.ComponentModel.DataAnnotations.Schema;

namespace Writely.DAL.Models.Users.Domain
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StreetAddress { get; set; }
        public string AccountType { get; set; }
        public bool IsEmailVerified { get; set; }
        public string Bio { get; set; }
        public string Occupation { get; set; }
        public string Education { get; set; }
        public string Language { get; set; }
        public User User{ get; set; }

        public UserDetails()
        {

        }
    }
}
