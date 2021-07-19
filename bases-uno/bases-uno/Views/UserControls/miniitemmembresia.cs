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

namespace bases_uno.Views.Components
{
    public partial class miniitemmembresia : UserControl
    {
               
        public index parent;
        public Membresia membresia;
        public Club club;
        public Participante participante = null;
       
        public miniitemmembresia(Membresia membresia, index parent, bool paraInvitados )
        {

            this.parent = parent;
            this.membresia = membresia;

            Coleccionista coleccionista = Read.Coleccionista(membresia.ColeccionistaID);
            club = Read.Club(membresia.ClubID);

            InitializeComponent();

            

            //Console.WriteLine(contacto.Telefono);
            label1.Text = coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
            label2.Text = coleccionista.ID.ToString();

            if (paraInvitados)
            {
                label3.Text =club.Nombre;
                label3_1.Visible = false;
            }
            else
            {
                string responsable = "no";

                if (membresia.ClubIDLider != 0)
                    responsable = "si";

                label3.Text = "Responsable? ";
                label3_1.Text = responsable;
            }

            Update();

        }

        public miniitemmembresia(Participante participante, index parent, bool paraInvitados)
        {
            this.participante = participante;

            this.parent = parent;
            this.membresia = participante.Membresia();

            Coleccionista coleccionista = Read.Coleccionista(membresia.ColeccionistaID);
            club = Read.Club(membresia.ClubID);

            InitializeComponent();



            //Console.WriteLine(contacto.Telefono);
            label1.Text = coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
            label2.Text = coleccionista.ID.ToString();

            if (paraInvitados)
            {
                label3.Text = club.Nombre;
                label3_1.Visible = false;
            }
            else
            {
                string responsable = "no";

                if (membresia.ClubIDLider != 0)
                    responsable = "si";

                label3.Text = "Responsable? ";
                label3_1.Text = responsable;
            }

            Update();

        }

        private void CerrarMembresia()
        {
            if (participante == null)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea retirar a este coleccionista de este club (Cerrar Membresia)?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)

                    try
                    {

                        membresia.FechaRetiro = DateTime.Now;

                        membresia.Update();

                        MessageBox.Show("Retiro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea retirar a este coleccionista de esta subasta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)

                    try
                    {
                        participante.Delete();

                        MessageBox.Show("Retiro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CerrarMembresia();
            // remover este de la lista y refrescar al que lo llamo
            if (participante == null)
            {
                parent.InsertForm(new club1_3(parent, club));
            }
            else
            {
                parent.InsertForm(new subastaplan1_3(parent, participante.Subasta()));
            }
        }

       
    }
}
