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
        public int DuracionMinutos { get; set; } //nullable
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD
        /// </summary>
        public Listado(Subasta subasta, float precioBase, DuenoHistorico duenoHistorico, int orden = 0, 
            int duracion = 0, float precioVenta = 0, Participante participante = null)
        {
            Orden = orden;
            PrecioBase = precioBase;
            PrecioVenta = precioVenta;
            SubastaID = subasta.ID;
            DuenoHistoricoColeccionistaID = duenoHistorico.ColeccionistaID;
            DuenoHistoricoFechaRegistro = duenoHistorico.FechaRegistro;
            DuenoHistoricoID = duenoHistorico.ID;
            DuracionMinutos = duracion;
            if (participante == null)
            {
                ParticipanteSubastaID = 0;
                ParticipanteIDInscripcion = 0;
            }
            else
            {
                ParticipanteSubastaID = participante.SubastaID;
                ParticipanteIDInscripcion = participante.IDInscripcion;
            }
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Listado(int id, int orden, float precioBase, float precioVenta, int subastaID, 
            int duenoHistoricoColeccionistaID,
            Nullable<DateTime> duenoHistoricoFechaRegistro, int participanteSubastaID, int duenoHistoricoID, 
            int participanteIDInscripcion, int duracion)
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
            DuracionMinutos = duracion;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGlistado WHERE id = @id AND subasta_id = @subastaid";
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

                string Query = "INSERT INTO JAGlistado (precio_base_dolar, subasta_id, dueno_historico_coleccionista_documento_identidad, " +
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
                if (!(DuracionMinutos == 0))
                {
                    Query += ", duracion_min";
                }
                Query += ") VALUES (@preciobase, @subastaid, @duenocoleccionistaid, @duenofecha, @duenoid";
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
                if (!(DuracionMinutos == 0))
                {
                    Query += ", @duracion";
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
                if (!(DuracionMinutos == 0))
                {
                    Script.Parameters.AddWithValue("duracion", DuracionMinutos);
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

                string Query = "UPDATE JAGlistado SET precio_base_dolar = @preciobase, dueno_historico_coleccionista_documento_identidad = @duenocoleccionistaid, " +
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
        public DuenoHistorico DuenoHistorico()
        {
            return Read.DuenoHistorico(
                Read.Coleccionista(DuenoHistoricoColeccionistaID),
                DuenoHistoricoFechaRegistro,
                DuenoHistoricoID);
        }

        public Subasta Subasta()
        {
            return Read.Subasta(SubastaID);
        }

        public Participante Participante()
        {
            return Read.Participante(ParticipanteIDInscripcion, Subasta());
        }

        public void Cerrar()
        {
            if (!(PrecioVenta == 0))
            {
                DuenoHistorico historico = DuenoHistorico();
                DuenoHistorico nuevoDueno;
                if (historico.ComicID == 0)
                {
                    nuevoDueno = new DuenoHistorico(
                    (DateTime)Subasta().Fecha,
                    Participante().Coleccionista(),
                    historico.Coleccionable(),
                    PrecioVenta);
                }
                else
                {
                    nuevoDueno = new DuenoHistorico(
                    (DateTime)Subasta().Fecha,
                    Participante().Coleccionista(),
                    historico.Comic(),
                    PrecioVenta);
                }
                nuevoDueno.Insert();
            }
        }
        #endregion
    }
}
