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
        /// <param name="tipo">Usar <code>
        /// public static class TipoLocal 
        /// <para>{</para>
        /// <para>public const string Address = "Direccion";</para>
        /// ,<para>public const string City = "Ciudad";</para>
        /// ,<para>public const string State = "Estado";</para>
        /// ,<para>public const string Country = "Pais";</para>
        /// }</code>, por el check</param>
        public Lugar(string nombre, string tipo, Lugar lugar = null)
        {
            Nombre = nombre;
            Tipo = tipo;
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
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Lugar(int id, string nombre, string tipo, int lugarID = 0)
        {
            ID = id;
            Nombre = nombre;
            Tipo = tipo;
            LugarID = lugarID;
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
