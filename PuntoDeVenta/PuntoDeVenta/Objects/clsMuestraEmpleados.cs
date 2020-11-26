using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    class clsMuestraEmpleados
    {
        private int idUsuario;
        private string nombre;
        private string apellidos;


        public int IDusuario
        {
            get
            {
                return idUsuario;
            }
            set
            {
                idUsuario = value;
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
