using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Contacto : DBConnection.CRUD<Contacto>
    {
        #region Atributes
        public int ID { get; set; } //pk
        public string Email { get; set; } //nullable
        public long Telefono { get; set; } //nullable
        public string Plataforma { get; set; }
        public int ClubID { get; set; } //pk
        #endregion

        #region Constructors
        /// <summary>
        /// Se usa previo a hacer un Insert en la BD
        /// </summary>
        public Contacto(string plataforma, Club club, string email = null,long telefono = 0)
        {
            Email = email;
            Telefono = telefono;
            Plataforma = plataforma;
            ClubID = club.ID;
        }

        /// <summary>
        /// Constructor usado por la clase READ, NO USAR
        /// </summary>
        public Contacto(int id, string plataforma, int clubID, string email = null,long telefono = 0)
        {
            ID = id;
            Email = email;
            Telefono = telefono;
            Plataforma = plataforma;
            ClubID = clubID;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGcontacto WHERE id = @id AND club_id = @clubid";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("clubid", ClubID);

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

                string Query = "INSERT INTO JAGcontacto (";
                if (!(Email == null))
                {
                    Query += "usuario_email, ";
                }
                if (!(Telefono == 0))
                {
                    Query += "telefono, ";
                }
                Query += "plataforma, club_id) VALUES (";
                if (!(Email == null))
                {
                    Query += "@email, ";
                }
                if (!(Telefono == 0))
                {
                    Query += "@telefono, ";
                }
                Query += "@plataforma, @clubid) RETURNING id";

                Script = new NpgsqlCommand(Query, Connection);

                if (!(Email == null))
                {
                    Script.Parameters.AddWithValue("email", Email);
                }
                if (!(Telefono == 0))
                {
                    Script.Parameters.AddWithValue("telefono", Telefono);
                }
                Script.Parameters.AddWithValue("plataforma", Plataforma);
                Script.Parameters.AddWithValue("clubid", ClubID);

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

                string Query = "UPDATE JAGcontacto SET plataforma = @plataforma";
                if (!(Email == null))
                {
                    Query += ", usuario_email = @email";
                }
                if (!(Telefono == 0))
                {
                    Query += ", telefono = @telefono";
                }
                Query += " WHERE id = @id AND club_id = @clubid";
                Script = new NpgsqlCommand(Query, Connection);

                if (!(Email == null))
                {
                    Script.Parameters.AddWithValue("email", Email);
                }
                if (!(Telefono == 0))
                {
                    Script.Parameters.AddWithValue("telefono", Telefono);
                }
                Script.Parameters.AddWithValue("plataforma", Plataforma);
                Script.Parameters.AddWithValue("clubid", ClubID);
                Script.Parameters.AddWithValue("id", ID);

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
