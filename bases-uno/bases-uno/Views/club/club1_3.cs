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
using Engine.DBConnection;
using System.Windows.Forms;
using bases_uno.Views.Components;


namespace bases_uno.Views
{
    public partial class club1_3 : Form
    {
        
        public index parent;
        public Club club;

        public List<Membresia> listMem;                                  // para la lista de membresias
        public List<Membresia> listMemAct = new List<Membresia>();                                  // para la lista de membresias

        public List<Coleccionista> listCol = Read.Coleccionistas();      // para el combo de coleccionistas



        public club1_3(index parent, Club club)
        {
            this.parent = parent;
            this.club = club;

            InitializeComponent();

            label1.Text = "Club: " + club.Nombre;


            listMem = Read.Membresias(club);


            foreach (Membresia membresia in listMem)
            {
                if (membresia.FechaRetiro == null)
                    listMemAct.Add(membresia);
            }


            foreach (Membresia membresia1 in listMemAct)
            {
                Console.WriteLine(membresia1.FechaRetiro);

                miniitemmembresia item = new miniitemmembresia(membresia1, parent);
                item.Dock = DockStyle.Top;

                dipanel2.Controls.Add(item);
            }




            for (int i = 0; i < listCol.Count; i++)
            {
                Coleccionista tmp = listCol[i];
                string item = tmp.ID + " " + tmp.PrimerNombre + " " + tmp.PrimerApellido + " " + Validacion.Edad(tmp.FechaNacimiento.Value);

                comboBoxColeccionista.Items.Add(item);

            }



            Update();

           
        }

        #region Funciones

        private void Registrar()
        {
            try
            {

                string[] tokens = Validacion.ValidarCombo(comboBoxColeccionista).Split(' ');
                int ColeccionistaID = int.Parse(tokens[0]);

                bool responsable = checkBoxResponsable.Checked;

                Coleccionista coleccionista = Read.Coleccionista(ColeccionistaID);

                for (int i = 0; i < listMemAct.Count; i++)
                    if (coleccionista.ID == listMemAct[i].ColeccionistaID)
                        throw new Exception("Ya este coleccionista esta en la lista");


                if (responsable && (Validacion.Edad(coleccionista.FechaNacimiento.Value) < 18))
                    throw new Exception("Este coleccionitas no puede ser responsable del club por ser menor de edad");
                

                Membresia membresia;

                if (responsable)
                {
                    membresia = new Membresia(
                    coleccionista,
                    club,
                    DateTime.Now,
                    textBoxEmail.Text,
                    null,
                    club
                    );
                }
                else {
                    membresia = new Membresia(
                    coleccionista,
                    club,
                    DateTime.Now,
                    textBoxEmail.Text,
                    null,
                    null
                    );
                }


                // club.AgregarInteres(coleccionista);

                membresia.Insert();

                MessageBox.Show("Registro Exitoso\n\nBienvenido '" + coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido + "' al club '" + club.Nombre + "'", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new club1_3(parent, club));

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

        #region click botones normales

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new club2(parent, club));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new club1_2(parent, club));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
        }


        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new club1_3(parent, club));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        } 
        #endregion
    }
}
