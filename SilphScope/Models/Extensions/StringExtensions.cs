using System;
using System.Reflection;

namespace SilphScope.Models.Extensions
{
    public static class StringExtensions
    {
        public static Uri ToAvaresUri(this string path)
        {
            return new Uri($"avares://{Assembly.GetExecutingAssembly().GetName()}/{path}");
        }
    }
}
