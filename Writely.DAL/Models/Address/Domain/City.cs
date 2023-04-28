using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Writely.DAL.Models.Users.Domain;

namespace Writely.DAL.Models.Address.Domain
{
    public  class City
    {
        [Key]
        public int Id { get; protected set; }

        public int StateId { get; protected set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; protected set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
