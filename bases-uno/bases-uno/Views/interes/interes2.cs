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
			Interes interes = new Interes(id);

            // label1.Text = "Interes: " + interes.Titlel;

            Update();
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void interes2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            interes1 mf = new interes1(parent, id);
            parent.InsertForm(mf);
        }
    }
}
