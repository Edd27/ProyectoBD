using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public class clsInventario
    {
        int IdInventario;
        String nombre;
        String descripcion;

        public int IDinventario
        {
            get
            {
                return IdInventario;
            }
            set
            {
                IdInventario = value;
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }

    }
}
