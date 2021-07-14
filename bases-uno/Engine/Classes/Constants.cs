using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public static class TipoLugar
    {
        public const string Address = "Direccion";
        public const string City = "Ciudad";
        public const string State = "Estado";
        public const string Country = "Pais";
    }

    public static class TipoLocal
    {
        public const string Alquilado = "Alquilado";
        public const string DeUnMiembro = "De un Miembro";
    }

    public static class TipoSubasta
    {
        public const string Presencial = "Presencial";
        public const string Virtual = "Virtual";
    }

    public static class Conversion
    {
        #region Conversion de Monedas
        private const float Euro = 1.12f;

        public static float ConvertirDolares(float dolares)
        {
            return dolares / Euro;
        }

        public static float ConvertirEuros(float euros)
        {
            return Euro * euros;
        }
        #endregion
    }
}
