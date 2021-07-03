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
       

        public comic1(index parent, Comic comic )
        {
            this.parent = parent;
            this.comic = comic;

            InitializeComponent();
			
			textBoxID.Text = comic.ID.ToString();
			textBoxTitle.Text = comic.Title;
			textBoxPublicationDate.Text = comic.PublicationDate.ToString();
			radioButton1.Checked = comic.Color;
            radioButton2.Checked = comic.Cover;
            textBoxVolume.Text = comic.Volume.ToString();
			textBoxNumber.Text = comic.Number.ToString();
			textBoxPublicationPrice.Text = comic.PublicationPrice.ToString();
			textBoxPages.Text = comic.Pages.ToString();
			textBoxEditor.Text = comic.Editor;
			textBoxSynopsis.Text = comic.Synopsis;

            label1.Text = "Comic: " + comic.Title;
            Update();

		}

     
        private void Modificar()
        {
            comic.Title = textBoxTitle.Text;
            comic.Editor = textBoxEditor.Text;
            comic.Synopsis = textBoxSynopsis.Text;
            if (textBoxVolume.Text == "")
            {
                comic.Volume = 0;
            }
            else
            {
                comic.Volume = int.Parse(textBoxVolume.Text);
            }
            comic.Number = int.Parse(textBoxNumber.Text);
            comic.Pages = int.Parse(textBoxPages.Text);
            if (textBoxPublicationPrice.Text == "")
            {
                comic.PublicationPrice = 0;
            }
            else
            {
                comic.PublicationPrice = int.Parse(textBoxPublicationPrice.Text);
            }
            comic.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
            comic.Cover = radioButton2.Checked;
            comic.Color = radioButton1.Checked;

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Comic?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    comic.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new comic1(parent, comic));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }

        private void Eliminar()
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Comic?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    comic.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comicl form = new comicl(parent);
                    parent.InsertForm(form);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            else if (dialogResult == DialogResult.No)
            {
                //do something else
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
            parent.InsertForm(new comic2(parent, comic));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            comicl form = new comicl(parent);
            parent.InsertForm(form);
        }


        private void iconButton17_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxTitle, iconButton17);
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
            parent.InsertForm(new comic1(parent, comic));
        }

      
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Hide();

        //    Reporte_comic NuevaReport = new Reporte_comic();

        //    NuevaReport.Show();
        //}
    }
}
