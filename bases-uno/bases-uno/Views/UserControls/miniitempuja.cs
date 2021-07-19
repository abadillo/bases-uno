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
    public partial class miniitempuja : UserControl
    {
               
     
        public Coleccionista coleccionista;

        public miniitempuja( Coleccionista coleccionista, float precio )
        {

           
            this.coleccionista = coleccionista;
            
            InitializeComponent();

            label1.Text = coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;

            label3.Text = precio + "$";

           

            Update();

        }


       

       
    }
}
