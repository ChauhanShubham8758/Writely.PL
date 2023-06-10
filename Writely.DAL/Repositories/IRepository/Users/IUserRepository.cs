using Writely.DAL.Models.Users.Domain;

namespace Writely.DAL.Repositories.IRepository.Users
{
    public interface IUserRepository
    {
        Task<bool> SaveUser(User user, CancellationToken cancellationToken = default);

        Task<User> GetUser(int id,CancellationToken cancellationToken = default);

    }
}
