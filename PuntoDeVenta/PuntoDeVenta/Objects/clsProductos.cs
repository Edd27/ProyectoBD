using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public class clsProductos
    {
        int idProducto;
        String producto;
        String descripcion;
        String tipo;
        String talla;
        double precio;
        int idInventario;

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

        public string Producto
        {
            get
            {
                return producto;
            }
            set
            {
                producto = value;
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

        public string Tipo
        {
            get
            {
                return tipo;
            }
            set
            {
                tipo = value;
            }
        }

        public string Talla
        {
            get
            {
                return talla;
            }
            set
            {
                talla = value;
            }
        }

        public double Precio
        {
            get
            {
                return precio;
            }
            set
            {
                precio = value;
            }
        }

        public int IDinventario
        {
            get
            {
                return idInventario;
            }
            set
            {
                idInventario = value;
            }
        }


    }
}
