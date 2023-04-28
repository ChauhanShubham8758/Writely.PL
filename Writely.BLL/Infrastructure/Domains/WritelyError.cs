namespace Writely.BLL.Infrastructure.Domains
{
    public class WritelyError
    {
        public string Code { get; protected set; }

        public string Message { get; protected set; }


        public ErrorLoggingDescriptor LoggingDescriptor { get; }

        public WritelyError(string code, string message, ErrorLoggingDescriptor loggingDescriptor = null)
        {
            if (message.Length > 70)
            {
                var messageList = message.Split('|');
                messageList[0] = messageList[0].Length > 70 ? string.Concat(messageList[0].Substring(0, 70), "...") : messageList[0];
                message = string.Concat(messageList[0].Trim(), " | ", messageList[1].Trim());
            }
            Code = code;
            Message = message;
            LoggingDescriptor = loggingDescriptor;
        }
    }
}
