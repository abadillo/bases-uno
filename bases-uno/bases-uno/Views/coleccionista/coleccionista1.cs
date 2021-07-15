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
    public partial class coleccionista1 : Form
    {
        
        public index parent;
        public Coleccionista coleccionista;

        public coleccionista1(index parent, Coleccionista coleccionista)
        {
            this.parent = parent;
            this.coleccionista = coleccionista;

            InitializeComponent();

            textBoxDocIdentidad.Text = coleccionista.ID.ToString();
            textBoxName.Text = coleccionista.Nombre;
            textBoxApellido.Text = coleccionista.Apellido;
            textBoxFechaNacimiento.Text = coleccionista.FechaNacimiento.Value.ToShortDateString();

            label1.Text = "Coleccionista: " + coleccionista.Nombre;
            Update();
           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {
                coleccionista.Nombre = Validacion.ValidarNull(textBoxName);
                coleccionista.Apellido = Validacion.ValidarNull(textBoxApellido);
                //coleccionista.ID = Validacion.ValidarInt(textBoxDocIdentidad, true);
                coleccionista.FechaNacimiento = Validacion.ValidarDateTime(textBoxFechaNacimiento, true);

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Coleccionista?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    coleccionista.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new coleccionista1(parent, coleccionista));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Coleccionista?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    coleccionista.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new coleccionistal(parent));
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
            //parent.InsertForm(new coleccionista2(parent, coleccionista));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new coleccionistal(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionista1(parent, coleccionista));
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
       
        private void iconButton16_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxFechaNacimiento, iconButton16);
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxApellido, iconButton1);
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            //Acciones.EnableInput(textBoxDocIdentidad, iconButton15);
        }
        #endregion
    }
}
