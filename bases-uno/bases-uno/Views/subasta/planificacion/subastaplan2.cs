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
    public partial class subastaplan2 : Form
    {

        public index parent;
        public Subasta subasta;

        public subastaplan2( index parent, Subasta subasta)
        {
            Validacion.ControlSubastas();
            this.parent = parent;
            this.subasta = subasta;
            
            InitializeComponent();
           
            label1.Text = "Subasta: " + subasta.ID;

            Update();
		}

       
        private void subastaplan2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.subasta' table. You can move, or remove it, as needed.
            //this.subastaTableAdapter.Fill(this.dataSet.subasta);

            //this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1(parent, subasta));
        }
    }
}
