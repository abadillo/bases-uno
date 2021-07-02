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
        public Interest interes;

        public iteminteres( Interest interes, index parent )
        {

            this.parent = parent;
            this.interes = interes;

            InitializeComponent();

            label1.Text = interes.Name;
            label2_2.Text = interes.Description;

            Update();

        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new interes1(parent, interes));
        }

    }
}
