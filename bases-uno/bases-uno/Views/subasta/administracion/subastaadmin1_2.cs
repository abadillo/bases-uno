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
    public partial class subastaadmin1_2 : Form
    {
        
        public index parent;
        public Subasta subasta;

        public float precioMasAlto = 0;
        public Coleccionista coleccionistaGanador;

        public List<Coleccionista> listOrg = new List<Coleccionista>();
        public List<Participante> listPar = new List<Participante>();

        public bool flagCancelado = false;      // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)

        public Listado listado;
        public DuenoHistorico duenoHistorico;



        public subastaadmin1_2(index parent, Subasta subasta, Listado listado)
        {
            Validacion.ControlSubastas();
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            

            label1.Text = "Subasta: " + subasta.ID;

            this.listado = listado;

            precioMasAlto = listado.PrecioBase;


            #region set flags

            if (subasta.Cancelado)
                flagCancelado = true;

            if (subasta.Tipo == "Presencial")
                flagPresencial = true;

            if (subasta.Caridad)
                flagBenefica = true;

            #endregion


            #region use flags

            if (flagBenefica == false || flagPresencial == false)
            {
                //DisableFunciones("Esta subasta no es de tipo benefica, por lo tanto no deberia ver ninguna organizacion asociada \nSi observa alguna arriba, algo salio mal");
            }

            if (flagCancelado)
            {
                DisableFunciones("Esta subasta fue cancelada, no puede agregar objetos \nSi observa alguna arriba, algo salio mal");
            }


            #endregion

           
           
            listPar = subasta.Participantes();

            foreach (Participante participante in listPar)
            {
                Coleccionista coleccionista = participante.Coleccionista();

                string item = coleccionista.ID + " " + coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
                comboBoxColeccionista.Items.Add(item);
            }


            Update();
        }

        #region Funciones

        private void DisableFunciones(string mensaje)
        {
            label11.Text = mensaje;
          
            btnanadir.Enabled = false;
            panelAlerta.Visible = true;
        }

        private void Actualizar()
        {
            try
            {
                listado.PrecioVenta = precioMasAlto;
                listado.ParticipanteIDInscripcion = coleccionistaGanador.ID;
                listado.SubastaID = subasta.ID;


                listado.Update();


                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new subastaadmin1_1(parent, subasta));

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

        private void AnadirPuja() {

            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxColeccionista).Split(' ');
                int ColeccionistaID = int.Parse(tokens[0]);
                Coleccionista coleccionista = Read.Coleccionista(ColeccionistaID);


                // DuenoHistorico duenoHistorico = BuscarHistorico(coleccionista, tipo, int.Parse(tokens[1]));

                //for (int i = 0; i < this.listado.Count; i++)
                //   if (listado[i].DuenoHistoricoID == duenoHistorico.ID)
                //       throw new Exception("Ya este objeto esta en la lista");


                //validar esto


                //if (flagBenefica && precio < duenoHistorico.PrecioDolares)
                //{
                //    throw new Exception("El precio a subastar debe ser mayor al ultimo precio subastado");

                //}

                float precio = Validacion.ValidarFloat(textBoxPrecio, true);

                if (precio <= precioMasAlto)
                {
                    throw new Exception("El precio a subastar debe ser mayor al ultimo precio subastado");

                }

                coleccionistaGanador = coleccionista;
                precioMasAlto = precio;

                miniitempuja item = new miniitempuja(coleccionista, precio);
                item.Dock = DockStyle.Top;

                dipanel2.Controls.Add(item);
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
            parent.InsertForm(new subastaadmin1_1(parent, subasta));
        }

        #endregion

        #region click botones FontAwesome

        
        

        private void btnanadir_Click(object sender, EventArgs e)
        {
            AnadirPuja();
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            // cerrar o algo
            Actualizar();
            parent.InsertForm(new subastaadmin1_1(parent, subasta));
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
