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
    public partial class interesr : Form
    {

        public double cambioeuro = 0.84;

        public index parent;
        public Interes interes = new Interes(0);

        public interesr(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Interes";
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

                Console.WriteLine(radioButton1.Checked);

                // interes.Titlel = textBoxTitel.Text;
                // interes.Editor = textBoxEditor.Text;
                // interes.Synopsis = textBoxSynopsis.Text;
                // interes.Volume = int.Parse(textBoxVolume.Text);
                // interes.Number = int.Parse(textBoxNumber.Text);
                // interes.Pages = int.Parse(textBoxPages.Text);
                // interes.PublicationPrice = float.Parse(textBoxPublicationPrice.Text);
                // interes.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
                // interes.Cover = radioButton2.Checked;
                // interes.Color = radioButton1.Checked;

                interes.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);

                // interes1 mf = new interes1( new Interes() );
                interesl mf = new interesl(parent);
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
            interesl mf = new interesl(parent);
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
