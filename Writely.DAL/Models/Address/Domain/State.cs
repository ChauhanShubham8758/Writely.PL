using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Writely.DAL.Models.Address.Domain
{
    public class State
    {
        [Key]
        public int Id { get; protected set; }

        public int CountryId { get; protected set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; protected set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }

    public class NullState : State
    {

    }
}
