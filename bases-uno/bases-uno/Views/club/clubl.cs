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
    public partial class clubl : Form
    {

        public index parent;

        public itemclub[] itemlist;
        
        public List<Club> list = Read.Clubes();

        public clubl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Clubes";

            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                itemclub item = new itemclub(list[i], parent);
                item.Dock = DockStyle.Top;

                dipanel1.Controls.Add(item);
            }


            Update();
		}


      
    }
}
