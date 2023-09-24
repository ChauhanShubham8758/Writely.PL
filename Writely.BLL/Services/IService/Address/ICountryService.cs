using OneOf;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.RequestModels.Address;
using Writely.BLL.ServiceModels.ResponseModels.Address;

namespace Writely.BLL.Services.IService.Address
{
    public interface ICountryService
    {
        Task<OneOf<List<CountryDisplayModel>, WritelyError>> GetAllCountries(CancellationToken cancellationToken = default);

        Task<OneOf<CountryDisplayModel, WritelyError>> CreateCountry(AddOrEditCountryModel addCountryModel, CancellationToken cancellationToken = default);

        Task<OneOf<bool, WritelyError>> DeleteCountry(int countryId, CancellationToken cancellationToken = default);

        Task<OneOf<CountryDisplayModel, WritelyError>> GetCountryById(int countryId, CancellationToken cancellationToken = default);

        Task<OneOf<CountryDisplayModel, WritelyError>> PatchCountry(CountryDisplayModel editCountryModel, CancellationToken cancellationToken = default);
    }
}
