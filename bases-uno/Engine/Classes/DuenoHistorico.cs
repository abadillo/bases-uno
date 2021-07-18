using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class DuenoHistorico : DBConnection.CRUD<DuenoHistorico>
    {
        #region Atributes
        public int ID { get; set; } //pk
        public Nullable<DateTime> FechaRegistro { get; set; } //pk
        public String Significado { get; set; } //nullable
        public int ColeccionistaID { get; set; } //pk
        //O ColeccionableID o ComicID son null
        public int ColeccionableID { get; set; }
        public int ComicID { get; set; }
        public float PrecioDolares { get; set; } //nullable
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
        public DuenoHistorico(DateTime fechaRegistro, Coleccionista coleccionista, Coleccionable coleccionable, float precioDolar = 0, string significado = null)
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
        public DuenoHistorico(DateTime fechaRegistro, Coleccionista coleccionista, Comic comic, float precioDolar = 0, string significado = null)
        {
            FechaRegistro = fechaRegistro;
            Significado = significado;
            ColeccionistaID = coleccionista.ID;
            ColeccionableID = 0;
            ComicID = comic.ID;
            PrecioDolares = precioDolar;
        }

        /// <summary>
        /// Constructor para la clase READ, NO USAR
        /// </summary>
        public DuenoHistorico(int id, Nullable<DateTime> fechaRegistro, String significado, int coleccionistaID, int coleccionableID, float precioDolar,
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

                string Query = "DELETE FROM dueno_historico WHERE coleccionista_documento_identidad = @coleccionistaid AND fecha_registro = @fecha AND id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);
                Script.Parameters.AddWithValue("fecha", FechaRegistro);

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

                string Query = "INSERT INTO dueno_historico (fecha_registro, coleccionista_documento_identidad, precio_dolar";
                if (!(Significado == null))
                {
                    Query += ", significado";
                }
                if (!(ColeccionableID == 0))
                {
                    Query += ", coleccionable_id";
                }
                else if (!(ComicID == 0))
                {
                    Query += ", comic_id";
                }
                Query += ") VALUES (@fecharegistro, @coleccionistaid, @precio";
                if (!(Significado == null))
                {
                    Query += ", @significado";
                }
                if (!(ColeccionableID == 0))
                {
                    Query += ", @coleccionableid";
                }
                else if (!(ComicID == 0))
                {
                    Query += ", @comicid";
                }
                Query += ") RETURNING id";

                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("fecharegistro", FechaRegistro);
                Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);
                Script.Parameters.AddWithValue("precio", PrecioDolares);
                if (!(Significado == null))
                {
                    Script.Parameters.AddWithValue("significado", Significado);
                }
                if (!(ColeccionableID == 0))
                {
                    Script.Parameters.AddWithValue("coleccionableid", ColeccionableID);
                }
                else if (!(ComicID == 0))
                {
                    Script.Parameters.AddWithValue("comicid", ComicID);
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

                string Query = "UPDATE dueno_historico SET ";
                if (!(PrecioDolares == 0))
                {
                    Query += "precio_dolar = @precio";
                    if ((!(Significado == null)) || (!(ColeccionableID == 0)))
                    {
                        Query += ", ";
                    }
                }
                if (!(Significado == null))
                {
                    Query += "significado = @significado";
                    if (!(ColeccionableID == 0))
                    {
                        Query += ", ";
                    }
                }
                if (!(ColeccionableID == 0))
                {
                    Query += "coleccionable_id = @coleccionableid";
                }
                else if (!(ComicID == 0))
                {
                    Query += ", comic_id = @comicid";
                }
                Query += " WHERE coleccionista_documento_identidad = @coleccionistaid AND fecha_registro = @fecha AND id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("fecharegistro", FechaRegistro);
                Script.Parameters.AddWithValue("coleccionistaid", ColeccionistaID);
                Script.Parameters.AddWithValue("precio", PrecioDolares);
                if (!(Significado == null))
                {
                    Script.Parameters.AddWithValue("significado", Significado);
                }
                if (!(ColeccionableID == 0))
                {
                    Script.Parameters.AddWithValue("coleccionableid", ColeccionableID);
                }
                else if (!(ComicID == 0))
                {
                    Script.Parameters.AddWithValue("comicid", ComicID);
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

        #region Other Methods\
        public Comic Comic()
        {
            return Read.Comic(ComicID);
        }

        public Coleccionable Coleccionable()
        {
            return Read.Coleccionable(ColeccionableID);
        }
        #endregion
    }
}
