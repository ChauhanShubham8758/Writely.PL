using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorFetchingCountry : WritelyError
    {
        public ErrorFetchingCountry(Exception ex = null) : base("ERR_COUNTRY_FETCHING", "Something went wrong while fetching country.",
              new ErrorLoggingDescriptor(ex, "Error fetchting country."))
        {

        }
    }
}
