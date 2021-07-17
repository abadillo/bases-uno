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
    public partial class miniiteminteres : UserControl
    {
               
        public index parent;
        public Interes interes;
        public Club club;

        public miniiteminteres( Interes interes, Club club ,index parent )
        {

            this.parent = parent;
            this.interes = interes;
            this.club = club;

            InitializeComponent();

            label1.Text = interes.Nombre;
            label2_2.Text = interes.Descripcion;

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            club.EliminarInteres(interes);
            parent.InsertForm(new club1_1(parent, club));
        }

       
    }
}
