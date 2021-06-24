﻿using Engine.Classes;
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
    public partial class interesr : Form
    {

        public double cambioeuro = 0.84;

        public index parent;
        public Interest interes = new Interest(0);

        public interesr(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Interes";
            Update();
        }
       

       

        private void registrar()
        {
            try
            {

                //Console.WriteLine(radioButton1.Checked);

                interes.Name = textBoxName.Text;
                interes.Description = textBoxDescription.Text;

                interes.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);

                // interes1 form = new interes1( new Interes() );
                interesl form = new interesl(parent);
                parent.InsertForm(form);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            registrar();

        }
        private void btnadelante_Click(object sender, EventArgs e)
        {
            registrar();
        }


        private void btncancelar_Click(object sender, EventArgs e)
        {
            interesl form = new interesl(parent);
            parent.InsertForm(form);
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            interesl form = new interesl(parent);
            parent.InsertForm(form);
        }
    }
}