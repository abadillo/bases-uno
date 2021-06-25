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
    public partial class interes2 : Form
    {

        public index parent;

        public int id;


        public interes2( index parent, int id )
        {
            this.parent = parent;
            this.id = id;
            
            InitializeComponent();
            Interest interes = new Interest(id);

            label1.Text = "Interes: " + interes.Name;

            Update();
		}

       
        private void interes2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.interes' table. You can move, or remove it, as needed.
            this.interesTableAdapter.Fill(this.dataSet.interes);

            this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            interes1 form = new interes1(parent, id);
            parent.InsertForm(form);
        }
    }
}
