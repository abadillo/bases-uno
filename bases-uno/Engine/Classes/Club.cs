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
        public Nullable<DateTime> FechaFundacion { get; set; }
        public int Telefono { get; set; } //nullable
        public string PaginaWeb { get; set; } //nullable
        public string Proposito { get; set; }
        public int ResponsableID { get; set; }
        public int ResponsableClubID { get; set; }
        public Nullable<DateTime> ResponsableFechaIngreso { get; set; }
        public int LugarID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar para hacer un nuevo registro en la BD
        /// </summary>
        public Club(DateTime fechaFundacion, string proposito, Membresia responsable,Lugar lugar, int telefono = 0, string paginaWeb = null) 
        {
            FechaFundacion = fechaFundacion;
            Telefono = telefono;
            PaginaWeb = paginaWeb;
            Proposito = proposito;
            ResponsableID = responsable.ColeccionistaID;
            ResponsableClubID = responsable.ClubID;
            ResponsableFechaIngreso = responsable.FechaIngreso;
            LugarID = lugar.ID;
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Club(int id, Nullable<DateTime> fechaFundacion, string proposito, int responsableID, int responsableClubId, 
            Nullable<DateTime> responsableFechaIngreso,int lugarID, int telefono = 0, string paginaWeb = null)
        {
            ID = id;
            FechaFundacion = fechaFundacion;
            Telefono = telefono;
            PaginaWeb = paginaWeb;
            Proposito = proposito;
            ResponsableID = responsableID;
            ResponsableClubID = responsableClubId;
            ResponsableFechaIngreso = responsableFechaIngreso;
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

                string Query = "INSERT INTO club (fecha_fundacion, ";
                if (!(Telefono == 0))
                {
                    Query += "telefono, ";
                }
                if (!(PaginaWeb == null))
                {
                    Query += "pagina_web, ";
                }
                Query +=    "proposito, membresia_coleccionista_documento_identidad, membresia_club_id, " +
                    "membresia_fecha_ingreso, lugar_id) " +
                    "VALUES (@fundacion, @telefono, @web, @proposito, @coleccionistaID, " +
                    "@clubID, @ingreso, @lugar) RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);
                if (!(Telefono == 0))
                {
                    Script.Parameters.AddWithValue("telefono", Telefono);
                }
                if (!(PaginaWeb == null))
                {
                    Script.Parameters.AddWithValue("web", PaginaWeb);
                }
                Script.Parameters.AddWithValue("proposito", Proposito);
                Script.Parameters.AddWithValue("coleccionistaID", ResponsableID);
                Script.Parameters.AddWithValue("clubId", ResponsableClubID);
                Script.Parameters.AddWithValue("ingreso", ResponsableFechaIngreso);
                Script.Parameters.AddWithValue("lugar", LugarID);

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

                string Query = "UPDATE club SET fecha_fundacion = @fundacion, ";

                if (!(Telefono == 0))
                {
                    Query += "telefono = @telefono, ";
                }
                if (!(PaginaWeb == null))
                {
                    Query += "pagina_web = @web, ";
                }

                Query += "proposito = @proposito, membresia_coleccionista_documento_identidad = @coleccionistaID, " +
                    "membresia_club_id = @clubID, membresia_fecha_ingreso = @ingreso, lugar_id = @lugar " +
                        "WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("fundacion", FechaFundacion);
                if (!(Telefono == 0))
                {
                    Script.Parameters.AddWithValue("telefono", Telefono);
                }
                if (!(PaginaWeb == null))
                {
                    Script.Parameters.AddWithValue("web", PaginaWeb);
                }
                Script.Parameters.AddWithValue("proposito", Proposito);
                Script.Parameters.AddWithValue("coleccionistaID", ResponsableID);
                Script.Parameters.AddWithValue("clubID", ResponsableClubID);
                Script.Parameters.AddWithValue("ingreso", ResponsableFechaIngreso);
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
