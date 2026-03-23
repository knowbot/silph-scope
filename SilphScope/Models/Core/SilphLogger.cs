namespace SilphScope.Models.Core;

public static class SilphLogger
{
    public delegate void MessageEventHandler(object sender, string message);

    public static event MessageEventHandler? Message;

    public static void Log(string message)
    {
        Message?.Invoke(typeof(SilphLogger), message);
    }
}
