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
    public partial class subasta1_1 : Form
    {
        
        public index parent;
        public Subasta subasta;
            
        public List<OrganizacionCaridad> altListInt;                    // para los organizaciones ya del subasta
        public List<OrganizacionCaridad> listInt = Read.OrganizacionesCaridad();   // para el combo de organizacion

        public bool flagCancelado = false;      // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)



        public subasta1_1(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;


            // para los organizaciones ya del subasta

            altListInt = subasta.OrganizacionesCaridad();
            
       
            for (int i = 0; i < altListInt.Count; i++)
            {
                //Console.WriteLine(altListInt[i].ID);
                miniitemorganizacion item = new miniitemorganizacion(altListInt[i], subasta, parent);
                item.Dock = DockStyle.Top;

                dipanel2.Controls.Add(item);
            }


            // para el combo de organizacion

            for (int i = 0; i < listInt.Count; i++)
            {
                OrganizacionCaridad tmp = listInt[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxOrganizacion.Items.Add(item);
            }


            #region set flags

            if (subasta.Cancelado)
                flagCancelado = true;

            if (subasta.Tipo == "Presencial")
                flagPresencial = true;

            if (subasta.Caridad)
                flagBenefica = true;

            #endregion


            #region use flags


            if (flagPresencial == false || flagBenefica == false)
            {
                panelAlerta.Visible = true;
                label7.Text = "Esta subasta es de tipo presencial no benefica o es de tipo virtual, por lo tanto no deberia ver ninguna organizacion asociada \n Si observa alguna arriba, algo salio mal";
            }

            if (flagCancelado)
            {
                panelAlerta.Visible = true;
                label7.Text = "Esta subasta fue cancelada, no puede agregar organizaciones \n Si observa alguna arriba, algo salio mal";

            }


            #endregion


            Update();

           
        }

        #region Funciones

        private void Registrar()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxOrganizacion).Split(' ');
                int OrganizacionID = int.Parse(tokens[0]);


                OrganizacionCaridad organizacion = Read.OrganizacionCaridad(OrganizacionID);

                for (int i = 0; i < altListInt.Count; i++)
                { 
                    if (organizacion.ID == altListInt[i].ID)          
                        throw new Exception("Ya este organizacion esta en la lista");
                    
                }

                int porcentaje = 100; 

                subasta.AgregarOrganizacionCaridad(organizacion, porcentaje);

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new subasta1_1(parent,subasta));

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
            parent.InsertForm(new subasta1_2(parent, subasta));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new subasta1(parent, subasta));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
        }


        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subasta1_1(parent, subasta));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion

    }
}
