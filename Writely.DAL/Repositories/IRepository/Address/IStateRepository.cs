using Writely.DAL.Models.Address.Domain;

namespace Writely.DAL.Repositories.IRepository.Address
{
    public interface IStateRepository
    {
        Task<List<State>> GetAllState(CancellationToken cancellationToken = default);
        Task<List<State>> GetStatesByCountryId(int countryId, CancellationToken cancellationToken = default);
    }
}
