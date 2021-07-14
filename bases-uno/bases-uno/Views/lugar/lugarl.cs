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
        public List<Lugar> list = Read.Lugares();


        public lugarl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Lugares";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                itemlugar item = new itemlugar(list[i], parent);
                item.Dock = DockStyle.Top;

                dipanel1.Controls.Add(item);
            }

            Update();
		}

    }
}
