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
    public partial class coleccionabler : Form
    {

        public double cambioeuro = 0.84;

        public index parent;
        public Coleccionable coleccionable = new Coleccionable(0);

        public coleccionabler( index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Coleccionable";
            Update();
        }
       

        private void Registrar()
        {
            try
            {

                coleccionable.Title = ValidarNull(textBoxTitle);
                coleccionable.Editor = ValidarNull(textBoxEditor);
                coleccionable.Synopsis = ValidarNull(textBoxSynopsis);

                coleccionable.Volume = ValidarInt(textBoxVolumen, false);
                Console.WriteLine(coleccionable.Volume.ToString() + "  " + textBoxVolumen.Text);

                coleccionable.Number = ValidarInt(textBoxNumber, true);
                coleccionable.Pages = ValidarInt(textBoxPages,true);
                coleccionable.PublicationPrice = ValidarFloat(textBoxPublicationPrice, false);
                coleccionable.PublicationDate = ValidarDateTime(textBoxPublicationDate,true);
                
                coleccionable.Cover = radioButton2.Checked;
                coleccionable.Color = radioButton1.Checked;

                coleccionable.Insert();


                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new coleccionablel(parent));

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

            int temp;

            if (!int.TryParse(campo.Text, out temp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero valido");
            } 

            campo.BackColor = Color.LightGray;
            return temp;

        }

        public float ValidarFloat(TextBox campo, bool NN)
        {

            if (!NN && string.IsNullOrEmpty(campo.Text))
                return 0;


            float temp;

            if (!float.TryParse(campo.Text, out temp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero decimal valido");
            }

            campo.BackColor = Color.LightGray;
            return temp;
        }
        public DateTime ValidarDateTime(TextBox campo, bool NN)
        {

            if (NN)
                ValidarNull(campo);

            DateTime temp;

            if (!DateTime.TryParse(campo.Text, out temp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser una fecha valida con formato MM/DD/YYYY");
            }

            campo.BackColor = Color.LightGray;
            return temp;
        }


        private void btnadelante_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionablel(parent));
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            Registrar();
        }
       

        private void btncancelar_Click(object sender, EventArgs e)
        {
            
            parent.InsertForm(new coleccionablel(parent));
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

     
    }
}
