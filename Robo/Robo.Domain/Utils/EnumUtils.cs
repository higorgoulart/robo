using System.ComponentModel;

namespace Robo.Domain.Utils;

public static class EnumUtils
{
    public static int DifferenceBetween(Enum a, Enum b)
    {
        return Math.Abs(Convert.ToInt16(a) - Convert.ToInt16(b));
    }
    
    public static T? ToEnum<T>(this string value) where T : Enum
    {
        var enums = typeof(T).GetEnumValues().Cast<T>();

        return enums.FirstOrDefault(x => x.ToString("G") == value);
    }
    
    public static List<KeyValuePair<string, string>> ToDictionary<T>() where T : Enum
    {
        var enums = typeof(T).GetEnumValues().Cast<T>();

        return enums
            .Select(x => new KeyValuePair<string, string>(x.ToString("G"), x.GetEnumDescription()))
            .ToList();
    }
    
    public static string GetEnumDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());

        if (field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                is DescriptionAttribute[] attributes && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}