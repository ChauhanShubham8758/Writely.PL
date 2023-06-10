using AutoMapper;
using Writely.BLL.Mappings.Address;
using Writely.BLL.Mappings.Users;

namespace Writely.BLL.AutomapperSetup
{
    public class AutoMapperMappingProfiles : Profile
    {
        public AutoMapperMappingProfiles()
        {
            CountryMapping.Map(this);
            StateMapping.Map(this);
            CityMapping.Map(this);
            UserMapping.Map(this);
        }
    }
}
