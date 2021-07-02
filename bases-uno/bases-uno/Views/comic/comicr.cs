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
    public partial class comicr : Form
    {

        public double cambioeuro = 0.84;

        public index parent;
        public Comic comic = new Comic(0);

        public comicr( index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Comic";
            Update();
        }
       

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new comicl(parent));
        }

        private void registrar()
        {
            try
            {

                Console.WriteLine(radioButton1.Checked);

                comic.Titlel = textBoxTitel.Text;
                comic.Editor = textBoxEditor.Text;
                comic.Synopsis = textBoxSynopsis.Text;
                comic.Volume = int.Parse(textBoxVolume.Text);
                comic.Number = int.Parse(textBoxNumber.Text);
                comic.Pages = int.Parse(textBoxPages.Text);
                comic.PublicationPrice = float.Parse(textBoxPublicationPrice.Text);
                comic.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
                comic.Cover = radioButton2.Checked;
                comic.Color = radioButton1.Checked;

                comic.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);

                // comic1 form = new comic1( new Comic() );

                parent.InsertForm(new comicl(parent));

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
            
            parent.InsertForm(new comicl(parent));
        }

        private void textBoxPublicationPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                label6.Text = (cambioeuro * float.Parse(textBoxPublicationPrice.Text)) + " €";
            }
            catch (Exception)
            {

                //throw;
            }
           
        }

    }
}
