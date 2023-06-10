using Writely.Common.Extensions;

namespace Writely.BLL.Infrastructure.Domains
{
    public class WritelyValidationError : WritelyError
    {
        public WritelyValidationError(List<string> errors) 
            : base("ERR_VALIDATION", string.Format($"Validation Error Occurred. Errors: {0}.", errors.JoinEm()),
                new ErrorLoggingDescriptor($"Validation Error: {errors.JoinEm()}"))
        {

        }
    }
}
