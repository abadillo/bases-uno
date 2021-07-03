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
        public Comic comic;
     


        public comic2( index parent, Comic comic )
        {
            this.parent = parent;
            this.comic = comic;
            
            InitializeComponent();

            label1.Text = "Comic: " + comic.Title;

            Update();
		}


        private void comic2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'comicDataSet.comic' table. You can move, or remove it, as needed.
            this.comicTableAdapter.Fill(this.comicDataSet.comic);
            reportViewer1.AutoSize = true;
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new comic1(parent, comic));
        }


	}
}
