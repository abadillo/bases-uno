using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Club : Engine.DBConnection.CRUD<Club, int>
    {
        #region Atributes
        public int ID { get; set; }
        public DateTime FechaFundacion { get; set; }
        public int Telefono { get; set; } //nullable
        public string PaginaWeb { get; set; } //nullable
        public string Proposito { get; set; }
        public int ResponsableID { get; set; }
        public int ResponsableClubID { get; set; }
        public DateTime ResponsableFechaIngreso { get; set; }
        public int LugarID { get; set; }
        #endregion

        #region Constructors
        // Se crea con toda la informacion de la instancia de clase
        public Club(int id, DateTime fechaFundacion, string proposito, int responsableID, int responsableClubId, DateTime responsableFechaIngreso,
            int lugarID, int telefono = 0, string paginaWeb = null)
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

        //Usualmente se usa cuando se va a hacer un insert de una clase cuya clave es un SERIAL
        public Club(DateTime fechaFundacion, int telefono, string paginaWeb, string proposito, int responsableID, 
            int responsableClubId, DateTime responsableFechaIngreso, int lugarID)
        {
            FechaFundacion = fechaFundacion;
            Telefono = telefono;
            PaginaWeb = paginaWeb;
            Proposito = proposito;
            ResponsableID = responsableID;
            ResponsableClubID = responsableClubId;
            ResponsableFechaIngreso = responsableFechaIngreso;
            LugarID = lugarID;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public Club(int id)
        {
            Club club = Read(id);
            if (!(club == null))
            {
                ID = club.ID;
                FechaFundacion = club.FechaFundacion;
                Telefono = club.Telefono;
                PaginaWeb = club.PaginaWeb;
                Proposito = club.Proposito;
                ResponsableID = club.ResponsableID;
                ResponsableClubID = club.ResponsableClubID;
                ResponsableFechaIngreso = club.ResponsableFechaIngreso;
                LugarID = club.LugarID;
            }
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

        public override Club Read(int id)
        {
            Club club = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM club WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    club = new Club(ReadInt(0), ReadDate(1), ReadString(4), ReadInt(5),ReadInt(6), ReadDate(7), 
                        ReadInt(8), ReadInt(2), ReadString(3));
                }
            }
            catch
            {
                club = null;
            }
            finally
            {
                CloseConnection();
            }

            return club;
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
