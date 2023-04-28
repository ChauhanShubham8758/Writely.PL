using OneOf;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.ResponseModels.Address;

namespace Writely.BLL.Services.IService.Address
{
    public interface ICountryService
    {
        Task<OneOf<List<CountryDisplayModel>, WritelyError>> GetAllCountries(CancellationToken cancellationToken = default);
    }
}
