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
using Engine;

namespace bases_uno.Views
{
    public partial class subastaadminl : Form
    {

        public index parent;

        public itemsubasta[] itemlist;
        
        public List<Subasta> list = Read.Subastas();

        public subastaadminl(index parent)
        {
            Validacion.ControlSubastas();
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Subastas Sin Cerrar";



            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                Subasta subasta = list[i];

                if (!subasta.Cerrado && !subasta.Cancelado)
                {
                    itemsubasta2 item = new itemsubasta2(subasta, parent);
                    item.Dock = DockStyle.Top;

                    dipanel1.Controls.Add(item);
                }

              
            }


            Update();
		}


      
    }
}
