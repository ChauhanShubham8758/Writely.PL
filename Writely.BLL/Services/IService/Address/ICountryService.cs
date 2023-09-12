using OneOf;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.RequestModels.Address;
using Writely.BLL.ServiceModels.ResponseModels.Address;

namespace Writely.BLL.Services.IService.Address
{
    public interface ICountryService
    {
        Task<OneOf<List<CountryDisplayModel>, WritelyError>> GetAllCountries(CancellationToken cancellationToken = default);

        Task<OneOf<CountryDisplayModel, WritelyError>> CreateCountry(AddCountryModel addCountryModel, CancellationToken cancellationToken = default);
    }
}
