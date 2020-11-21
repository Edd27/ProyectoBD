using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Objects
{
    public class clsListaProductos
    {
        public int IdProducto { get; set; }
        public String Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Subtotal { get; set; }

        public clsListaProductos() { }

        public clsListaProductos(int IdProducto, String Producto, int Cantidad, double Precio)
        {
            this.IdProducto = IdProducto;
            this.Producto = Producto;
            this.Cantidad = Cantidad;
            this.Precio = Precio;
            this.Subtotal = Cantidad * Precio;
        }

    }
}
