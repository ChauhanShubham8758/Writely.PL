using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorCountryNotFound : WritelyError
    {
        public ErrorCountryNotFound(int countryId, Exception ex = null) : base("ERR_COUNTRY_NOTFOUND", "Country not found for the information provided.",
             new ErrorLoggingDescriptor(ex, $"CountryId {countryId} country not found."))
        {

        }
    }
}
