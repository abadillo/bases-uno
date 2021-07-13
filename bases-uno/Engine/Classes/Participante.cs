using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    class Participante : DBConnection.CRUD<ClassModell>
    {
        #region Atributes
        public int ID { get; set; }
        public string OtherData { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD, si la clase tiene una clave serial
        /// </summary>
        public ClassModell(string otherData)
        {
            OtherData = otherData;
        }

        /// <summary>
        /// Crea una instancia de un registro especifico de la BD
        /// </summary>
        public ClassModell(int id)
        {
            ClassModell modell = Read(id);
            if (!(modell == null))
            {
                ID = modell.ID;
                OtherData = modell.OtherData;
            }
        }

        /// <summary>
        /// Constructor General de la Clase, usualmente para la clase READ
        /// </summary>
        public ClassModell(int id, string otherData)
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

                string Query = "DELETE FROM modelo WHERE id = @id";
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
                #region Modelo Caso ID no es SERIAL
                OpenConnection();

                string Query = "INSERT INTO modelo (id, otherData) " +
                    "VALUES (@id, @otherData)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("otherData", OtherData);

                Script.Prepare();

                Script.ExecuteNonQuery();
                #endregion

                #region Modelo Caso ID es SERIAL
                Connection.Open();

                string Query2 = "INSERT INTO modelo (otherData) " +
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

                string Query = "UPDATE modelo SET otherData = @otherData " +
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