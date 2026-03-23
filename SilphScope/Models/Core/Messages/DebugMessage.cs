namespace SilphScope.Models.Core.Messages;

public class DebugMessage(string message) : SilphServiceMessage
{
    public readonly string Message = message;
}
