using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.CustomProperties;

namespace Engine.DBConnection
{
    public abstract class CRUD<Tipo> : DBConnection
    {
        #region CRUDs
        /// <summary>
        /// Inserta <typeparamref name="Tipo"/> en la BD 
        /// </summary>
        public abstract void Insert();

        /// <summary>
        /// Actualiza a informacion de <typeparamref name="Tipo"/> en la BD
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Elimina a <typeparamref name="Tipo"/> de la BD
        /// </summary>
        public abstract void Delete();
        #endregion
    }
}
