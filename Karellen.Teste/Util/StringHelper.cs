using System;
using System.Linq;

namespace Karellen.Teste.Util
{
    public static class StringHelper
    {
        public static string ToPrimeiraLetraUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));
            return input.First().ToString().ToUpper() + string.Join("", input.Skip(1));

        }
    }
}
