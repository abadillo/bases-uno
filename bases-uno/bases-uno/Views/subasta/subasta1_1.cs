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
            
        public List<Organizacion> altListInt;                    // para los organizaciones ya del subasta
        public List<Organizacion> listInt = Read.Organizaciones();   // para el combo de organizacion

        public subasta1_1(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.Nombre;


            // para los organizaciones ya del subasta

            altListInt = subasta.Organizaciones();
            
       
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
                Organizacion tmp = listInt[i];
                string item = tmp.ID + " " + tmp.Nombre;

                comboBoxOrganizacion.Items.Add(item);
            }


            Update();

           
        }

        #region Funciones

        private void Registrar()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxOrganizacion).Split(' ');
                int OrganizacionID = int.Parse(tokens[0]);


                Organizacion organizacion = Read.Organizacion(OrganizacionID);

                for (int i = 0; i < altListInt.Count; i++)
                { 
                    if (organizacion.ID == altListInt[i].ID)          
                        throw new Exception("Ya este organizacion esta en la lista");
                    
                }

                subasta.AgregarOrganizacion(organizacion);

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
