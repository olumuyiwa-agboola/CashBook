using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CashBook.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                                            .GetField(enumValue.ToString())!
                                            .GetCustomAttribute<DisplayAttribute>();

            return displayAttribute?.Name ?? enumValue.ToString();
        }
    }
}
