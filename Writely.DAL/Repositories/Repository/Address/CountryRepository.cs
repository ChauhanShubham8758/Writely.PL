using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
