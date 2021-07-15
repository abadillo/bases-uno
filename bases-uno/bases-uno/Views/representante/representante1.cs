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
    public partial class representante1 : Form
    {
        
        public index parent;
        public Representante representante;

        public representante1(index parent, Representante representante)
        {
            this.parent = parent;
            this.representante = representante;

            InitializeComponent();

            textBoxDocIdentidad.Text = representante.ID.ToString();
            textBoxName.Text = representante.Nombre;
            textBoxApellido.Text = representante.Apellido;
            textBoxFechaNacimiento.Text = representante.FechaNacimiento.Value.ToShortDateString();

            label1.Text = "Representante: " + representante.Nombre;
            Update();
           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {
                representante.Nombre = Validacion.ValidarNull(textBoxName);
                representante.Apellido = Validacion.ValidarNull(textBoxApellido);
                //representante.ID = Validacion.ValidarInt(textBoxDocIdentidad, true);
                representante.FechaNacimiento = Validacion.ValidarDateTime(textBoxFechaNacimiento, true);

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Representante?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    representante.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new representante1(parent, representante));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Representante?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    representante.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new representantel(parent));
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
            //parent.InsertForm(new representante2(parent, representante));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new representantel(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new representante1(parent, representante));
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
