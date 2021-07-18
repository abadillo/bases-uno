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
    public partial class miniitemclub : UserControl
    {

        public index parent;
        public Club club;
        public Subasta subasta;
        public bool organizador;

        public miniitemclub(Club club, Subasta subasta ,index parent, bool organizador)
        {

            this.parent = parent;
            this.club = club;
            this.subasta = subasta;
            this.organizador = organizador;

            InitializeComponent();

            //Console.WriteLine(club.Telefono);
            label1.Text = club.Nombre;
            

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
       
            if (organizador)
                subasta.EliminarOrganizador(club);
            else
                subasta.EliminarInvitado(club);

            parent.InsertForm(new subastaplan1_2(parent, subasta));
        }

       
    }
}
