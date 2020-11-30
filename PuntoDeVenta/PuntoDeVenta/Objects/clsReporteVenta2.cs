using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
   public  class clsReporteVenta2
    {

        private int idEmpleado;
        private int ventas;
        private string empleado;
        private double total;

        public int IDEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public int Ventas
        {
            get { return ventas; }
            set { ventas = value; }
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
