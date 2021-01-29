using System.Globalization;

namespace Robson.WebApplication.Extensions
{
    public static class StringsExtension
    {
        public static string ToTitleCase(this string texto)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(texto.ToLower());
        }
    }
}
