using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
  public  class clsUsuarios
    {
        private int idUsuario;
        private string login;
        private string nombre;
        private string apellidos;
        private string password;
        private bool administrador;

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

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
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

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public bool Administrador
        {
            get
            {
                return administrador;
            }
            set
            {
                administrador = value;
            }
        }

    }
}
