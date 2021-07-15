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
    public partial class itemlocal : UserControl
    {

        public index parent;
        public Local local;

        public itemlocal(Local local, index parent)
        {

            this.parent = parent;
            this.local = local;

            string locationName = "-";


            Local temP = Read.Local(local.LocalID);
             if (temP != null)
            {
                locationName = temP.Nombre;
            }
          

            InitializeComponent();

            label1.Text = local.Nombre;

            label3_1.Text = "Tipo:";
            label3_2.Text = local.Tipo;
           
            label2_2.Text = locationName;

            Update();

        }

       

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new local1(parent, local));
        }
    }
}
