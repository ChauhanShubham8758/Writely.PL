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
    public class StateRepository : IStateRepository
    {
        private readonly WritelyDbContext _dbContext;

        public StateRepository(WritelyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<State>> GetAllState(CancellationToken cancellationToken = default)
        {
            var statelist = await _dbContext.States.ToListAsync();
            return statelist;
        }

        public async Task<List<State>> GetStatesByCountryId(int countryId, CancellationToken cancellationToken = default)
        {
            var statelist = _dbContext.States.Include(c => c.Country).Where(x => x.CountryId == countryId);
            return await statelist.ToListAsync(cancellationToken);
        }
    }
}
