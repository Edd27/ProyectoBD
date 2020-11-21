using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Data;
using PuntoDeVenta.Objects;

namespace PuntoDeVenta.Presentacion
{
    public partial class frmEliminarInventario : Form
    {
        int id;
        public frmEliminarInventario(int ID)
        {
            InitializeComponent();
            id = ID;
        }
        /// <summary>
        /// Metodo de click del boton de cerrras, este cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo de click de cancelar, este cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Metodo que se ejecuta al momento que se carga la ventana
        /// este obtiene el producto a eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmEliminarInventario_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            clsProductos prod;
            prod = new daoProductos().ObtenerProducto(id);

            lbMensaje.Text += prod.Producto+"?";
        }

        /// <summary>
        /// Metodo de click del boton eliminar, este elimina el prodcuto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (new daoProductos().EliminarProducto(id))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }
    }
}
