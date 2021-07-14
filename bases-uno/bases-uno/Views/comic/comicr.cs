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

      

        public index parent;
        //public Comic comic = Read.Comic(0);

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
          
                Comic comic = new Comic(
                    ValidarNull(textBoxTitle), ValidarInt(textBoxNumber, true),
                    ValidarDateTime(textBoxPublicationDate, true), radioButtonColor.Checked,
                    ValidarNull(textBoxSynopsis), ValidarInt(textBoxPages, true), radioButtonCover.Checked,
                    ValidarNull(textBoxEditor), ValidarInt(textBoxVolumen, false),
                    ValidarFloat(textBoxPublicationPrice, false)
                );

                comic.Insert();


                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new comicl(parent));

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

        public string ValidarNull(TextBox campo) {

            if (string.IsNullOrEmpty(campo.Text))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("Campo " + campo.Tag + " vacio");
            }

            campo.BackColor = Color.LightGray;
            return campo.Text;
        }
        public int ValidarInt(TextBox campo, bool NN)
        {

            if (!NN && string.IsNullOrEmpty(campo.Text))
                return 0;

            if (NN)
            {
                ValidarNull(campo);   
            }

            int tmp;

            if (!int.TryParse(campo.Text, out tmp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero valido");
            } 

            campo.BackColor = Color.LightGray;
            return tmp;

        }
        public float ValidarFloat(TextBox campo, bool NN)
        {

            if (!NN && string.IsNullOrEmpty(campo.Text))
                return 0;

            if (NN)
            {
                ValidarNull(campo);
            }

            float tmp;

            if (!float.TryParse(campo.Text, out tmp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero decimal valido");
            }

            campo.BackColor = Color.LightGray;
            return tmp;
        }
        public DateTime ValidarDateTime(TextBox campo, bool NN)
        {

            if (NN)
                ValidarNull(campo);

            DateTime tmp;

            if (!DateTime.TryParse(campo.Text, out tmp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser una fecha valida con formato MM/DD/YYYY");
            }

            campo.BackColor = Color.LightGray;
            return tmp;
        }




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
                label6.Text = Conversion.ConvertirEuros(float.Parse(textBoxPublicationPrice.Text)) + " €";
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

     
    }
}
