using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Listado : DBConnection.CRUD<Listado>
    {
        #region Atributes
        public int ID { get; set; } //PK
        public int Orden { get; set; } //nullable
        public float PrecioBase { get; set; }
        public float PrecioVenta { get; set; } //nullable
        public int SubastaID { get; set; } //PK
        public int DuenoHistoricoColeccionistaID { get; set; }
        public Nullable<DateTime> DuenoHistoricoFechaRegistro { get; set; }
        public int ParticipanteSubastaID { get; set; } //nullable
        public int DuenoHistoricoID { get; set; }
        public int ParticipanteIDInscripcion { get; set; } //nullable
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD
        /// </summary>
        public Listado(Subasta subasta, float precioBase, DuenoHistorico duenoHistorico, int orden = 0, 
            float precioVenta = 0, Participante participante)
        {
            Orden = orden;
            PrecioBase = precioBase;
            PrecioVenta = precioVenta;
            SubastaID = subasta.ID;
            DuenoHistoricoColeccionistaID = duenoHistorico.ColeccionistaID;
            DuenoHistoricoFechaRegistro = duenoHistorico.FechaRegistro;
            DuenoHistoricoID = duenoHistorico.ID;
            ParticipanteSubastaID = participante.SubastaID;
            ParticipanteIDInscripcion = participante.IDInscripcion;
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Listado(int id, int orden, float precioBase, float precioVenta, int subastaID, 
            int duenoHistoricoColeccionistaID,
            Nullable<DateTime> duenoHistoricoFechaRegistro, int participanteSubastaID, int duenoHistoricoID, 
            int participanteIDInscripcion)
        {
            ID = id;
            Orden = orden;
            PrecioBase = precioBase;
            PrecioVenta = precioVenta;
            SubastaID = subastaID;
            DuenoHistoricoColeccionistaID = duenoHistoricoColeccionistaID;
            DuenoHistoricoFechaRegistro = duenoHistoricoFechaRegistro;
            ParticipanteSubastaID = participanteSubastaID;
            DuenoHistoricoID = duenoHistoricoID;
            ParticipanteIDInscripcion = participanteIDInscripcion;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM listado WHERE id = @id AND subasta_id = @subastaid";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
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
                Connection.Open();

                string Query = "INSERT INTO listado (precio_base_dolar, subasta_id, dueno_historico_coleccionista_documento_identidad, " +
                    "dueno_historico_fecha_registro, dueno_historico_id";
                if (!(Orden == 0))
                {
                    Query += ", orden";
                }
                if (!(PrecioVenta == 0))
                {
                    Query += ", precio_vendido_dolar";
                }
                if (!(ParticipanteIDInscripcion == 0 || ParticipanteSubastaID == 0))
                {
                    Query += ", participante_subasta_id, participante_id_inscripcion";
                }
                Query += ") VALUES (@preciobase, @subastaid, @duenoid, @duenofecha, @duenocoleccionistaid";
                if (!(Orden == 0))
                {
                    Query += ", @orden";
                }
                if (!(PrecioVenta == 0))
                {
                    Query += ", @preciovendido";
                }
                if (!(ParticipanteIDInscripcion == 0 || ParticipanteSubastaID == 0))
                {
                    Query += ", @participantesubastaid, @participanteidinscripcion";
                }
                Query += ") RETURNING id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("preciobase", PrecioBase);
                Script.Parameters.AddWithValue("subastaid", SubastaID);
                Script.Parameters.AddWithValue("duenoid", DuenoHistoricoID);
                Script.Parameters.AddWithValue("duenofecha", DuenoHistoricoFechaRegistro);
                Script.Parameters.AddWithValue("duenocoleccionistaid", DuenoHistoricoColeccionistaID);
                if (!(Orden == 0))
                {
                    Script.Parameters.AddWithValue("orden", Orden);
                }
                if (!(PrecioVenta == 0))
                {
                    Script.Parameters.AddWithValue("preciovendido", PrecioVenta);
                }
                if (!(ParticipanteIDInscripcion == 0 || ParticipanteSubastaID == 0))
                {
                    Script.Parameters.AddWithValue("participantesubastaid", ParticipanteSubastaID);
                    Script.Parameters.AddWithValue("participanteidinscripcion", ParticipanteIDInscripcion);
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

                string Query = "UPDATE listado SET precio_base_dolar = @preciobase, dueno_historico_coleccionista_documento_identidad = @duenocoleccionistaid, " +
                    "dueno_historico_fecha_registro = @duenofecha, dueno_historico_id = @duenoid";
                if (!(Orden == 0))
                {
                    Query += ", orden = @orden";
                }
                if (!(PrecioVenta == 0))
                {
                    Query += ", precio_vendido_dolar = @preciovendido";
                }
                if (!(ParticipanteIDInscripcion == 0 || ParticipanteSubastaID == 0))
                {
                    Query += ", participante_subasta_id = @participantesubastaid, participante_id_inscripcion = @participanteidinscripcion";
                }
                Query += " WHERE id = @id AND subasta_id = @subastaid";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("preciobase", PrecioBase);
                Script.Parameters.AddWithValue("subastaid", SubastaID);
                Script.Parameters.AddWithValue("duenoid", DuenoHistoricoID);
                Script.Parameters.AddWithValue("duenofecha", DuenoHistoricoFechaRegistro);
                Script.Parameters.AddWithValue("duenoid", DuenoHistoricoColeccionistaID);
                if (!(Orden == 0))
                {
                    Script.Parameters.AddWithValue("orden", Orden);
                }
                if (!(PrecioVenta == 0))
                {
                    Script.Parameters.AddWithValue("preciovendido", PrecioVenta);
                }
                if (!(ParticipanteIDInscripcion == 0 || ParticipanteSubastaID == 0))
                {
                    Script.Parameters.AddWithValue("participantesubastaid", ParticipanteSubastaID);
                    Script.Parameters.AddWithValue("participanteidinscripcion", ParticipanteIDInscripcion);
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
