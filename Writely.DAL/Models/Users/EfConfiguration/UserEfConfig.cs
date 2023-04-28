using Microsoft.EntityFrameworkCore;
using Writely.DAL.Models.Address.Domain;
using Writely.DAL.Models.Users.Domain;

namespace Writely.DAL.Models.Users.EfConfiguration
{
    public class UserEfConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne<City>(c => c.City)
                .WithMany(i => i.Users)
                .HasForeignKey(u => u.CityId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
               .HasIndex(e => e.PhoneNumber)
               .IsUnique(true);

            builder
               .HasIndex(e => e.Email)
               .IsUnique(true);

            builder
                .HasOne(u => u.UserDetails)
                .WithOne(d => d.User)
                .HasForeignKey<UserDetails>(d => d.UserId);

            builder
                .HasMany(u => u.UserSessions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
