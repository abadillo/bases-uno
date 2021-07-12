using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Contacto : DBConnection.CRUD<Contacto, int>
    {
        #region Atributes
        public int ID { get; set; }
        public string Email { get; set; } //nullable
        public int Telefono { get; set; } //nullable
        public string Plataforma { get; set; }
        public int ClubID { get; set; }
        #endregion

        #region Constructors
        // Se crea con toda la informacion de la instancia de clase
        public Contacto(int id, string plataforma, int clubID, string email = null, int telefono = 0)
        {
            ID = id;
            Email = email;
            Telefono = telefono;
            Plataforma = plataforma;
            ClubID = clubID;
        }

        //Usualmente se usa cuando se va a hacer un insert de una clase cuya clave es un SERIAL
        public Contacto(string plataforma, int clubID, string email = null, int telefono = 0)
        {
            Email = email;
            Telefono = telefono;
            Plataforma = plataforma;
            ClubID = clubID;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public Contacto(int id)
        {
            Contacto contact = Read(id);
            if (!(contact == null))
            {
                ID = contact.ID;
                Email = contact.Email;
                Telefono = contact.Telefono;
                Plataforma = contact.Plataforma;
                ClubID = contact.ClubID;
            }
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM contacto WHERE id = @id";
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

                string Query = "INSERT INTO contacto (";
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

        public override Contacto Read(int id)
        {
            Contacto contact = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM contacto WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    contact = new Contacto(ReadInt(0), ReadString(3), ReadInt(4), ReadString(1), ReadInt(2));
                }
            }
            catch
            {
                contact = null;
            }
            finally
            {
                CloseConnection();
            }

            return contact;
        }

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE contacto SET plataforma = @plataforma, club_id = @clubid";
                if (!(Email == null))
                {
                    Query += ", usuario_email = @email";
                }
                if (!(Telefono == 0))
                {
                    Query += ", telefono = @telefono";
                }
                Query += " WHERE id = @id";
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
