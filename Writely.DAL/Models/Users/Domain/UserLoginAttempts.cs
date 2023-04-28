using System.ComponentModel.DataAnnotations.Schema;

namespace Writely.DAL.Models.Users.Domain
{
    public  class UserLoginAttempts
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int MaximumAttempts { get; set; }
        public TimeSpan LoginLockOutTime { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public UserLoginAttempts()
        {

        }
    }
}
