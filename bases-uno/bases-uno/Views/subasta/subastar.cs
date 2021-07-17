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
using Engine;

namespace bases_uno.Views
{
    public partial class subastar : Form
    {

        public index parent;
        public List<Local> list = Read.Locales();

        public subastar(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Subasta";

            comboBoxType.Items.AddRange(new object[] {
                "Presencial",
                "Virtual"
            });

            comboBoxLocal.Items.Add("0 Ninguno");

            for (int i = 0; i < list.Count; i++)
            {
                Local tmp = list[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxLocal.Items.Add(item);
            }

            comboBoxLocal.SelectedIndex = 0;

            Update();
        }

        #region Funciones
        private void Registrar()
        {
            try
            {

                string[] tokens = Validacion.ValidarCombo(comboBoxLocal).Split(' ');
                int localID = int.Parse(tokens[0]);

                string tipo = Validacion.ValidarCombo(comboBoxType);


                if (tipo == "Presencial" && localID == 0)
                {
                    panelOpcional.Visible = true;
                    throw new Exception("Debe seleccionar el local para realizar el evento");
                }

                //Console.WriteLine(Read.Local(localID).Nombre);

                Subasta subasta = new Subasta(
                    Validacion.ValidarDateTime(textBoxFecha,true),
                    Validacion.ValidarTime(textBoxHoraInicio,true),
                    Validacion.ValidarTime(textBoxHoraCierre,true),
                    tipo,
                    radioButtonCaridad.Checked,
                    false,
                    Read.Local(localID)               
                );

                subasta.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);
                parent.InsertForm(new subastal(parent));

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
        #endregion

        #region click botones y modificadores de campo
      
        private void btnadelante_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastal(parent));
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastal(parent));
        }

        private void textBoxFecha_Click(object sender, EventArgs e)
        {
            Acciones.EraseInput(textBoxFecha);
        }

        private void textBoxHoraCierre_Click(object sender, EventArgs e)
        {
            Acciones.EraseInput(textBoxHoraCierre);
        }


        private void textBoxHoraInicio_Click(object sender, EventArgs e)
        {
            Acciones.EraseInput(textBoxHoraInicio);
        }

        #endregion

    }
}
