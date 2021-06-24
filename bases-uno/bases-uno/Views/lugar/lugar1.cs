using Engine.DBConnection;
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
    public partial class lugar1 : Form
    {

        public int id;

        public index parent;
        public Place lugar;
       

        public lugar1(index parent, int id )
        {
            this.parent = parent;
            this.id = id;

            InitializeComponent();
			Place lugar = new Place(id);
			// textBoxID.Text = lugar.ID.ToString();
			// textBoxTitel.Text = lugar.Titlel;
			// textBoxPublicationDate.Text = lugar.PublicationDate.ToString();
			// radioButton1.Checked = lugar.Color ? true : false;
            // radioButton2.Checked = lugar.Cover ? true : false;
            // textBoxVolume.Text = (lugar.Volume == 0) ? lugar.Volume.ToString() : "";
			// textBoxNumber.Text = lugar.Number.ToString();
			// textBoxPublicationPrice.Text = (lugar.PublicationPrice == 0) ? lugar.PublicationPrice.ToString() : "";
			// textBoxPages.Text = lugar.Pages.ToString();
			// textBoxEditor.Text = lugar.Editor;
			// textBoxSynopsis.Text = lugar.Synopsis;

            // label1.Text = "Lugar: " + lugar.Titlel;
            Update();

            this.lugar = lugar;
		}

        private void Modificar()
        {
            // try
            // {
            //     lugar.Titlel = textBoxTitel.Text;
            //     lugar.Editor = textBoxEditor.Text;
            //     lugar.Synopsis = textBoxSynopsis.Text;
            //     if (textBoxVolume.Text == "")
            //     {
            //         lugar.Volume = 0;
            //     }
            //     else
            //     {
            //         lugar.Volume = int.Parse(textBoxVolume.Text);
            //     }
            //     lugar.Number = int.Parse(textBoxNumber.Text);
            //     lugar.Pages = int.Parse(textBoxPages.Text);
            //     if (textBoxPublicationPrice.Text == "")
            //     {
            //         lugar.PublicationPrice = 0;
            //     }
            //     else
            //     {
            //         lugar.PublicationPrice = int.Parse(textBoxPublicationPrice.Text);
            //     }
            //     lugar.PublicationDate = DateTime.Parse(textBoxPublicationDate.Text);
            //     lugar.Cover = radioButton2.Checked;
            //     lugar.Color = radioButton1.Checked;

            //     MessageBox.Show("¿Está seguro que desea modificar este Lugar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //     lugar.Update();

            //     MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //     lugar1 form = new lugar1(parent, lugar.ID);
            //     parent.InsertForm(form);

            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // }

        }

        private void Eliminar()
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Lugar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    lugar.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lugarl form = new lugarl(parent);
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
            lugar2 mf = new lugar2(parent, id);
            parent.InsertForm(mf);
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            lugarl mf = new lugarl(parent);
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
            lugar1 mf = new lugar1(parent, lugar.ID);
            parent.InsertForm(mf);
        }

      
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}
