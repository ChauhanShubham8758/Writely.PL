using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorDeletingCountry : WritelyError
    {
        public ErrorDeletingCountry(Exception ex = null) : base("ERR_COUNTRY_DELETING", "Something went wrong while deleting country.",
              new ErrorLoggingDescriptor(ex, "Error deleting country."))
        {

        }
    }
}
