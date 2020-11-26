using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public class clsVentas
    {
        int idVenta;
        DateTime fecha;
        double total;
        int usuarios_IDusuario;
        int clientes_ID;

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

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }

        public int Usuarios_IDusuario
        {
            get
            {
                return usuarios_IDusuario;
            }
            set
            {
                usuarios_IDusuario = value;
            }
        }

        public int Clientes_ID
        {
            get
            {
                return clientes_ID;
            }
            set
            {
                clientes_ID = value;
            }
        }

    }
}
