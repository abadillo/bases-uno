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
        public DateTime DuenoHistoricoFechaRegistro { get; set; }
        public int ParticipanteSubastaID { get; set; } //nullable
        public int DuenoHistoricoID { get; set; }
        public int ParticipanteIDInscripcion { get; set; } //nullable
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD
        /// </summary>
        public Listado(int subastaID, float precioBase, DuenoHistorico duenoHistorico, int orden = 0, float precioVenta = 0, int participanteSubastaID = 0, 
            int participanteIDInscripcion = 0) //Falta Subasta, Participante
        {
            OtherData = otherData;
        }

        /// <summary>
        /// Crea una instancia de un registro especifico de la BD
        /// </summary>
        public Listado(int id)
        {
            Listado listado = Read(id);
            if (!(listado == null))
            {
                ID = listado.ID;
                OtherData = listado.OtherData;
            }
        }

        /// <summary>
        /// Constructor General de la Clase, usualmente para la clase READ
        /// </summary>
        public Listado(int id, string otherData)
        {
            ID = id;
            OtherData = otherData;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM listado WHERE id = @id";
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
                #region listado Caso ID no es SERIAL
                OpenConnection();

                string Query = "INSERT INTO listado (id, otherData) " +
                    "VALUES (@id, @otherData)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("otherData", OtherData);

                Script.Prepare();

                Script.ExecuteNonQuery();
                #endregion

                #region listado Caso ID es SERIAL
                Connection.Open();

                string Query2 = "INSERT INTO listado (otherData) " +
                    "VALUES (@otherData) RETURNING id";
                Script = new NpgsqlCommand(Query2, Connection);

                Script.Parameters.AddWithValue("otherData", OtherData);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    ID = ReadInt(0);
                }
                #endregion
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

                string Query = "UPDATE listado SET otherData = @otherData " +
                        "WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("otherData", OtherData);

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
