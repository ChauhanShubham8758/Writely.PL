using Writely.BLL.ServiceModels.RequestModels.Address;
using Writely.DAL.Models.Address.Domain;

namespace Writely.BLL.Builders.Address
{
    public class CountryBuilder
    {
        public static Country Convert(AddCountryModel model)
        {
            var country = new Country(model.Name, model.CountryCode, model.Currency);
            return country;
        }
    }
}
