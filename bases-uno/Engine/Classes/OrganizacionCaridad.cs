using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class OrganizacionCaridad : DBConnection.CRUD<OrganizacionCaridad>
    {
        #region Atributes
        public int ID { get; set; } //pk
        public string Nombre { get; set; }
        public string Mision { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD
        /// </summary>
        public OrganizacionCaridad(string nombre, string mision)
        {
            Nombre = nombre;
            Mision = mision;
        }

        /// <summary>
        /// Constructor General de la Clase, usualmente para la clase READ
        /// </summary>
        public OrganizacionCaridad(int id, string nombre, string mision)
        {
            ID = id;
            Nombre = nombre;
            Mision = mision;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGorganizacion_caridad WHERE id = @id";
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

                string Query2 = "INSERT INTO JAGorganizacion_caridad (nombre, mision) " +
                    "VALUES (@nombre, @mision) RETURNING id";
                Script = new NpgsqlCommand(Query2, Connection);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("mision", Mision);

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

                string Query = "UPDATE JAGorganizacion_caridad " +
                    "SET nombre = @nombre, mision = @mision " +
                    "WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("mision", Mision);

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