using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writely.BLL.Infrastructure.Domains;

namespace Writely.BLL.ErrorCodes.Address
{
    public class ErrorFetchingCountry : WritelyError
    {
        public ErrorFetchingCountry(Exception ex = null) : base("ERR_ENTREPRENUER_FETCHING", "Something went wrong while fetching country.",
              new ErrorLoggingDescriptor(ex, "Error fetchting entrepreneur."))
        {

        }
    }
}
