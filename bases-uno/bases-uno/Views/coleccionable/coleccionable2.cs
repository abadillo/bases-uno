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
    public partial class coleccionable2 : Form
    {

        public index parent;
        public Coleccionable coleccionable;
     


        public coleccionable2( index parent, Coleccionable coleccionable )
        {
            this.parent = parent;
            this.coleccionable = coleccionable;
            
            InitializeComponent();

            label1.Text = "Coleccionable: " + coleccionable.Title;

            Update();
		}


        private void coleccionable2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'coleccionableDataSet.coleccionable' table. You can move, or remove it, as needed.
            this.coleccionableTableAdapter.Fill(this.coleccionableDataSet.coleccionable);
            reportViewer1.AutoSize = true;
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionable1(parent, coleccionable));
        }


	}
}
