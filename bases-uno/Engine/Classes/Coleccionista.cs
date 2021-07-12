using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Coleccionista : Engine.DBConnection.CRUD<Coleccionista>
    {
        #region Atributes
        public int ID { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; } //nullable
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; } //nullable
        public int Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int LugarNacimiento { get; set; }
        public int LugarResidencia { get; set; }
        public int ColeccionistaRepresentanteID { get; set; }
        public int RepresentanteID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Coleccionista(int id, string primerNombre, string primerApellido, int telefono, DateTime fechaNacimiento, int lugarNacimiento,
            int lugarResidencia, string segundoNombre = null, string segundoApellido = null, int representanteID = 0)
        {
            ID = id;
            PrimerNombre = primerNombre;
            SegundoApellido = segundoApellido;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento;
            Coleccionista representanteColeccionista = Read.Coleccionista(representanteID);
            if (representanteColeccionista.ID == 0)
            {
                ColeccionistaRepresentanteID = 0;
                RepresentanteID = representanteID;
            }
            else
            {
                ColeccionistaRepresentanteID = representanteID;
                RepresentanteID = 0;
            }
        }

        /// <summary>
        /// Crea una instancia de un registro especifico de la BD
        /// </summary>
        public Coleccionista(int id)
        {
            Coleccionista collector = Read.Coleccionista(id);
            if (!(collector == null))
            {
                ID = collector.ID;
                PrimerNombre = collector.PrimerNombre;
                SegundoNombre = collector.SegundoNombre;
                PrimerApellido = collector.PrimerApellido;
                SegundoApellido = collector.SegundoApellido;
                Telefono = collector.Telefono;
                FechaNacimiento = collector.FechaNacimiento;
                LugarNacimiento = collector.LugarNacimiento;
                LugarResidencia = collector.LugarResidencia;
                ColeccionistaRepresentanteID = collector.ColeccionistaRepresentanteID;
                RepresentanteID = collector.RepresentanteID;
            }
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Coleccionista(int id, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int telefono,
            DateTime fechaNacimiento, int lugarNacimiento, int representanteID, int representanteColeccionista, int lugarResidencia)
        {
            ID = id;
            PrimerNombre = primerNombre;
            SegundoApellido = segundoApellido;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento;
            RepresentanteID = representanteID;
            ColeccionistaRepresentanteID = representanteColeccionista;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM coleccionista WHERE documento_identidad = @id";
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
                OpenConnection();

                string Query = "INSERT INTO coleccionista (id, primer_nombre, ";
                if (!(SegundoNombre == null))
                {
                    Query += "segundo_nombre, ";
                }
                Query += "primer_apellido, ";
                if (!(SegundoNombre == null))
                {
                    Query += "segundo_apellido";
                }
                Query += "telefono, fecha_nacimiento, lugar_id2";
                if (!(ColeccionistaRepresentanteID == 0))
                {
                    Query += "coleccionista_documento_identidad, ";
                }
                else
                {
                    if (!(RepresentanteID == 0))
                    {
                        Query += "representante_documento_identidad, ";
                    }
                }
                Query += "lugar_id) VALUES (@id, @primernombre, ";
                if (!(SegundoNombre == null))
                {
                    Query += "@segundonombre";
                }
                Query += "@telefono, @fechanacimiento, @lugarnacimiento, ";
                if (!(ColeccionistaRepresentanteID == 0))
                {
                    Query += "@coleccionistarepresentante, ";
                }
                else
                {
                    if (!(RepresentanteID == 0))
                    {
                        Query += "@representante, ";
                    }
                }
                Query += "@residencia)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("primernombre", PrimerNombre);
                if (!(SegundoNombre == null))
                {
                    Script.Parameters.AddWithValue("segundonombre", SegundoNombre);
                }
                Script.Parameters.AddWithValue("telefono", Telefono);
                Script.Parameters.AddWithValue("fechanacimiento", FechaNacimiento);
                Script.Parameters.AddWithValue("lugarnacimiento", LugarNacimiento);
                if (!(ColeccionistaRepresentanteID == 0))
                {
                    Script.Parameters.AddWithValue("coleccionistarepresentante", ColeccionistaRepresentanteID);
                }
                else
                {
                    if (!(RepresentanteID == 0))
                    {
                        Script.Parameters.AddWithValue("representante", RepresentanteID);
                    }
                }

                Script.Prepare();

                Script.ExecuteNonQuery();
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

                string Query = "UPDATE coleccionista SET primer_nombre = @primernombre, ";
                if (!(SegundoNombre == null))
                {
                    Query += "segundo_nombre = @segundonombre, ";
                }
                Query += "primer_apellido = @primerapellido, ";
                if (!(SegundoApellido == null))
                {
                    Query += "segundo_apellido = @segundoapellido, ";
                }
                Query += "telefono = @telefono, fecha_nacimiento = @fechanacimiento, lugar_id2 = @lugarnacimiento, ";
                if (!(ColeccionistaRepresentanteID == 0))
                {
                    Query += "coleccionista_documento_identidad = @coleccionistaid, ";
                }
                else
                {
                    if (!(RepresentanteID == 0))
                    {
                        Query += "representante_documento_identidad = @representanteid, ";
                    }
                }
                Query += "lugar_id = @residencia WHERE documento_identidad = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("primernombre", PrimerNombre);

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