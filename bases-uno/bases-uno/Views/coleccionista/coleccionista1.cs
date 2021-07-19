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

        public bool confirmarEdad = false;


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

            //Console.WriteLine(coleccionista.LugarNacimiento.ToString());
            //Console.WriteLine(coleccionista.LugarResidencia.ToString());

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
            comboBoxRepresentanteR.Items.Add("0 Ninguno");

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
            comboBoxRepresentanteC.Items.Add("0 Ninguno");

            for (int i = 0; i < listCol.Count; i++)
            {
                Coleccionista tmp = listCol[i];
                string item = tmp.ID + " " + tmp.PrimerNombre + " " + tmp.SegundoApellido;

                comboBoxRepresentanteC.Items.Add(item);

                if (tmp.ID == coleccionista.ColeccionistaRepresentanteID)
                    comboBoxRepresentanteC.SelectedItem = item;
            }
            if (coleccionista.ColeccionistaRepresentanteID == 0)
                comboBoxRepresentanteC.SelectedIndex = 0;


            int edad = Validacion.Edad(Validacion.ValidarDateTime(textBoxFechaNacimiento, true));

            if (edad < 18)
                panelOpcional.Visible = true;


            label1.Text = "Coleccionista: " + coleccionista.PrimerNombre + " " + coleccionista.SegundoNombre;
            Update();
           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {

                int edad = Validacion.Edad(Validacion.ValidarDateTime(textBoxFechaNacimiento, true));

                string[] tokens = Validacion.ValidarCombo(comboBoxLugarNacimiento).Split(' ');
                int LugarNID = int.Parse(tokens[0]);

                tokens = Validacion.ValidarCombo(comboBoxLugarResidencia).Split(' ');
                int LugarRID = int.Parse(tokens[0]);

                tokens = Validacion.ValidarCombo(comboBoxRepresentanteR).Split(' ');
                int RepresentanteRID = int.Parse(tokens[0]);

                tokens = Validacion.ValidarCombo(comboBoxRepresentanteC).Split(' ');
                int RepresentanteCID = int.Parse(tokens[0]);

                if (edad < 15 && confirmarEdad == false)
                {
                    panelOpcional.Visible = true;
                    confirmarEdad = true;
                    throw new Exception("Debe selecionar un representante por ser menor de edad\n\nDe no seleccionar ninguno, no podra partipar en ninguna subasta hasta cumplir el requerimiento de edad (18 años)");
                }

                if (RepresentanteCID != 0 && RepresentanteRID != 0)
                    throw new Exception("Debe selecionar solo un representante");
                

                coleccionista.PrimerNombre = Validacion.ValidarNull(textBoxPrimerNombre);
                coleccionista.SegundoNombre = textBoxSegundoNombre.Text;
                coleccionista.PrimerApellido = Validacion.ValidarNull(textBoxPrimerApellido);
                coleccionista.SegundoApellido =textBoxSegundoApellido.Text;
                coleccionista.FechaNacimiento = Validacion.ValidarDateTime(textBoxFechaNacimiento, true);
                coleccionista.Telefono = Validacion.ValidarLong(textBoxTelefono, true);
                coleccionista.LugarNacimiento = Read.Lugar(LugarNID).ID;
                coleccionista.LugarResidencia = Read.Lugar(LugarRID).ID;


                if (RepresentanteRID != 0)
                    coleccionista.RepresentanteID = Read.Representante(RepresentanteRID).ID;

                else if (RepresentanteCID != 0)
                    coleccionista.ColeccionistaRepresentanteID = Read.Coleccionista(RepresentanteCID).ID;
                    
               
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
        
        private void btnmodificar_Click_1(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionista1(parent, coleccionista));
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            Eliminar();
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

       
        private void iconButton5_Click(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxRepresentanteC, iconButton5);
            Acciones.EnableCombo(comboBoxRepresentanteR, iconButton5);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxLugarNacimiento, iconButton9);
            Acciones.EnableCombo(comboBoxLugarResidencia, iconButton9);
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxTelefono, iconButton4);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxSegundoApellido, iconButton3);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxSegundoNombre, iconButton2);
        }

        private void iconButton15_Click_1(object sender, EventArgs e)
        {
            // doc de indentidad no se modifica
        }

        #endregion

       
    }
}
