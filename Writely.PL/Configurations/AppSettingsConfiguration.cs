using Writely.BLL.Infrastructure.AppSettings;

namespace Writely.PL.Configurations
{
    public static class AppSettingsConfiguration
    {
        public static void ConfigurationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSettings>(options =>
              {
                  options.Key = configuration.GetSection("JWT:Key").Value;
                  options.Issuer = configuration.GetSection("JWT:Issuer").Value;
                  options.Audience = configuration.GetSection("JWT:Audience").Value;
              });
        }
    }
}
