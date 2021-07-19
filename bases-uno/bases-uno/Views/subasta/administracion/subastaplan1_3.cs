using Engine.Classes;
using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.DBConnection;
using System.Windows.Forms;
using bases_uno.Views.Components;


namespace bases_uno.Views
{
    public partial class subastaplan1_3 : Form
    {
        
        public index parent;
        public Subasta subasta;

        //public List<Membresia> listMem = new List<Membresia>;              // para los membresias ya de la subasta
        
        public List<Participante> listPar;
        //public List<Club> ListCluOrg;                    // para los clubes organizadores a la subasta
        public List<Club> ListCluInv;                    // para los clubes invitados
                                                         //public List<Membresia> ListPar = Read.Membresias();             // para el combo de membresia
        public bool flagCancelado = false;      // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)
        public bool flagCerrada = false;


        public subastaplan1_3(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;



            #region set flags

            if (subasta.Cancelado)
                flagCancelado = true;

            if (subasta.Tipo == "Presencial")
                flagPresencial = true;

            if (subasta.Caridad)
                flagBenefica = true;

            if (subasta.Cerrado)
                flagCerrada = true;
            #endregion

            #region use flags

            if (flagBenefica == false || flagPresencial == false)
            {
                //DisableFunciones("Esta subasta no es de tipo benefica, por lo tanto no deberia ver ninguna organizacion asociada \nSi observa alguna arriba, algo salio mal");
            }

            if (flagCancelado)
            {
                DisableFunciones("Esta subasta fue cancelada, no puede agregar partipantes \nSi observa alguna arriba, algo salio mal");
            }
            if (flagCerrada)
            {
                DisableFunciones("Esta subasta fue cerrada, no puede agregar ni modificar ningun atributo incluyendo organizaciones, clubes, objetos o partipantes");
            }

            #endregion



            ListCluInv = subasta.ClubesInvitados();
            listPar = subasta.Participantes();



            foreach (Participante participante in listPar)
            {
                Membresia membresia = participante.Membresia();

                miniitemmembresia item = new miniitemmembresia(participante, parent, true);
                item.Dock = DockStyle.Top;

                dipanel2.Controls.Add(item);
            }


            // llena el combo de clubes
            foreach (Club club in ListCluInv)
            {

                string item = club.ID + " " + club.Nombre;
                comboBoxClub.Items.Add(item);
            }
            


            
            


            Update();

           
        }

        #region Funciones

        private void DisableFunciones(string mensaje)
        {
            label11.Text = mensaje;
            iconButton5.Visible = false;
            btnanadir.Enabled = false;
            panelAlerta.Visible = true;
        }


        private void Registrar()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxClub).Split(' ');
                int clubID = int.Parse(tokens[0]);

                Club club = Read.Club(clubID);

                tokens = Validacion.ValidarCombo(comboBoxColeccionista).Split(' ');
                int ColeccionistaID = int.Parse(tokens[0]);

                Coleccionista coleccionista = Read.Coleccionista(ColeccionistaID);


                Membresia membresia = Read.Membresia(coleccionista, club);

                if (flagBenefica)
                {
                    subasta.AgregarParticipante(membresia, true);
                }
                else
                {
                    subasta.AgregarParticipante(membresia, false);
                }
               

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new subastaplan1_3(parent,subasta));

            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error de tipo de dato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error con base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LlenarColeccionistas()
        {

            string[] tokens = Validacion.ValidarCombo(comboBoxClub).Split(' ');
            int clubID = int.Parse(tokens[0]);

            Club club = Read.Club(clubID);

            List<Membresia> membresias = Read.Membresias(club);


            foreach (Membresia membresia in membresias)
            {
                Coleccionista coleccionista = Read.Coleccionista(membresia.ColeccionistaID);

                bool activa = membresia.FechaRetiro == null;
                bool permisoEdad = coleccionista.RepresentanteID != 0 || Validacion.Edad(coleccionista.FechaNacimiento.Value) >= 18;

                if (activa && permisoEdad) 
                { 
                    string item = coleccionista.ID + " " + coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
                    comboBoxColeccionista.Items.Add(item);
                }
            }

           

            //Update();
        }


      
        #endregion

        #region click botones normales

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1_4(parent, subasta));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new subastaplan1_2(parent, subasta));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
           
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1_3(parent, subasta));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion


        private void comboBoxClub_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarColeccionistas();
        }
    }
}
