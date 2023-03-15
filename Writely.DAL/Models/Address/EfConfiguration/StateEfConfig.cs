using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writely.DAL.Models.Address.Domain;

namespace Writely.DAL.Models.Address.EfConfiguration
{
    public  class StateEfConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
              .HasOne<Country>(c => c.Country)
              .WithMany(s => s.States)
              .HasForeignKey(c => c.CountryId)
              .OnDelete(DeleteBehavior.Restrict);

            //builder.HasKey(s => new { s.CountryId, s.Name });
        }
    }
}
