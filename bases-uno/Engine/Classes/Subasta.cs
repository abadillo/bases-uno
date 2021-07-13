using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Subasta : DBConnection.CRUD<Subasta>
    {
        #region Atributes
        public int ID { get; set; } //pk
        public Nullable<DateTime> Fecha { get; set; }
        public Nullable<DateTime> HoraInicio { get; set; }
        public Nullable<DateTime> HoraCierre { get; set; }
        public string Tipo { get; set; }
        public bool Caridad { get; set; }
        public bool Cancelado { get; set; }
        public int LocalID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD, si la clase tiene una clave serial
        /// </summary>Usar por el Check:
        /// <param name="tipo">
        /// public static class TipoSubasta 
        /// <para>{</para>
        /// <para>public const string Presencial = "Presencial";</para>
        /// <para>public const string Virtual = "Virtual";</para>
        /// <para>}</para>
        /// </param>
        public Subasta(DateTime fecha, DateTime horaInicio, DateTime horaCierre, string tipo, 
            bool caridad, bool cancelado, Local local)
        {
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraCierre = horaCierre;
            Tipo = tipo;
            Caridad = caridad;
            Cancelado = cancelado;
            LocalID = local.ID;
        }

        /// <summary>
        /// Constructor General de la Clase, usualmente para la clase READ
        /// </summary>
        public Subasta(int id, Nullable<DateTime> fecha, Nullable<DateTime> horaInicio, Nullable<DateTime> horaCierre, 
            string tipo, bool caridad, bool cancelado, int localID)
        {
            ID = id;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraCierre = horaCierre;
            Tipo = tipo;
            Caridad = caridad;
            Cancelado = cancelado;
            LocalID = localID;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM subasta WHERE id = @id";
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

                string Query = "INSERT INTO subasta (fecha, hora_inicio, hora_cierre, tipo, caridad, " +
                    "cancelado, local_id) " +
                    "VALUES () RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("fecha", Fecha);
                Script.Parameters.AddWithValue("horainicio", HoraInicio);
                Script.Parameters.AddWithValue("horacierre", HoraCierre);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("caridad", Caridad);
                Script.Parameters.AddWithValue("cancelado", Cancelado);
                Script.Parameters.AddWithValue("localid", LocalID);

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

                string Query = "UPDATE subasta SET fecha = @fecha, hora_inicio = @horainicio, " +
                    "hora_cierre = , @horacierre, tipo = @tipo, caridad = , @caridad, cancelado = @cancelado, " +
                    "local_id = @localid" +
                    "WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("fecha", Fecha);
                Script.Parameters.AddWithValue("horainicio", HoraInicio);
                Script.Parameters.AddWithValue("horacierre", HoraCierre);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("caridad", Caridad);
                Script.Parameters.AddWithValue("cancelado", Cancelado);
                Script.Parameters.AddWithValue("localid", LocalID);

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
