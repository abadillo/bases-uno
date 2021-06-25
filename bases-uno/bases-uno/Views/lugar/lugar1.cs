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

namespace bases_uno.Views
{
    public partial class lugar1 : Form
    {

        public int id;

        public index parent;
        public Place lugar;
       

        public lugar1(index parent, int id )
        {
            this.parent = parent;
            this.id = id;

            InitializeComponent();
			Place lugar = new Place(id);
            textBoxID.Text = lugar.ID.ToString();
            textBoxName.Text = lugar.Name;
            textBoxLocationID.Text = lugar.LocationID.ToString();
            comboBoxType.SelectedItem = lugar.Type;

            label1.Text = "Lugar: " + lugar.Name;
            Update();

            this.lugar = lugar;
		}

      

        private void Modificar()
        {
            lugar.Name = textBoxName.Text;
            lugar.LocationID = int.Parse(textBoxLocationID.Text);
            lugar.Type = comboBoxType.SelectedItem.ToString(); 

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Lugar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    lugar.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lugar1 form = new lugar1(parent, lugar.ID);
                    parent.InsertForm(form);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }


        }


        private void Eliminar()
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Lugar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    lugar.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lugarl form = new lugarl(parent);
                    parent.InsertForm(form);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }
     

        public void EnableInput(TextBox input, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            input.ReadOnly = false;
            input.ForeColor = Color.Black;
            input.BackColor = Color.LightGray;

        }

        public void EnableCombo(ComboBox combo, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            combo.Enabled = true;

        }



        private void btnadelante_Click(object sender, EventArgs e)
        {
            lugar2 form = new lugar2(parent, id);
            parent.InsertForm(form);
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            lugarl form = new lugarl(parent);
            parent.InsertForm(form);
        }

        private void iconButton17_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxName, iconButton17);
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            EnableCombo(comboBoxType, iconButton15);
        }

       

        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            lugar1 form = new lugar1(parent, lugar.ID);
            parent.InsertForm(form);
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxLocationID, iconButton1);

        }
    }
}
