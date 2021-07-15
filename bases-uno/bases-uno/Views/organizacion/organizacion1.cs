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
    public partial class organizacion1 : Form
    {
        
        public index parent;
        public Organizacion organizacion;

        public organizacion1(index parent, Organizacion organizacion)
        {
            this.parent = parent;
            this.organizacion = organizacion;

            InitializeComponent();
            
            textBoxID.Text = organizacion.ID.ToString();
            textBoxName.Text = organizacion.Nombre;
            textBoxMision.Text = organizacion.Mision;

            label1.Text = "Organizacion: " + organizacion.Nombre;
            Update();

           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {
                organizacion.Nombre = Validacion.ValidarNull(textBoxName);
                organizacion.Mision = Validacion.ValidarNull(textBoxMision);
                
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Organizacion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    organizacion.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new organizacion1(parent, organizacion));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Organizacion?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    organizacion.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new organizacionl(parent));
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
            parent.InsertForm(new organizacion2(parent, organizacion));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new organizacionl(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new organizacion1(parent, organizacion));
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
            Acciones.EnableInput(textBoxMision, iconButton1);
        }
        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }
        #endregion



    }
}
