using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public static class Validacion
    {
        public static string ValidarNull(TextBox campo)
        {
            if (string.IsNullOrEmpty(campo.Text))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                campo.Focus();
                throw new ApplicationException("Campo " + campo.Tag + " vacio");
            }

            if (campo.ReadOnly == false)
            {
                campo.BackColor = Color.LightGray;
            }
            return campo.Text;
        }

        public static string ValidarCombo(ComboBox combo)
        {

            string[] tokens = combo.SelectedItem.ToString().Split(' ');
            int valor = int.Parse(tokens[0]);

            if (combo.SelectedItem == null || valor == 0)
            {
                combo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("Combo " + combo.Tag + " vacio");
            }
                                    
            combo.BackColor = Color.LightGray;
            return combo.SelectedItem.ToString();
        }

        public static int ValidarInt(TextBox campo, bool NN)
        {

            if (!NN && string.IsNullOrEmpty(campo.Text))
                return 0;

            int tmp;

            if (!int.TryParse(campo.Text, out tmp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                campo.Focus();
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero valido");
            }

            //Console.WriteLine(tmp);

            if (NN && tmp == 0)
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                campo.Focus();
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero valido");
            }

            if (campo.ReadOnly == false)
            {
                campo.BackColor = Color.LightGray;
            }

            
            return tmp;

        }

        public static float ValidarFloat(TextBox campo, bool NN)
        {
            if (!NN && string.IsNullOrEmpty(campo.Text))
                return 0;

            if (NN)
            {
                ValidarNull(campo);
            }

            float tmp;

            if (!float.TryParse(campo.Text, out tmp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                campo.Focus();
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero decimal valido");
            }

            if (campo.ReadOnly == false)
            {
                campo.BackColor = Color.LightGray;
            }
            return tmp;
        }

        public static DateTime ValidarDateTime(TextBox campo, bool NN)
        {
            if (NN)
                ValidarNull(campo);

            DateTime tmp;

            if (!DateTime.TryParse(campo.Text, out tmp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                campo.Focus();
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser una fecha valida con formato MM/DD/YYYY");
            }

            if (campo.ReadOnly == false)
            {
                campo.BackColor = Color.LightGray;
            }
            return tmp;
        }
    }
}
