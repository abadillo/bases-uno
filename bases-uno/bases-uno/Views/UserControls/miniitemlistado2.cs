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
    public partial class miniitemlistado2 : UserControl
    {
               
        public index parent;
        public Listado listado;
        public DuenoHistorico duenoHistorico;

        public miniitemlistado2( Listado listado,index parent, bool permiso )
        {

            this.parent = parent;
            this.listado = listado;
            
            InitializeComponent();

            duenoHistorico = listado.DuenoHistorico();

            Comic comic = duenoHistorico.Comic();
            Coleccionable coleccionable = duenoHistorico.Coleccionable();

            if (comic != null)
                label1.Text = "Comic: " + comic.Title;
            else
                label1.Text = "Coleccionable: " + coleccionable.Nombre;


            label3.Text = listado.PrecioBase.ToString() + "$";

            if (listado.Subasta().Cerrado)
                iconButton1.Visible = false;

            Update();

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            //contacto.Delete();
            //remover este de la lista y refrescar al que lo llamo
            parent.InsertForm(new subastaadmin1_2(parent, listado.Subasta(),listado));
        }

       
    }
}
