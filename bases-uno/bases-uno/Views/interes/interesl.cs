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
    public partial class interesl : Form
    {

        public index parent;

        public iteminteres[] itemlist;
        
        public List<Interest> list = Query.Interests();



        public interesl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Intereses";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                Components.iteminteres item = new Components.iteminteres(list[i], parent);

                flowLayoutPanel1.Controls.Add(item);
            }

            Update();
		}


      
    }
}
