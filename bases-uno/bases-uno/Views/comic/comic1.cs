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
using System.Windows.Forms;

namespace bases_uno.Views
{
    public partial class comic1 : Form
    {

        public index parent;
        public Comic comic;
       

        public comic1(index parent, Comic comic )
        {
            this.parent = parent;
            this.comic = comic;

            InitializeComponent();
			
			textBoxID.Text = comic.ID.ToString();
			textBoxTitle.Text = comic.Title;
			textBoxPublicationDate.Text = comic.PublicationDate.ToString();
			radioButtonColor.Checked = comic.Color;
            radioButtonCover.Checked = comic.Cover;
            textBoxVolumen.Text = comic.Volume.ToString();
			textBoxNumber.Text = comic.Number.ToString();
			textBoxPublicationPrice.Text = comic.PublicationPrice.ToString();
			textBoxPages.Text = comic.Pages.ToString();
			textBoxEditor.Text = comic.Editor;
			textBoxSynopsis.Text = comic.Synopsis;

            label1.Text = "Comic: " + comic.Title;
            Update();

		}

        #region Funciones

        private void Modificar()
        {
            try
            {
                comic.Title = Validacion.ValidarNull(textBoxTitle);
                comic.Editor = Validacion.ValidarNull(textBoxEditor);
                comic.Synopsis = textBoxSynopsis.Text;
                comic.Volume = Validacion.ValidarInt(textBoxVolumen, false);

                comic.Number = Validacion.ValidarInt(textBoxNumber, true);
                comic.Pages = Validacion.ValidarInt(textBoxPages, true);
                comic.PublicationPrice = Validacion.ValidarFloat(textBoxPublicationPrice, false);

                comic.PublicationDate = Validacion.ValidarDateTime(textBoxPublicationDate, true);
                comic.Cover = radioButtonCover.Checked;
                comic.Color = radioButtonColor.Checked;

                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea modificar este Comic?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    comic.Update();

                    MessageBox.Show("Modificacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parent.InsertForm(new comic1(parent, comic));
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            } catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error de tipo de dato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error con base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Eliminar()
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este Comic?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)

                try
                {
                    comic.Delete();
                    MessageBox.Show("Eliminacion Exitosa", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    parent.InsertForm(new comicl(parent));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error con base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }
        #endregion

        #region click botones normales

        private void btnadelante_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new comic2(parent, comic));
        }

        private void btnatras_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new comicl(parent));
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            parent.InsertForm(new comic1(parent, comic));
        }
        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
        #endregion

        #region click botones FontAwesome

        private void iconButton14_Click(object sender, EventArgs e)
        {
            // id no se modifica
        }
        private void iconButton17_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxTitle, iconButton17);
        }
        private void iconButton15_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxNumber, iconButton15);
        }
        private void iconButton10_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxVolumen, iconButton10);
        }
        private void iconButton16_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxPublicationDate, iconButton16);
        }
        private void iconButton19_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxPublicationPrice, iconButton19);
        }

        private void iconButton18_Click(object sender, EventArgs e)
        {
            Acciones.EnableRadio(radioButtonColor, iconButton18);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxPages, iconButton9);
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            Acciones.EnableRadio(radioButtonCover, iconButton12);
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxEditor, iconButton11);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Acciones.EnableInput(textBoxSynopsis, iconButton1);
        }
        #endregion

    }
}
