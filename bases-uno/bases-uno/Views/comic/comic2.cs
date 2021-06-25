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
    public partial class comic2 : Form
    {

        public index parent;

        public int id;


        public comic2( index parent, int id )
        {
            this.parent = parent;
            this.id = id;
            
            InitializeComponent();
			Comic comic = new Comic(id);

            label1.Text = "Comic: " + comic.Titlel;

            Update();
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comic2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'comicDataSet.comic' table. You can move, or remove it, as needed.
            this.comicTableAdapter.Fill(this.comicDataSet.comic);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            comic1 form = new comic1(parent, id);
            parent.InsertForm(form);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        }
    }
}
