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

namespace bases_uno.Views.Components
{
    public partial class itemcomic : UserControl
    {

        public index parent;
        public Comic comic;

        public itemcomic( Comic comic, index parent )
        {

            this.parent = parent;
            this.comic = comic;

            InitializeComponent();
                        
            label1.Text = comic.Title;
           
            label2_1.Text = comic.Editor;
            label2_2.Text = comic.PublicationDate.ToShortDateString();

            label3_1.Text = "Volumen: " + "\n" + "Numero: " + "\n" + "Paginas: ";
            label3_2.Text =  comic.Volume.ToString() + "\n" + comic.Number.ToString() + "\n" + comic.Pages.ToString();

            Update();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new comic1(parent, comic));
        }
    }
}
