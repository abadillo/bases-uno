using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Classes;
using Npgsql;

namespace Engine.DBConnection
{
    public static class Query
    {
        public static List<Comic> Comics()
        {
            List<Comic> list = new List<Comic>();

            DBConnection connection = new DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM comic";
                NpgsqlCommand Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = Script.ExecuteReader();

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

        public static List<Interes> Interests()
        {
            List<Interes> list = new List<Interes>();
            DBConnection connection = new DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM interes";
                NpgsqlCommand Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Interes interest = new Interes(connection.ReadInt(0), connection.ReadString(1), connection.ReadString(2));

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

        public static List<Lugar> Places()
        {
            List<Lugar> list = new List<Lugar>();
            DBConnection connection = new DBConnection();

            try
            {
                connection.OpenConnection();

                string Query = "SELECT * FROM lugar";
                NpgsqlCommand Script = new NpgsqlCommand(Query, connection.Connection);

                connection.Reader = Script.ExecuteReader();

                while (connection.Reader.Read())
                {
                    Lugar place = new Lugar(connection.ReadInt(0), connection.ReadString(1), connection.ReadString(2), 
                        connection.ReadInt(3));

                    list.Add(place);
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

        /* public List<ClassModell> Models()
        {
            List<ClassModell> list = new List<ClassModell>();

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM modelo";
                NpgsqlCommand Script = new NpgsqlCommand(Query, Connection);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    ClassModell modell = new ClassModell(ReadInt(0), ReadString(1));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<ClassModell>();
            }
            finally
            {
                CloseConnection();
            }

            return list;
        }
        */
    }
}
