using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Club : Engine.DBConnection.CRUD<Club>
    {
        #region Atributes
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Nullable<DateTime> FechaFundacion { get; set; }
        public int Telefono { get; set; } //nullable
        public string PaginaWeb { get; set; } //nullable
        public string Proposito { get; set; }
        public int LugarID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar para hacer un nuevo registro en la BD
        /// </summary>
        public Club(string nombre,  DateTime fechaFundacion, string proposito,Lugar lugar, int telefono = 0, string paginaWeb = null) 
        {
            FechaFundacion = fechaFundacion;
            Nombre = nombre;
            Telefono = telefono;
            PaginaWeb = paginaWeb;
            Proposito = proposito;
            LugarID = lugar.ID;
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Club(int id, string nombre, Nullable<DateTime> fechaFundacion, string proposito, int lugarID, int telefono = 0, string paginaWeb = null)
        {
            ID = id;
            Nombre = nombre;
            FechaFundacion = fechaFundacion;
            Telefono = telefono;
            PaginaWeb = paginaWeb;
            Proposito = proposito;
            LugarID = lugarID;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM club WHERE id = @id";
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

                string Query = "INSERT INTO club (fecha_fundacion, proposito, lugar_id, nombre";
                if (!(Telefono == 0))
                {
                    Query += ", telefono";
                }
                if (!(PaginaWeb == null))
                {
                    Query += ", pagina_web";
                }
                Query += ") VALUES (@fundacion, @proposito, @lugar, @nombre";
                if (!(Telefono == 0))
                {
                    Query += ", @telefono"; 
                }
                if (!(PaginaWeb == null))
                {
                    Query += ", @web";
                }
                Query += ") RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("fundacion", FechaFundacion);
                Script.Parameters.AddWithValue("proposito", Proposito);
                Script.Parameters.AddWithValue("lugar", LugarID);
                Script.Parameters.AddWithValue("nombre", Nombre);
                if (!(Telefono == 0))
                {
                    Script.Parameters.AddWithValue("telefono", Telefono);
                }
                if (!(PaginaWeb == null))
                {
                    Script.Parameters.AddWithValue("web", PaginaWeb);
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

                string Query = "UPDATE club SET fecha_fundacion = @fundacion, nombre = @nombre, ";

                if (!(Telefono == 0))
                {
                    Query += "telefono = @telefono, ";
                }
                if (!(PaginaWeb == null))
                {
                    Query += "pagina_web = @web, ";
                }

                Query += "proposito = @proposito, lugar_id = @lugar " +
                        "WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("fundacion", FechaFundacion);
                Script.Parameters.AddWithValue("nombre", Nombre);
                if (!(Telefono == 0))
                {
                    Script.Parameters.AddWithValue("telefono", Telefono);
                }
                else
                {
                    Script.Parameters.AddWithValue("telefono", DBNull.Value);
                }
                if (!(PaginaWeb == null))
                {
                    Script.Parameters.AddWithValue("web", PaginaWeb);
                }
                else
                {
                    Script.Parameters.AddWithValue("web", DBNull.Value);
                }
                Script.Parameters.AddWithValue("proposito", Proposito);
                Script.Parameters.AddWithValue("lugar", LugarID);

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
