using System.Linq;

namespace IUMS.Web.Extensions
{
    public static class ViewExtensions
    {
            public static string ConvertToUniCode(int value)
            {
                string bengali_text = string.Concat(value.ToString().Select(c => (char)('\u09E6' + c - '0'))); // "১২৩৪৫৬৭৮৯০"

                // string english_text = string.Concat(bengali_text.Select(c => (char)('0' + c - '\u09E6'))); // "1234567890"

                return bengali_text;
            }
    }
}