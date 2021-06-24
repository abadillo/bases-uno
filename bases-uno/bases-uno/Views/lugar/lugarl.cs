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
using bases_uno.Views.Components;


namespace bases_uno.Views
{
    public partial class lugarl : Form
    {

        public index parent;

        public itemlugar[] itemlist;
        public List<Place> list = Query.Places();


        public lugarl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Lugares";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                Components.itemlugar item = new Components.itemlugar(list[i], parent);

                flowLayoutPanel1.Controls.Add(item);
            }

            Update();
		}


        private void lugarl_Load(object sender, EventArgs e)
        {
          

        }



        private void hrpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
           
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            /// lugarl mf = new lugarl(parent);
            /// parent.InsertForm(mf);
        }

     

      

        private void stpanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
