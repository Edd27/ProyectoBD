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
    public partial class frmVentas : Form
    {
        private List<clsListaProductos> productos;
        double total;
        clsUsuarios usuario;
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
        /// <summary>
        /// Inicializa la ventana con el usuario que ingresó al sistema
        /// </summary>
        /// <param name="usuario">Usuario que ingresó a lsistema</param>
        public frmVentas(clsUsuarios usuario)
        {
            InitializeComponent();
            productos = new List<clsListaProductos>();
            clsListaProductos clsListaProductos = new clsListaProductos();
            total = 0;
            this.usuario = usuario;
            lblUsuario.Text = usuario.Nombre + " " + usuario.Apellidos;
        }

        /// <summary>
        /// Solamente inicializa la ventana
        /// </summary>
        public frmVentas()
        {
            InitializeComponent();
            productos = new List<clsListaProductos>();
            clsListaProductos clsListaProductos = new clsListaProductos();
            total = 0;
        }

        /// <summary>
        /// Cierra esta ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Minimiza la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        String dia, nombreDia, mes, anio;
        /// <summary>
        /// Establece la fecha y la hora actual en las etiquetas correspondientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            dia= DateTime.Now.ToString("dd");
            nombreDia= DateTime.Now.ToString("dddd");
            mes= DateTime.Now.ToString("MMMM");
            anio=DateTime.Now.ToString("yyyy");
            lblfecha.Text = nombreDia+" "+dia+" de "+mes+" del "+anio;
        }

        /// <summary>
        /// Abre la ventana buscar
        /// </summary>
        /// <remarks>
        /// Abre la ventana buscar y recibe el producto seleccionado, lo agrega al data grid view
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            frmVentasBuscar abrir = new frmVentasBuscar();
            clsListaProductos clsProducto = abrir.showReturn();
            if (clsProducto!=null)
            {
                bool flag = true;
                for (int i = 0; i < productos.Count; i++)
                {
                    if (clsProducto != null && productos[i].IdProducto == clsProducto.IdProducto)
                    {
                        productos[i].Cantidad += clsProducto.Cantidad;
                        productos[i].Subtotal += clsProducto.Subtotal;
                        flag = false;
                    }
                }
                if (flag)
                {
                    productos.Add(clsProducto);
                }

                dgvVenta.DataSource = null;
                dgvVenta.DataSource = productos;
                calcularTotal();
            }
        }

        /// <summary>
        /// Calcula el total de la venta
        /// </summary>
        private void calcularTotal()
        {
            double total = 0;
            for (int i = 0; i < productos.Count; i++)
            {
                total += productos[i].Subtotal;
            }
            lblSubtotal.Text = total + "";
            lblTotal.Text = total + "";
            this.total = total;
        }

        /// <summary>
        /// quita un elemento de la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVenta.CurrentRow != null)
                {
                    productos.RemoveAt(dgvVenta.CurrentRow.Index);
                    dgvVenta.DataSource = null;
                    dgvVenta.DataSource = productos;
                }
                else
                {
                    MessageBox.Show("Por favor selcciona un producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            calcularTotal();
        }

        /// <summary>
        /// Abre frmVentasBuscar al presionar F4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmVentas_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode== Keys.F4)
            {
                frmVentasBuscar frmVentasBuscar = new frmVentasBuscar();
                frmVentasBuscar.Show();
            }
        }

        /// <summary>
        /// Función maximizar de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState==FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Realiza la operación de almacenar la venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine(productos.Count);
            if (productos!=null && productos.Count!=0)
            {
                frmVentasCobrar frmVentasCobrar = new frmVentasCobrar(total);
                if (frmVentasCobrar.abrir())
                {
                    clsVentas venta = new clsVentas();
                    DateTime fecha = DateTime.Now;
                    int idUsuario = usuario.IDusuario;
                    venta.Fecha = fecha;
                    venta.Clientes_ID = idUsuario;
                    venta.Total = total;
                    venta.Usuarios_IDusuario = idUsuario;
                    daoVentas daoVentas = new daoVentas();

                    if (!daoVentas.insertar(venta, productos))
                    {
                        MessageBox.Show("Hubo un error al realizar la transacción.");
                    }
                    else
                    {
                        MessageBox.Show("Venta realizada con éxito");
                        productos = new List<clsListaProductos>();
                        dgvVenta.DataSource = null;
                        dgvVenta.DataSource = productos;
                        calcularTotal();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe haberse agregado antes al menos un producto.");
            }
        }

        /// <summary>
        /// Modifica la cantidad de productos ingresada en el data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVenta.CurrentRow != null)
                {
                    int index = dgvVenta.CurrentRow.Index;
                    frmVentasModificar frmVentas = new frmVentasModificar(productos[index].Producto,productos[index].Precio);
                    int cant = frmVentas.obtenerCantidad();
                    if (cant!=-1)
                    {
                        productos[index].Cantidad = cant;
                        productos[index].Subtotal = productos[index].Precio * cant;
                    }
                    dgvVenta.DataSource = null;
                    dgvVenta.DataSource = productos;
                }
                else
                {
                    MessageBox.Show("Por favor selcciona un producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            calcularTotal();

        }
    }
}
