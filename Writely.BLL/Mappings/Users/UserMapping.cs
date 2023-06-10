using Writely.BLL.AutomapperSetup;
using Writely.BLL.ServiceModels.ResponseModels.Users;
using Writely.DAL.Models.Users.Domain;

namespace Writely.BLL.Mappings.Users
{
    public class UserMapping
    {
        public static void Map(AutoMapperMappingProfiles profile)
        {
            profile.CreateMap<User, UserDisplayModel>();
        }
    }
}
