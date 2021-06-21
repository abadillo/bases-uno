﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Engine
{
    class ClassModell : ConnectionDB<ClassModell, int>
    {
        #region Atributes
        public int ID { get; set; }
        public string OtherData { get; set; }
        #endregion

        #region Constructors
        // Se crea con toda la informacion de la instancia de clase
        public ClassModell(int id,string otherData)
        {
            ID = id;
            OtherData = otherData;
        }

        //Usualmente se usa cuando se va a hacer un insert de una clase cuya clave es un SERIAL
        public ClassModell(string otherData)
        {
            OtherData = otherData;
        }

        //Se usa cuando se quiere una instancia especifica de una clase en la base de datos
        public ClassModell(int id)
        {
            ClassModell modell = Read(id);
            if (!(modell == null))
            {
                ID = modell.ID;
                OtherData = modell.OtherData;
            }
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM modell WHERE id = @id";
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

        public override List<ClassModell> ListAll()
        {
            List<ClassModell> list = new List<ClassModell>();

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM modell";
                NpgsqlCommand Script = new NpgsqlCommand(Query, Connection);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    ClassModell modell= new ClassModell(ReadInt(0), ReadString(1));

                    list.Add(modell);
                }
            }
            catch
            {
                list = new List<ClassModell>();
            }
            finally
            {
                CloseConnection();
            }

            return list;
        }

        public override ClassModell Read(int id)
        {
            ClassModell modell = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM modell WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    modell = new ClassModell(ReadInt(0), ReadString(1));
                }
            }
            catch
            {
                modell = null;
            }
            finally
            {
                CloseConnection();
            }

            return modell;
        }

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE modell SET otherData = @otherData " +
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