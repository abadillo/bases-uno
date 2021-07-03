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
       

        private void Registrar()
        {
            try
            {

                //comic.Title = Validar(ref , textBoxTitle.Text, "string", true);
                //comic.Editor = textBoxEditor.Text;
                //comic.Synopsis = textBoxSynopsis.Text;
                comic.Volume = int.Parse(maskedTextBoxVolumen.Text);
            //comic.Number = int.Parse(textBoxNumber.Text);
            //comic.Pages = int.Parse(textBoxPages.Text);
            //comic.PublicationPrice = float.Parse(textBoxPublicationPrice.Text);
            //comic.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
            //comic.Cover = radioButton2.Checked;
            //comic.Color = radioButton1.Checked;

                //    comic.Insert();

                //    MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //    parent.InsertForm(new comicl(parent));

             }


            //catch (ApplicationException aex)
            //{
            //    MessageBox.Show(aex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        //public int ValidarInt(TextBox campo, bool NN)
        //{

        //    if (NN && string.IsNullOrEmpty(campo.Text))
        //    {
        //        campo.ForeColor = Color.Red;
        //        throw new ApplicationException("Campo vacio");
        //    }

        //    int temp;

        //    if (!int.TryParse(campo.Text, out temp))
        //    {
        //        campo.Invalidate = Color.Red;
        //        throw new ApplicationException(campo.Text + " debe ser un numero");
        //    }
             

        //    return temp;
        //}
       

        private void btnadelante_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new comicl(parent));
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            Registrar();
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

        private void textBoxPublicationDate_Click(object sender, EventArgs e)
        {
            textBoxPublicationDate.Text = "";
            textBoxPublicationDate.ForeColor = Color.Black;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Campo algo ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
