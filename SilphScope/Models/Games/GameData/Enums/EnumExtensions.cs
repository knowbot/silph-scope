using System;
using System.ComponentModel;
using System.Reflection;

namespace SilphScope.Models.Games.GameData.Enums
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
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
