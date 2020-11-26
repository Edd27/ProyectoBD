using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public  class clsEtadistico
    {
        int ventas;
        string nombre;
        int total;

        /*public clsEtadistico(int ventas, string nombre, int total)
        {
            this.ventas = ventas;
            this.nombre = nombre;
            this.total = total;
        }*/
        public int Ventas
        {
            get
            {
                return ventas;
            }
            set
            {
                ventas = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public int Total
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
    }
}
