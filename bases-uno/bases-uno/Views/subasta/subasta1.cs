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
    public partial class subasta1 : Form
    {
        
        public index parent;
        public Subasta subasta;
        public List<Local> listLoc = Read.Locales();


        public bool flagCancelado = false;      // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)

        public subasta1(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;

            #region fill combos and textfields


            string horaInicioStr = subasta.HoraInicio.Value.Hours.ToString() + ":" + subasta.HoraInicio.Value.Minutes.ToString();
            string horaCierreStr = subasta.HoraCierre.Value.Hours.ToString() + ":" + subasta.HoraCierre.Value.Minutes.ToString();


            textBoxID.Text = subasta.ID.ToString();
            textBoxFecha.Text = subasta.Fecha.Value.ToShortDateString();
            textBoxHoraInicio.Text = horaInicioStr;
            textBoxHoraCierre.Text = horaCierreStr;
            checkBoxCaridad.Checked = subasta.Caridad;
            checkBoxCancelado.Checked = subasta.Cancelado;

            comboBoxType.Items.AddRange(new object[] {
                "Presencial",
                "Virtual"
            });

            comboBoxType.SelectedItem = subasta.Tipo;


            comboBoxLocal.Items.Add("0 Ninguno");

            for (int i = 0; i < listLoc.Count; i++)
            {
                Local tmp = listLoc[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLocal.Items.Add(item);

                if (tmp.ID == subasta.LocalID)
                    comboBoxLocal.SelectedItem = item;
            }

            if (subasta.LocalID == 0)
                comboBoxLocal.SelectedIndex = 0;

            #endregion


            #region set flags

            if (subasta.Cancelado)
                flagCancelado = true;

            if (subasta.Tipo == "Presencial")
                flagPresencial = true;

            if (subasta.Caridad)
                flagBenefica = true;

            #endregion


            #region use flags

            if (flagPresencial)
                panelOpcional.Visible = true;

            #endregion


            Update();

           
        }

        #region Funciones

        private void Modificar()
        {
           
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxLocal).Split(' ');
                int LocalID = int.Parse(tokens[0]);

                string tipo = Validacion.ValidarCombo(comboBoxType);

                if (tipo == "Presencial" && LocalID == 0)
                {
                    panelOpcional.Visible = true;
                    throw new Exception("Debe seleccionar el local para realizar el evento");
                }

                DateTime fecha = Validacion.ValidarDateTime(textBoxFecha, true);
                TimeSpan horaInicio = Validacion.ValidarTime(textBoxHoraInicio, true);
                TimeSpan horaCierre = Validacion.ValidarTime(textBoxHoraCierre, true);

                Validacion.ValidadFechayHora(fecha, horaInicio, horaCierre);

                subasta.Fecha = fecha;
                subasta.HoraInicio = horaInicio;
                subasta.HoraCierre = horaCierre;
                subasta.Tipo = Validacion.ValidarCombo(comboBoxType);
                //subasta.Cancelado = checkBoxCancelado.Checked;
                subasta.Caridad = checkBoxCaridad.Checked;

                if (LocalID != 0)
                    subasta.LocalID = Read.Local(LocalID).ID;
                

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Subasta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    subasta.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new subasta1(parent, subasta));
                }
                else if (dialogResult == DialogResult.No)
                {
                    // do something else
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

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar esta Subasta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
         
                try
                {
                    subasta.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    parent.InsertForm(new subastal(parent));
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

        private void CancelarEvento()
        {

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar esta Subasta? \n\nSe eliminaran todas las organizaciones, pujas, invitaciones y de mas registros asociados a esta subasta", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    subasta.Cancelar();
                    MessageBox.Show("Subasta CANCELADA exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    parent.InsertForm(new subasta1(parent,subasta));
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
            parent.InsertForm(new subasta1_1(parent, subasta));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new subastal(parent));
        }


        private void btnmodificar_Click_1(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subasta1(parent, subasta));
        }

        private void btneliminar_Click_1(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void buttonCancelarEvento_Click(object sender, EventArgs e)
        {
            CancelarEvento();
        }
        #endregion


        #region click botones FontAwesome



        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }

        private void iconButton16_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxFecha, iconButton16);
        }

       

       
        private void iconButton4_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxHoraInicio, iconButton4);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxHoraCierre, iconButton1);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxType, iconButton2);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            Acciones.EnableCombo(comboBoxLocal, iconButton5);
        }

        private void iconButton18_Click(object sender, EventArgs e)
        {
            Acciones.EnableRadio(checkBoxCaridad, iconButton18);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            // este no se puede alterar por aqui ya que lleva a eliminacion de muchas cosa
        }

        #endregion

       
    }
}
