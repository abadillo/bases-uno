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
    public partial class subasta1 : Form
    {
        
        public index parent;
        public Subasta subasta;
        public List<Local> listLoc = Read.Locales();

        public subasta1(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;

            textBoxID.Text = subasta.ID.ToString();
            //textBoxFecha.Text = subasta.textBoxFecha.Value.ToShortDateString();
            
                       

            for (int i = 0; i < listLoc.Count; i++)
            {
                Local tmp = listLoc[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLugar.Items.Add(item);

                if (tmp.ID == subasta.LocalID)
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

                //subasta.Nombre = Validacion.ValidarNull(textBoxNombre);
                //subasta.FechaFundacion = Validacion.ValidarDateTime(textBoxFechaFundacion, true);
                //subasta.Proposito = textBoxProposito.Text;
                //subasta.PaginaWeb = textBoxPaginaWeb.Text;
                //subasta.LugarID = Read.Lugar(LugarID).ID;
                //subasta.Telefono = Validacion.ValidarInt(textBoxTelefono, true);

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Subasta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    subasta.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new subasta1(parent, subasta));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Subasta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    subasta.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new subastal(parent));
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
            parent.InsertForm(new subasta1_1(parent, subasta));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new subastal(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subasta1(parent, subasta));
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
