using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Engine
{
    public class Comic : ConnectionDB<Comic, int>
    {
        #region Atributes
        public int ID { get; set; }
        public string Titel { get; set; }
        public int Volume { get; set; }
        public int Number { get; set; }
        public DateTime PublicationDate { get; set; }
        public float PublicationPrice { get; set; }
        public bool Color { get; set; }
        public string Synopsis { get; set; }
        public int Pages { get; set; }
        public bool Cover { get; set; }
        public string Editor { get; set; }
        #endregion

        #region Constructors
        public Comic(int id, string titel, int number, DateTime publicationDate, bool color,
           string synopsis, int pages, bool cover, string editor, int volumen = 0, float publicationPrice = 0)
        {
            ID = id;
            Titel = titel;
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
            Titel = titel;
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

        public Comic(int id)
        {
            Comic comic = Read(id);
            if (!(comic == null))
            {
                ID = comic.ID;
                Titel = comic.Titel;
                Number = comic.Number;
                PublicationDate = comic.PublicationDate;
                Color = comic.Color;
                Synopsis = comic.Synopsis;
                Pages = comic.Pages;
                Cover = comic.Cover;
                Editor = comic.Editor;
                Volume = comic.Volume;
                PublicationPrice = comic.PublicationPrice;
            }
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM comic WHERE id = @id";
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

                string Query = "INSERT INTO comic (titulo, numero, fecha_pub, color, sinopsis, paginas, cubierta, editor";
                if (!(Volume == 0))
                {
                    Query += ", volumen";
                }
                if (!(PublicationPrice == 0))
                {
                    Query += ", precio_pub";
                }
                Query += ") VALUES (@titulo, @numero, @fecha_pub, @color, @sinopsis, @paginas, @cubierta, @editor";
                if (!(Volume == 0))
                {
                    Query += ", @volumen";
                }
                if (!(PublicationPrice == 0))
                {
                    Query += ", @precio_pub";
                }
                Query += ") RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("titulo", Titel);
                Script.Parameters.AddWithValue("numero", Number);
                Script.Parameters.AddWithValue("fecha_pub", PublicationDate);
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
                    Script.Parameters.AddWithValue("precio_pub", PublicationPrice);
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

        public override List<Comic> ListAll()
        {
            List<Comic> list = new List<Comic>();

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM comic";
                NpgsqlCommand Script = new NpgsqlCommand(Query, Connection);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    Comic comic = new Comic(ReadInt(0), ReadString(1), ReadInt(3), ReadDate(4), ReadBool(6), 
                        ReadString(7), ReadInt(8), ReadBool(9), ReadString(10), ReadInt(2), ReadFloat(5));

                    list.Add(comic);
                }
            }
            catch
            {
                list = new List<Comic>();
            }
            finally
            {
                CloseConnection();
            }

            return list;
        }

        public override Comic Read(int id)
        {
            Comic comic = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM comic WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    comic = new Comic(ReadInt(0), ReadString(1), ReadInt(3), ReadDate(4), ReadBool(6),
                        ReadString(7), ReadInt(8), ReadBool(9), ReadString(10), ReadInt(2), ReadFloat(5));
                }
            }
            catch
            {
                comic = null;
            }
            finally
            {
                CloseConnection();
            }

            return comic;
        }

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE comic SET otherData = @otherData " +
                        "WHERE id = @id";
                if (Volume == 0)
                {
                    
                    if (PublicationPrice == 0)
                    {
                        Query = "UPDATE comic SET titulo = @titulo, numero = @numero, fecha_pub = @fecha_pub, " +
                            "color = @color, sinopsis = @sinopsis, paginas = @paginas, cubierta = @cubierta, " +
                            "editor = @editor " +
                            "WHERE id = @id";
                        Script = new NpgsqlCommand(Query, Connection);

                        Script.Parameters.AddWithValue("id", ID);
                        Script.Parameters.AddWithValue("titulo", Titel);
                        Script.Parameters.AddWithValue("numero", Number);
                        Script.Parameters.AddWithValue("fecha_pub", PublicationDate);
                        Script.Parameters.AddWithValue("color", Color);
                        Script.Parameters.AddWithValue("sinopsis", Synopsis);
                        Script.Parameters.AddWithValue("paginas", Pages);
                        Script.Parameters.AddWithValue("cubierta", Cover);
                        Script.Parameters.AddWithValue("editor", Editor);
                    }
                    else
                    {
                        Query = "UPDATE comic SET titulo = @titulo, numero = @numero, fecha_pub = @fecha_pub, " +
                            "precio_pub = @precio_pub, color = @color, sinopsis = @sinopsis, paginas = @paginas, " +
                            "cubierta = @cubierta, editor = @editor " +
                            "WHERE id = @id";
                        Script = new NpgsqlCommand(Query, Connection);

                        Script.Parameters.AddWithValue("id", ID);
                        Script.Parameters.AddWithValue("titulo", Titel);
                        Script.Parameters.AddWithValue("numero", Number);
                        Script.Parameters.AddWithValue("fecha_pub", PublicationDate);
                        Script.Parameters.AddWithValue("precio_pub", PublicationPrice);
                        Script.Parameters.AddWithValue("color", Color);
                        Script.Parameters.AddWithValue("sinopsis", Synopsis);
                        Script.Parameters.AddWithValue("paginas", Pages);
                        Script.Parameters.AddWithValue("cubierta", Cover);
                        Script.Parameters.AddWithValue("editor", Editor);
                    }
                }
                else if (PublicationPrice == 0)
                {
                    Query = "UPDATE comic SET titulo = @titulo, volumen = @volumen, numero = @numero, " +
                        "fecha_pub = @fecha_pub, color = @color, sinopsis = @sinopsis, paginas = @paginas, " +
                        "cubierta = @cubierta, editor = @editor " +
                        "WHERE id = @id";
                    Script = new NpgsqlCommand(Query, Connection);

                    Script.Parameters.AddWithValue("id", ID);
                    Script.Parameters.AddWithValue("titulo", Titel);
                    Script.Parameters.AddWithValue("volumen", Volume);
                    Script.Parameters.AddWithValue("numero", Number);
                    Script.Parameters.AddWithValue("fecha_pub", PublicationDate);
                    Script.Parameters.AddWithValue("color", Color);
                    Script.Parameters.AddWithValue("sinopsis", Synopsis);
                    Script.Parameters.AddWithValue("paginas", Pages);
                    Script.Parameters.AddWithValue("cubierta", Cover);
                    Script.Parameters.AddWithValue("editor", Editor);
                }
                else
                {
                    Query = "UPDATE comic SET titulo = @titulo, volumen = @volumen, numero = @numero, " +
                        "fecha_pub = @fecha_pub, precio_pub = @precio_pub, color = @color, " +
                        "sinopsis = @sinopsis, paginas = @paginas, cubierta = @cubierta, editor = @editor " +
                        "WHERE id = @id";
                    Script = new NpgsqlCommand(Query, Connection);

                    Script.Parameters.AddWithValue("id", ID);
                    Script.Parameters.AddWithValue("titulo", Titel);
                    Script.Parameters.AddWithValue("volumen", Volume);
                    Script.Parameters.AddWithValue("numero", Number);
                    Script.Parameters.AddWithValue("fecha_pub", PublicationDate);
                    Script.Parameters.AddWithValue("precio_pub", PublicationPrice);
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
