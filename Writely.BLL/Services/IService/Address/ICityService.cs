using OneOf;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.ResponseModels.Address;

namespace Writely.BLL.Services.IService.Address
{
    public interface ICityService
    {
        Task<OneOf<List<CityDisplayModel>, WritelyError>> GetAllCities(CancellationToken cancellationToken = default);
        Task<OneOf<List<CityDisplayModel>, WritelyError>> GetCityByStateId(int stateId, CancellationToken cancellationToken = default);
    }
}
