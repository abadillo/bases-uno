﻿using Engine.Classes;
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
    public partial class subastaplan1_3 : Form
    {
        
        public index parent;
        public Subasta subasta;
            
        public List<Membresia> altListPar;                              // para los membresias ya de la subasta
        public List<Membresia> ListPar = Read.Membresias();             // para el combo de membresia

        public bool flagCancelado = false;      // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)



        public subastaplan1_3(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;

            subasta.AgregarParticipantes();
            //Participante part = Read.Participantes()

            //part.


            #region set flags

            if (subasta.Cancelado)
                flagCancelado = true;

            if (subasta.Tipo == "Presencial")
                flagPresencial = true;

            if (subasta.Caridad)
                flagBenefica = true;

            #endregion


            #region use flags

            if (flagBenefica == false || flagPresencial== false)
            {
                //DisableFunciones("Esta subasta no es de tipo benefica, por lo tanto no deberia ver ninguna organizacion asociada \nSi observa alguna arriba, algo salio mal");
            }
           
            if (flagCancelado)
            {
                DisableFunciones("Esta subasta fue cancelada, no puede agregar partipantes \nSi observa alguna arriba, algo salio mal");
            }


            #endregion


            LlenarComboMembresias();

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
                //string[] tokens = Validacion.ValidarCombo(comboBoxOrganizacion).Split(' ');
                //int OrganizacionID = int.Parse(tokens[0]);

                ////Membresia organizacion = Read.Membresia(OrganizacionID);

                //int porcentaje = int.Parse(Validacion.ValidarCombo(comboBoxPorcentaje));

                //for (int i = 0; i < altListPar.Count; i++)
                //{ 
                //    if (organizacion.ID == altListPar[i].ID)          
                //        throw new Exception("Ya este organizacion esta en la lista");
                    
                //}

                //subasta.AgregarMembresia(organizacion, porcentaje);

                //MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //parent.InsertForm(new subastaplan1_1(parent,subasta));

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

        private void LlenarPorcentajes()
        {

            var porcentajeRestante = 100;


            for (int i = 0; i < altListPar.Count; i++)
            {
                Membresia tmp = altListPar[i];
                //porcentajeRestante = porcentajeRestante - subasta.Porcentaje(tmp);
            }

            for (int n = 1; n <= porcentajeRestante; n++)
            {
                string item = n.ToString();
                comboBoxPorcentaje.Items.Add(item);

                if (n == porcentajeRestante)
                    comboBoxPorcentaje.SelectedItem = item ;

            }



            //Update();
        }


        private void LlenarComboMembresias()
        {




        }
        #endregion

        #region click botones normales

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1_3(parent, subasta));
        }
        private void btnatras_Click(object sender, EventArgs e)
        { 
            parent.InsertForm(new subastaplan1_2(parent, subasta));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
            LlenarPorcentajes();
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1_3(parent, subasta));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion

    }
}
