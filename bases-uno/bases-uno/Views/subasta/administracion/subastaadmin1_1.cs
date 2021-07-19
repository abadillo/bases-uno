using Engine.Classes;
using Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.DBConnection;
using System.Windows.Forms;
using bases_uno.Views.Components;


namespace bases_uno.Views
{
    public partial class subastaadmin1_1 : Form
    {
        
        public index parent;
        public Subasta subasta;
            
        public List<Listado> listados;                    // para los clubes organizadores a la subasta
      

        public bool flagCancelado = false;      // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)
        public bool flagCerrada = false;  

                
        public subastaadmin1_1(index parent, Subasta subasta)
        {
            Validacion.ControlSubastas();
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;

            listados = subasta.Listados();



            for (int i = 0; i < listados.Count; i++)
            {

                Listado listado = listados[i];

                miniitemlistado2 item = new miniitemlistado2(listado, parent);
                item.Dock = DockStyle.Top;

                if (listado.PrecioVenta != 0)

                    dipanel3.Controls.Add(item);
                else
                    dipanel2.Controls.Add(item);
               

                

            }
            
            
            #region set flags

            if (subasta.Cancelado)
                flagCancelado = true;

            if (subasta.Tipo == "Presencial")
                flagPresencial = true;

            if (subasta.Caridad)
                flagBenefica = true;

            if (subasta.Cerrado)
                flagCerrada = true;
            #endregion


            #region use flags

            if (flagCancelado)
            {
                DisableFunciones("Esta subasta fue cancelada, no puede agregar objetos \nSi observa alguna arriba, algo salio mal");
            }

            if (flagCerrada)
            {
                DisableFunciones("Esta subasta fue cerrada, no puede agregar ni modificar ningun atributo incluyendo organizaciones, clubes, objetos o partipantes");
            }
            #endregion


            Update();

        }

        #region Funciones

        private void DisableFunciones(string mensaje)
        {
           

            label11.Text = mensaje;
            panelAlerta.Visible = true;
        }

       
       
        #endregion

        #region click botones normales

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1_1(parent, subasta));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new subastaplan1_1(parent, subasta));
        }

        #endregion

        #region click botones FontAwesome

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1_2(parent, subasta));
        }

      
        #endregion


    }
}
