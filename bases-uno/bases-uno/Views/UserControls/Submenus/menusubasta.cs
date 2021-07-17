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
    public partial class menusubasta : Form
    {

        public index parent;
        public Button activeButton;

        public menusubasta(index parent)
        {
            this.parent = parent;

            InitializeComponent();

            activeButton = buttonListadoSubasta;
            ButtonEnable(buttonListadoSubasta, new subastal(parent));
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
            ButtonEnable(buttonListadoSubasta, new subastal(parent));
        }

        private void buttonRegistro_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonRegistroSubasta, new subastar(parent));
        }

        private void buttonListadoOrganizacion_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonListadoOrganizacion, new organizacionl(parent));
        }

        private void buttonRegistroOrganizacion_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonRegistroOrganizacion, new organizacionr(parent));
        }

        private void buttonListadoLocal_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonRegistroLocal, new locall(parent));
        }

        private void buttonRegistroLocal_Click(object sender, EventArgs e)
        {
            ButtonEnable(buttonRegistroLocal, new localr(parent));
        }
    }
}
