using Presentacion;
using PuntoDeVenta.Objects;
using PuntoDeVenta.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            clsUsuarios obj = new clsUsuarios();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new FormLogin());
           
            
        }
    }
}
