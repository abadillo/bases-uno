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
    public partial class coleccionabler : Form
    {

        public index parent;
       
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

                Coleccionable coleccionable = new Coleccionable(
                    Validacion.ValidarNull(textBoxNombre),
                    Validacion.ValidarNull(textBoxDescripcion)
                );

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

       
    }
}
