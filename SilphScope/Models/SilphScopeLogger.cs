namespace SilphScope.Models
{
    public static class SilphScopeLogger
    {
        public delegate void MessageEventHandler(object sender, string message);

        public static event MessageEventHandler? Message;

        public static void Log(string message)
        {
            Message?.Invoke(typeof(SilphScopeLogger), message);
        }
    }
}
