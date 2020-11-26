using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using PuntoDeVenta.Objects;
using PuntoDeVenta.Data;

namespace Presentacion
{
    public partial class frmVentasBuscar : Form
    {
        private clsListaProductos clsListaProductos;
        private daoProductos daoProductos;
        private List<clsProductos> listaProductos;
        int cant;

        #region Dlls para poder hacer el movimiento del Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        Rectangle sizeGripRectangle;
        bool inSizeDrag = false;
        const int GRIP_SIZE = 15;

        int w = 0;
        int h = 0;
        #endregion
        public frmVentasBuscar()
        {
            InitializeComponent();

            daoProductos = new daoProductos();
            listaProductos = new List<clsProductos>();
            cargarProdutcos();
        }

        /// <summary>
        /// Carga los productos al data grid view
        /// </summary>
        public void cargarProdutcos()
        {
            listaProductos = daoProductos.ObtenerProductos();
            dgvProductos.DataSource = listaProductos;            
        }

        /// <summary>
        /// Obtiene el producto seleccionado, lo asigna a la variable clsProductos, y cierra la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int seleccionado = dgvProductos.CurrentCell.RowIndex;
            frmVentasModificar modificar = new frmVentasModificar(listaProductos[seleccionado].Producto,listaProductos[seleccionado].Precio);
            cant = modificar.obtenerCantidad();
            clsListaProductos = new clsListaProductos(listaProductos[seleccionado].IDproducto, listaProductos[seleccionado].Producto, cant, listaProductos[seleccionado].Precio);
            if (clsListaProductos.Cantidad!=-1)
            {
                this.Close();
                this.Dispose();
            }

        }

        /// <summary>
        /// Muestra este formulario, al cerrarse se retorna el producto seleccionado. Si no se selecciona ningun producto, se retorna un null.
        /// </summary>
        /// <returns>Producto seleccionado por el usuario.</returns>
        public clsListaProductos showReturn()
        {         
            this.ShowDialog();
            if (cant==-1)
            {
                clsListaProductos = null;
            }
            return clsListaProductos;
        }

        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }
        /// <summary>
        /// Cierra la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// Minimiza la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Cierra la ventana.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Buscar producto
        /// </summary>
        /// <remarks>
        /// Busca entre todos los productos los valores del producto, descripción y ID con el texto ingresado.
        /// </remarks>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text!=""  && txtBuscar.Text != null) {
                List<clsProductos> productosEncontrados = new List<clsProductos>();
                for (int i = 0; i < listaProductos.Count; i++)
                {
                    if ((listaProductos[i].IDproducto + "").IndexOf(txtBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        (listaProductos[i].Descripcion + "").IndexOf(txtBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        (listaProductos[i].Producto + "").IndexOf(txtBuscar.Text, StringComparison.OrdinalIgnoreCase) >= 0
                        )
                    {
                        productosEncontrados.Add(listaProductos[i]);
                    }
                }
                dgvProductos.DataSource = productosEncontrados;
            }
            else
            {
                dgvProductos.DataSource = listaProductos;
            }
        }
    }
}
