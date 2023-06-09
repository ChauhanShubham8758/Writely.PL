using Writely.BLL.Helpers;
using Writely.BLL.Services.IService.Address;
using Writely.BLL.Services.IService.Users;
using Writely.BLL.Services.Service.Address;
using Writely.BLL.Services.Service.User;
using Writely.DAL.Repositories.IRepository.Address;
using Writely.DAL.Repositories.IRepository.Users;
using Writely.DAL.Repositories.Repository.Address;
using Writely.DAL.Repositories.Repository.Users;

namespace Writely.PL.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICountryService,CountryService>();
            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddTransient<IStateService, StateService>();
            services.AddTransient<IStateRepository, StateRepository>();

            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICityRepository, CityRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IHelperService, HelperService>();
        }
    }
}
