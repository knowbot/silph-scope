namespace SilphScope.Models.Core.Messages
{
    public class SilphStateChangedMessage(SilphState newState) : SilphServiceMessage
    {
        public readonly SilphState NewState = newState;
    }
}
