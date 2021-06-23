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

		public int id = 1;

		public index()
		{
			InitializeComponent();
			Comic comic = new Comic(id);
			label1.Text = "Comic: " + comic.Titlel;
			Update();

			comic1 mf = new comic1();
			InsertForm(mf);

		}

		public void InsertForm(object form)
		{
			if (this.mainpanel.Controls.Count > 0)
				this.mainpanel.Controls.RemoveAt(0);
			Form f = form as Form;
			f.TopLevel = false;
			f.FormBorderStyle = FormBorderStyle.None;
			f.Dock = DockStyle.Fill;
			this.mainpanel.Controls.Add(f);
			this.mainpanel.Tag = f;
			f.Show();
		}

        private void button3_Click(object sender, EventArgs e)
        {
		
		}

        private void button4_Click(object sender, EventArgs e)
        {
			
		}

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
			comic2 mf = new comic2( this );
			InsertForm(mf);
		}

        private void btnatras_Click(object sender, EventArgs e)
        {
			comicr mf = new comicr( this );
			InsertForm(mf);
		}
    }
}
