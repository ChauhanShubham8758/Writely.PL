using Writely.BLL.Infrastructure.Domains;
using Writely.BLL.ServiceModels.RequestModels.Users;

namespace Writely.BLL.ErrorCodes.User
{
    public class ErrorCreatingUser : WritelyError
    {
        public ErrorCreatingUser(Exception ex = null)
            :base("ERR_ENTREPRENUER_CREATE",UserResource.ErrorCreatingUser, 
                 new ErrorLoggingDescriptor(ex, "Error!! Something went wrong while creating user."))
        {

        }
    }
}
