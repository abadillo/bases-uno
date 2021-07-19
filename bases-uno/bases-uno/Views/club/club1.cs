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
using System.Windows.Forms;


namespace bases_uno.Views
{
    public partial class club1 : Form
    {
        
        public index parent;
        public Club club;
        public List<Lugar> list = Read.Lugares();

        public club1(index parent, Club club)
        {
            this.parent = parent;
            this.club = club;

            InitializeComponent();

            label1.Text = "Club: " + club.Nombre;

            textBoxID.Text = club.ID.ToString();
            textBoxNombre.Text = club.Nombre;
            textBoxPaginaWeb.Text = club.PaginaWeb;
            textBoxProposito.Text = club.Proposito;
            textBoxFechaFundacion.Text = club.FechaFundacion.Value.ToShortDateString();
            textBoxTelefono.Text = club.Telefono.ToString();
                       

            for (int i = 0; i < list.Count; i++)
            {
                Lugar tmp = list[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLugar.Items.Add(item);

                if (tmp.ID == club.LugarID)
                    comboBoxLugar.SelectedItem = item;
            }

            Update();

           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxLugar).Split(' ');
                int LugarID = int.Parse(tokens[0]);

                club.Nombre = Validacion.ValidarNull(textBoxNombre);
                club.FechaFundacion = Validacion.ValidarDateTime(textBoxFechaFundacion, true);
                club.Proposito = textBoxProposito.Text;
                club.PaginaWeb = textBoxPaginaWeb.Text;
                club.LugarID = Read.Lugar(LugarID).ID;
                club.Telefono = Validacion.ValidarLong(textBoxTelefono, true);

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Club?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    club.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new club1(parent, club));
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

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

        private void Eliminar()
        {

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Club?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    club.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new clubl(parent));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }
        #endregion

        #region click botones normales

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new club1_1(parent, club));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new clubl(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new club1(parent, club));
        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
        #endregion

        #region click botones FontAwesome

        private void iconButton17_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxNombre, iconButton17);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxProposito, iconButton1);
        }
        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }

        private void iconButton16_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxFechaFundacion, iconButton16);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxPaginaWeb, iconButton2);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxLugar, iconButton3);
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxTelefono, iconButton15);
        }

        #endregion

    }
}
