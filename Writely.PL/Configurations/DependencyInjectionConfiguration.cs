using Writely.BLL.Services.IService.Address;
using Writely.BLL.Services.Service.Address;
using Writely.DAL.Repositories.IRepository.Address;
using Writely.DAL.Repositories.Repository.Address;

namespace Writely.PL.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICountryService,CountryService>();
            services.AddTransient<ICountryRepository, CountryRepository>();//CountryRepository : ICountryRepository
        }
    }
}
