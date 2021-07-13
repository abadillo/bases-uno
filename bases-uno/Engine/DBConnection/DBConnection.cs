using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.DBConnection
{
    public class DBConnection
    {
        #region Atributos para establecer la conexion
        //Retrieve Connection String By Name
        static string sConn = "bases_uno.Properties.Settings.DBConnectionString";
        static ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[sConn];
        string connection = settings.ConnectionString;
        NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
        public NpgsqlCommand Script;
        public NpgsqlDataReader Reader;
        public NpgsqlConnection Connection = new NpgsqlConnection(settings.ConnectionString);
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
        public Nullable<DateTime> ReadDate(int posicion)
        {
            try
            {
                return Reader.GetDateTime(posicion);
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
    }
}
