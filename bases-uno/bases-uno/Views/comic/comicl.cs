using Engine.Classes;
using Engine.DBConnection;
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
    public partial class comicl : Form
    {

        public index parent;

        public itemcomic[] itemlist;
        public List<Comic> list = Query.Comics();


        public comicl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Comics";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                Components.itemcomic item = new Components.itemcomic(list[i], parent);

                flowLayoutPanel1.Controls.Add(item);
            }

            Update();
		}


        private void comicl_Load(object sender, EventArgs e)
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
            /// comicl form = new comicl(parent);
            /// parent.InsertForm(form);
        }

     

      

        private void stpanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
