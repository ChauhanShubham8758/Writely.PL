using System.ComponentModel.DataAnnotations.Schema;
using Writely.DAL.Models.Address.Domain;

namespace Writely.DAL.Models.Users.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public UserDetails UserDetails { get; set; }
        public ICollection<UserSessions> UserSessions { get; set; }
        public User()
        {

        }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
