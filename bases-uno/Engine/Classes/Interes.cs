using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Interes : DBConnection.CRUD<Interes>
    {
        #region Atributes
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor para antes de hacer un Insert en la BD
        /// </summary>
        public Interes(string name, string description = null)
        {
            Nombre = name;
            Descripcion = description;
        }

        /// <summary>
        /// Constructor que instancia una fila especifica de la Tabla
        /// </summary>
        public Interes(int id)
        {
            Interes interest = Read.Interes(id);
            if (!(interest == null))
            {
                ID = interest.ID;
                Nombre = interest.Nombre;
                Descripcion = interest.Descripcion;
            }
        }

        /// <summary>
        /// Constructor de la Clase READ, NO USAR
        /// </summary>
        public Interes(int id, string name, string description = null)
        {
            ID = id;
            Nombre = name;
            Descripcion = description;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM interes WHERE id = @id";
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

                string Query = "INSERT INTO interes (nombre";
                if (!(Descripcion == null))
                {
                    Query += ", descripcion";
                }
                Query += ") VALUES (@nombre";
                if (!(Descripcion == null))
                {
                    Query += ", @descripcion";
                }
                Query += ") RETURNING id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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

                string Query = "UPDATE interes SET nombre = @nombre";
                if (!(Descripcion == null))
                {
                    Query += ", descripcion = @descripcion";
                }
                Query += " WHERE id = @id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("nombre", Nombre);
                if (!(Descripcion == null))
                {
                    Script.Parameters.AddWithValue("descripcion", Descripcion);
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
