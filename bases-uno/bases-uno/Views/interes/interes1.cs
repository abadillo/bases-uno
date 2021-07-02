﻿using Engine.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace bases_uno.Views
{
    public partial class interes1 : Form
    {
        

        public index parent;
        public Interest interes;

        public interes1(index parent, Interest interes)
        {
            this.parent = parent;
            this.interes = interes;

            InitializeComponent();
            
            textBoxID.Text = interes.ID.ToString();
            textBoxName.Text = interes.Name;
            textBoxDescription.Text = interes.Description;

            label1.Text = "Interes: " + interes.Name;
            Update();

           
        }

        private void Modificar()
        {
            interes.Name = textBoxName.Text;
            interes.Description = textBoxDescription.Text;

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Interes?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    interes.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    parent.InsertForm(new interes1(parent, interes));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Interes?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    interes.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new interesl(parent));
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

        public void EnableRadio(RadioButton input, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            input.Enabled = true;

        }



        private void btnadelante_Click(object sender, EventArgs e)
        {
           
            parent.InsertForm(new interes2(parent, interes));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            interesl form = new interesl(parent);
            parent.InsertForm(form);
        }


        private void iconButton17_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxName, iconButton17);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            EnableInput(textBoxDescription, iconButton1);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();

        }

        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }


        private void btncancelar_Click(object sender, EventArgs e)
        {
          
            parent.InsertForm(new interes1(parent, interes));
        }


        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}
