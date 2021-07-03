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
    public partial class lugar2 : Form
    {

        public index parent;
        public Lugar lugar;


        public lugar2( index parent, Lugar lugar )
        {
            this.parent = parent;
            this.lugar = lugar;
            
            InitializeComponent();
			
            label1.Text = "Lugar: " + lugar.Nombre;

            Update();
		}

       

        private void lugar2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.lugar' table. You can move, or remove it, as needed.
            this.lugarTableAdapter.Fill(this.dataSet.lugar);

            this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
          
            parent.InsertForm(new lugar1(parent, lugar));
        }
    }
}
