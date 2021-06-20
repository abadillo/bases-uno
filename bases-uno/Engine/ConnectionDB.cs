using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.CustomProperties;

namespace Engine
{
    public abstract class ConnectionDB<Tipo, Codigo>
    {
        #region Atributos para establecer la conexion
        //Retrieve Connection String By Name
        static string sConn = "bases_uno.Properties.Settings.DBConnectionString";
        static ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[sConn];
        SqlConnection conn = new SqlConnection(settings.ConnectionString);
        public NpgsqlCommand Script;
        public NpgsqlDataReader Reader;     
        public NpgsqlConnection Connection = new NpgsqlConnection(settings.ConnectionString);
        #endregion

        #region CRUDs
        /// <summary>
        /// Inserta <typeparamref name="Tipo"/> en la BD 
        /// </summary>
        public abstract void Insert();

        /// <summary>
        /// Busca <typeparamref name="Tipo"/> en la Base de Datos
        /// </summary>
        /// <returns>Lista con todos los objetos de la tabla de la <typeparamref name="Tipo"/></returns>
        public abstract List<Tipo> ListAll();

        /// <summary>
        /// Busca especificamente <typeparamref name="Tipo"/> en la base de datos
        /// </summary>
        /// <param name="codigo">Codigo de tipo <typeparamref name="Codigo"/> para la busqueda</param>
        /// <returns>La instancia especifica en la tabla de <typeparamref name="Tipo"/></returns>
        public abstract Tipo Read(Codigo codigo);

        /// <summary>
        /// Actualiza a informacion de <typeparamref name="Tipo"/> en la BD
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Elimina a <typeparamref name="Tipo"/> de la BD
        /// </summary>
        public abstract void Delete();
        #endregion

        #region Lectura con el Reader
        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>string</c></returns>
        public string ReadString(int posicion)
        {
            try
            {
                return Reader.GetString(posicion);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>int</c></returns>
        public int ReadInt(int posicion)
        {
            try
            {
                return Reader.GetInt32(posicion);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>float</c></returns>
        public float ReadFloat(int posicion)
        {
            try
            {
                return Reader.GetFloat(posicion);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>DateTime</c></returns>
        public DateTime ReadDate(int posicion)
        {
            try
            {
                return Reader.GetDateTime(posicion);
            }
            catch (Exception)
            {
                return new DateTime();
            }
        }

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>TimeSpan</c>, emula las horas</returns>
        public TimeSpan ReadTime(int posicion)
        {
            try
            {
                return Reader.GetTimeSpan(posicion);
            }
            catch (Exception)
            {
                return new TimeSpan();
            }
        }

        /// <summary>
        /// Usa el <c>Reader</c> para hacer una lectura
        /// </summary>
        /// <param name="posicion">Poscicion en la tabla, inicio en 0</param>
        /// <returns>Dato de tipo <c>bool</c></returns>
        public bool ReadBool(int posicion)
        {
            try
            {
                return Reader.GetBoolean(posicion);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Manejo de Conexion
        public bool OpenConnection()
        {
            try
            {
                Connection.Open();

                return true;
            }
            catch
            {
                CloseConnection();
            }

            return false;
        }

        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            finally { }
        }
        #endregion
    }
}
