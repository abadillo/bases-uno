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

namespace bases_uno.Views.Components
{
    public partial class iteminteres : UserControl
    {
               
        public index parent;
        public Interes interes;

        public iteminteres( Interes interes, index parent )
        {

            this.parent = parent;
            this.interes = interes;

            InitializeComponent();

            label1.Text = interes.Nombre;
            label2_2.Text = interes.Descripcion;

            Update();

        }

      

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new interes1(parent, interes));
        }
    }
}
