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

        public async Task<bool> RemoveCountry(Country country, CancellationToken cancellationToken = default)
        {
            _dbContext.Countries.Remove(country);
            var count = await _dbContext.SaveChangesAsync(cancellationToken);

            return count > 0;
        }

        public async Task<bool> SaveCountry(Country country, CancellationToken cancellationToken = default)
        {
            await _dbContext.Countries.AddAsync(country, cancellationToken);
            var outcome = await _dbContext.SaveChangesAsync(cancellationToken);
            return outcome > 0;
        }

        public async Task<bool> UpdatCountry(int countryId, Country country, CancellationToken cancellationToken)
        {
            var existingCountry = await _dbContext.Countries
                                                            .Where(x => x.Id == countryId)
                                                            .FirstOrDefaultAsync(cancellationToken);

            if (existingCountry == null)
            {
                return false;
            }

            existingCountry.Name = country.Name;
            existingCountry.Currency = country.Currency;
            existingCountry.CountryCode = country.CountryCode;
            _dbContext.Entry(existingCountry).State = EntityState.Modified;
            var count = await _dbContext.SaveChangesAsync(cancellationToken);

            return count > 0;
        }
    }
}
