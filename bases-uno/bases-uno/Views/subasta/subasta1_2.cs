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

        
        public List<Club> listClu = Read.Clubes();

        public subasta1_2(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

           

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;

            
            for (int i = 0; i < listClu.Count; i++)
            {
                /// Console.WriteLine(list[i]);
                ///

                if (listClu[i].ID == subasta.ID)
                {

                    miniitemclub item = new miniitemclub(listClu[i], subasta, parent);
                    item.Dock = DockStyle.Top;

                    dipanel2.Controls.Add(item);
                } 

                
            }

            //textBoxID.Text = subasta.ID.ToString();
            //textBoxNombre.Text = subasta.Nombre;
            //textBoxPaginaWeb.Text = subasta.PaginaWeb;
            //textBoxProposito.Text = subasta.Proposito;
            //textBoxFechaFundacion.Text = subasta.FechaFundacion.Value.ToShortDateString();
            //textBoxTelefono.Text = subasta.Telefono.ToString();


            //for (int i = 0; i < list.Count; i++)
            //{
            //    Lugar tmp = list[i];
            //    string item = tmp.ID + " " + tmp.Nombre;

            //    comboBoxLugar.Items.Add(item);

            //    if (tmp.ID == subasta.LugarID)
            //        comboBoxLugar.SelectedItem = item;
            //}

            Update();

           
        }

        #region Funciones

        private void Registrar()
        {
            try
            {
                
                //Club club = new Club(
                //    Validacion.ValidarNull(textBoxPlataforma),
                //    subasta,
                //    textBoxUsuarioEmail.Text,
                //    Validacion.ValidarInt(textBoxTelefono,false) 
                //);


                //club.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new subasta1_2(parent, subasta));

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
            parent.InsertForm(new subasta2(parent, subasta));
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
