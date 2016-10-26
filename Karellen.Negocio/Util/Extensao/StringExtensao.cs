using System;
using System.Linq;

namespace Karellen.Negocio.Util.Extensao
{
    public static class StringExtensao
    {
        public static string ToPrimeiraLetraUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));
            return input.First().ToString().ToUpper() + string.Join("", input.Skip(1));

        }
    }
}
