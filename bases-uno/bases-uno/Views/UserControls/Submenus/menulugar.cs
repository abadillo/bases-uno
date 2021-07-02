using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bases_uno.Views.Components.Submenus
{
    public partial class menulugar : Form
    {

        public index parent;

        public menulugar(index parent)
        {
            this.parent = parent;
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new lugarl(parent));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new lugarr(parent));
        }
    }
}
