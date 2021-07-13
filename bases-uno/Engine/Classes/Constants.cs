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
        public static ClassModell ClassModell(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            ClassModell modell = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM modelo WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    modell = new ClassModell(connection.ReadInt(0), connection.ReadString(1));
                }
            }
            catch
            {
                modell = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return modell;
        }

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

        public static Contacto Contacto(int id, Club club)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Contacto contact = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM contacto WHERE id = @id AND club_id = @clubid";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Script.Parameters.AddWithValue("clubid", id);
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

        public static DuenoHistorico DuenoHistorico(Coleccionista coleccionista, DateTime fechaRegistro, int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            DuenoHistorico duenoHistorico = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM dueno_historico WHERE coleccionista_documento_identidad = @coleccionistaid AND fecha_registro = @fecha AND id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("coleccionistaid", coleccionista.ID);
                connection.Script.Parameters.AddWithValue("fecha", fechaRegistro);
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

        public static Listado Listado(int id, Subasta subasta)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Listado listado = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM listado WHERE id = @id AND subasta_id = @subastaid";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Script.Parameters.AddWithValue("subastaid", subasta.ID);

                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    listado = new Listado(connection.ReadInt(0), connection.ReadInt(1), connection.ReadFloat(2), connection.ReadFloat(3),
                        connection.ReadInt(4), connection.ReadInt(5), connection.ReadDate(6), connection.ReadInt(7), connection.ReadInt(8),
                        connection.ReadInt(9));
                }
            }
            catch
            {
                listado = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return listado;
        }

        public static Local Local(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Local local = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM modelo WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    local = new Local(connection.ReadInt(0), connection.ReadString(1), connection.ReadBool(2), connection.ReadInt(3),
                        connection.ReadInt(4), connection.ReadString(5));
                }
            }
            catch
            {
                local = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return local;
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

        public static Membresia Membresia(Coleccionista coleccionista, Club club, DateTime fechaIngreso)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Membresia membresia = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM modelo WHERE fecha_ingreso = @fechaingreso AND club_id = @clubid AND " +
                    "coleccionista_documento_identidad = @coleccionistaid";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("fechaingreso", fechaIngreso);
                connection.Script.Parameters.AddWithValue("clubid", club.ID);
                connection.Script.Parameters.AddWithValue("coleccionistaid", coleccionista.ID);

                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    membresia = new Membresia(connection.ReadDate(0), connection.ReadDate(1), connection.ReadInt(2), 
                        connection.ReadInt(3), connection.ReadString(4));
                }
            }
            catch
            {
                membresia = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return membresia;
        }

        public static OrganizacionCaridad OrganizacionCaridad(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            OrganizacionCaridad organizacionCaridad= null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM modelo WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    organizacionCaridad = new OrganizacionCaridad(connection.ReadInt(0), connection.ReadString(1), 
                        connection.ReadString(2));
                }
            }
            catch
            {
                organizacionCaridad = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return organizacionCaridad;
        }

        public static Participante Participante(int idInscripcion, Subasta subasta)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Participante participante = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM modelo WHERE id_inscripcion = @idinscripcion AND subasta_id = @subastaid";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("idinscripcion", idInscripcion);
                connection.Script.Parameters.AddWithValue("subastaid", subasta.ID);

                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    participante = new Participante(connection.ReadInt(0), connection.ReadInt(1), connection.ReadInt(2), 
                        connection.ReadInt(3), connection.ReadDate(4), connection.ReadBool(5));
                }
            }
            catch
            {
                participante = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return participante;
        }

        public static Representante Representante(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Representante representante = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM modelo WHERE documento_identidad = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    representante = new Representante(connection.ReadInt(0), connection.ReadString(1), 
                        connection.ReadString(2), connection.ReadDate(3));
                }
            }
            catch
            {
                representante = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return representante;
        }

        public static Subasta Subasta(int id)
        {
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();
            Subasta subasta = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM subasta WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    subasta = new Subasta(connection.ReadInt(0), connection.ReadDate(1), connection.ReadDate(2), 
                        connection.ReadDate(3), connection.ReadString(4), connection.ReadBool(5), connection.ReadBool(6),
                        connection.ReadInt(7));
                }
            }
            catch
            {
                subasta = null;
            }
            finally
            {
                connection.CloseConnection();
            }

            return subasta;
        }
    }

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
