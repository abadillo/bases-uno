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
    public partial class club1_1 : Form
    {
        
        public index parent;
        public Club club;
            
        public List<Interes> altListInt;                    // para los intereses ya del club
        public List<Interes> listInt = Read.Intereses();   // para el combo de interes

        public club1_1(index parent, Club club)
        {
            this.parent = parent;
            this.club = club;

            InitializeComponent();

            label1.Text = "Club: " + club.Nombre;


            // para los intereses ya del club

            altListInt = club.Intereses();
            
       
            for (int i = 0; i < altListInt.Count; i++)
            {
                //Console.WriteLine(altListInt[i].ID);
                miniiteminteres item = new miniiteminteres(altListInt[i], club, parent);
                item.Dock = DockStyle.Top;

                dipanel2.Controls.Add(item);
            }


            // para el combo de interes

            for (int i = 0; i < listInt.Count; i++)
            {
                Interes tmp = listInt[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxInteres.Items.Add(item);
            }


            Update();

           
        }

        #region Funciones

        private void Registrar()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxInteres).Split(' ');
                int InteresID = int.Parse(tokens[0]);


                Interes interes = Read.Interes(InteresID);

                for (int i = 0; i < altListInt.Count; i++)
                { 
                    if (interes.ID == altListInt[i].ID)          
                        throw new Exception("Ya este interes esta en la lista");
                    
                }

                club.AgregarInteres(interes);

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new club1_1(parent,club));

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
            parent.InsertForm(new club1_2(parent, club));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new club1(parent, club));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
        }


        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new club1_1(parent, club));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion

    }
}
