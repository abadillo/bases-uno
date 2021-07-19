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
    public partial class itemsubasta2 : UserControl
    {

        public index parent;
        public Subasta subasta;

        public itemsubasta2( Subasta subasta, index parent )
        {

            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();
                        
            label1.Text = subasta.ID.ToString();
          
            label2_1.Text = subasta.Fecha.Value.ToShortDateString();

            string horaInicioStr = subasta.HoraInicio.Value.Hours.ToString() + ":" + subasta.HoraInicio.Value.Minutes.ToString();
            string horaCierreStr = subasta.HoraCierre.Value.Hours.ToString() + ":" + subasta.HoraCierre.Value.Minutes.ToString();

            label2_2.Text = horaInicioStr + " - " + horaCierreStr;


            int clubes = subasta.Organizadores().Count + subasta.ClubesInvitados().Count;
            int participantes = subasta.Participantes().Count;
            int objetos = subasta.Listados().Count;


            label3_1.Text = "Nº Clubes: " + "\n" + "Nº Partipantes: " + "\n" + "Nº Objetos: ";
            label3_2.Text =  clubes + "\n" + participantes + "\n" + objetos;

            Update();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaadmin1(parent, subasta));
        }

      
    }
}
