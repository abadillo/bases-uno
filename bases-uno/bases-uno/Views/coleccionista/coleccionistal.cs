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
    public partial class coleccionistal : Form
    {

        public index parent;
                
        public List<Coleccionista> list = Read.Coleccionistas();

        public coleccionistal(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Coleccionistas";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                itemcoleccionista item = new itemcoleccionista(list[i], parent);
                item.Dock = DockStyle.Top;

                dipanel1.Controls.Add(item);
            }


            Update();
		}


      
    }
}
