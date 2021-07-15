using Engine.DBConnection;
using Engine.Classes;
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
    public partial class organizacion2 : Form
    {

        public index parent;
        public Organizacion organizacion;

        public organizacion2( index parent, Organizacion organizacion)
        {
            this.parent = parent;
            this.organizacion = organizacion;
            
            InitializeComponent();
           
            label1.Text = "Organizacion: " + organizacion.Nombre;

            Update();
		}

       
        private void organizacion2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.organizacion' table. You can move, or remove it, as needed.
            this.organizacionTableAdapter.Fill(this.dataSet.organizacion);

            this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new organizacion1(parent, organizacion));
        }
    }
}
