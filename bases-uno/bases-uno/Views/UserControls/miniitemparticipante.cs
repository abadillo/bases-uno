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
    public partial class miniitemparticipante : UserControl
    {
               
        public index parent;
        public Membresia membresia;
        public Subasta subasta;

        public miniitemparticipante(Membresia membresia, Subasta subasta ,index parent )
        {

            this.parent = parent;
            this.membresia = membresia;
            this.subasta = subasta;

            InitializeComponent();

            //label1.Text = membresia.Nombre;
            //label2.Text = membresia.Mision;
            //label3.Text = subasta.Porcentaje(membresia).ToString() + "%";

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
       
            //subasta.EliminarOrganizacionCaridad(membresia);
            parent.InsertForm(new subastaplan1_3(parent, subasta));
        }

       
    }
}
