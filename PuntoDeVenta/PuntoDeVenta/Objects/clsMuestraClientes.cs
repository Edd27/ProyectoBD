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
        private string numero_telefonico;


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
        public string Numero_telefonico
        {
            get
            {
                return numero_telefonico;
            }
            set
            {
                numero_telefonico = value;
            }
        }
    }
}