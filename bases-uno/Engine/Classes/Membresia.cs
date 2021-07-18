using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Membresia : DBConnection.CRUD<Membresia>
    {
        #region Atributes
        public Nullable<DateTime> FechaIngreso { get; set; } //pk
        public Nullable<DateTime> FechaRetiro { get; set; } //nullable
        public int ClubID { get; set; } //pk
        public int ClubIDLider { get; set; } //nullable
        public int ColeccionistaID { get; set; } //pk
        public string Email { get; set; } //nullable
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor general de la clase
        /// </summary>
        public Membresia(Coleccionista coleccionista, Club club, DateTime fechaIngreso, string email = null, 
            Nullable<DateTime> fechaRetiro = null, Club clubLider = null)
        {
            FechaIngreso = fechaIngreso;
            FechaRetiro = fechaRetiro;
            ClubID = club.ID;
            ColeccionistaID = coleccionista.ID;
            Email = email;
            if (clubLider == null)
            {
                ClubIDLider = 0;
            }
            else
            {
                ClubIDLider = clubLider.ID;
            }
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Membresia(Nullable<DateTime> fechaIngreso, Nullable<DateTime> fechaRetiro, int clubID,
            int coleccionistaID, string email, int clubLider)
        {
            FechaIngreso = fechaIngreso;
            FechaRetiro = fechaRetiro;
            ClubID = clubID;
            ColeccionistaID = coleccionistaID;
            Email = email;
            ClubIDLider = clubLider;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM membresia WHERE fecha_ingreso = @fechaingreso AND club_id = @clubid AND " +
                    "coleccionista_documento_identidad = @coleccionistaid";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("fechaingreso", FechaIngreso);
                Script.Parameters.AddWithValue("clubid", ClubID);
                Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);

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

                string Query = "INSERT INTO membresia (fecha_ingreso, club_id, coleccionista_documento_identidad";
                if (!(FechaRetiro == null))
                {
                    Query += ", fecha_retiro";
                }
                if (!(Email == null))
                {
                    Query += ", email_contacto";
                }
                if (!(ClubIDLider == 0))
                {
                    Query += ", club_id_lider";
                }
                Query += ") VALUES (@fechaingreso, @clubid, @coleccionistaid";
                if (!(FechaRetiro == null))
                {
                    Query += ", @fecharetiro";
                }
                if (!(Email == null))
                {
                    Query += ", @email";
                }
                if (!(ClubIDLider == 0))
                {
                    Query += ", @clublider";
                }
                Query += ")";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("fechaingreso", FechaIngreso);
                Script.Parameters.AddWithValue("clubid", ClubID);
                Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);
                if (!(FechaRetiro == null))
                {
                    Script.Parameters.AddWithValue("fecharetiro", FechaRetiro);

                }
                if (!(Email == null))
                {
                    Script.Parameters.AddWithValue("email", Email);
                }
                if (!(ClubIDLider == 0))
                {
                    Script.Parameters.AddWithValue("clublider", ClubIDLider);
                }

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

                string Query = "UPDATE membresia SET ";
                if (!(FechaRetiro == null))
                {
                    Query += "fecha_retiro = @fecharetiro ";
                    if ((Email == null) || (ClubIDLider == 0))
                    {
                        Query += " ";
                    }
                    else
                    {
                        Query += ", ";
                    }
                }
                if (!(Email == null))
                {
                    Query += "email_contacto = @email ";
                    if (ClubIDLider == 0)
                    {
                        Query += " ";
                    }
                    else
                    {
                        Query += ", ";
                    }
                }
                if (!(ClubIDLider == 0))
                {
                    Query += "club_id_lider = @clublider ";
                }
                Query += "WHERE fecha_ingreso = @fechaingreso AND club_id = @clubid AND " +
                        "coleccionista_documento_identidad = @coleccionistaid";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("fechaingreso", FechaIngreso);
                Script.Parameters.AddWithValue("clubid", ClubID);
                Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);
                if (!(FechaRetiro == null))
                {
                    Script.Parameters.AddWithValue("fecharetiro", FechaRetiro);

                }
                if (!(Email == null))
                {
                    Script.Parameters.AddWithValue("email", Email);
                }
                if (!(ClubIDLider == 0))
                {
                    Script.Parameters.AddWithValue("clublider", ClubIDLider);
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
