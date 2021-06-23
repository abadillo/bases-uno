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
    public partial class comicr : Form
    {

        public index parent;

        public comicr(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Comic";
            Update();
        }
       


        private void btneliminar_Click(object sender, EventArgs e)
        {
            /// comic.delete(id)
        }


        private void btncancelar_Click(object sender, EventArgs e)
        {
            comicl mf = new comicl(parent);
            parent.InsertForm(mf);
        }

        private void hrpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            comicl mf = new comicl(parent);
            parent.InsertForm(mf);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
