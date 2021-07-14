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
    public partial class itemlugar : UserControl
    {

        public index parent;
        public Lugar lugar;

        public itemlugar(Lugar lugar, index parent)
        {

            this.parent = parent;
            this.lugar = lugar;

            string locationName = "-";


            Lugar temP = Read.Lugar(lugar.LugarID);
             if (temP.Nombre != null)
            {
                locationName = temP.Nombre;
            }
          

            InitializeComponent();

            label1.Text = lugar.Nombre;

            label3_1.Text = "Tipo:";
            label3_2.Text = lugar.Tipo;
           
            label2_2.Text = locationName;

            Update();

        }

       

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new lugar1(parent, lugar));
        }
    }
}
