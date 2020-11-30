using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public class clsReporteVenta
    {

        private int id;
        private string fecha;
        private double total;
        private string empleado;
        public int IDReporte
        {
            get { return id; }
            set { id = value; }
        }

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

        public double MontoTotal
        {
            get { return total; }
            set { total = value; }
        }

    }
}
