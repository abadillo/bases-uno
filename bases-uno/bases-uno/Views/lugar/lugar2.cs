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

        public int id;


        public lugar2( index parent, int id )
        {
            this.parent = parent;
            this.id = id;
            
            InitializeComponent();
			Place lugar = new Place(id);

            label1.Text = "Lugar: " + lugar.Name;

            Update();
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lugar2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.lugar' table. You can move, or remove it, as needed.
            this.lugarTableAdapter.Fill(this.dataSet.lugar);

            this.reportViewer1.RefreshReport();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            lugar1 form = new lugar1(parent, id);
            parent.InsertForm(form);
        }
    }
}
