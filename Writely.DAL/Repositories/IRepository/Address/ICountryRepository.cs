using Writely.DAL.Models.Address.Domain;

namespace Writely.DAL.Repositories.IRepository.Address
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountry(CancellationToken cancellationToken = default);
        Task<Country> GetCountryById(int id,CancellationToken cancellationToken = default);
        Task<bool> SaveCountry(Country country, CancellationToken cancellationToken = default);
    }
}
