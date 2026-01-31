using System;
using System.ComponentModel;
using System.Reflection;

namespace SilphScope.Models.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo? fi = value.GetType().GetField(value.ToString());
            if (fi != null && Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
            {
                return attr.Description;
            }
            return value.ToString();
        }
    }
}
