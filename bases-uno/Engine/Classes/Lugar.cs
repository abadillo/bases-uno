using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Engine.Classes
{
    public class Lugar : DBConnection.CRUD<Lugar>
    {

        #region Atributes
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int LugarID { get; set; } //nullable
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor para antes de hacer un Insert
        /// </summary>
        /// <param name="locationID"></param>
        public Lugar(string name, string type, Lugar lugar = null)
        {
            Nombre = name;
            Tipo = type;
            if (lugar == null)
            {
                LugarID = 0;
            }
            else
            {
                LugarID = lugar.ID;
            }
        }

        /// <summary>
        /// Instancia una fila especifica de la tabla
        /// </summary>
        public Lugar(int id)
        {
            Lugar place = Read.Lugar(id);
            if (!(place == null))
            {
                ID = place.ID;
                Tipo = place.Tipo;
                LugarID = place.LugarID;
            }
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Lugar(int id, string name, string type, int locationID = 0)
        {
            ID = id;
            Nombre = name;
            Tipo = type;
            LugarID = locationID;
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
