using Writely.BLL.AutomapperSetup;

namespace Writely.PL.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperMappingProfiles));
        }
    }
}
