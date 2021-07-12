﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Coleccionable:Engine.DBConnection.CRUD<Coleccionable,int>
    {
        #region Atributes
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD
        /// </summary>
        public Coleccionable(string nombre, string descripcion = null)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        /// <summary>
        /// Crea una instancia de un registro especifico de la BD
        /// </summary>
        public Coleccionable(int id)
        {
            Coleccionable colectable = Read(id);
            if (!(colectable == null))
            {
                ID = colectable.ID;
                Nombre = colectable.Nombre;
                Descripcion = colectable.Descripcion;
            }
        }

        /// <summary>
        /// Constructor para la clase READ, NO USAR
        /// </summary>
        public Coleccionable(int id, string nombre, string descripcion = null)
        {
            ID = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM coleccionable WHERE id = @id";
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

                string Query = "INSERT INTO coleccionable (nombre, descripcion_detallada) " +
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

        public override Coleccionable Read(int id)
        {
            Coleccionable colectable = null;

            try
            {
                OpenConnection();

                string Query = "SELECT * FROM coleccionable WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", id);
                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    colectable = new Coleccionable(ReadInt(0), ReadString(1), ReadString(2));
                }
            }
            catch
            {
                colectable = null;
            }
            finally
            {
                CloseConnection();
            }

            return colectable;
        }

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE coleccionable SET nombre = @nombre, descripcion_detallada = @descripcion" +
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