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
            lugarl panel = new lugarl(parent);
            parent.InsertForm(panel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lugarr panel = new lugarr(parent);
            parent.InsertForm(panel);
        }
    }
}
