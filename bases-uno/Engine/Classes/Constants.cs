using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public static class Read
    {
        public static Club Club(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Club club = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM club WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    club = new Club(connection.ReadInt(0), connection.ReadDate(1), connection.ReadInt(2), connection.ReadString(3),
                        connection.ReadString(4), connection.ReadInt(5), connection.ReadInt(6), connection.ReadDate(7), connection.ReadInt(8));
                }
            }
            catch
            {
                club = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return club;
        }

        public static Coleccionable Coleccionable(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Coleccionable colectable = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM coleccionable WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    colectable = new Coleccionable(connection.ReadInt(0), connection.ReadString(1), connection.ReadString(2));
                }
            }
            catch
            {
                colectable = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return colectable;
        }

        public static Comic Comic(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Comic comic = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM comic WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    comic = new Comic(connection.ReadInt(0), connection.ReadString(1), connection.ReadInt(3), connection.ReadDate(4), connection.ReadBool(6),
                        connection.ReadString(7), connection.ReadInt(8), connection.ReadBool(9), connection.ReadString(10), connection.ReadInt(2), connection.ReadFloat(5));
                }
            }
            catch
            {
                comic = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return comic;
        }
    }

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
