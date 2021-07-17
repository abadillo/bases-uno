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
        public OrganizacionCaridad organizacion;
        public Subasta subasta;

        public miniitemorganizacion(OrganizacionCaridad organizacion, Subasta subasta ,index parent )
        {

            this.parent = parent;
            this.organizacion = organizacion;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = organizacion.Nombre;
            label2.Text = organizacion.Mision;
            label3.Text = subasta.Porcentaje(organizacion).ToString() + "%";

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
       
            subasta.EliminarOrganizacionCaridad(organizacion);
            parent.InsertForm(new subasta1_1(parent, subasta));
        }

       
    }
}
