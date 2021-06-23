using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Engine.Classes
{
    public class Place : DBConnection.CRUD<Place, int>
    {

        #region Atributes
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int LocationID { get; set; }
        #endregion

        #region Constructors
        // Se crea con toda la informacion de la instancia de clase
        public Place(int id, string name, string type, int locationID = 0)
        {
            ID = id;
            Name = name;
            Type = type;
            LocationID = locationID;
        }

        //Usualmente se usa cuando se va a hacer un insert de una clase cuya clave es un SERIAL
        public Place(string name, string type, int locationID = 0)
        {
            Name = name;
            Type = type;
            LocationID = locationID;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public Place(int id)
        {
            Place place = Read(id);
            if (!(place == null))
            {
                ID = place.ID;
                Type = place.Type;
                LocationID = place.LocationID;
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

                if (!(LocationID == 0))
                {
                    Query += ", lugar_id";
                }

                Query += ") VALUES (@nombre, @tipo";

                if (!(LocationID == 0))
                {
                    Query += ", @lugar_id";
                }

                Query += ") RETURNING id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("nombre", Name);
                Script.Parameters.AddWithValue("tipo", Type);

                if (!(LocationID == 0))
                {
                    Script.Parameters.AddWithValue("lugar_id", LocationID);
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

        public override Place Read(int id)
        {
            Place place = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM lugar WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    place = new Place(ReadInt(0), ReadString(1), ReadString(2), ReadInt(3));
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
                if (!(LocationID == 0))
                {
                    Query += ", lugar_id = @lugar_id";
                }
                Query += " WHERE id = @id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("tipo", Type);
                if (!(LocationID == 0))
                {
                    Script.Parameters.AddWithValue("lugar_id", LocationID);
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
