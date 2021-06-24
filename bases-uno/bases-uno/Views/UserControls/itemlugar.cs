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
                        
            label1.Text = lugar.Name;
            label2.Text = lugar.Type;
            label3.Text = "Localidad: " + lugar.LocationID;

            Update();

        }

        private void btnadelante_Click(object sender, EventArgs e)
        {
            lugar1 form = new lugar1(parent, id);
            parent.InsertForm(form);
        }

    }
}
