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

        public club1(index parent, Club club)
        {
            this.parent = parent;
            this.club = club;

            InitializeComponent();
            
            textBoxID.Text = club.ID.ToString();
            textBoxName.Text = club.PaginaWeb;
            textBoxProposito.Text = club.Proposito;

            label1.Text = "Club: " + club.PaginaWeb;
            Update();

           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {
                club.PaginaWeb = Validacion.ValidarNull(textBoxName);
                club.Proposito = Validacion.ValidarNull(textBoxProposito);
                
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
            parent.InsertForm(new club2(parent, club));
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
            Acciones.EnableInput(textBoxName, iconButton17);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxProposito, iconButton1);
        }
        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }
        #endregion



    }
}
