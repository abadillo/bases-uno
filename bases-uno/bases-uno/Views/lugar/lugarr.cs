using Engine.DBConnection;
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

namespace bases_uno.Views
{
    public partial class lugarr : Form
    {

        public index parent;
        public Lugar lugar = Read.Lugar(0);

        public lugarr(index parent)
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Lugar";
            Update();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            lugarl form = new lugarl(parent);
            parent.InsertForm(form);

        }


        private void registrar()
        {
            try
            {

                lugar.Nombre = textBoxName.Text;
                lugar.LugarID = int.Parse(textBoxLocationID.Text);
                lugar.Tipo = comboBoxType.SelectedItem.ToString();

                lugar.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // lugar1 form = new lugar1( new Lugar() );
                lugarl form = new lugarl(parent);
                parent.InsertForm(form);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            registrar();

        }
        private void btnadelante_Click(object sender, EventArgs e)
        {
            registrar();
        }


        private void btncancelar_Click(object sender, EventArgs e)
        {
            lugarl form = new lugarl(parent);
            parent.InsertForm(form);
        }
    }
}
