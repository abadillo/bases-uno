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
        public Nullable<DateTime> FechaNacimiento { get; set; }
        public int LugarNacimiento { get; set; }
        public int LugarResidencia { get; set; }
        public int ColeccionistaRepresentanteID { get; set; }
        public int RepresentanteID { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor de la Clase caso tiene o no representante que es Coleccionista
        /// </summary>
        public Coleccionista(int id, string primerNombre, string primerApellido, int telefono, DateTime fechaNacimiento, Lugar lugarNacimiento,
            Lugar lugarResidencia, string segundoNombre = null, string segundoApellido = null, Coleccionista representante = null)

        {
            ID = id;
            PrimerNombre = primerNombre;
            SegundoApellido = segundoApellido;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento.ID;
            LugarResidencia = lugarResidencia.ID;
            if (representante == null)
            {
                RepresentanteID = 0;
            }
            else
            {
                ColeccionistaRepresentanteID = representante.ID;
            }
        }

        /// <summary>
        /// Constructor de la Clase caso tiene representante que NO es Coleccionista
        /// </summary>
        public Coleccionista(int id, string primerNombre, string primerApellido, int telefono, DateTime fechaNacimiento, Lugar lugarNacimiento,
            Lugar lugarResidencia, Representante representante, string segundoNombre = null, string segundoApellido = null)

        {
            ID = id;
            PrimerNombre = primerNombre;
            SegundoApellido = segundoApellido;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento.ID;
            LugarResidencia = lugarResidencia.ID;
            ColeccionistaRepresentanteID = 0;
            RepresentanteID = representante.ID;
        }

        /// <summary>
        /// Constructor de la clase READ, NO USAR
        /// </summary>
        public Coleccionista(int id, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido, int telefono,
            Nullable<DateTime> fechaNacimiento, int lugarNacimiento, int representanteID, int representanteColeccionista, int lugarResidencia)
        {
            ID = id;
            PrimerNombre = primerNombre;
            SegundoApellido = segundoApellido;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            LugarNacimiento = lugarNacimiento;
            LugarResidencia = lugarResidencia;
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

                string Query = "INSERT INTO coleccionista (documento_identidad, primer_nombre, " +
                    "primer_apellido, telefono, fecha_nacimiento, LUGAR_id_nacionalidad, LUGAR_id_direccion";
                if (!(SegundoNombre == null))
                {
                    Query += ", segundo_nombre";
                }
                if (!(SegundoApellido == null))
                {
                    Query += ", segundo_apellido";
                }
                if (!(ColeccionistaRepresentanteID == 0))
                {
                    Query += ", coleccionista_documento_identidad";
                }
                else
                {
                    if (!(RepresentanteID == 0))
                    {
                        Query += ", representante_documento_identidad";
                    }
                }
                Query += ") VALUES (@id, @primernombre, @primerapellido, " +
                    "@telefono, @fechanacimiento, @lugarnacimiento,  @direccion";
                if (!(SegundoNombre == null))
                {
                    Query += ", @segundonombre";
                }
                if (!(SegundoApellido == null))
                {
                    Query += ", @segundoapellido";
                }
                if (!(ColeccionistaRepresentanteID == 0))
                {
                    Query += ", @coleccionistarepresentante";
                }
                else
                {
                    if (!(RepresentanteID == 0))
                    {
                        Query += ", @representante";
                    }
                }
                Query += ")";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("primernombre", PrimerNombre);
                Script.Parameters.AddWithValue("primerapellido", PrimerApellido);
                Script.Parameters.AddWithValue("telefono", Telefono);
                Script.Parameters.AddWithValue("fechanacimiento", FechaNacimiento);
                Script.Parameters.AddWithValue("lugarnacimiento", LugarNacimiento);
                Script.Parameters.AddWithValue("direccion", LugarResidencia);
                if (!(SegundoNombre == null))
                {
                    Script.Parameters.AddWithValue("segundonombre", SegundoNombre);
                }
                if (!(SegundoApellido == null))
                {
                    Script.Parameters.AddWithValue("segundoapellido", SegundoApellido);
                }
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

                string Query = "UPDATE coleccionista SET primer_nombre = @primernombre, " +
                    "primer_apellido = @primerapellido, telefono = @telefono, fecha_nacimiento = @fechanacimiento, " +
                    "LUGAR_id_nacionalidad = @lugarnacimiento, LUGAR_id_direccion = @direccion";
                if (!(SegundoNombre == null))
                {
                    Query += ", segundo_nombre = @segundonombre";
                }
                if (!(SegundoApellido == null))
                {
                    Query += ", segundo_apellido = @segundoapellido";
                }
                if (!(ColeccionistaRepresentanteID == 0))
                {
                    Query += ", coleccionista_documento_identidad = @coleccionistaid";
                }
                else
                {
                    if (!(RepresentanteID == 0))
                    {
                        Query += ", representante_documento_identidad = @representanteid";
                    }
                }
                Query += " WHERE documento_identidad = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("primernombre", PrimerNombre);
                Script.Parameters.AddWithValue("primerapellido", PrimerApellido);
                Script.Parameters.AddWithValue("telefono", Telefono);
                Script.Parameters.AddWithValue("fechanacimiento", FechaNacimiento);
                Script.Parameters.AddWithValue("lugarnacimiento", LugarNacimiento);
                Script.Parameters.AddWithValue("direccion", LugarResidencia);
                if (!(SegundoNombre == null))
                {
                    Script.Parameters.AddWithValue("segundonombre", SegundoNombre);
                }
                if (!(SegundoApellido == null))
                {
                    Script.Parameters.AddWithValue("segundoapellido", SegundoApellido);
                }
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
                CloseConnection();
            }
        }
        #endregion

        #region Other Methods
        #endregion
    }
}