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
    public partial class local1 : Form
    {

        public index parent;
        public Local local;
        public List<Local> list = Read.Locales();

        public local1(index parent, Local local )
        {
            this.parent = parent;
            this.local = local;

            InitializeComponent();

            label1.Text = "Local: " + local.Nombre;

            textBoxID.Text = local.ID.ToString();
            textBoxName.Text = local.Nombre;

            comboBoxType.Items.AddRange(new object[] {
                "Pais",
                "Estado",
                "Ciudad",
                "Direccion"
            });

            comboBoxType.SelectedItem = local.Tipo;


            comboBoxLocal.Items.Add("0 Ninguno");
           

            for (int i = 0; i < list.Count; i++)
            {
                Local tmp = list[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLocal.Items.Add(item);
                
                if (tmp.ID == local.LocalID)
                    comboBoxLocal.SelectedItem = item;
            }
            if (local.LocalID == 0)
                comboBoxLocal.SelectedIndex = 0;

            Update();

		}


        #region Funciones

        private void Modificar()
        { 
            try
            {
                string[] tokens = comboBoxLocal.SelectedItem.ToString().Split(' ');
                int IDLocation = int.Parse(tokens[0]);

                local.Nombre = Validacion.ValidarNull(textBoxName);
                local.Tipo = Validacion.ValidarCombo(comboBoxType);
                local.LocalID = IDLocation;
                
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este local?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    local.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new local1(parent, local));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este local?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    local.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    parent.InsertForm(new locall(parent));
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
            parent.InsertForm(new local2(parent, local));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new locall(parent));
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
            parent.InsertForm(new local1(parent, local));
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
            Acciones.EnableCombo(comboBoxLocal, iconButton1);
        }
        #endregion
    }
}
