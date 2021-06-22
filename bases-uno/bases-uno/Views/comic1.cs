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
    public partial class comic1 : Form
    {
        public comic1()
        {
            InitializeComponent();
			Comic comic = new Comic(1);
			label1.Text = "Comic: " + comic.Titel;
			textBoxID.Text = comic.ID.ToString();
			textBoxTitel.Text = comic.Titel;
			textBoxPublicationDate.Text = comic.PublicationDate.ToString();
			textBoxColor.Text = comic.Color ? "Si" : "No";
			textBoxCover.Text = comic.Cover ? "Si" : "No";
			textBoxVolume.Text = (comic.Volume == 0) ? comic.Volume.ToString() : "";
			textBoxNumber.Text = comic.Number.ToString();
			textBoxPublicationPrice.Text = (comic.PublicationPrice == 0) ? comic.PublicationPrice.ToString() : "";
			textBoxPages.Text = comic.Pages.ToString();
			textBoxEditor.Text = comic.Editor;
			textBoxSynopsis.Text = comic.Synopsis;
			Update();
		}

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
