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

        public List<Comic> list = Read.Comics();

        public comicl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Comics";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                itemcomic item = new itemcomic(list[i], parent);
                item.Dock = DockStyle.Top;                

                dipanel1.Controls.Add(item);
            }

            Update();
		}


     

      
    }
}
