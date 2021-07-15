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


namespace bases_uno.Views
{
    public partial class coleccionista1 : Form
    {
        
        public index parent;
        public Coleccionista coleccionista;

        public List<Lugar> listLug = Read.Lugares();
        public List<Representante> listRep = Read.Representantes();
        public List<Coleccionista> listCol = Read.Coleccionistas();

        public coleccionista1(index parent, Coleccionista coleccionista)
        {
            this.parent = parent;
            this.coleccionista = coleccionista;

            InitializeComponent();

            textBoxDocIdentidad.Text = coleccionista.ID.ToString();
            textBoxPrimerNombre.Text = coleccionista.PrimerNombre;
            textBoxSegundoNombre.Text = coleccionista.SegundoNombre;
            textBoxPrimerApellido.Text = coleccionista.PrimerApellido;
            textBoxSegundoApellido.Text = coleccionista.SegundoApellido;
            textBoxFechaNacimiento.Text = coleccionista.FechaNacimiento.Value.ToShortDateString();
            textBoxTelefono.Text = coleccionista.Telefono.ToString();

            // combos lugares
            for (int i = 0; i < listLug.Count; i++)
            {
                Lugar tmp = listLug[i];
                string item = tmp.ID + " " + tmp.Nombre;

                // para combo de lugar de direccion
                comboBoxLugarResidencia.Items.Add(item);

                if (tmp.ID == coleccionista.LugarResidencia)
                    comboBoxLugarResidencia.SelectedItem = item;

                // para combo de lugar de nacionalidad
                comboBoxLugarNacimiento.Items.Add(item);

                if (tmp.ID == coleccionista.LugarNacimiento)
                    comboBoxLugarNacimiento.SelectedItem = item;
            }

            // combo representantes
            for (int i = 0; i < listRep.Count; i++)
            {
                Representante tmp = listRep[i];
                string item = tmp.ID + " " + tmp.Nombre + " " + tmp.Apellido;

                comboBoxRepresentanteR.Items.Add(item);

                if (tmp.ID == coleccionista.RepresentanteID)
                    comboBoxRepresentanteR.SelectedItem = item;
            }
            if (coleccionista.RepresentanteID == 0)
                comboBoxRepresentanteR.SelectedIndex = 0;

            // combo coleccionistas
            for (int i = 0; i < listCol.Count; i++)
            {
                Coleccionista tmp = listCol[i];
                string item = tmp.ID + " " + tmp.PrimerNombre + " " + tmp.SegundoApellido;

                comboBoxRepresentanteC.Items.Add(item);

                if (tmp.ID == coleccionista.RepresentanteID)
                    comboBoxRepresentanteC.SelectedItem = item;
            }
            if (coleccionista.ColeccionistaRepresentanteID == 0)
                comboBoxRepresentanteC.SelectedIndex = 0;


            label1.Text = "Coleccionista: " + coleccionista.PrimerNombre + " " + coleccionista.SegundoNombre;
            Update();
           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {

                coleccionista.PrimerNombre = Validacion.ValidarNull(textBoxPrimerNombre);
                coleccionista.SegundoNombre = Validacion.ValidarNull(textBoxSegundoNombre);
                coleccionista.PrimerApellido = Validacion.ValidarNull(textBoxPrimerApellido);
                coleccionista.SegundoApellido = Validacion.ValidarNull(textBoxSegundoApellido);
                coleccionista.FechaNacimiento = Validacion.ValidarDateTime(textBoxFechaNacimiento, true);
                coleccionista.Telefono = Validacion.ValidarInt(textBoxTelefono, true);



                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Coleccionista?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    coleccionista.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new coleccionista1(parent, coleccionista));
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Coleccionista?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    coleccionista.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new coleccionistal(parent));
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
            //parent.InsertForm(new coleccionista2(parent, coleccionista));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new coleccionistal(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionista1(parent, coleccionista));
        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
        #endregion

        #region click botones FontAwesome

        private void iconButton17_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxPrimerNombre, iconButton17);
        }
       
        private void iconButton16_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxFechaNacimiento, iconButton16);
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxPrimerApellido, iconButton1);
        }

        private void iconButton15_Click(object sender, EventArgs e)
        {
            //Acciones.EnableInput(textBoxDocIdentidad, iconButton15);
        }
        #endregion
    }
}
