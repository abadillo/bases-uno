using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class DuenoHistorico : DBConnection.CRUD<DuenoHistorico, int>
    {
        #region Atributes
        public int ID { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String Significado { get; set; } //nullable
        public int ColeccionistaID { get; set; }
        //O ColeccionableID o ComicID son null
        public int ColeccionableID { get; set; }
        public int ComicID { get; set; }
        public float PrecioDolares { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Caso Dueño de un articulo coleccionable (NO un COMIC)
        /// </summary>
        /// <param name="fechaRegistro">Fecha del cambio de dueño, el ultimo es el dueño actual</param>
        /// <param name="coleccionista"></param>
        /// <param name="coleccionable"></param>
        /// <param name="precioDolar"></param>
        /// <param name="significado"></param>
        public DuenoHistorico(DateTime fechaRegistro, Coleccionista coleccionista, Coleccionable coleccionable, float precioDolar, string significado = null)
        {
            FechaRegistro = fechaRegistro;
            Significado = significado;
            ColeccionistaID = coleccionista.ID;
            ColeccionableID = coleccionable.ID;
            ComicID = 0;
            PrecioDolares = precioDolar;
        }

        /// <summary>
        /// Caso Dueño de un Comic
        /// </summary>
        /// <param name="fechaRegistro"></param>
        /// <param name="coleccionista"></param>
        /// <param name="comic"></param>
        /// <param name="precioDolar"></param>
        /// <param name="significado"></param>
        public DuenoHistorico(DateTime fechaRegistro, Coleccionista coleccionista, Comic comic, float precioDolar, string significado = null)
        {
            FechaRegistro = fechaRegistro;
            Significado = significado;
            ColeccionistaID = coleccionista.ID;
            ColeccionableID = 0;
            ComicID = comic.ID;
            PrecioDolares = precioDolar;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public DuenoHistorico(int id)
        {
            DuenoHistorico duenoHistorico = Read(id);
            if (!(duenoHistorico == null))
            {
                ID = duenoHistorico.ID;
                FechaRegistro = duenoHistorico.FechaRegistro;
                Significado = duenoHistorico.Significado;
                ColeccionistaID = duenoHistorico.ColeccionistaID;
                ColeccionableID = duenoHistorico.ColeccionableID;
                ComicID = duenoHistorico.ComicID;
                PrecioDolares = duenoHistorico.PrecioDolares;
            }
        }

        /// <summary>
        /// Constructor para la clase READ, NO USAR
        /// </summary>
        public DuenoHistorico(int id, DateTime fechaRegistro, String significado, int coleccionistaID, int coleccionableID, float precioDolar,
            int comicID)
        {
            ID = id;
            FechaRegistro = fechaRegistro;
            Significado = significado;
            ColeccionistaID = coleccionistaID;
            ColeccionableID = coleccionableID;
            ComicID = comicID;
            PrecioDolares = precioDolar;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM dueno_historico WHERE id = @id";
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

                string Query = "INSERT INTO dueno_historico (otherData) " +
                    "VALUES (@otherData) RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("otherData", OtherData);

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

        public override DuenoHistorico Read(int id)
        {
            DuenoHistorico duenoHistorico = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM dueno_historico WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    duenoHistorico = new DuenoHistorico(ReadInt(0), ReadString(1));
                }
            }
            catch
            {
                duenoHistorico = null;
            }
            finally
            {
                CloseConnection();
            }

            return duenoHistorico;
        }

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE dueno_historico SET otherData = @otherData " +
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
