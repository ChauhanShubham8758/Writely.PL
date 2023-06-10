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
    public class CityRepository : ICityRepository
    {
        private readonly WritelyDbContext _dbContext;

        public CityRepository(WritelyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<City>> GetAllCity(CancellationToken cancellationToken = default)
        {
            var citylist = await _dbContext.Cities.ToListAsync();
            return citylist;
        }

        public async Task<List<City>> GetCityByStateId(int stateId, CancellationToken cancellationToken = default)
        {
            var citylist = _dbContext.Cities.Include(c => c.State).Where(x => x.StateId == stateId);
            return await citylist.ToListAsync(cancellationToken);
        }
    }
}
