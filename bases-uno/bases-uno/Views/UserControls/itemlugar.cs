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
    public partial class itemlugar : UserControl
    {

        public int id;
        public index parent;

        public itemlugar( Place lugar, index parent )
        {

            this.parent = parent;
            this.id = lugar.ID;

            InitializeComponent();
                        
            //label1.Text = lugar.Titlel;
           
            //label2.Text = lugar.Editor + "     " + lugar.PublicationDate.ToString();
           
            //label3.Text = "Volumen: " + ( (lugar.Volume == 0) ? lugar.Volume.ToString() : "" ) + "\n" + "Numero: " + lugar.Number.ToString() + "\n" + "Paginas: " + lugar.Pages.ToString();
           
            Update();

        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
            lugar1 mf = new lugar1(parent, id);
            parent.InsertForm(mf);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
