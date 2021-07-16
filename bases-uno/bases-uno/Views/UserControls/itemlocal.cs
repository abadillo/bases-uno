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
    public partial class itemlocal : UserControl
    {

        public index parent;
        public Local local;

        public itemlocal(Local local, index parent)
        {

            this.parent = parent;
            this.local = local;

            InitializeComponent();

            label1.Text = local.Nombre;
            label2_2.Text = Read.Lugar(local.LugarID).Nombre;

            label3_1.Text = "Tipo:";
            label3_2.Text = local.Tipo;


            string nombreDueno = "-";

            Coleccionista dueno = Read.Coleccionista(local.ColeccionistaID);
            Console.WriteLine(local.ColeccionistaID);
            if (dueno != null)
            {
                nombreDueno = dueno.PrimerNombre + " " + dueno.PrimerApellido;
            }

            label3_1.Text = "Tipo: " + "\n" + "Dueño: ";
            label3_2.Text = local.Tipo + "\n" + nombreDueno ;


            Update();

        }

       

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new local1(parent, local));
        }
    }
}
