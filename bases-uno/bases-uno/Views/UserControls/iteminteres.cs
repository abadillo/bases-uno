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

        public int id;
        public index parent;

        public iteminteres( Interest interes, index parent )
        {

            this.parent = parent;
            this.id = interes.ID;

            InitializeComponent();
                        
            label1.Text = interes.Name;
           
            label2.Text = interes.Description;
           
            Update();

        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
            interes1 form = new interes1(parent, id);
            parent.InsertForm(form);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
