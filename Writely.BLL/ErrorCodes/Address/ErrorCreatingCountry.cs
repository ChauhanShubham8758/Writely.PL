using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorCreatingCountry : WritelyError
    {
        public ErrorCreatingCountry(Exception ex = null) : base("ERR_COUNTRY_CREATING", "Something went wrong while saving country.",
              new ErrorLoggingDescriptor(ex, "Error saving country."))
        {
                
        }
    }
}
