using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Interest : DBConnection.CRUD<Interest, int>
    {
        #region Atributes
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructors
        // Se crea con toda la informacion de la instancia de clase
        public Interest(int id, string name, string description = "")
        {
            ID = id;
            Name = name;
            Description = description;
        }

        //Usualmente se usa cuando se va a hacer un insert de una clase cuya clave es un SERIAL
        public Interest(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public Interest(int id)
        {
            Interest interest = Read(id);
            if (!(interest == null))
            {
                ID = interest.ID;
                Name = interest.Name;
                Description = interest.Description;
            }
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM interes WHERE id = @id";
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

                string Query = "INSERT INTO interes (nombre, descripcion) " +
                    "VALUES (@nombre, @descripcion) RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("nombre", Name);
                Script.Parameters.AddWithValue("descripcion", Description);

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

        public override Interest Read(int id)
        {
            Interest interest = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM interes WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    interest = new Interest(ReadInt(0), ReadString(1), ReadString(2));
                }
            }
            catch
            {
                interest = null;
            }
            finally
            {
                CloseConnection();
            }

            return interest;
        }

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE interes SET nombre = @nombre, descripcion = @descripcion " +
                        "WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("nombre", Name);
                Script.Parameters.AddWithValue("descripcion", Description);

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
