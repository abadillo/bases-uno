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
    public partial class subastal : Form
    {

        public index parent;

        public itemsubasta[] itemlist;
        
        public List<Subasta> list = Read.Subastaes();

        public subastal(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Subastaes";

            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                itemsubasta item = new itemsubasta(list[i], parent);
                item.Dock = DockStyle.Top;

                dipanel1.Controls.Add(item);
            }


            Update();
		}


      
    }
}
