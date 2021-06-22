using Engine;
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
        public comic2()
        {
            InitializeComponent();
			Comic comic = new Comic(1);
			
			
			Update();
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comic2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
