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
    public partial class subasta1_2 : Form
    {
        
        public index parent;
        public Subasta subasta;
            
        public List<Club> altListCluOrg;                    // para los clubes organizadores a la subasta
        public List<Club> altListCluInv;                    // para los clubes invitados
        public List<Club> listClu = Read.Clubes();      // para el combo de club
        

        public bool flagCancelado = false;              // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)



        public subasta1_2(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;


            // para los clubes invitados a la subasta

            altListCluOrg = subasta.Organizadores();

            // para los clubes inivitados a la subasta

            altListCluInv = subasta.ClubesInvitados();


            for (int i = 0; i < altListCluOrg.Count; i++)
            {
                //Console.WriteLine(altListClu[i].ID);
                miniitemclub item = new miniitemclub(altListCluOrg[i], subasta, parent);
                item.Dock = DockStyle.Top;

                dipanel2.Controls.Add(item);
            }


            // para el combo de club

            for (int i = 0; i < listClu.Count; i++)
            {
                Club tmp = listClu[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxClub.Items.Add(item);
            }


            #region set flags

            if (subasta.Cancelado)
                flagCancelado = true;

            if (subasta.Tipo == "Presencial")
                flagPresencial = true;

            if (subasta.Caridad)
                flagBenefica = true;

            #endregion


            #region use flags

            if (flagBenefica == false || flagPresencial == false)
            {
                DisableFunciones("Esta subasta no es de tipo benefica, por lo tanto no deberia ver ningun club organizador \nSi observa alguna arriba, algo salio mal");
            }

            if (flagCancelado)
            {
                DisableFunciones("Esta subasta fue cancelada, no puede agregar clubes \nSi observa alguna arriba, algo salio mal");
            }


            #endregion


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

                for (int i = 0; i < altListCluOrg.Count; i++)
                { 
                    if (club.ID == altListCluOrg[i].ID)          
                        throw new Exception("Ya este club es un organizador");
                }

                for (int i = 0; i < altListCluInv.Count; i++)
                {
                    if (club.ID == altListCluInv[i].ID)
                        throw new Exception("Ya este club es un invitado");

                }

                subasta.AgregarOrganizador(club);

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new subasta1_2(parent,subasta));

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

       
       
        #endregion

        #region click botones normales

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subasta1_3(parent, subasta));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new subasta1_1(parent, subasta));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
            
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subasta1_2(parent, subasta));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion

    }
}
