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

        public List<Lugar> listLug = Read.Lugares();
        public List<Coleccionista> listCol = Read.Coleccionistas();

        public local1(index parent, Local local )
        {
            this.parent = parent;
            this.local = local;

            InitializeComponent();

            label1.Text = "Local: " + local.Nombre;

            textBoxID.Text = local.ID.ToString();
            textBoxName.Text = local.Nombre;


            comboBoxType.Items.AddRange(new object[] {
                "Alquilado",
                "De un Miembro"
            });

            comboBoxType.SelectedItem = local.Tipo;


            // para la direccion
            for (int i = 0; i < listLug.Count; i++)
            {
                Lugar tmp = listLug[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxDireccion.Items.Add(item);
                
                if (tmp.ID == local.LugarID)
                    comboBoxDireccion.SelectedItem = item;
            }

            // para el dueño si tiene
            comboBoxColeccionista.Items.Add("0 Ninguno");

            for (int i = 0; i < listCol.Count; i++)
            {
                Coleccionista tmp = listCol[i];
                string item = tmp.ID + " " + tmp.PrimerNombre + " " + tmp.PrimerApellido;

                comboBoxDireccion.Items.Add(item);

                if (tmp.ID == local.ColeccionistaID)
                    comboBoxDireccion.SelectedItem = item;
            }
            if (local.ColeccionistaID == 0)
                comboBoxDireccion.SelectedIndex = 0;

            Update();

		}


        #region Funciones

        private void Modificar()
        { 
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxDireccion).Split(' ');
                int IDLocation = int.Parse(tokens[0]);

                tokens = comboBoxColeccionista.SelectedItem.ToString().Split(' ');
                int DuenoID = int.Parse(tokens[0]);

                string tipo = Validacion.ValidarCombo(comboBoxType);

                if (tipo == "De un Miembro" && DuenoID == 0)
                {
                    panelOpcional.Visible = true;
                    throw new Exception("Debe seleccionar un dueño del local");
                }

                local.Nombre = Validacion.ValidarNull(textBoxName);
                local.Tipo = Validacion.ValidarCombo(comboBoxType);
                local.LugarID = Read.Lugar(IDLocation).ID;
                local.ColeccionistaID = Read.Coleccionista(DuenoID).ID;


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
            //parent.InsertForm(new local2(parent, local));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new locall(parent));
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new local1(parent, local));
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
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
            Acciones.EnableCombo(comboBoxDireccion, iconButton1);
        }
        private void iconButton5_Click_1(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxColeccionista, iconButton5);
        }

        #endregion


    }
}
