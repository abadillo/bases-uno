using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Representante : DBConnection.CRUD<Representante>
    {
        #region Atributes
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<DateTime> FechaNacimiento { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Unico Constructor de la clase
        /// </summary>
        public Representante(int id, string nombre, string apellido, Nullable<DateTime> fechaNacimiento)
        {
            ID = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM representante WHERE documento_identidad = @id";
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
                OpenConnection();

                string Query = "INSERT INTO representante (documento_identidad, nombre, apellido, fecha_nacimiento) " +
                    "VALUES (@id, @nombre, @apellido, @fecha)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("apellido", Apellido);
                Script.Parameters.AddWithValue("fecha", FechaNacimiento);

                Script.Prepare();

                Script.ExecuteNonQuery();
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

                string Query = "UPDATE representante SET nombre = @nombre, apellido = @apellido, " +
                    "fecha_nacimiento = @fecha " +
                    "WHERE documento_identidad = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("apellido", Apellido);
                Script.Parameters.AddWithValue("fecha", FechaNacimiento);

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
