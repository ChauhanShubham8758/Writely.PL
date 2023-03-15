using Microsoft.EntityFrameworkCore;
using Writely.DAL.Models.Address.Domain;
using Writely.DAL.Models.Address.EfConfiguration;

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
    }
}
