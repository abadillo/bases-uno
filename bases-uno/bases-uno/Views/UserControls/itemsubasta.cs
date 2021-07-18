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
    public partial class itemsubasta : UserControl
    {

        public index parent;
        public Subasta subasta;

        public itemsubasta( Subasta subasta, index parent )
        {

            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();
                        
            label1.Text = subasta.ID.ToString();
          
            label2_1.Text = subasta.Fecha.Value.ToShortDateString();

            string horaInicioStr = subasta.HoraInicio.Value.Hours.ToString() + ":" + subasta.HoraInicio.Value.Minutes.ToString();
            string horaCierreStr = subasta.HoraCierre.Value.Hours.ToString() + ":" + subasta.HoraCierre.Value.Minutes.ToString();

            label2_2.Text = horaInicioStr + " - " + horaCierreStr;

            string caridad = "No";

            if (subasta.Caridad)
                caridad = "Si";

            string cancelada = "No";

            if (subasta.Cancelado) 
                cancelada = "Si";
           
            label3_1.Text = "Tipo: " + "\n" + "Caridad: " + "\n" + "Cancelada: ";
            label3_2.Text =  subasta.Tipo + "\n" + caridad + "\n" + cancelada;

            Update();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1(parent, subasta));
        }

      
    }
}
