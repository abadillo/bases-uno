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
    public partial class miniitemclubALT : UserControl
    {
               
        public index parent;
        public Club club;
        public Subasta subasta;

        public miniitemclubALT( Club club, Subasta subasta ,index parent )
        {

            this.parent = parent;
            this.club = club;
            this.subasta = subasta;

            InitializeComponent();

            //Console.WriteLine(club.Telefono);
            label1.Text = club.Nombre;
            label2.Text = club.Telefono.ToString();
            label3.Text = Read.Lugar(club.LugarID).Nombre;

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            // subasta.EliminarClubes(organizacion);
            // club.Delete();
            // remover este de la lista y refrescar al que lo llamo
            parent.InsertForm(new subasta1_2(parent, subasta));
        }

       
    }
}
