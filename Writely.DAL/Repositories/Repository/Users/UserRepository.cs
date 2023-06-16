using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writely.DAL.AppDbContext;
using Writely.DAL.Models.Users.Domain;
using Writely.DAL.Repositories.IRepository.Users;

namespace Writely.DAL.Repositories.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly WritelyDbContext _dbContext;
        public UserRepository(WritelyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveUser(User user, CancellationToken cancellationToken = default)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);
            var outcome = await _dbContext.SaveChangesAsync(cancellationToken);
            return outcome > 0;
        }

        public async Task<User> GetUser(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Users.
                Where(x => x.Id == id).
                FirstOrDefaultAsync(cancellationToken) ?? new NullUser();
        }

        public async Task<User> GetUserByEmail(string email, CancellationToken cancellationToken = default)
        {
            var user = await _dbContext.Users
                                .FirstOrDefaultAsync(u => u.Email == email, cancellationToken) ?? new NullUser();
            return user;
        }
    }
}
