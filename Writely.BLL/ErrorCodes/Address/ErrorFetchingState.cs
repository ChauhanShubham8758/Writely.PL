using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorFetchingState : WritelyError
    {
        public ErrorFetchingState(Exception ex = null) 
            : base("ERR_STATE_FETCHING", "Something went wrong while fetching state.",
             new ErrorLoggingDescriptor(ex, "Error fetchting state."))
        {

        }
    }
}
