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
    public partial class miniitemorganizacion : UserControl
    {
               
        public index parent;
        public Organizacion organizacion;
        public Subasta subasta;

        public miniitemorganizacion( Organizacion organizacion, Subasta subasta ,index parent )
        {

            this.parent = parent;
            this.organizacion = organizacion;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = organizacion.Nombre;
            label2_2.Text = organizacion.Descripcion;

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            subasta.EliminarOrganizacion(organizacion);
            parent.InsertForm(new subasta1_1(parent, subasta));
        }

       
    }
}
