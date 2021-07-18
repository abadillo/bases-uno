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
    public partial class miniitemlistado : UserControl
    {
               
        public index parent;
        public Listado listado;
        

        public miniitemlistado( Listado listado,index parent )
        {

            this.parent = parent;
            this.listado = listado;
            
            InitializeComponent();

            DuenoHistorico duenoHistorico = listado.DuenoHistorico();

            Comic comic = duenoHistorico.Comic();
            Coleccionable coleccionable = duenoHistorico.Coleccionable();

            if (comic != null)
                label1.Text = "Comic: " + comic.Title;
            else
                label1.Text = "Coleccionable: " + coleccionable.Nombre;


            label2.Text = "Numero: " + listado.Orden.ToString();
            label3.Text = listado.PrecioBase.ToString() + "$";

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            // contacto.Delete();
            // remover este de la lista y refrescar al que lo llamo
            //parent.InsertForm(new coleccionista1(parent, Read.Coleccionista(duenoHistorico.ColeccionistaID)));
        }

       
    }
}
