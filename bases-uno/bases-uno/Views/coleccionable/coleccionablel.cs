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
    public partial class coleccionablel : Form
    {

        public index parent;

        public itemcoleccionable[] itemlist;
        public List<Coleccionable> list = Query.Coleccionables();


        public coleccionablel(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Coleccionables";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                itemcoleccionable item = new itemcoleccionable(list[i], parent);
                item.Dock = DockStyle.Top;                

                dipanel1.Controls.Add(item);
            }

            Update();
		}


     

      
    }
}
