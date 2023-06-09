using Writely.BLL.AutomapperSetup;
using Writely.BLL.ServiceModels.ResponseModels.Address;
using Writely.DAL.Models.Address.Domain;

namespace Writely.BLL.Mappings.Address
{
    public class CityMapping
    {
        public static void Map(AutoMapperMappingProfiles profile)
        {
            profile.CreateMap<City, CityDisplayModel>();
        }
    }
}
