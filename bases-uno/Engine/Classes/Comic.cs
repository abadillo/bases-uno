using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Engine.Classes
{
    public class Comic : DBConnection.CRUD<Comic>
    {
        #region Atributes
        public int ID { get; set; }
        public string Title { get; set; }
        public int Volume { get; set; } //nullable
        public int Number { get; set; }
        public Nullable<DateTime> PublicationDate { get; set; }
        public float PublicationPrice { get; set; } //nullable
        public bool Color { get; set; }
        public string Synopsis { get; set; }
        public int Pages { get; set; }
        public bool Cover { get; set; }
        public string Editor { get; set; }
        #endregion

        #region Constructors
        public Comic(int id, string titel, int number, Nullable<DateTime> publicationDate, bool color,
           string synopsis, int pages, bool cover, string editor, int volumen = 0, float publicationPrice = 0)
        {
            ID = id;
            Title = titel;
            Number = number;
            PublicationDate = publicationDate;
            Color = color;
            Synopsis = synopsis;
            Pages = pages;
            Cover = cover;
            Editor = editor;
            Volume = volumen;
            PublicationPrice = publicationPrice;
        }

        public Comic(string titel, int number, DateTime publicationDate, bool color, string synopsis, 
            int pages, bool cover, string editor, int volumen = 0, float publicationPrice = 0)
        {
            ID = 0;
            Title = titel;
            Number = number;
            PublicationDate = publicationDate;
            Color = color;
            Synopsis = synopsis;
            Pages = pages;
            Cover = cover;
            Editor = editor;
            Volume = volumen;
            PublicationPrice = publicationPrice;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGcomic WHERE id = @id";
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

                string Query = "INSERT INTO JAGcomic (titulo, numero, fecha_publicacion, color, sinopsis, paginas, cubierta, editor";
                if (!(Volume == 0))
                {
                    Query += ", volumen";
                }
                if (!(PublicationPrice == 0))
                {
                    Query += ", precio_publicacion";
                }
                Query += ") VALUES (@titulo, @numero, @fecha_publicacion, @color, @sinopsis, @paginas, @cubierta, @editor";
                if (!(Volume == 0))
                {
                    Query += ", @volumen";
                }
                if (!(PublicationPrice == 0))
                {
                    Query += ", @precio_publicacion";
                }
                Query += ") RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("titulo", Title);
                Script.Parameters.AddWithValue("numero", Number);
                Script.Parameters.AddWithValue("fecha_publicacion", PublicationDate);
                Script.Parameters.AddWithValue("color", Color);
                Script.Parameters.AddWithValue("sinopsis", Synopsis);
                Script.Parameters.AddWithValue("paginas", Pages);
                Script.Parameters.AddWithValue("cubierta", Cover);
                Script.Parameters.AddWithValue("editor", Editor);
                if (!(Volume == 0))
                {
                    Script.Parameters.AddWithValue("volumen", Volume);
                }
                if (!(PublicationPrice == 0))
                {
                    Script.Parameters.AddWithValue("precio_publicacion", PublicationPrice);
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

                string Query = "UPDATE JAGcomic SET otherData = @otherData " +
                        "WHERE id = @id";
                if (Volume == 0)
                {
                    
                    if (PublicationPrice == 0)
                    {
                        Query = "UPDATE JAGcomic SET titulo = @titulo, numero = @numero, fecha_publicacion = @fecha_publicacion, " +
                            "color = @color, sinopsis = @sinopsis, paginas = @paginas, cubierta = @cubierta, " +
                            "editor = @editor " +
                            "WHERE id = @id";
                        Script = new NpgsqlCommand(Query, Connection);

                        Script.Parameters.AddWithValue("id", ID);
                        Script.Parameters.AddWithValue("titulo", Title);
                        Script.Parameters.AddWithValue("numero", Number);
                        Script.Parameters.AddWithValue("fecha_publicacion", PublicationDate);
                        Script.Parameters.AddWithValue("color", Color);
                        Script.Parameters.AddWithValue("sinopsis", Synopsis);
                        Script.Parameters.AddWithValue("paginas", Pages);
                        Script.Parameters.AddWithValue("cubierta", Cover);
                        Script.Parameters.AddWithValue("editor", Editor);
                    }
                    else
                    {
                        Query = "UPDATE JAGcomic SET titulo = @titulo, numero = @numero, fecha_publicacion = @fecha_publicacion, " +
                            "precio_publicacion = @precio_publicacion, color = @color, sinopsis = @sinopsis, paginas = @paginas, " +
                            "cubierta = @cubierta, editor = @editor " +
                            "WHERE id = @id";
                        Script = new NpgsqlCommand(Query, Connection);

                        Script.Parameters.AddWithValue("id", ID);
                        Script.Parameters.AddWithValue("titulo", Title);
                        Script.Parameters.AddWithValue("numero", Number);
                        Script.Parameters.AddWithValue("fecha_publicacion", PublicationDate);
                        Script.Parameters.AddWithValue("precio_publicacion", PublicationPrice);
                        Script.Parameters.AddWithValue("color", Color);
                        Script.Parameters.AddWithValue("sinopsis", Synopsis);
                        Script.Parameters.AddWithValue("paginas", Pages);
                        Script.Parameters.AddWithValue("cubierta", Cover);
                        Script.Parameters.AddWithValue("editor", Editor);
                    }
                }
                else if (PublicationPrice == 0)
                {
                    Query = "UPDATE JAGcomic SET titulo = @titulo, volumen = @volumen, numero = @numero, " +
                        "fecha_publicacion = @fecha_publicacion, color = @color, sinopsis = @sinopsis, paginas = @paginas, " +
                        "cubierta = @cubierta, editor = @editor " +
                        "WHERE id = @id";
                    Script = new NpgsqlCommand(Query, Connection);

                    Script.Parameters.AddWithValue("id", ID);
                    Script.Parameters.AddWithValue("titulo", Title);
                    Script.Parameters.AddWithValue("volumen", Volume);
                    Script.Parameters.AddWithValue("numero", Number);
                    Script.Parameters.AddWithValue("fecha_publicacion", PublicationDate);
                    Script.Parameters.AddWithValue("color", Color);
                    Script.Parameters.AddWithValue("sinopsis", Synopsis);
                    Script.Parameters.AddWithValue("paginas", Pages);
                    Script.Parameters.AddWithValue("cubierta", Cover);
                    Script.Parameters.AddWithValue("editor", Editor);
                }
                else
                {
                    Query = "UPDATE JAGcomic SET titulo = @titulo, volumen = @volumen, numero = @numero, " +
                        "fecha_publicacion = @fecha_publicacion, precio_publicacion = @precio_publicacion, color = @color, " +
                        "sinopsis = @sinopsis, paginas = @paginas, cubierta = @cubierta, editor = @editor " +
                        "WHERE id = @id";
                    Script = new NpgsqlCommand(Query, Connection);

                    Script.Parameters.AddWithValue("id", ID);
                    Script.Parameters.AddWithValue("titulo", Title);
                    Script.Parameters.AddWithValue("volumen", Volume);
                    Script.Parameters.AddWithValue("numero", Number);
                    Script.Parameters.AddWithValue("fecha_publicacion", PublicationDate);
                    Script.Parameters.AddWithValue("precio_publicacion", PublicationPrice);
                    Script.Parameters.AddWithValue("color", Color);
                    Script.Parameters.AddWithValue("sinopsis", Synopsis);
                    Script.Parameters.AddWithValue("paginas", Pages);
                    Script.Parameters.AddWithValue("cubierta", Cover);
                    Script.Parameters.AddWithValue("editor", Editor);
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
    }
}
