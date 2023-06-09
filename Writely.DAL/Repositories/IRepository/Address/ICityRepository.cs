using Writely.DAL.Models.Address.Domain;

namespace Writely.DAL.Repositories.IRepository.Address
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCity(CancellationToken cancellationToken = default);
        Task<List<City>> GetCityByStateId(int stateId, CancellationToken cancellationToken = default);
    }
}
