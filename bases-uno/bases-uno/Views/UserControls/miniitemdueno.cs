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
    public partial class miniitemdueno : UserControl
    {
               
        public index parent;
        public DuenoHistorico duenoHistorico;
      

        public miniitemdueno( DuenoHistorico duenoHistorico,index parent )
        {

            this.parent = parent;
            this.duenoHistorico = duenoHistorico;
            
            InitializeComponent();

            Coleccionista coleccionista = Read.Coleccionista(duenoHistorico.ColeccionistaID);
            
            label1.Text = coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido + " " + coleccionista.ID;
          
            label2.Text = duenoHistorico.FechaRegistro.Value.ToShortDateString();
            label3.Text = duenoHistorico.PrecioDolares.ToString() + "$";

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            // contacto.Delete();
            // remover este de la lista y refrescar al que lo llamo
            parent.InsertForm(new coleccionista1(parent, Read.Coleccionista(duenoHistorico.ColeccionistaID)));
        }

       
    }
}
