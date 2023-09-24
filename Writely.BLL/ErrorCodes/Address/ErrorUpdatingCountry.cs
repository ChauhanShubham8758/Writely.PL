using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorUpdatingCountry : WritelyError
    {
        public ErrorUpdatingCountry(int countryId, Exception ex = null)
            : base("ERR_COUNTRY_UPDATE", "Error updating country",
                new ErrorLoggingDescriptor(ex, $"There was an error updating country with Id: {countryId}."))
        {

        }
    }
}
