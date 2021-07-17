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
    public partial class miniitemcontacto : UserControl
    {
               
        public index parent;
        public Contacto contacto;
        public Club club;

        public miniitemcontacto( Contacto contacto, Club club ,index parent )
        {

            this.parent = parent;
            this.contacto = contacto;
            this.club = club;

            InitializeComponent();

            //Console.WriteLine(contacto.Telefono);
            label1.Text = contacto.Plataforma;
            label2.Text = contacto.Telefono.ToString();
            label3.Text = contacto.Email;

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            contacto.Delete();
            // remover este de la lista y refrescar al que lo llamo
            parent.InsertForm(new club1_2(parent, club));
        }

       
    }
}
