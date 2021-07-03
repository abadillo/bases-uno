using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Interes : DBConnection.CRUD<Interes, int>
    {
        #region Atributes
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructors
        // Se crea con toda la informacion de la instancia de clase
        public Interes(int id, string name, string description = "")
        {
            ID = id;
            Nombre = name;
            Descripcion = description;
        }

        //Usualmente se usa cuando se va a hacer un insert de una clase cuya clave es un SERIAL
        public Interes(string name, string description = "")
        {
            Nombre = name;
            Descripcion = description;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public Interes(int id)
        {
            Interes interest = Read(id);
            if (!(interest == null))
            {
                ID = interest.ID;
                Nombre = interest.Nombre;
                Descripcion = interest.Descripcion;
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

                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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

        public override Interes Read(int id)
        {
            Interes interest = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM interes WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    interest = new Interes(ReadInt(0), ReadString(1), ReadString(2));
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
                Script.Parameters.AddWithValue("nombre", Nombre);
                Script.Parameters.AddWithValue("descripcion", Descripcion);

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
