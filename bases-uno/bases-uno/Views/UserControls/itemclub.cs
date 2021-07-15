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

            label1.Text = club.PaginaWeb;
            label2_2.Text = club.proposito;

            Update();

        }

      

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new club1(parent, club));
        }
    }
}
