using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public class clsReporteDeVenta
    {
        int idProducto;
        int idVenta;
        double precioUnitario;
        int cantidad;
        public int IDproducto
        {
            get
            {
                return idProducto;
            }
            set
            {
                idProducto = value;
            }
        }

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

        public double PrecioUnitario
        {
            get
            {
                return precioUnitario;
            }
            set
            {
                precioUnitario = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                cantidad = value;
            }
        }

    }
}
