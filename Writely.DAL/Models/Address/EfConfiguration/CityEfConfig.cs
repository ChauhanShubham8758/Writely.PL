using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Writely.DAL.Models.Address.Domain;

namespace Writely.DAL.Models.Address.EfConfiguration
{
    public  class CityEfConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
              .HasOne<State>(s => s.State)
              .WithMany(c => c.Cities)
              .HasForeignKey(c => c.StateId)
              .OnDelete(DeleteBehavior.Restrict);

            //builder.HasKey(c => new { c.StateId, c.Name });
        }
    }
}
