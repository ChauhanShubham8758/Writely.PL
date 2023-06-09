using OneOf;
using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.RequestModels.Users;
using Writely.BLL.ServiceModels.ResponseModels.Users;

namespace Writely.BLL.Services.IService.Users
{
    public interface IUserService
    {
        Task<OneOf<UserDisplayModel, WritelyError>> CreateUser(AddUserModel model,
           CancellationToken cancellationToken);

        Task<OneOf<UserDisplayModel, WritelyError>> GetUserById(UserDisplayModel model,
          CancellationToken cancellationToken);
    }
}
