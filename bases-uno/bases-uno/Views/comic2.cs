﻿using Engine;
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
    public partial class comic2 : Form
    {

        public index parent;

        public int id = 1;


        public comic2( index parent)
        {
            this.parent = parent;
            
            InitializeComponent();
			Comic comic = new Comic(id);

            label1.Text = "Comic: " + comic.Titlel;

            Update();
		}

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comic2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            comic1 mf = new comic1(parent);
            parent.InsertForm(mf);
        }
    }
}
