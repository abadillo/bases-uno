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
    public partial class localr : Form
    {

        public index parent;
        public List<Lugar> listLug = Read.Lugares();
        public List<Coleccionista> listCol = Read.Coleccionistas();

        public localr(index parent)
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Local";

            comboBoxType.Items.AddRange(new object[] {
                "Alquilado",
                "De un Miembro"
            });


            // para la direccion
            

            for (int i = 0; i < listLug.Count; i++)
            {
                Lugar tmp = listLug[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxDireccion.Items.Add(item);
            }

            // para el dueño si lo requiere
            comboBoxColeccionista.Items.Add("0 Ninguno");
            
            for (int i = 0; i < listCol.Count; i++)
            {
                Coleccionista tmp = listCol[i];
                string item = tmp.ID + " " + tmp.PrimerNombre + " " + tmp.PrimerApellido;

                comboBoxColeccionista.Items.Add(item);
            }
            comboBoxColeccionista.SelectedIndex = 0;


            Update();
        }


        private void Registrar()
        {
            try
            {

                string[] tokens = Validacion.ValidarCombo(comboBoxDireccion).Split(' ');
                int LugarID = int.Parse(tokens[0]);

                tokens = Validacion.ValidarCombo(comboBoxColeccionista).Split(' '); 
                int DuenoID = int.Parse(tokens[0]);

                string tipo = Validacion.ValidarCombo(comboBoxType);


                if ( tipo == "De un Miembro" && DuenoID == 0)
                {
                    panelOpcional.Visible = true;
                    throw new Exception("Debe seleccionar un dueño del local");
                }                 

                Local local = new Local(
                    Validacion.ValidarNull(textBoxNombre),
                    Read.Lugar(LugarID),
                    tipo,
                    Read.Coleccionista(DuenoID)
                ); 
             
                local.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new locall(parent));

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

        #region click botones normales
        private void btnadelante_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new locall(parent));
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new locall(parent));
        }

        private void btncrear_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        #endregion
    }
}
