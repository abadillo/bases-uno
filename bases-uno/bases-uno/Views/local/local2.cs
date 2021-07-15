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
    public partial class local2 : Form
    {

        public index parent;
        public Local local;


        public local2( index parent, Local local )
        {
            this.parent = parent;
            this.local = local;
            
            InitializeComponent();
			
            label1.Text = "Local: " + local.Nombre;

            Update();
		}

       

        private void local2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.local' table. You can move, or remove it, as needed.
            this.localTableAdapter.Fill(this.dataSet.local);

            this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
          
            parent.InsertForm(new local1(parent, local));
        }
    }
}
