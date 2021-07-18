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

        #region Funciones
        private void Registrar()
        {
            try
            {
          
                Comic comic = new Comic(
                    Validacion.ValidarNull(textBoxTitle), 
                    Validacion.ValidarInt(textBoxNumber, true),
                    Validacion.ValidarDateTime(textBoxPublicationDate, true),
                    checkBoxColor.Checked,
                    Validacion.ValidarNull(textBoxSynopsis), 
                    Validacion.ValidarInt(textBoxPages, true), 
                    checkBoxCover.Checked,
                    Validacion.ValidarNull(textBoxEditor), 
                    Validacion.ValidarInt(textBoxVolumen, false),
                    Validacion.ValidarFloat(textBoxPublicationPrice, false)
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
        #endregion

        #region click botones y modificadores de campo
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
            Acciones.EraseInput(textBoxPublicationDate);
        }
        
        #endregion

    }
}
