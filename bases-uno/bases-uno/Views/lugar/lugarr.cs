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

        public double cambioeuro = 0.84;

        public index parent;
        public Place lugar = new Place(0);

        public lugarr(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Lugar";
            Update();
        }
       
        private void hrpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnatras_Click(object sender, EventArgs e)
        {
          
        }

       

        private void registrar()
        {
            try
            {

                // Console.WriteLine(radioButton1.Checked);

                // lugar.Titlel = textBoxTitel.Text;
                // lugar.Editor = textBoxEditor.Text;
                // lugar.Synopsis = textBoxSynopsis.Text;
                // lugar.Volume = int.Parse(textBoxVolume.Text);
                // lugar.Number = int.Parse(textBoxNumber.Text);
                // lugar.Pages = int.Parse(textBoxPages.Text);
                // lugar.PublicationPrice = float.Parse(textBoxPublicationPrice.Text);
                // lugar.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
                // lugar.Cover = radioButton2.Checked;
                // lugar.Color = radioButton1.Checked;

                lugar.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);

                // lugar1 mf = new lugar1( new Lugar() );
                lugarl mf = new lugarl(parent);
                parent.InsertForm(mf);

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
            lugarl mf = new lugarl(parent);
            parent.InsertForm(mf);
        }

        private void textBoxPublicationPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // label6.Text = (cambioeuro * float.Parse(textBoxPublicationPrice.Text)) + " €";
            }
            catch (Exception)
            {

                //throw;
            }
           
        }

        private void textBoxPublicationPrice_MouseHover(object sender, EventArgs e)
        {
              
        }
    }
}
