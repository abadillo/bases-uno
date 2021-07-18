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

        public static void EnableCheck(CheckBox radio, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            radio.Enabled = true;
            
        }


        public static void EnableCombo(ComboBox combo, FontAwesome.Sharp.IconButton iconbutton)
        {
            iconbutton.Enabled = false;
            combo.Enabled = true;
        }

        public static void EraseInput(TextBox input)
        {
            input.Text = "";
            input.ForeColor = Color.Black;
        }

        //public static void LlenaCombo (ComboBox combo, List<Object> list , int idObj, string item, bool NN)
        //{

        //    if (!NN) 
        //        combo.Items.Add("0 Ninguno"); 
            

        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        Object tmp = list[i];
                
        //        combo.Items.Add(item);

        //        if (tmp.ID == idObj)
        //            combo.SelectedItem = item;
        //    }

        //    if (!NN && idObj == 0)
        //        combo.SelectedIndex = 0;




        //}

    }
}
