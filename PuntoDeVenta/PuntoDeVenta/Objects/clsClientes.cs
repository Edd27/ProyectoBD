using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    class clsClientes
    {
        int idCliente;
        String nombre;
        String apellidos;
        String numero_Telefonico;

        public int IDcliente
        {
            get
            {
                return idCliente;
            }
            set
            {
                idCliente = value;
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

        public string Numero_Telefonico
        {
            get
            {
                return numero_Telefonico;
            }
            set
            {
                numero_Telefonico = value;
            }
        }


    }
}
