﻿using Engine.DBConnection;
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
using bases_uno.Views.Components;


namespace bases_uno.Views
{
    public partial class lugarl : Form
    {

        public index parent;

        public itemlugar[] itemlist;
        public List<Place> list = Query.Places();


        public lugarl(index parent)
        {
            this.parent = parent;

            InitializeComponent();
			
            label1.Text = "Listado: Lugares";


            for (int i = 0; i < list.Count; i++)
            {
                /// Console.WriteLine(list[i]);

                Components.itemlugar item = new Components.itemlugar(list[i], parent);

                flowLayoutPanel1.Controls.Add(item);
            }

            Update();
		}

    }
}