using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Classes
{
    public class Subasta : DBConnection.CRUD<Subasta>
    {
        #region Atributes
        public int ID { get; set; } //pk
        public Nullable<DateTime> Fecha { get; set; }
        public Nullable<TimeSpan> HoraInicio { get; set; }
        public Nullable<TimeSpan> HoraCierre { get; set; }
        public string Tipo { get; set; }
        public bool Caridad { get; set; }
        public bool Cancelado { get; set; }
        public int LocalID { get; set; } //nullable
        public bool Cerrado { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Usar previo a insercion de un registro en la BD, si la clase tiene una clave serial
        /// </summary>Usar por el Check:
        /// <param name="tipo">
        /// public static class TipoSubasta 
        /// <para>{</para>
        /// <para>public const string Presencial = "Presencial";</para>
        /// <para>public const string Virtual = "Virtual";</para>
        /// <para>}</para>
        /// </param>
        public Subasta(DateTime fecha, TimeSpan horaInicio, TimeSpan horaCierre, string tipo, 
            bool caridad, bool cancelado, Local local = null, bool cerrado = false)
        {

           

            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraCierre = horaCierre;
            Tipo = tipo;
            Caridad = caridad;
            Cancelado = cancelado;
            if (local == null)
            {
                LocalID = 0;
            }
            else
            {
                LocalID = local.ID;
            }
            Cerrado = cerrado;

            //try
            //{
            //    Console.WriteLine(local.Nombre);
            //}
            //catch (Exception)
            //{

            //    //throw;
            //}

        }

        /// <summary>
        /// Constructor General de la Clase, usualmente para la clase READ
        /// </summary>
        public Subasta(int id, Nullable<DateTime> fecha, Nullable<TimeSpan> horaInicio, Nullable<TimeSpan> horaCierre, 
            string tipo, bool caridad, bool cancelado, int localID, bool cerrado)
        {
            ID = id;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraCierre = horaCierre;
            Tipo = tipo;
            Caridad = caridad;
            Cancelado = cancelado;
            LocalID = localID;
            Cerrado = cerrado;
        }
        #endregion

        #region CRUDs
        public override void Delete()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGsubasta WHERE id = @id";
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

                string Query = "INSERT INTO JAGsubasta (fecha, hora_inicio, hora_cierre, tipo, caridad, " +
                    "cancelado, local_id, cerrado) " +
                    "VALUES (@fecha, @horainicio, @horacierre, @tipo, @caridad, @cancelado, @localid, @cerrado) " +
                    "RETURNING id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("fecha", Fecha);
                Script.Parameters.AddWithValue("horainicio", HoraInicio);
                Script.Parameters.AddWithValue("horacierre", HoraCierre);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("caridad", Caridad);
                Script.Parameters.AddWithValue("cancelado", Cancelado);
                if (LocalID == 0)
                {
                    Script.Parameters.AddWithValue("localid", DBNull.Value);
                }
                else
                {
                    Script.Parameters.AddWithValue("localid", LocalID);
                }
                Script.Parameters.AddWithValue("cerrado", Cerrado);

                Console.WriteLine(LocalID + " " + Query);

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

        public override void Update()
        {
            try
            {
                OpenConnection();

                string Query = "UPDATE JAGsubasta SET fecha = @fecha, hora_inicio = @horainicio, " +
                    "hora_cierre = @horacierre, tipo = @tipo, caridad = @caridad, cancelado = @cancelado, " +
                    "local_id = @localid, cerrado = @cerrado " +
                    "WHERE id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("fecha", Fecha);
                Script.Parameters.AddWithValue("horainicio", HoraInicio);
                Script.Parameters.AddWithValue("horacierre", HoraCierre);
                Script.Parameters.AddWithValue("tipo", Tipo);
                Script.Parameters.AddWithValue("caridad", Caridad);
                Script.Parameters.AddWithValue("cancelado", Cancelado);
                if (LocalID == 0)
                {
                    Script.Parameters.AddWithValue("localid", DBNull.Value);
                }
                else
                {
                    Script.Parameters.AddWithValue("localid", LocalID);
                }
                Script.Parameters.AddWithValue("cerrado", Cerrado);

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

        #region Organizacion Caridad
        public void AgregarOrganizacionCaridad(OrganizacionCaridad organizacionCaridad, int porcentaje)
        {
            if (Caridad)
            {
                try
                {
                    OpenConnection();

                    string Query = "INSERT INTO JAGorg_sub (subasta_id, organizacion_caridad_id, porcentaje) " +
                        "VALUES (@subasta, @organizacion, @porcentaje)";
                    Script = new NpgsqlCommand(Query, Connection);

                    Script.Parameters.AddWithValue("subasta", ID);
                    Script.Parameters.AddWithValue("organizacion", organizacionCaridad.ID);
                    Script.Parameters.AddWithValue("porcentaje", porcentaje);

                    Script.Prepare();

                    Script.ExecuteNonQuery();
                }
                finally
                {
                    Connection.Close();
                }
            }
        }

        public void EliminarOrganizacionCaridad(OrganizacionCaridad organizacionCaridad)
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGorg_sub " +
                    "WHERE subasta_id = @subasta AND organizacion_caridad_id = @organizacion";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("subasta", ID);
                Script.Parameters.AddWithValue("organizacion", organizacionCaridad.ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public void EliminarOrganizacionesCaridad()
        {
            List<OrganizacionCaridad> organizacionesCaridad = OrganizacionesCaridad();
            foreach (OrganizacionCaridad organizacion in organizacionesCaridad)
            {
                EliminarOrganizacionCaridad(organizacion);
            }
        }

        public void ActualizarMontoCaridad(OrganizacionCaridad organizacionCaridad)
        {
            float monto = 0;
            List<Listado> listados = Listados();
            foreach (Listado listado in listados)
            {
                monto += listado.PrecioVenta;
            }
            monto = monto * Porcentaje(organizacionCaridad) / 100;

            try
            {
                OpenConnection();

                string Query = "UPDATE JAGorg_sub SET monto_recibido = @monto " +
                    "WHERE subasta_id = @subasta AND organizacion_caridad_id = @organizacion";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("subasta", ID);
                Script.Parameters.AddWithValue("organizacion", organizacionCaridad.ID);
                Script.Parameters.AddWithValue("monto", monto);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void ActualizarMontoCaridad()
        {
            List<OrganizacionCaridad> organizaciones = OrganizacionesCaridad();
            foreach (OrganizacionCaridad organizacion in organizaciones)
            {
                ActualizarMontoCaridad(organizacion);
            }
        }

        public float MontoCaridad(OrganizacionCaridad organizacionCaridad)
        {
            float monto = 0;

            try
            {
                OpenConnection();

                string Query = "SELECT monto_recibido FROM JAGorg_sub " +
                    "WHERE subasta_id = @subasta AND organizacion_caridad_id = @organizacion";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("subasta", ID);
                Script.Parameters.AddWithValue("organizacion", organizacionCaridad.ID);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    monto = ReadFloat(0);
                }
            }
            catch
            {
                monto = 0;
            }
            finally
            {
                Connection.Close();
            }

            return monto;
        }

        public float MontoCaridad()
        {
            float monto = 0;

            foreach (OrganizacionCaridad organizacion in OrganizacionesCaridad())
            {
                monto += MontoCaridad(organizacion);
            }

            return monto;
        }

        public List<OrganizacionCaridad> OrganizacionesCaridad()
        {
            List<int> ids = new List<int>();
            try
            {
                OpenConnection();

                string Query = "SELECT organizacion_caridad_id FROM JAGorg_sub where subasta_id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);

                Console.WriteLine(Query);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    ids.Add(ReadInt(0));
                }
            }
            catch
            {
                ids = new List<int>();
            }
            finally
            {
                CloseConnection();
            }

            List<OrganizacionCaridad> organizaciones = new List<OrganizacionCaridad>();
            foreach (int id in ids)
            {
                organizaciones.Add(Read.OrganizacionCaridad(id));
            }
            return organizaciones;
        }

        public int Porcentaje(OrganizacionCaridad organizacionCaridad)
        {
            int porcentaje = 0;

            try
            {
                OpenConnection();

                string Query = "SELECT porcentaje FROM JAGorg_sub " +
                    "WHERE subasta_id = @id AND organizacion_caridad_id = @organizacion";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("organizacion", organizacionCaridad.ID);

                Reader = Script.ExecuteReader();

                if (Reader.Read())
                {
                    porcentaje = ReadInt(0);
                }
            }
            catch
            {
                porcentaje = 0;
            }
            finally
            {
                CloseConnection();
            }

            return porcentaje;
        }
        #endregion

        #region Organizador e Invitados
        public void AgregarOrganizador(Club club)
        {
            try
            {
                Connection.Open();

                string Query = "INSERT INTO JAGorg_inv (subasta_id, club_id_org) " +
                    "VALUES (@subasta, @club)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("subasta", ID);
                Script.Parameters.AddWithValue("club", club.ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void AgregarClubInvitado(Club club)
        {
            try
            {
                Connection.Open();

                string Query = "INSERT INTO JAGorg_inv (subasta_id, club_id_inv) " +
                    "VALUES (@subasta, @club)";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("subasta", ID);
                Script.Parameters.AddWithValue("club", club.ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                Connection.Close();
            }
        }

        public void AgregarParticipante(Membresia membresia, bool autorizado)
        {
            Participante participante = new Participante(
                NextParticipanteID(),
                this,
                membresia,
                autorizado);
            participante.Insert();
        }

        public List<Participante> Participantes()
        {
            List<Participante> participantes = Read.Participantes();
            List<Participante> aux = new List<Participante>();
            foreach (Participante participante in participantes)
            {
                if (participante.SubastaID == ID)
                {
                    aux.Add(participante);
                }
            }
            return aux;
        }

        private int NextParticipanteID()
        {
            int cont = 1;
            while (Read.Participante(cont, this) != null)
            {
                cont += 1;
            }
            return cont;
        }

        public List<Club> Organizadores()
        {
            List<int> ids = new List<int>();
            try
            {
                OpenConnection();

                string Query = "SELECT club_id_org FROM JAGorg_inv where subasta_id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    ids.Add(ReadInt(0));
                }
            }
            catch
            {
                ids = new List<int>();
            }
            finally
            {
                CloseConnection();
            }

            if (ids.Count() == 0)
            {
                return new List<Club>();
            }
            else
            {
                List<Club> clubes = new List<Club>();
                foreach (int id in ids)
                {
                    if (!(id == 0))
                    {
                        clubes.Add(Read.Club(id));
                    }
                }
                return clubes;
            }
        } 

        public List<Club> ClubesInvitados()
        {
            List<int> ids = new List<int>();
            try
            {
                OpenConnection();

                string Query = "SELECT club_id_inv FROM JAGorg_inv where subasta_id = @id";
                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);

                Reader = Script.ExecuteReader();

                while (Reader.Read())
                {
                    ids.Add(ReadInt(0));
                }
            }
            catch
            {
                ids = new List<int>();
            }
            finally
            {
                CloseConnection();
            }

            if (ids.Count() == 0)
            {
                return new List<Club>();
            }
            else
            {
                List<Club> clubes = new List<Club>();
                foreach (int id in ids)
                {
                    if (!(id == 0))
                    {
                        clubes.Add(Read.Club(id));
                    }
                }
                return clubes;
            }
        }

        public void EliminarClubes()
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGorg_inv WHERE subasta_id = @id";
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

        public void EliminarOrganizador(Club club)
        {
            try
            {
                OpenConnection();

                string Query = "DELETE FROM JAGorg_inv " +
                    "WHERE subasta_id = @id AND club_id_org = @club ;" +
                    "DELETE FROM JAGlistado WHERE subasta_id = @id; " +

                     "DELETE FROM JAGparticipante WHERE subasta_id = @id ;";
               Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("club", club.ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public void EliminarOrganizadores()
        {
            List<Club> organizadores = Organizadores();
            foreach (Club organizador in organizadores)
            {
                EliminarOrganizador(organizador);
            }
        }

        public void EliminarInvitado(Club club)
        {
            try
            {
                OpenConnection();

                string Query =
                    "DELETE FROM JAGlistado WHERE subasta_id = @id; " +

                    "DELETE FROM JAGparticipante WHERE subasta_id = @id ;" +

                    "DELETE FROM JAGorg_inv WHERE subasta_id = @id AND club_id_inv = @club; ";


                Script = new NpgsqlCommand(Query, Connection);

                Script.Parameters.AddWithValue("id", ID);
                Script.Parameters.AddWithValue("club", club.ID);

                Script.Prepare();

                Script.ExecuteNonQuery();
            }
            finally
            {
                CloseConnection();
            }
        }

        public void EliminarInvitados()
        {
            List<Club> invitados = ClubesInvitados();
            foreach (Club invitado in invitados)
            {
                EliminarInvitado(invitado);
            }
        }
        #endregion

        public List<Listado> Listados()
        {
            List<Listado> listados = Read.Listados(ID);
            
            return listados;
        }

        public int SiguienteNroListado()
        {
            int cont = 1;
            while (Read.Listado(cont, this) != null)
            {
                cont += 1;
            }
            return cont;
        }

        /*
        public void AgregarParticipantes()
        {
            List<Membresia> invitados = new List<Membresia>();
            List<Club> clubesInvitados = ClubesInvitados();
            foreach (Club club in clubesInvitados)
            {
                invitados.AddRange(Read.Membresias(club));
            }

            int id = 1;
            foreach (Membresia invitado in invitados)
            {
                Participante participante = new Participante(id, this, invitado, true);
                participante.Insert();
                id += 1;
            }
        }
        */

        public void Cancelar()
        {
            Cancelado = true;
            Cerrado = true;
            foreach (OrganizacionCaridad organizacion in OrganizacionesCaridad())
            {
                EliminarOrganizacionCaridad(organizacion);
            }
            List<Participante> participantes = Read.Participantes();
            foreach (Participante participante in participantes)
            {
                if (participante.SubastaID == ID)
                {
                    participante.Delete();
                }
            }
            List<Listado> listados = Read.Listados();
            foreach (Listado listado in listados)
            {
                if (listado.SubastaID == ID)
                {
                    listado.Delete();
                }
            }
            EliminarClubes();
            Update();
        }

        public void Cerrar()
        {
            Cerrado = true;
            List<Listado> listados = Listados();
            foreach (Listado listado in listados)
            {
                listado.Cerrar();
            }
            ActualizarMontoCaridad();
            Update();
        }
        #endregion
    }
}
