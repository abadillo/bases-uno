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
    public partial class itemrepresentante : UserControl
    {
               
        public index parent;
        public Representante representante;

        public itemrepresentante( Representante representante, index parent )
        {

            this.parent = parent;
            this.representante = representante;

            InitializeComponent();

            label1.Text = representante.Nombre;
            label2_2.Text = representante.Apellido;

            Update();

        }

      

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new representante1(parent, representante));
        }
    }
}
