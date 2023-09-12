using Microsoft.EntityFrameworkCore;
using Writely.DAL.AppDbContext;
using Writely.DAL.Models.Address.Domain;
using Writely.DAL.Repositories.IRepository.Address;

namespace Writely.DAL.Repositories.Repository.Address
{
    public class CountryRepository : ICountryRepository
    {
        private readonly WritelyDbContext _dbContext;

        public CountryRepository(WritelyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Country>> GetAllCountry(CancellationToken cancellationToken = default)
        {
            var countrylist = await _dbContext.Countries.ToListAsync();
            return countrylist;
        }

        public async Task<Country> GetCountryById(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Countries.Where(c => c.Id == id).FirstOrDefaultAsync(cancellationToken) ?? new NullCountry();
        }

        public async Task<bool> SaveCountry(Country country, CancellationToken cancellationToken = default)
        {
            await _dbContext.Countries.AddAsync(country, cancellationToken);
            var outcome = await _dbContext.SaveChangesAsync(cancellationToken);
            return outcome > 0;
        }
    }
}
