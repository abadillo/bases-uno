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
        #region Lectura de una instancia
        /* modelo de lectura de una clase
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
        */

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
                    club = new Club(connection.ReadInt(0), connection.ReadString(6), connection.ReadDate(1), connection.ReadString(4), 
                        connection.ReadInt(5), connection.ReadInt(2), connection.ReadString(3));
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

                string Query = "SELECT * FROM coleccionista WHERE documento_identidad = @id";
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

                string Query = "SELECT * FROM dueno_historico WHERE coleccionista_documento_identidad = @coleccionistaid AND " +
                    "fecha_registro = @fecha AND id = @id";
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
                        connection.ReadInt(9), connection.ReadInt(10));
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

                string Query = "SELECT * FROM local WHERE id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", id);
                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    local = new Local(connection.ReadInt(0), connection.ReadString(1), connection.ReadInt(2),
                        connection.ReadInt(3), connection.ReadString(4));
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
                    place = new Lugar(connection.ReadInt(0), connection.ReadString(1),
                        connection.ReadString(2), connection.ReadInt(3));
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

                string Query = "SELECT * FROM membresia WHERE fecha_ingreso = @fechaingreso AND club_id = @clubid AND " +
                    "coleccionista_documento_identidad = @coleccionistaid";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("fechaingreso", fechaIngreso);
                connection.Script.Parameters.AddWithValue("clubid", club.ID);
                connection.Script.Parameters.AddWithValue("coleccionistaid", coleccionista.ID);

                connection.Reader = connection.Script.ExecuteReader();

                if (connection.Reader.Read())
                {
                    membresia = new Membresia(connection.ReadDate(0), connection.ReadDate(1), connection.ReadInt(2),
                        connection.ReadInt(4), connection.ReadString(5),connection.ReadInt(3));
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
            OrganizacionCaridad organizacionCaridad = null;

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM organizacion_caridad WHERE id = @id";
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

                string Query = "SELECT * FROM participante WHERE id_inscripcion = @idinscripcion AND subasta_id = @subastaid";
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

                string Query = "SELECT * FROM representante WHERE documento_identidad = @id";
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
                    subasta = new Subasta(connection.ReadInt(0), connection.ReadDate(1), connection.ReadTime(2),
                        connection.ReadTime(3), connection.ReadString(4), connection.ReadBool(5), connection.ReadBool(6),
                        connection.ReadInt(7), connection.ReadBool(8));
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
        #endregion

        #region Lectura de Toda la tabla en una lista
        /*public static List<ClassModell> Models()
        {
            List<ClassModell> list = new List<ClassModell>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM modelo";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    ClassModell modell = new ClassModell(connection.ReadInt(0), 
        connection.ReadString(1));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<ClassModell>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }
        */

        public static List<Club> Clubes()
        {
            List<Club> list = new List<Club>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM club";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Club club = new Club(connection.ReadInt(0), connection.ReadString(6), connection.ReadDate(1), connection.ReadString(4),
                        connection.ReadInt(5), connection.ReadInt(2), connection.ReadString(3));

                    list.Add(club);
                }
            }
            catch
            {
                list = new List<Club>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Coleccionable> Coleccionables()
        {
            List<Coleccionable> list = new List<Coleccionable>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM coleccionable";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Coleccionable coleccionable = new Coleccionable(connection.ReadInt(0), connection.ReadString(1),
                        connection.ReadString(2));

                    list.Add(coleccionable);
                }
            }
            catch
            {
                list = new List<Coleccionable>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Coleccionista> Coleccionistas()
        {
            List<Coleccionista> list = new List<Coleccionista>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM coleccionista";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Coleccionista modell = new Coleccionista(connection.ReadInt(0),
                        connection.ReadString(1),
                        connection.ReadString(2), connection.ReadString(3), connection.ReadString(4),
                        connection.ReadInt(5), connection.ReadDate(6), connection.ReadInt(7),
                        connection.ReadInt(8), connection.ReadInt(9), connection.ReadInt(10));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Coleccionista>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Comic> Comics()
        {
            List<Comic> list = new List<Comic>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM comic";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Comic comic = new Comic(connection.ReadInt(0), connection.ReadString(1), connection.ReadInt(3),
                        connection.ReadDate(4), connection.ReadBool(6), connection.ReadString(7),
                        connection.ReadInt(8), connection.ReadBool(9), connection.ReadString(10),
                        connection.ReadInt(2), connection.ReadFloat(5));

                    list.Add(comic);
                }
            }
            catch
            {
                list = new List<Comic>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Contacto> Contactos()
        {
            List<Contacto> list = new List<Contacto>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM contacto";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Contacto modell = new Contacto(connection.ReadInt(0), connection.ReadString(3), connection.ReadInt(4),
                        connection.ReadString(1), connection.ReadInt(2));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Contacto>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<DuenoHistorico> DuenosHistoricos()
        {
            List<DuenoHistorico> list = new List<DuenoHistorico>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM dueno_historico";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    DuenoHistorico modell = new DuenoHistorico(connection.ReadInt(0), connection.ReadDate(1),
                        connection.ReadString(2), connection.ReadInt(3), connection.ReadInt(4),
                        connection.ReadFloat(5), connection.ReadInt(6));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<DuenoHistorico>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<DuenoHistorico> DuenosActuales()
        {
            List<DuenoHistorico> historicos = DuenosHistoricos();
            List<DuenoHistorico> duenos = new List<DuenoHistorico>();

            foreach (DuenoHistorico historico in historicos)
            {
                if (duenos.Count() == 0)
                {
                    duenos.Add(historico);
                }
                else
                {
                    bool flag = false;

                    foreach (DuenoHistorico dueno in duenos)
                    {
                        if (dueno.ColeccionableID == historico.ColeccionableID && dueno.ComicID == historico.ComicID
                            && dueno.FechaRegistro < historico.FechaRegistro)
                        {
                            duenos.Remove(dueno);
                            duenos.Add(historico);
                            flag = true;
                            break;
                        }
                    }

                    if (!flag)
                    {
                        duenos.Add(historico);
                    }
                }
            }

            return duenos;
        }

        public static List<Interes> Intereses()
        {
            List<Interes> list = new List<Interes>();
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM interes";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Interes interest = new Interes(connection.ReadInt(0), connection.ReadString(1),
                        connection.ReadString(2));

                    list.Add(interest);
                }
            }
            catch
            {
                list = new List<Interes>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Listado> Listados()
        {
            List<Listado> list = new List<Listado>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM listado";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Listado modell = new Listado(connection.ReadInt(0), connection.ReadInt(1), connection.ReadFloat(2),
                        connection.ReadFloat(3), connection.ReadInt(4), connection.ReadInt(5), connection.ReadDate(6),
                        connection.ReadInt(7), connection.ReadInt(8), connection.ReadInt(9), connection.ReadInt(10));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Listado>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Local> Locales()
        {
            List<Local> list = new List<Local>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM local";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Local modell = new Local(connection.ReadInt(0), connection.ReadString(1), connection.ReadInt(2),
                        connection.ReadInt(3), connection.ReadString(4));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Local>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Lugar> Lugares()
        {
            List<Lugar> list = new List<Lugar>();
            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM lugar";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Lugar lugar = new Lugar(connection.ReadInt(0), connection.ReadString(1),
                        connection.ReadString(2), connection.ReadInt(3));

                    list.Add(lugar);
                }
            }
            catch
            {
                list = new List<Lugar>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Membresia> Membresias()
        {
            List<Membresia> list = new List<Membresia>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM membresia";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Membresia modell = new Membresia(connection.ReadDate(0), connection.ReadDate(1), connection.ReadInt(2),
                        connection.ReadInt(4), connection.ReadString(5), connection.ReadInt(3));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Membresia>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Membresia> Membresias(Club club)
        {
            //List<Membresia> membresias = Membresias();
            //List<Membresia> aux = new List<Membresia>();
            //foreach (Membresia membresia in membresias)
            //{
            //    if (membresia.ClubID == club.ID)
            //    {
            //        aux.Add(membresia);
            //    }
            //}
            //return aux;


            List<Membresia> list = new List<Membresia>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM membresia WHERE CLUB_id = @id";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Script.Parameters.AddWithValue("id", club.ID);

                //Console.WriteLine(Script.CommandText);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Membresia modell = new Membresia(connection.ReadDate(0), connection.ReadDate(1), connection.ReadInt(2),
                        connection.ReadInt(4), connection.ReadString(5), connection.ReadInt(3));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Membresia>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;

            
         
            /////////
            ///

           

                
        }

        public static List<OrganizacionCaridad> OrganizacionesCaridad()
        {
            List<OrganizacionCaridad> list = new List<OrganizacionCaridad>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM organizacion_caridad";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    OrganizacionCaridad modell = new OrganizacionCaridad(connection.ReadInt(0), connection.ReadString(1),
                        connection.ReadString(2));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<OrganizacionCaridad>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Participante> Participantes()
        {
            List<Participante> list = new List<Participante>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM participante";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Participante modell = new Participante(connection.ReadInt(0), connection.ReadInt(1),
                        connection.ReadInt(2), connection.ReadInt(3), connection.ReadDate(4), connection.ReadBool(5));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Participante>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Representante> Representantes()
        {
            List<Representante> list = new List<Representante>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM representante";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Representante modell = new Representante(connection.ReadInt(0), connection.ReadString(1),
                        connection.ReadString(2), connection.ReadDate(3));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Representante>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }

        public static List<Subasta> Subastas()
        {
            List<Subasta> list = new List<Subasta>();

            Engine.DBConnection.DBConnection connection = new Engine.DBConnection.DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM subasta";
                connection.Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = connection.Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Subasta modell = new Subasta(connection.ReadInt(0), connection.ReadDate(1), connection.ReadTime(2),
                        connection.ReadTime(3), connection.ReadString(4), connection.ReadBool(5), connection.ReadBool(6),
                        connection.ReadInt(7), connection.ReadBool(8));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<Subasta>();
            }
            finally
            {
                connection.CloseConnection();
            }

            return list;
        }
        #endregion
    }
}
