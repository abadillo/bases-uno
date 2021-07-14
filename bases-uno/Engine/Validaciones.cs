﻿using System;
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
                throw new ApplicationException("Campo " + campo.Tag + " vacio");
            }

            campo.BackColor = Color.LightGray;
            return campo.Text;
        }

        public static int ValidarInt(TextBox campo, bool NN)
        {
            if (!NN && string.IsNullOrEmpty(campo.Text))
                return 0;

            if (NN)
            {
                ValidarNull(campo);
            }

            int tmp;

            if (!int.TryParse(campo.Text, out tmp))
            {
                campo.BackColor = Color.FromArgb(232, 81, 94);
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero valido");
            }

            campo.BackColor = Color.LightGray;
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
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser un numero decimal valido");
            }

            campo.BackColor = Color.LightGray;
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
                throw new ApplicationException("'" + campo.Text + "' en el campo " + campo.Tag + " debe ser una fecha valida con formato MM/DD/YYYY");
            }

            campo.BackColor = Color.LightGray;
            return tmp;
        }
    }
}