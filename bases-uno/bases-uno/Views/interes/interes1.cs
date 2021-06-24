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
    public partial class interes1 : Form
    {

        public int id;

        public index parent;
        public Interes interes;
       

        public interes1(index parent, int id )
        {
            this.parent = parent;
            this.id = id;

            InitializeComponent();
			Interes interes = new Interes(id);
			// textBoxID.Text = interes.ID.ToString();
			// textBoxTitel.Text = interes.Titlel;
			// textBoxPublicationDate.Text = interes.PublicationDate.ToString();
			// radioButton1.Checked = interes.Color ? true : false;
            // radioButton2.Checked = interes.Cover ? true : false;
            // textBoxVolume.Text = (interes.Volume == 0) ? interes.Volume.ToString() : "";
			// textBoxNumber.Text = interes.Number.ToString();
			// textBoxPublicationPrice.Text = (interes.PublicationPrice == 0) ? interes.PublicationPrice.ToString() : "";
			// textBoxPages.Text = interes.Pages.ToString();
			// textBoxEditor.Text = interes.Editor;
			// textBoxSynopsis.Text = interes.Synopsis;

            // label1.Text = "Interes: " + interes.Titlel;
            Update();

            this.interes = interes;
		}

        private void Modificar()
        {
            // try
            // {
            //     interes.Titlel = textBoxTitel.Text;
            //     interes.Editor = textBoxEditor.Text;
            //     interes.Synopsis = textBoxSynopsis.Text;
            //     if (textBoxVolume.Text == "")
            //     {
            //         interes.Volume = 0;
            //     }
            //     else
            //     {
            //         interes.Volume = int.Parse(textBoxVolume.Text);
            //     }
            //     interes.Number = int.Parse(textBoxNumber.Text);
            //     interes.Pages = int.Parse(textBoxPages.Text);
            //     if (textBoxPublicationPrice.Text == "")
            //     {
            //         interes.PublicationPrice = 0;
            //     }
            //     else
            //     {
            //         interes.PublicationPrice = int.Parse(textBoxPublicationPrice.Text);
            //     }
            //     interes.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
            //     interes.Cover = radioButton2.Checked;
            //     interes.Color = radioButton1.Checked;

            //     MessageBox.Show("¿Está seguro que desea modificar este Interes?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //     interes.Update();

            //     MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //     interes1 mf = new interes1(parent, interes.ID);
            //     parent.InsertForm(mf);

            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // }

        }

        private void Eliminar()
        {
            try
            {

                MessageBox.Show("¿Está seguro que desea eliminar este Interes?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                interes.Delete();
                interesl mf = new interesl(parent);

            }
            catch (Exception)
            {

                //throw;
            }

        }

        public void EnableInput(TextBox input, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            input.ReadOnly = false;
            input.ForeColor = Color.Black;
            input.BackColor = Color.LightGray;

        }

        public void EnableRadio(RadioButton input, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            input.Enabled = true;

        }



        private void btnadelante_Click(object sender, EventArgs e)
        {
            interes2 mf = new interes2(parent, id);
            parent.InsertForm(mf);
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            interesl mf = new interesl(parent);
            parent.InsertForm(mf);
        }


        private void iconButton17_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxTitel, iconButton17);
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxNumber, iconButton15);
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxVolume, iconButton10);
        }

        private void iconButton16_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxPublicationDate, iconButton16);
        }

        private void iconButton19_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxPublicationPrice, iconButton19);
        }

        private void iconButton18_Click(object sender, EventArgs e)
        {
            EnableRadio(radioButton1, iconButton18);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxPages, iconButton9);
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            EnableRadio(radioButton2, iconButton12);
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxEditor, iconButton11);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxSynopsis, iconButton1);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();



        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }


        private void btncancelar_Click(object sender, EventArgs e)
        {
            interes1 mf = new interes1(parent, interes.ID);
            parent.InsertForm(mf);
        }

      
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}
