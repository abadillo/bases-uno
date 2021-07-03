using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Engine.Classes
{
    public class Lugar : DBConnection.CRUD<Lugar, int>
    {

        #region Atributes
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int LugarID { get; set; }
        #endregion

        #region Constructors
        // Se crea con toda la informacion de la instancia de clase
        public Lugar(int id, string name, string type, int locationID = 0)
        {
            ID = id;
            Nombre = name;
            Tipo = type;
            LugarID = locationID;
        }

        //Usualmente se usa cuando se va a hacer un insert de una clase cuya clave es un SERIAL
        public Lugar(string name, string type, int locationID = 0)
        {
            Nombre = name;
            Tipo = type;
            LugarID = locationID;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public Lugar(int id)
        {
            Lugar place = Read(id);
            if (!(place == null))
            {
                ID = place.ID;
                Tipo = place.Tipo;
                LugarID = place.LugarID;
            }
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM lugar WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public override void Insert()
        {
            try
            {
                Connection.Open();

                string Query = "INSERT INTO lugar (nombre, tipo";

                if (!(LugarID == 0))
                {
                    Query += ", lugar_id";
                }

                Query += ") VALUES (@nombre, @tipo";

                if (!(LugarID == 0))
                {
                    Query += ", @lugar_id";
                }

                Query += ") RETURNING id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("tipo", Tipo);

                if (!(LugarID == 0))
                {
                    Script.Parameters.AddWithValue("lugar_id", LugarID);
                }

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    ID = ReadInt(0);
                }
            }
            finally
            {
                Connection.Close();
            }
        }

        public override Lugar Read(int id)
        {
            Lugar place = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM lugar WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    place = new Lugar(ReadInt(0), ReadString(1), ReadString(2), ReadInt(3));
                }
            }
            catch
            {
                place = null;
            }
            finally
            {
                CloseConnection();
            }

            return place;
        }

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE lugar SET nombre = @nombre, tipo = @tipo";
                if (!(LugarID == 0))
                {
                    Query += ", lugar_id = @lugar_id";
                }
                Query += " WHERE id = @id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("tipo", Tipo);
                if (!(LugarID == 0))
                {
                    Script.Parameters.AddWithValue("lugar_id", LugarID);
                }

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region Other Methods
        #endregion
    }
}
