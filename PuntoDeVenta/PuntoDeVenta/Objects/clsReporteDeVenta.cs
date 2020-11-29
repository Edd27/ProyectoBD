using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public class clsReporteDeVenta
    {
        int idVenta;
        string fechaVenta;
        double montoTotal;
        string empleado;

        public int IDventa
        {
            get
            {
                return idVenta;
            }
            set
            {
                idVenta = value;
            }
        }

        public string FechaVenta
        {
            get
            {
                return fechaVenta;
            }
            set
            {
                fechaVenta = value;
            }
        }

        public double MontoTotal
        {
            get
            {
                return montoTotal;
            }
            set
            {
                montoTotal = value;
            }
        }

        public string Empleado
        {
            get{return Empleado;}
            set{ Empleado = value; }
        }

    }
}
