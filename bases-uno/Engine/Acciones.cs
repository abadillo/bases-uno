using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Classes;
using Engine;


namespace Engine
{
    public static class Acciones
    {

        public static void EnableInput(TextBox input, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            input.ReadOnly = false;
            input.ForeColor = Color.Black;
            input.BackColor = Color.LightGray;
        }

        public static void EnableRadio(RadioButton input, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            input.Enabled = true;
        }


        public static void EnableCombo(ComboBox combo, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            combo.Enabled = true;
        }


    }
}
