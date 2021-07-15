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
    public partial class representante2 : Form
    {

        public index parent;
        public Representante representante;

        public representante2( index parent, Representante representante)
        {
            this.parent = parent;
            this.representante = representante;
            
            InitializeComponent();
           
            label1.Text = "Representante: " + representante.Nombre;

            Update();
		}

       
        private void representante2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.representante' table. You can move, or remove it, as needed.
            this.representanteTableAdapter.Fill(this.dataSet.representante);

            this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new representante1(parent, representante));
        }
    }
}
