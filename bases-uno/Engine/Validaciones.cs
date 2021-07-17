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

            //bool flag = false;

            try
            {
                return combo.SelectedItem.ToString();

                //flag = true;
                //Console.WriteLine("algo: _" + str);           

            }
            catch (Exception)
            {
                combo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("Combo " + combo.Tag + " vacio");
            }
                
            //if (!(flag))
            //{
            //    combo.BackColor = Color.FromArgb(232, 81, 94);
            //    throw new ApplicationException("Combo " + combo.Tag + " vacio");
            //}
            
            //string[] tokens = combo.SelectedItem.ToString().Split(' ');
            //int valor = int.Parse(tokens[0]);
           
            

            //if (combo.SelectedItem == null || valor == 0)
            //{
                
            //}
                                    
            //combo.BackColor = Color.LightGray;
            //return combo.SelectedItem.ToString();
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

        public static int Edad (DateTime birthdate)
        {
            var today = DateTime.Today;
          
            int edad = today.Year - birthdate.Year;

            if (birthdate.Date > today.AddYears(-edad)) edad--;

            return edad;
            
        }



        // porque no puedes ser como python :CCCCCCC
        public static bool EstaEnLista (Object obj, List<Object> listObj)
        {
            for (int i = 0; i < listObj.Count; i++)
            {
                if (obj == listObj[i])
                    return true;
            }

            return false;
        }
    }
}
