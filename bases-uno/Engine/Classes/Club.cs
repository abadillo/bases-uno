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
        public long Telefono { get; set; } //nullable
        public string PaginaWeb { get; set; } //nullable
        public string Proposito { get; set; }
        public int LugarID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar para hacer un nuevo registro en la BD
        /// </summary>
        public Club(string nombre,  DateTime fechaFundacion, string proposito,Lugar lugar,long telefono = 0, string paginaWeb = null) 
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
        public Club(int id, string nombre, Nullable<DateTime> fechaFundacion, string proposito, int lugarID,long telefono = 0, string paginaWeb = null)
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

                string Query = "DELETE FROM JAGclub WHERE id = @id";
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

                string Query = "INSERT INTO JAGclub (fecha_fundacion, proposito, lugar_id, nombre";
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

                string Query = "UPDATE JAGclub SET fecha_fundacion = @fundacion, nombre = @nombre, ";

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
        public void AgregarInteres(Interes interes)
        {
            try
            {
                OpenConnection();

                string Query = "INSERT INTO JAGclu_int (club_id, interes_id) " +
                    "VALUES (@club, @interes)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("club", ID);
                Script.Parameters.AddWithValue("interes", interes.ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }

        public List<Interes> Intereses()
        {
            List<int> ids = new List<int>();
            try
            {
                OpenConnection();

                string Query = "SELECT interes_id FROM JAGclu_int WHERE club_id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);

                //Console.WriteLine(Script.CommandText);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    ids.Add(ReadInt(0));
                }
            }
            catch
            {
                ids = new List<int>();
            }
            finally
            {
                CloseConnection();
            }

            
            List<Interes> intereses = new List<Interes>();
            foreach (int id in ids)
            {
                intereses.Add(Read.Interes(id));
            }
            return intereses;
        }

        public void EliminarInteres(Interes interes)
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGclu_int WHERE club_id = @club AND interes_id = @interes";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("club", ID);
                Script.Parameters.AddWithValue("interes", interes.ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }
        #endregion
    }
}
