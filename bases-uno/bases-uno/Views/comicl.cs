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
    public partial class comicl : Form
    {

        public int id = 1;

        public index parent;
       

        public comicl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado Comics";
            Update();
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
            comic2 mf = new comic2(parent);
            parent.InsertForm(mf);
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            /// comicl mf = new comicl(parent);
            /// parent.InsertForm(mf);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mnpanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
