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
    public partial class comic1_1 : Form
    {
        
        public index parent;
        public Comic comic;

        public List<Coleccionista> listCol = Read.Coleccionistas();
        public List<DuenoHistorico> listDue ;

        public bool flagAgregar = true;

        public comic1_1(index parent, Comic comic)
        {
            this.parent = parent;
            this.comic = comic;

            InitializeComponent();

            label1.Text = "Comic: " + comic.Title;



            listDue = Read.DuenosHistoricos(comic);


            for (int i = 0; i < listDue.Count; i++)
            {
               
                if (listDue[i].ComicID == comic.ID)
                {
                    flagAgregar = false;
                    miniitemdueno item = new miniitemdueno(listDue[i], parent);
                    item.Dock = DockStyle.Top;

                    dipanel2.Controls.Add(item);
                }

            }


            for (int i = 0; i < listCol.Count; i++)
            {
                Coleccionista coleccionista = listCol[i];

                string item = coleccionista.ID + " " + coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
                comboBoxColeccionista.Items.Add(item);

            }


            if (!flagAgregar)
                DisableFunciones("Este objeto ya tiene algun dueño, no puede agregarle dueños nuevo");
                        

            Update();

           
        }

        #region Funciones

        private void DisableFunciones(string mensaje)
        {
            label11.Text = mensaje;
            iconButton5.Visible = false;
            btnanadir.Enabled = false;
            panelAlerta.Visible = true;
        }


        private void Registrar()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxColeccionista).Split(' ');
                int DuenoID = int.Parse(tokens[0]);

                Coleccionista coleccionista = Read.Coleccionista(DuenoID);

                string significado = null;

                DuenoHistorico duenoHistorico = new DuenoHistorico(
                    DateTime.Now,
                    coleccionista,
                    comic,
                    0                
                    
                );

                duenoHistorico.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new comic1_1(parent, comic));

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
            //parent.InsertForm(new comic2(parent, comic));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new comic1(parent, comic));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
           
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new comic1_1(parent, comic));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion

    }
}
