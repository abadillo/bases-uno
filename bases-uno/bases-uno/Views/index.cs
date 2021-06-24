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
using bases_uno.Views.Components.Submenus;


namespace bases_uno.Views

{
	public partial class index : Form
	{

		public FontAwesome.Sharp.IconButton activebutton;

		public index()
		{
			InitializeComponent();
			
			// home startup window and menu
			comicl panel = new comicl(this);
			InsertForm(panel);

			menucomic menu = new menucomic(this);
			InsertMenu(menu);

			activebutton = iconButton6;

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

		public void InsertMenu(object form)
		{
			if (this.menupanel.Controls.Count > 0)
				this.menupanel.Controls.RemoveAt(0);
			Form p = form as Form;
			p.TopLevel = false;
			p.FormBorderStyle = FormBorderStyle.None;
			p.Dock = DockStyle.Fill;
			this.menupanel.Controls.Add(p);
			this.menupanel.Tag = p;
			p.Show();
		}

		public void ButtonEnable( FontAwesome.Sharp.IconButton pressedbutton, Form menu )
        {
 			// not selected
			// Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(103)))), ((int)(((byte)(135)))));

			// selected
			// Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(84)))), ((int)(((byte)(110)))));

			activebutton.BackColor = Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(103)))), ((int)(((byte)(135)))));
			pressedbutton.BackColor = Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(84)))), ((int)(((byte)(110)))));
			
			InsertMenu(menu);
			activebutton = pressedbutton;
		}


        private void iconButton6_Click(object sender, EventArgs e)
        {
			menucomic menu = new menucomic(this);
			ButtonEnable(iconButton6, menu);
		}

        private void iconButton4_Click(object sender, EventArgs e)
        {
			menulugar menu = new menulugar(this);
			ButtonEnable(iconButton4, menu);
		}

        private void iconButton3_Click(object sender, EventArgs e)
        {
			menuinteres menu = new menuinteres(this);
			ButtonEnable(iconButton3, menu);

		}
    }
}
