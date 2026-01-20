namespace SilphScope.Models.Core.Messages
{
    public class DebugMessage : SilphServiceMessage
    {
        public readonly string Message;

        public DebugMessage(string message)
        {
            Message = message;
        }
    }
}
