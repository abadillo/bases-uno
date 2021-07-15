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
    public partial class itemorganizacion : UserControl
    {
               
        public index parent;
        public Organizacion organizacion;

        public itemorganizacion( Organizacion organizacion, index parent )
        {

            this.parent = parent;
            this.organizacion = organizacion;

            InitializeComponent();

            label1.Text = organizacion.Nombre;
            label2_2.Text = organizacion.Mision;

            Update();

        }

      

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new organizacion1(parent, organizacion));
        }
    }
}
