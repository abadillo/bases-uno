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
using System.Windows.Forms;
using Engine.DBConnection;
using bases_uno.Views.Components;


namespace bases_uno.Views
{
    public partial class lugar1 : Form
    {

        public index parent;
        public Lugar lugar;
        public List<Lugar> list = Read.Lugares();

        public lugar1(index parent, Lugar lugar )
        {
            this.parent = parent;
            this.lugar = lugar;

            InitializeComponent();

            label1.Text = "Lugar: " + lugar.Nombre;

            textBoxID.Text = lugar.ID.ToString();
            textBoxName.Text = lugar.Nombre;

            comboBoxType.Items.AddRange(new object[] {
                "Pais",
                "Estado",
                "Ciudad",
                "Direccion"
            });

            comboBoxType.SelectedItem = lugar.Tipo;


            comboBoxLugar.Items.Add("0 Ninguno");
           

            for (int i = 0; i < list.Count; i++)
            {
                Lugar tmp = list[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLugar.Items.Add(item);
                
                if (tmp.ID == lugar.LugarID)
                    comboBoxLugar.SelectedItem = item;
            }
            if (lugar.LugarID == 0)
                comboBoxLugar.SelectedIndex = 0;

            Update();

		}


        #region Funciones

        private void Modificar()
        { 
            try
            {
                string[] tokens = comboBoxLugar.SelectedItem.ToString().Split(' ');
                int IDLocation = int.Parse(tokens[0]);

                lugar.Nombre = Validacion.ValidarNull(textBoxName);
                lugar.Tipo = Validacion.ValidarCombo(comboBoxType);
                lugar.LugarID = IDLocation;
                
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este lugar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    lugar.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new lugar1(parent, lugar));
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error de tipo de dato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error con base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Eliminar()
        {

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este lugar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    lugar.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    parent.InsertForm(new lugarl(parent));
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
        #endregion

        #region click botones normales
        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new lugar2(parent, lugar));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new lugarl(parent));
        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new lugar1(parent, lugar));
        }
        #endregion

        #region click botones FontAwesome

        private void iconButton17_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxName, iconButton17);
        }
        private void iconButton15_Click(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxType, iconButton15);
        }
        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxLugar, iconButton1);
        }
        #endregion
    }
}
