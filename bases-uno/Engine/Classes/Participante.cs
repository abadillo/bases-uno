using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Participante : DBConnection.CRUD<Participante>
    {
        #region Atributes
        public int IDInscripcion { get; set; } //pk
        public int SubastaID { get; set; } //pk
        public int MembresiaColeccionistaID { get; set; }
        public int MembresiaClubID { get; set; }
        public Nullable<DateTime> MembresiaFechaRegistro { get; set; }
        public bool Autorizado { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD
        /// </summary>
        public Participante(int idInscripcion, Subasta subasta, Membresia membresia, bool autorizado)
        {
            IDInscripcion = idInscripcion;
            SubastaID = subasta.ID;
            MembresiaColeccionistaID = membresia.ColeccionistaID;
            MembresiaClubID = membresia.ClubID;
            MembresiaFechaRegistro = membresia.FechaIngreso;
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Participante(int idInscripcion, int subastaID, int membresiaColeccionistaID, int membresiaClubID, 
            Nullable<DateTime> membresiaFechaRegistro, bool autorizado)
        {
            IDInscripcion = idInscripcion;
            SubastaID = subastaID;
            MembresiaColeccionistaID = membresiaColeccionistaID;
            MembresiaClubID = membresiaClubID;
            MembresiaFechaRegistro = membresiaFechaRegistro;
            Autorizado = autorizado;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM participante WHERE id_inscripcion = @idinscripcion AND subasta_id = @subastaid";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("idinscripcion", IDInscripcion);
                Script.Parameters.AddWithValue("subastaid", SubastaID);

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

                string Query = "INSERT INTO participante (id_inscripcion, subasta_id, " +
                    "membresia_coleccionista_documento_identidad, membresia_club_id, membresia_fecha_ingreso, " +
                    "autorizado) " +
                    "VALUES (@idinscripcion, @subastaid, @membresiaid, @membresiaclub, @membresiafecha, @autorizado)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("idinscripcion", IDInscripcion);
                Script.Parameters.AddWithValue("subastaid", SubastaID);
                Script.Parameters.AddWithValue("membresiaid", MembresiaColeccionistaID);
                Script.Parameters.AddWithValue("membresiaclub", MembresiaClubID);
                Script.Parameters.AddWithValue("membresiafecha", MembresiaFechaRegistro);
                Script.Parameters.AddWithValue("autorizado", Autorizado);

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

                string Query = "UPDATE participante " +
                    "SET membresia_coleccionista_documento_identidad = @membresiaid, " +
                    "membresia_club_id = @membresiaclub, membresia_fecha_ingreso = @membresiafecha, " +
                    "autorizado = @autorizado" +
                        "WHERE id_inscripcion = @idinscripcion AND subasta_id = @subastaid";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("idinscripcion", IDInscripcion);
                Script.Parameters.AddWithValue("subastaid", SubastaID);
                Script.Parameters.AddWithValue("membresiaid", MembresiaColeccionistaID);
                Script.Parameters.AddWithValue("membresiaclub", MembresiaClubID);
                Script.Parameters.AddWithValue("membresiafecha", MembresiaFechaRegistro);
                Script.Parameters.AddWithValue("autorizado", Autorizado);

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
        public Membresia Membresia()
        {
            return Read.Membresia(
                Read.Coleccionista(MembresiaColeccionistaID),
                Read.Club(MembresiaClubID),
                MembresiaFechaRegistro);
        }

        public Subasta Subasta()
        {
            return Read.Subasta(SubastaID);
        }

        public Coleccionista Coleccionista()
        {
            return Read.Coleccionista(MembresiaColeccionistaID);
        }
        #endregion
    }
}