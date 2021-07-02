using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public static class TypePlace
    {
        public const string Address = "Direccion";
        public const string City = "Ciudad";
        public const string State = "Estado";
        public const string Country = "Pais";
    }

    public static class Conversion
    {
        #region Conversion de Monedas
        private const double Euro = 1.12;

        public static double ConvertirDolares(double dolares)
        {
            return dolares / Euro;
        }

        public static double ConvertirEuros(double euros)
        {
            return Euro * euros;
        }
        #endregion
    }
}
