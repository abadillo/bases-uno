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
	public partial class index : Form
	{
		public index()
		{
			InitializeComponent();

		}

		private void AbrirFormEnPanel(object formHijo)
		{
			if (this.mainpanel.Controls.Count > 0)
				this.mainpanel.Controls.RemoveAt(0);
			Form fh = formHijo as Form;
			fh.TopLevel = false;
			fh.FormBorderStyle = FormBorderStyle.None;
			fh.Dock = DockStyle.Fill;
			this.mainpanel.Controls.Add(fh);
			this.mainpanel.Tag = fh;
			fh.Show();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			comic1 fm = new comic1();
			AbrirFormEnPanel(fm);
		}

        private void button4_Click(object sender, EventArgs e)
        {
			comic2 fm = new comic2();
			AbrirFormEnPanel(fm);
		}

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
