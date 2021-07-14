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
    public partial class coleccionable1 : Form
    {

        public index parent;
        public Coleccionable coleccionable;
       

        public coleccionable1(index parent, Coleccionable coleccionable )
        {
            this.parent = parent;
            this.coleccionable = coleccionable;

            InitializeComponent();

            textBoxID.Text = coleccionable.ID.ToString();
            textBoxNombre.Text = coleccionable.Nombre;
            textBoxDescripcion.Text = coleccionable.Descripcion;

            label1.Text = "Coleccionable: " + coleccionable.Nombre;
            Update();

		}


        #region Funciones

        private void Modificar()
        {

            try
            {
                coleccionable.Nombre = Validacion.ValidarNull(textBoxNombre);
                coleccionable.Descripcion = Validacion.ValidarNull(textBoxDescripcion);

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este coleccionable?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    coleccionable.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new coleccionable1(parent, coleccionable));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este coleccionable?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    coleccionable.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    parent.InsertForm(new coleccionablel(parent));
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

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionablel(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionable1(parent, coleccionable));
        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
        #endregion

        #region clcik botones FontAwesome
        private void iconButton17_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxNombre, iconButton17);
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxDescripcion, iconButton1);
        }
        #endregion

    }
}
