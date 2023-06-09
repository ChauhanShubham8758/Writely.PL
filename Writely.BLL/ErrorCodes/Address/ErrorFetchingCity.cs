using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorFetchingCity : WritelyError
    {
        public ErrorFetchingCity(Exception ex = null)
            : base("ERR_CITY_FETCHING", "Something went wrong while fetching city.",
             new ErrorLoggingDescriptor(ex, "Error fetchting city."))
        {

        }
    }
}
