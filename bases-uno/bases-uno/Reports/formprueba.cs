using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bases_uno.Reports
{
    public partial class formprueba : Form
    {
        public formprueba()
        {
            InitializeComponent();
        }

        private void formprueba_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prueba.jagclub' table. You can move, or remove it, as needed.
            this.jagclubTableAdapter.Fill(this.prueba.jagclub);
            // TODO: This line of code loads data into the 'prueba.jagclub' table. You can move, or remove it, as needed.
            this.jagclubTableAdapter.Fill(this.prueba.jagclub);

            this.reportViewer1.RefreshReport();
        }

        private void pruebaBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
