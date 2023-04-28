using System.Text.Json.Serialization;

namespace Writely.BLL.Infrastructure.Domains
{
    public class ErrorLoggingDescriptor
    {
        [JsonIgnore]
        public Exception Exception { get; protected set; }

        public string ErrorMessage { get; }

        public ErrorLoggingDescriptor(string messageTemplate, params object[] values)
            : this(null, messageTemplate, values)
        {

        }

        public ErrorLoggingDescriptor(Exception ex, string messageTemplate, params object[] values)
        {
            Exception = ex;
            ErrorMessage = string.Format(messageTemplate, values);
        }

        public ErrorLoggingDescriptor(string message, Exception ex = null)
        {
            Exception = ex;
            ErrorMessage = message;
        }
    }
}
