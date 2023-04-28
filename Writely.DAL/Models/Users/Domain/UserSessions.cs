using System.ComponentModel.DataAnnotations.Schema;

namespace Writely.DAL.Models.Users.Domain
{
    public class UserSessions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LastLoginAt { get; set; }
        public string LastLoginIp { get; set; }
        public virtual User User { get; set; }

        public UserSessions()
        {

        }
    }
}
