using System.ComponentModel.DataAnnotations;

namespace Writely.DAL.Models.Address.Domain
{
    public  class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; protected set; }

        public int CountryCode { get; set; }

        public string Currency { get; set; }

        public virtual ICollection<State> States { get; set; }
    }

    public class NullCountry : Country
    {

    }
}
