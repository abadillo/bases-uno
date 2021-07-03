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
    public partial class coleccionable1 : Form
    {

        public int id;

        public index parent;
        public Coleccionable coleccionable;
       

        public coleccionable1(index parent, Coleccionable coleccionable )
        {
            this.parent = parent;
            this.coleccionable = coleccionable;

            InitializeComponent();
			
			textBoxID.Text = coleccionable.ID.ToString();
			textBoxTitle.Text = coleccionable.Title;
			textBoxPublicationDate.Text = coleccionable.PublicationDate.ToString();
			radioButton1.Checked = coleccionable.Color;
            radioButton2.Checked = coleccionable.Cover;
            textBoxVolume.Text = coleccionable.Volume.ToString();
			textBoxNumber.Text = coleccionable.Number.ToString();
			textBoxPublicationPrice.Text = coleccionable.PublicationPrice.ToString();
			textBoxPages.Text = coleccionable.Pages.ToString();
			textBoxEditor.Text = coleccionable.Editor;
			textBoxSynopsis.Text = coleccionable.Synopsis;

            label1.Text = "Coleccionable: " + coleccionable.Title;
            Update();

		}

     
        private void Modificar()
        {
            coleccionable.Title = textBoxTitle.Text;
            coleccionable.Editor = textBoxEditor.Text;
            coleccionable.Synopsis = textBoxSynopsis.Text;
            if (textBoxVolume.Text == "")
            {
                coleccionable.Volume = 0;
            }
            else
            {
                coleccionable.Volume = int.Parse(textBoxVolume.Text);
            }
            coleccionable.Number = int.Parse(textBoxNumber.Text);
            coleccionable.Pages = int.Parse(textBoxPages.Text);
            if (textBoxPublicationPrice.Text == "")
            {
                coleccionable.PublicationPrice = 0;
            }
            else
            {
                coleccionable.PublicationPrice = int.Parse(textBoxPublicationPrice.Text);
            }
            coleccionable.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
            coleccionable.Cover = radioButton2.Checked;
            coleccionable.Color = radioButton1.Checked;

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Coleccionable?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    coleccionable.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new coleccionable1(parent, coleccionable));
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
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Coleccionable?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    coleccionable.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    coleccionablel form = new coleccionablel(parent);
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
            parent.InsertForm(new coleccionable2(parent, coleccionable));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            coleccionablel form = new coleccionablel(parent);
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
            parent.InsertForm(new coleccionable1(parent, coleccionable));
        }

      
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Hide();

        //    Reporte_coleccionable NuevaReport = new Reporte_coleccionable();

        //    NuevaReport.Show();
        //}
    }
}
