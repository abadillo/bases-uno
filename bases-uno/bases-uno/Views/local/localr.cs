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
using Engine.DBConnection;
using bases_uno.Views.Components;

namespace bases_uno.Views
{
    public partial class localr : Form
    {

        public index parent;
        public List<Local> list = Read.Locales();

        public localr(index parent)
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Local";

            comboBoxType.Items.AddRange(new object[] {
                "Pais",
                "Estado",
                "Ciudad",
                "Direccion"
            });

            comboBoxLocal.Items.Add("0 Ninguno");

            for (int i = 0; i < list.Count; i++)
            {
                Local tmp = list[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLocal.Items.Add(item);
            }

            comboBoxLocal.SelectedIndex = 0;

            Update();
        }


        private void Registrar()
        {
            try
            {

                string[] tokens = comboBoxLocal.SelectedItem.ToString().Split(' ');
                int LocalID = int.Parse(tokens[0]);

                Local local = new Local(
                    Validacion.ValidarNull(textBoxName),
                    Validacion.ValidarCombo(comboBoxType),
                    Read.Local(LocalID)
                ); 
             
                local.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new locall(parent));

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

        #region click botones normales
        private void btnadelante_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new locall(parent));
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new locall(parent));
        }
        #endregion
    }
}
