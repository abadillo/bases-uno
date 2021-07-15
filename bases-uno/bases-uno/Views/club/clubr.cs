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
    public partial class clubr : Form
    {

        public index parent;
      
        public clubr(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Club";
            Update();
        }

        #region Funciones
        private void Registrar()
        {
            try
            {

                Club club = new Club(
                    Validacion.ValidarNull(textBoxName),
                    Validacion.ValidarNull(textBoxProposito)
                );

                club.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);
                parent.InsertForm(new clubl(parent));

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
            parent.InsertForm(new clubl(parent));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new clubl(parent));
        }
        #endregion
    }
}
