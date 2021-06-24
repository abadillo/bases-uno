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
       

        public comic1(index parent, int id )
        {
            this.parent = parent;
            this.id = id;

            InitializeComponent();
			Comic comic = new Comic(id);
			textBoxID.Text = comic.ID.ToString();
			textBoxTitel.Text = comic.Titlel;
			textBoxPublicationDate.Text = comic.PublicationDate.ToString();
			textBoxColor.Text = comic.Color ? "Si" : "No";
			textBoxCover.Text = comic.Cover ? "Si" : "No";
			textBoxVolume.Text = (comic.Volume == 0) ? comic.Volume.ToString() : "";
			textBoxNumber.Text = comic.Number.ToString();
			textBoxPublicationPrice.Text = (comic.PublicationPrice == 0) ? comic.PublicationPrice.ToString() : "";
			textBoxPages.Text = comic.Pages.ToString();
			textBoxEditor.Text = comic.Editor;
			textBoxSynopsis.Text = comic.Synopsis;

            label1.Text = "Comic: " + comic.Titlel;
            Update();
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

     
        public void enableinput (TextBox input)
        {
            input.ReadOnly = false;
            input.ForeColor = Color.Black;
            input.BackColor = Color.LightGray;

        }

        private void iconButton17_Click(object sender, EventArgs e)
        {
            enableinput(textBoxTitel);
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            enableinput(textBoxNumber);
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            enableinput(textBoxVolume);
        }

        private void iconButton16_Click(object sender, EventArgs e)
        {
            enableinput(textBoxPublicationDate);
        }

        private void iconButton19_Click(object sender, EventArgs e)
        {
            enableinput(textBoxPublicationPrice);
        }

        private void iconButton18_Click(object sender, EventArgs e)
        {
            enableinput(textBoxColor);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            enableinput(textBoxPages);
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            enableinput(textBoxCover);
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            enableinput(textBoxEditor);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            enableinput(textBoxSynopsis);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Está seguro que desea eliminar este Comic?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);



        }
    }
}
