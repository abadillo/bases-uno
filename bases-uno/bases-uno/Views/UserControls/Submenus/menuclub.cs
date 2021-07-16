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
    public partial class menuclub : Form
    {

        public index parent;
        public Button activeButton;

        public menuclub(index parent)
        {
            this.parent = parent;

            InitializeComponent();

            activeButton = buttonListadoClub;
            ButtonEnable(buttonListadoClub, new clubl(parent));
        }

        public void ButtonEnable(Button pressedButton, Form form)
        {
            // not selected
            // Color.FromArgb(73, 103,135);

            // selected
            // Color.FromArgb(59,84,110);

            activeButton.FlatAppearance.BorderSize = 0;
            pressedButton.FlatAppearance.BorderSize = 1;

            parent.InsertForm(form);
            activeButton = pressedButton;
        }

        private void buttonListado_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonListadoClub, new clubl(parent));
        }

        private void buttonRegistro_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonRegistroClub, new clubr(parent));
        }

        private void buttonListadoInteres_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonListadoInteres, new interesl(parent));
        }

        private void buttonRegistroInteres_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonRegistroInteres, new interesr(parent));
        }
    }
}
