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
        //Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

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
                    club = new Club(connection.ReadInt(0), connection.ReadDate(1), connection.ReadString(4), connection.ReadInt(5), 
                        connection.ReadInt(6), connection.ReadDate(7), connection.ReadInt(8), connection.ReadInt(2), connection.ReadString(3));
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

        public static Coleccionista Coleccionista(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Coleccionista collector = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM coleccionista WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    collector = new Coleccionista(connection.ReadInt(0), connection.ReadString(1), connection.ReadString(2), connection.ReadString(3),
                        connection.ReadString(4), connection.ReadInt(5), connection.ReadDate(6), connection.ReadInt(7), connection.ReadInt(8), 
                        connection.ReadInt(9), connection.ReadInt(10));
                }
            }
            catch
            {
                collector = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return collector;
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

        public static Contacto Contacto(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Contacto contact = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM contacto WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    contact = new Contacto(connection.ReadInt(0), connection.ReadString(3), connection.ReadInt(4),
                        connection.ReadString(1), connection.ReadInt(2));
                }
            }
            catch
            {
                contact = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return contact;
        }

        public static DuenoHistorico DuenoHistorico(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            DuenoHistorico duenoHistorico = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM dueno_historico WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    duenoHistorico = new DuenoHistorico(connection.ReadInt(0), connection.ReadDate(1), connection.ReadString(2),
                        connection.ReadInt(3), connection.ReadInt(4), connection.ReadFloat(5), connection.ReadInt(6));
                }
            }
            catch
            {
                duenoHistorico = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return duenoHistorico;
        }

        public static Interes Interes(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Interes interest = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM interes WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    interest = new Interes(connection.ReadInt(0), connection.ReadString(1), connection.ReadString(2));
                }
            }
            catch
            {
                interest = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return interest;
        }

        public static Lugar Lugar(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Lugar place = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM lugar WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    place = new Lugar(connection.ReadInt(0), connection.ReadString(1), connection.ReadString(2), connection.ReadInt(3));
                }
            }
            catch
            {
                place = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return place;
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
