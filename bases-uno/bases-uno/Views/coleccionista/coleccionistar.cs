using Engine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace bases_uno.Views
{
    public partial class coleccionistar : Form
    {

        public index parent;
      
        public coleccionistar(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Coleccionista";
            Update();
        }

        #region Funciones
        private void Registrar()
        {
            try
            {

                Coleccionista coleccionista = new Coleccionista(
                    Validacion.ValidarInt(textBoxDocIdentidad,true),
                    Validacion.ValidarNull(textBoxName),
                    Validacion.ValidarNull(textBoxApellido),
                    Validacion.ValidarDateTime(textBoxFechaNacimiento,true)
                );

                coleccionista.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);
                parent.InsertForm(new coleccionistal(parent));

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

        #region click botones y modificadores de campo
        private void btncrear_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        private void btnadelante_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionistal(parent));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionistal(parent));
        }
        #endregion

        private void textBoxFechaNacimiento_Click(object sender, EventArgs e)
        {
            Acciones.EraseInput(textBoxFechaNacimiento);
        }
    }
}
