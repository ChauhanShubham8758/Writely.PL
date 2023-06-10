using Microsoft.EntityFrameworkCore;
using Writely.DAL.Models.Address.Domain;
using Writely.DAL.Models.Address.EfConfiguration;
using Writely.DAL.Models.Users.Domain;

namespace Writely.DAL.AppDbContext
{
    public class WritelyDbContext : DbContext
    {
        public WritelyDbContext(DbContextOptions<WritelyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityEfConfig());
            modelBuilder.ApplyConfiguration(new StateEfConfig());
        }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserLoginAttempts> UserLoginAttempts { get; set; }
    }
}
