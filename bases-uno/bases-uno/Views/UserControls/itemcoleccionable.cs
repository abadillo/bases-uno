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
    public partial class itemcoleccionable : UserControl
    {
               
        public index parent;
        public Coleccionable coleccionable;

        public itemcoleccionable( Coleccionable coleccionable, index parent )
        {

            this.parent = parent;
            this.coleccionable = coleccionable;

            InitializeComponent();

            label1.Text = coleccionable.Nombre;
            label2_2.Text = coleccionable.Descripcion;

            Update();

        }

      

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionable1(parent, coleccionable));
        }
    }
}
