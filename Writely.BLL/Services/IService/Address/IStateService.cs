using OneOf;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.ResponseModels.Address;

namespace Writely.BLL.Services.IService.Address
{
    public interface IStateService
    {
        Task<OneOf<List<StateDisplayModel>, WritelyError>> GetAllStates(CancellationToken cancellationToken = default);
        Task<OneOf<List<StateDisplayModel>, WritelyError>> GetStatesByCountryId(int countryId, CancellationToken cancellationToken = default);
    }
}
