using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version2_CACYF_Final.Menu;
using Version2_CACYF_Final.Animal;
using Version2_CACYF_Final.Citas;
using Version2_CACYF_Final.Trabajadores;
using Version2_CACYF_Final.Recursos;
using Version2_CACYF_Final.Ciudadanos;

namespace Version2_CACYF_Final
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
