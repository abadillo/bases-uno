using Engine.DBConnection;
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
    public partial class subasta2 : Form
    {

        public index parent;
        public Subasta subasta;

        public subasta2( index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;
            
            InitializeComponent();
           
            label1.Text = "Subasta: " + subasta.PaginaWeb;

            Update();
		}

       
        private void subasta2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.subasta' table. You can move, or remove it, as needed.
            //this.subastaTableAdapter.Fill(this.dataSet.subasta);

            //this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subasta1(parent, subasta));
        }
    }
}
