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
    public partial class club1_2 : Form
    {
        
        public index parent;
        public Club club;

        
        public List<Contacto> listCon = Read.Contactos();

        public club1_2(index parent, Club club)
        {
            this.parent = parent;
            this.club = club;

            InitializeComponent();

            label1.Text = "Club: " + club.Nombre;

            
            for (int i = 0; i < listCon.Count; i++)
            {
                /// Console.WriteLine(list[i]);
                ///

                if (listCon[i].ClubID == club.ID)
                {

                    miniitemcontacto item = new miniitemcontacto(listCon[i], club, parent);
                    item.Dock = DockStyle.Top;

                    dipanel2.Controls.Add(item);
                } 

                
            }

            //textBoxID.Text = club.ID.ToString();
            //textBoxNombre.Text = club.Nombre;
            //textBoxPaginaWeb.Text = club.PaginaWeb;
            //textBoxProposito.Text = club.Proposito;
            //textBoxFechaFundacion.Text = club.FechaFundacion.Value.ToShortDateString();
            //textBoxTelefono.Text = club.Telefono.ToString();


            //for (int i = 0; i < list.Count; i++)
            //{
            //    Lugar tmp = list[i];
            //    string item = tmp.ID + " " + tmp.Nombre;

            //    comboBoxLugar.Items.Add(item);

            //    if (tmp.ID == club.LugarID)
            //        comboBoxLugar.SelectedItem = item;
            //}

            Update();

           
        }

        #region Funciones

        private void Registrar()
        {
            try
            {
                
                Contacto contacto = new Contacto(
                    Validacion.ValidarNull(textBoxPlataforma),
                    club,
                    textBoxUsuarioEmail.Text,
                    Validacion.ValidarLong(textBoxTelefono,false) 
                );


                contacto.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new club1_2(parent, club));

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
            parent.InsertForm(new club1_3(parent, club));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new club1_1(parent, club));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
        }


        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new club1_2(parent, club));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        } 
        #endregion
    }
}
