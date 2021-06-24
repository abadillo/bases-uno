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
    public partial class comic1 : Form
    {

        public int id;

        public index parent;
        public Comic comic;
       

        public comic1(index parent, int id )
        {
            this.parent = parent;
            this.id = id;

            InitializeComponent();
			Comic comic = new Comic(id);
			textBoxID.Text = comic.ID.ToString();
			textBoxTitel.Text = comic.Titlel;
			textBoxPublicationDate.Text = comic.PublicationDate.ToString();
			radioButton1.Checked = comic.Color ? true : false;
            radioButton2.Checked = comic.Cover ? true : false;
            textBoxVolume.Text = (comic.Volume == 0) ? comic.Volume.ToString() : "";
			textBoxNumber.Text = comic.Number.ToString();
			textBoxPublicationPrice.Text = (comic.PublicationPrice == 0) ? comic.PublicationPrice.ToString() : "";
			textBoxPages.Text = comic.Pages.ToString();
			textBoxEditor.Text = comic.Editor;
			textBoxSynopsis.Text = comic.Synopsis;

            label1.Text = "Comic: " + comic.Titlel;
            Update();

            this.comic = comic;
		}

        private void Modificar()
        {
            try
            {


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

                MessageBox.Show("Está seguro que desea modificar este Comic?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                comic.Update();

                MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


                comic1 mf = new comic1(parent, comic.ID);
                parent.InsertForm(mf);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Eliminar()
        {
            try
            {

                MessageBox.Show("Está seguro que desea eliminar este Comic?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                comic.Delete();
                comicl mf = new comicl(parent);

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
            comic2 mf = new comic2(parent, id);
            parent.InsertForm(mf);
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            comicl mf = new comicl(parent);
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
            comic1 mf = new comic1(parent, comic.ID);
            parent.InsertForm(mf);
        }

      
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}
