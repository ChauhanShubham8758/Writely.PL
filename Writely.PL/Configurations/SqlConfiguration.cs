using Microsoft.EntityFrameworkCore;
using Writely.DAL.AppDbContext;

namespace Writely.PL.Configurations
{
    public static class SqlConfiguration
    {
        public static void ConfigureSqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            //var connectionString = configuration["appSettings:FundraisingConnection:ConnectionString"];
            services.AddDbContext<WritelyDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly("Writely.DAL");
                    b.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            });
        }
    }
}
