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
    public partial class coleccionistar : Form
    {
        

        public index parent;
        public List<Lugar> listLug = Read.Lugares();
        public List<Representante> listRep = Read.Representantes();
        public List<Coleccionista> listCol = Read.Coleccionistas();

        public coleccionistar(  index parent )
        {
            this.parent = parent;
            InitializeComponent();
            label1.Text = "Registro Coleccionista";

            // combos lugares
            

            for (int i = 0; i < listLug.Count; i++)
            {
                Lugar tmp = listLug[i];
                string item = tmp.ID + " " + tmp.Nombre;

                // para combo de lugar de direccion
                comboBoxLugarResidencia.Items.Add(item);

                // para combo de lugar de nacionalidad
                comboBoxLugarNacimiento.Items.Add(item);

            }
            
            // combo representantes
            comboBoxRepresentanteR.Items.Add("0 Ninguno");

            for (int i = 0; i < listRep.Count; i++)
            {
                Representante tmp = listRep[i];
                string item = tmp.ID + " " + tmp.Nombre + " " + tmp.Apellido;

                comboBoxRepresentanteR.Items.Add(item);
            }
            comboBoxRepresentanteR.SelectedIndex = 0;

            // combo representantes
            comboBoxRepresentanteC.Items.Add("0 Ninguno");

            for (int i = 0; i < listCol.Count; i++)
            {
                Coleccionista tmp = listCol[i];
                string item = tmp.ID + " " + tmp.PrimerNombre + " " + tmp.SegundoApellido;

                comboBoxRepresentanteC.Items.Add(item);
            }
            comboBoxRepresentanteC.SelectedIndex = 0;


            Update();
        }

        #region Funciones
        private void Registrar()
        {
            try
            {
                Coleccionista coleccionista;

                int edad = Validacion.Edad(Validacion.ValidarDateTime(textBoxFechaNacimiento, true));

                string[] tokens = Validacion.ValidarCombo(comboBoxLugarNacimiento).Split(' ');
                int LugarNID = int.Parse(tokens[0]);

                tokens = Validacion.ValidarCombo(comboBoxLugarResidencia).Split(' ');
                int LugarRID = int.Parse(tokens[0]);

                tokens = Validacion.ValidarCombo(comboBoxRepresentanteR).Split(' ');
                int RepresentanteRID = int.Parse(tokens[0]);

                tokens = Validacion.ValidarCombo(comboBoxRepresentanteC).Split(' ');
                int RepresentanteCID = int.Parse(tokens[0]);

                //Console.WriteLine(RepresentanteRID + " " + RepresentanteCID);
                
                if (edad < 15 && RepresentanteCID == 0 && RepresentanteRID == 0)
                {
                    panelOpcional.Visible = true;
                    throw new Exception("Debe selecionar un representante por ser menor de edad");
                } 

                if (RepresentanteCID != 0 && RepresentanteRID != 0)
                    throw new Exception("Debe selecionar solo representante");
                


                if (RepresentanteRID != 0)
                {
                    coleccionista = new Coleccionista(
                        Validacion.ValidarInt(textBoxDocIdentidad, true),
                        Validacion.ValidarNull(textBoxPrimerNombre),
                        Validacion.ValidarNull(textBoxPrimerApellido),
                        Validacion.ValidarInt(textBoxTelefono, true),
                        Validacion.ValidarDateTime(textBoxFechaNacimiento, true),
                        Read.Lugar(LugarNID),
                        Read.Lugar(LugarRID),
                        Read.Representante(RepresentanteRID),
                        textBoxSegundoNombre.Text,
                        textBoxSegundoApellido.Text
                    );
                }
                else
                {
                
                     coleccionista = new Coleccionista(
                        Validacion.ValidarInt(textBoxDocIdentidad, true),
                        Validacion.ValidarNull(textBoxPrimerNombre),
                        Validacion.ValidarNull(textBoxPrimerApellido),
                        Validacion.ValidarInt(textBoxTelefono, true),
                        Validacion.ValidarDateTime(textBoxFechaNacimiento, true),
                        Read.Lugar(LugarNID),
                        Read.Lugar(LugarRID),
                        textBoxSegundoNombre.Text,
                        textBoxSegundoApellido.Text,
                        Read.Coleccionista(RepresentanteCID)
                     );
                }


                // Console.WriteLine("algo");
                coleccionista.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK ,MessageBoxIcon.Information);
                parent.InsertForm(new coleccionistal(parent));

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
        private void btncrear_Click_1(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionistal(parent));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new coleccionistal(parent));
        }

        private void textBoxFechaNacimiento_Click(object sender, EventArgs e)
        {
            Acciones.EraseInput(textBoxFechaNacimiento);
        }

        #endregion


    }
}
