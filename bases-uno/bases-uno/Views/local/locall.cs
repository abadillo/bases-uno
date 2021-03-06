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
    public partial class locall : Form
    {

        public index parent;

        public List<Local> list = Read.Locales();


        public locall(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Locales";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                itemlocal item = new itemlocal(list[i], parent);
                item.Dock = DockStyle.Top;

                dipanel1.Controls.Add(item);
            }

            Update();
		}

    }
}
