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

        public int id;
        public index parent;

        public itemcomic( Comic comic, index parent )
        {

            this.parent = parent;
            this.id = comic.ID;

            InitializeComponent();
                        
            label1.Text = comic.Titlel;
           
            label2.Text = comic.Editor + "     " + comic.PublicationDate.ToString();
           
            label3.Text = "Volumen: " + ( (comic.Volume == 0) ? comic.Volume.ToString() : "" ) + "\n" + "Numero: " + comic.Number.ToString() + "\n" + "Paginas: " + comic.Pages.ToString();
           
            Update();

        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
            comic1 form = new comic1(parent, id);
            parent.InsertForm(form);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
