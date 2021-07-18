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
    public partial class subastaplan1_4 : Form
    {
        
        public index parent;
        public Subasta subasta;

        public List<Participante> listPar;
        public List<Coleccionista> listOrg;

        public bool flagCancelado = false;      // true if cancelado, false if no cancelado
        public bool flagPresencial = false;      // true if presencial, false if virtual
        public bool flagBenefica = false;            // true if benefica, false if regular (o virtual)

        public List<Listado> listado = null;


        public int orden = 0;


        public subastaplan1_4(index parent, Subasta subasta)
        {
            this.parent = parent;
            this.subasta = subasta;

            InitializeComponent();

            label1.Text = "Subasta: " + subasta.ID;


            listado = subasta.Listados();


            for (int i = 0; i < listado.Count; i++)
            {
                miniitemlistado item = new miniitemlistado(listado[i], parent);
                item.Dock = DockStyle.Top;

                dipanel2.Controls.Add(item);


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

            if (flagBenefica == false || flagPresencial == false)
            {
                //DisableFunciones("Esta subasta no es de tipo benefica, por lo tanto no deberia ver ninguna organizacion asociada \nSi observa alguna arriba, algo salio mal");
            }

            if (flagCancelado)
            {
                DisableFunciones("Esta subasta fue cancelada, no puede agregar objetos \nSi observa alguna arriba, algo salio mal");
            }


            #endregion




            List<Club> clubesOrg = subasta.Organizadores();

            for (int i = 0; i < clubesOrg.Count; i++)
            {
                List<Membresia> membresias = Read.Membresias(clubesOrg[i]);

                for (int n = 0; n < membresias.Count; n++) {
                    listOrg.Add(Read.Coleccionista(membresias[n].ColeccionistaID));
                }
                
            }

            for (int i = 0; i < listOrg.Count; i++)
            {
                Coleccionista coleccionista = listOrg[i];

                string item = coleccionista.ID + " " + coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
                comboBoxObjeto.Items.Add(item);
            }



            if (flagBenefica)
            {
                listPar = subasta.Participantes();


                for (int i = 0; i < listPar.Count; i++)
                {
                    Coleccionista coleccionista = listPar[i].Coleccionista();

                    string item = coleccionista.ID + " " + coleccionista.PrimerNombre + " " + coleccionista.PrimerApellido;
                    comboBoxObjeto.Items.Add(item);

                }
            }
           


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

        private void LlenarObjetos()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxObjeto).Split(' ');
                int DuenoID = int.Parse(tokens[0]);

                Coleccionista coleccionista = Read.Coleccionista(DuenoID);


                List<DuenoHistorico> listDueHis = Read.ColeccionActual(coleccionista);



                for (int i = 0; i < listDueHis.Count; i++)
                {

                    DuenoHistorico duenoHistorico = listDueHis[i];

                    if (duenoHistorico.ComicID != 0)
                    {
                        Comic comic = Read.Comic(duenoHistorico.ComicID);

                        string item = "Comic " + comic.ID + " " + comic.Title;
                        comboBoxObjeto.Items.Add(item);
                    }
                    else
                    {
                        Coleccionable coleccionable = Read.Coleccionable(duenoHistorico.ColeccionableID);

                        string item = "Coleccionable " + coleccionable.ID + " " + coleccionable.Nombre;
                        comboBoxObjeto.Items.Add(item);

                    }

                }

            }
            catch (Exception)
            {
        
                ////
            }
            
        }

        private void LlenarPrecio()
        {

            string[] tokens = Validacion.ValidarCombo(comboBoxObjeto).Split(' ');

            string tipo = tokens[0];

            int ColeccionistaID = int.Parse(tokens[0]);
            Coleccionista coleccionista = Read.Coleccionista(ColeccionistaID);

            DuenoHistorico duenoHistorico = BuscarHistorico(coleccionista, tipo, int.Parse(tokens[1]));
            float precio = duenoHistorico.PrecioDolares;

            textBoxPrecio.Text = precio.ToString();

            if (precio > 0 || flagBenefica)
            {
                textBoxPrecio.Enabled = false;
            }
          

                
        }

        private DuenoHistorico BuscarHistorico( Coleccionista coleccionista, string tipo, int idObj )
        {

            //List<DuenoHistorico> listDueHis = Read.DuenosHistoricos(coleccionista);
            List<DuenoHistorico> listDueHis = null;


            for (int i = 0; i < listDueHis.Count; i++)
            {
                DuenoHistorico dH = listDueHis[i];

                if (tipo == "Comic")
                {
                    int comicID = idObj;
                    Comic comic = Read.Comic(comicID);

                    if (dH.ComicID == comic.ID)
                    {
                        return dH;
                    }
                }
                else
                {
                    int coleccionableID =  idObj;
                    Coleccionable coleccionable = Read.Coleccionable(coleccionableID);

                    if (dH.ColeccionableID == coleccionable.ID)
                    {
                        return dH;
                    }
                }

                

            }

            return null;
        }

        private void Registrar()
        {
            try
            {
                string[] tokens = Validacion.ValidarCombo(comboBoxObjeto).Split(' ');

                string tipo = tokens[0];

                int ColeccionistaID = int.Parse(tokens[0]);
                Coleccionista coleccionista = Read.Coleccionista(ColeccionistaID);


                DuenoHistorico duenoHistorico = BuscarHistorico(coleccionista, tipo, int.Parse(tokens[1]));

                //for (int i = 0; i < this.listado.Count; i++)
                //   if (listado[i].DuenoHistoricoID == duenoHistorico.ID)
                //       throw new Exception("Ya este objeto esta en la lista");


                //validar esto
                float precio = Validacion.ValidarFloat(textBoxPrecio,true);

                
                if (precio <= 0)
                {
                    throw new Exception("Aqui no se subastan objetos de gratis");
                }

                if (flagBenefica && precio < duenoHistorico.PrecioDolares) 
                {
                    throw new Exception("El precio a subastar debe ser mayor al ultimo precio subastado");

                }


                Listado listado = new Listado(
                    subasta,
                    precio,
                    duenoHistorico,
                    subasta.SiguienteNroListado(),
                    Validacion.ValidarInt(textBoxDuracion,true)
              
                ) ;

                listado.Insert();

                MessageBox.Show("Registro Exitoso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                parent.InsertForm(new subastaplan1_4(parent, subasta));

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
            parent.InsertForm(new subastaplan1_3(parent, subasta));
        }

        #endregion

        #region click botones FontAwesome

        private void iconButton5_Click(object sender, EventArgs e)
        {
            panelAgregar.Visible = true;
           
        }

        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            parent.InsertForm(new subastaplan1_4(parent, subasta));
        }

        private void btnanadir_Click(object sender, EventArgs e)
        {
            Registrar();
        }
        #endregion

        private void comboBoxColeccionista_SelectedValueChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
        }

        private void comboBoxColeccionista_SelectedValueChanged_1(object sender, EventArgs e)
        {
            LlenarObjetos();
        }
    }
}
