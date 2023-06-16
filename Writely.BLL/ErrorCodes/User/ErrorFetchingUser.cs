using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.RequestModels.Users;

namespace Writely.BLL.ErrorCodes.User
{
    public class ErrorFetchingUser : WritelyError
    {
        public ErrorFetchingUser(Exception ex = null)
          : base("ERR_USER_FETCH", UserResource.ErrorFetchingUser,
              new ErrorLoggingDescriptor(ex, "Email not exist"))
        {

        }
    }
}
