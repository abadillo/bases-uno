using Engine.DBConnection;
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

namespace bases_uno.Views
{
    public partial class club2 : Form
    {

        public index parent;
        public Club club;

        public club2( index parent, Club club)
        {
            this.parent = parent;
            this.club = club;
            
            InitializeComponent();
           
            label1.Text = "Club: " + club.PaginaWeb;

            Update();
		}

       
        private void club2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet.club' table. You can move, or remove it, as needed.
            //this.clubTableAdapter.Fill(this.dataSet.club);

            //this.reportViewer1.RefreshReport();
        }


        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new club1(parent, club));
        }
    }
}
