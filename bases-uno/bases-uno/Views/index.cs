using bases_uno.Views.UserControls.Submenus;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace bases_uno.Views

{
    public partial class index : Form
    {

        public FontAwesome.Sharp.IconButton activebutton;

        public index()
        {
            InitializeComponent();

            // home startup window and menu


            activebutton = iconButton1;
            ButtonEnable(iconButton1, new menusubasta(this));
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

        public void InsertMenu(object menu)
        {
            if (this.menupanel.Controls.Count > 0)
                this.menupanel.Controls.RemoveAt(0);
            Form p = menu as Form;
            p.TopLevel = false;
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;
            this.menupanel.Controls.Add(p);
            this.menupanel.Tag = p;

            p.Show();
        }

        public void ButtonEnable(FontAwesome.Sharp.IconButton pressedbutton, Form menu)
        {
            // not selected
            // Color.FromArgb(73, 103,135);

            // selected
            // Color.FromArgb(59,84,110);

            activebutton.BackColor = Color.FromArgb(73, 103, 135);
            pressedbutton.BackColor = Color.FromArgb(59, 84, 110);

            InsertMenu(menu);
            activebutton = pressedbutton;
        }


        private void iconButton6_Click(object sender, EventArgs e)
        {
            ButtonEnable(iconButton6, new menucomic(this));
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ButtonEnable(iconButton4, new menulugar(this));
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ButtonEnable(iconButton7, new menucoleccionable(this));
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ButtonEnable(iconButton2, new menuclub(this));
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            ButtonEnable(iconButton10, new menucoleccionista(this));
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ButtonEnable(iconButton1, new menusubasta(this));
        }
    }
}
