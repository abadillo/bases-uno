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

namespace bases_uno.Views.Components
{
    public partial class itemsubasta : UserControl
    {

        public index parent;
        public Subasta subasta;

        public itemsubasta( Subasta subasta, index parent )
        {

            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();
                        
            label1.Text = subasta.Nombre;
           
            label2_1.Text = subasta.Proposito;
            label2_2.Text = subasta.FechaFundacion.Value.ToShortDateString();

            label3_1.Text = "Pagina Web: " + "\n" + "Telefono: ";
            label3_2.Text =  subasta.PaginaWeb + "\n" + subasta.Telefono.ToString();

            Update();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subasta1(parent, subasta));
        }

      
    }
}
