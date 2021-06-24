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
    public partial class menucomic : Form
    {

        public index parent;

        public menucomic(index parent)
        {
            this.parent = parent;
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comicl panel = new comicl(parent);
            parent.InsertForm(panel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comicr panel = new comicr(parent);
            parent.InsertForm(panel);
        }
    }
}
