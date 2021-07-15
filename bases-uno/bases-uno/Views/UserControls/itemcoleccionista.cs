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
    public partial class itemcoleccionista : UserControl
    {
               
        public index parent;
        public Coleccionista coleccionista;

        public itemcoleccionista( Coleccionista coleccionista, index parent )
        {

            this.parent = parent;
            this.coleccionista = coleccionista;

            InitializeComponent();

            label1.Text = coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
            label2_2.Text = coleccionista.ID.ToString();

            Update();

        }

      

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionista1(parent, coleccionista));
        }
    }
}
