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
    public partial class itemclub : UserControl
    {

        public index parent;
        public Club club;

        public itemclub( Club club, index parent )
        {

            this.parent = parent;
            this.club = club;

            InitializeComponent();
                        
            label1.Text = club.Nombre;
           
            label2_1.Text = club.Proposito;
            label2_2.Text = club.FechaFundacion.Value.ToShortDateString();

            label3_1.Text = "Pagina Web: " + "\n" + "Telefono: ";
            label3_2.Text =  club.PaginaWeb + "\n" + club.Telefono.ToString();

            Update();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new club1(parent, club));
        }

      
    }
}
