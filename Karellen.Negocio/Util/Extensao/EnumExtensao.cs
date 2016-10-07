using System;
using System.ComponentModel;

namespace Karellen.Negocio.Util.Extensao
{
    public static class EnumExtensao
    {
        public static string GetDescricao(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
