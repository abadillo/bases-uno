using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Engine;


namespace bases_uno.Views
{
    public partial class comics : bases_uno.MDIParent1
    {
        public comics()
        {
			InitializeComponent();
			Comic comic = new Comic(1);
			label1.Text = "Informacion: " + comic.Titel;
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
    }
}
