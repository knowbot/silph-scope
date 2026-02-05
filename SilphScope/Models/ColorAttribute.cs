using System;
using System.Reflection;

namespace SilphScope.Models
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ColorAttribute : Attribute
	{
		public string ColorString { get; set; }

		public ColorAttribute(string colorString)
		{
			ColorString = colorString;
		}

		public static string? Get(Enum value)
		{
			FieldInfo? fi = value.GetType().GetField(value.ToString());
			if (fi != null && GetCustomAttribute(fi, typeof(ColorAttribute)) is ColorAttribute attr)
			{
				return attr.ColorString;
			}
			return null;
		}
	}
}
