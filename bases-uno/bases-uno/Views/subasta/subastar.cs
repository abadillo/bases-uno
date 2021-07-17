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
    public partial class subastar : Form
    {

        public index parent;
        public List<Lugar> list = Read.Lugares();

        public subastar(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Subasta";

            for (int i = 0; i < list.Count; i++)
            {
                Lugar tmp = list[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLugar.Items.Add(item);
            }

            Update();
        }

        #region Funciones
        private void Registrar()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxLugar).Split(' ');
                int LugarID = int.Parse(tokens[0]);

                Subasta subasta = new Subasta(
                    Validacion.ValidarNull(textBoxNombre),
                    Validacion.ValidarDateTime(textBoxFechaFundacion, true),
                    textBoxProposito.Text,
                    Read.Lugar(LugarID),
                    Validacion.ValidarInt(textBoxTelefono, true),
                    textBoxPaginaWeb.Text
                  
                );

                subasta.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);
                parent.InsertForm(new subastal(parent));

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
      
        private void btnadelante_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastal(parent));
        }
        private void textBoxFechaFundacion_Click(object sender, EventArgs e)
        {
            Acciones.EraseInput(textBoxFechaFundacion);
        }

        private void btncrear_Click_1(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subastal(parent));
        }
        #endregion
    }
}
