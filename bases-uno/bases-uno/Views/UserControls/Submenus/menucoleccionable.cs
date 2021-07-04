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
        public Button activeButton;

        public menucoleccionable(index parent)
        {
            this.parent = parent;

            InitializeComponent();

            activeButton = buttonListado;
            ButtonEnable(buttonListado, new coleccionablel(parent));
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
            ButtonEnable(buttonListado, new coleccionablel(parent));
        }
        private void buttonRegistro_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonRegistro, new coleccionabler(parent));
        }


    }
}
