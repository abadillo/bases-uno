using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bases_uno.Views.UserControls.Submenus
{
    public partial class menucoleccionable : Form
    {

        public index parent;
        public Button activebutton;

        public menucoleccionable(index parent)
        {
            this.parent = parent;

            InitializeComponent();

            activebutton = button1;
            ButtonEnable(button1, new coleccionablel(parent));
        }

        public void ButtonEnable(Button pressedbutton, Form form)
        {
            // not selected
            // Color.FromArgb(73, 103,135);

            // selected
            // Color.FromArgb(59,84,110);

            activebutton.FlatAppearance.BorderSize = 0;
            pressedbutton.FlatAppearance.BorderSize = 1;

            parent.InsertForm(form);
            activebutton = pressedbutton;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonEnable(button1, new coleccionablel(parent));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ButtonEnable(button2, new coleccionabler(parent));
        }


    }
}
