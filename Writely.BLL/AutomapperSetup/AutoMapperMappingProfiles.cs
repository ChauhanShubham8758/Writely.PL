using AutoMapper;
using Writely.BLL.Mappings.Address;

namespace Writely.BLL.AutomapperSetup
{
    public class AutoMapperMappingProfiles : Profile
    {
        public AutoMapperMappingProfiles()
        {
            CountryMapping.Map(this);   
        }
    }
}
