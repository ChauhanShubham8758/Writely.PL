using Writely.BLL.ServiceModels.RequestModels.Address;
using Writely.BLL.ServiceModels.ResponseModels.Address;
using Writely.DAL.Models.Address.Domain;

namespace Writely.BLL.Builders.Address
{
    public class CountryBuilder
    {
        public static Country Convert(AddOrEditCountryModel model)
        {
            var country = new Country(model.Name, model.CountryCode, model.Currency);
            return country;
        }

        public static Country ConvertToEdit(CountryDisplayModel model)
        {
            var country = new Country(model.Name, model.CountryCode, model.Currency);
            return country;
        }
    }
}
