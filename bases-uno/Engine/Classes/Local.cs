using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Local : DBConnection.CRUD<Local>
    {
        #region Atributes
        public int ID { get; set; } //pk
        public string Nombre { get; set; }
       
        public int LugarID { get; set; }
        public int ColeccionistaID { get; set; } //nullable
        public string Tipo { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD
        /// </summary>
        /// <param name="tipo">Usar <code>
        /// public static class TipoLocal 
        /// <para>{</para>
        /// <para>  public const string Alquilado = "Alquilado";</para>
        /// <para>  public const string DeUnMiembro = "De un Miembro";</para>
        /// }</code>, por el check</param>
        public Local(string nombre, Lugar ubicacion, string tipo, Coleccionista dueno = null)
        {
            Nombre = nombre;
           
            LugarID = ubicacion.ID;
            Tipo = tipo;
            if (dueno == null)
            {
                ColeccionistaID = 0;
            }
            else
            {
                ColeccionistaID = dueno.ID;
            }
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Local(int id, string nombre, int lugarID, int coleccionistaID, string tipo)
        {
            ID = id;
            Nombre = nombre;

            LugarID = lugarID;
            ColeccionistaID = coleccionistaID;
            Tipo = tipo;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM local WHERE id = @id";
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

                string Query = "INSERT INTO local (nombre, lugar_id, tipo";
                if (!(ColeccionistaID == 0))
                {
                    Query += ", coleccionista_documento_identidad";
                }
                Query += ") VALUES (@nombre, @lugar, @tipo";
                if (!(ColeccionistaID == 0))
                {
                    Query += ", @coleccionistaid";
                }
                Query += ") RETURNING id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("lugar", LugarID);
                Script.Parameters.AddWithValue("tipo", Tipo);
                if (!(ColeccionistaID == 0))
                {
                    Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);
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

                string Query = "UPDATE local SET nombre = @nombre, lugar_id = @lugar, tipo = @tipo";
                if (!(ColeccionistaID == 0))
                {
                    Query += ", coleccionista_documento_identidad = @coleccionistaid";
                }
                Query += " WHERE id = @id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID); 
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("lugar", LugarID);
                Script.Parameters.AddWithValue("tipo", Tipo);
                if (!(ColeccionistaID == 0))
                {
                    Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);
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
