using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Classes;

namespace bases_uno
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Club club = new Club("El Cetro", new DateTime(2018, 5, 28), "Centro de ayuda", Read.Lugar(14), 9531226);
            //club.Insert();
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /// Application.Run(new Form1());
            Application.Run(new Views.index());
        }
    }
}
