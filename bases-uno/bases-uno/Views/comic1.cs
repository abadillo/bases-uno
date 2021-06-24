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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
           
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            /// comic.delete(id)
        }

        private void hrpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

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
    }
}
