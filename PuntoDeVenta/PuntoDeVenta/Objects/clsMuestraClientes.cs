using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    class clsMuestraClientes
    {
        private int id;
        private string nombre;
        private string apellidos;


        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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

        public string Apellidos
        {
            get
            {
                return apellidos;
            }
            set
            {
                apellidos = value;
            }
        }

    }
}