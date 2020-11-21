using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Presentacion;
using System.Runtime.InteropServices;
using PuntoDeVenta.Objects;
using PuntoDeVenta.Data;
namespace Presentacion
{
    public partial class Inventario : Form
    {
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

        List<clsProductos> listProd;
        daoInventario daoInventario;
        public Inventario()
        {
            InitializeComponent();
            listProd = new List<clsProductos>();
            daoInventario = new daoInventario();
          
        }
        /// <summary>
        /// Cierra la ventana del inventario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
           
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

        /// <summary>
        /// Asignacion de la hora y el dia para los label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dddd:MMMM:yyy");
        }

        /// <summary>
        /// Al momento de la carga de la interfaz se manda a llamar el metodo de cargar
        /// para cargar todos los productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inventario_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void Inventario_MouseDown(object sender, MouseEventArgs e)
        {
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            w = this.Width;
            h = this.Height;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            frmVentas abrir = new frmVentas();
            abrir.Show();
            this.Hide();
        }

        /// <summary>
        /// Metodo del boton de buscar en el llama el metodo del dao para buscar productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listProd = new daoProductos().BuscarProductos(tbBusqueda.Text);
               
                if (listProd.Count == 0)
                {
                    MessageBox.Show("No se encontraron elementos");

                }
                else
                {
                    dgvProductos.Rows.Clear();
                    for (int i = 0; i < listProd.Count; i++)
                    {
                        dgvProductos.Rows.Add(listProd[i].Producto, listProd[i].Descripcion, listProd[i].Tipo, listProd[i].Talla, listProd[i].Precio, daoInventario.ObtenerInventario(listProd[i].IDinventario).Nombre);

                    }
                    tbBusqueda.Text = "";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error");
            }
        }

        /// <summary>
        /// Llama al formulario de agregar producto al inventario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new frmAgregarInventario().ShowDialog();
            cargar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = listProd[dgvProductos.CurrentRow.Index].IDproducto;
            new frmEliminarInventario(id).ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = listProd[dgvProductos.CurrentRow.Index].IDproducto;
            new frmModificarInventario(id).ShowDialog();
            cargar();
        }

        /// <summary>
        /// Metodo que carga todos los productos en el data gried view para ello se utiliza una lista.
        /// </summary>
        public void cargar() {
            try
            {
                dgvProductos.Rows.Clear();
                listProd = new daoProductos().ObtenerProductos();

                for (int i = 0; i < listProd.Count; i++)
                {
                    dgvProductos.Rows.Add(listProd[i].Producto,listProd[i].Descripcion, listProd[i].Tipo, listProd[i].Talla, listProd[i].Precio,daoInventario.ObtenerInventario(listProd[i].IDinventario).Nombre);

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error");
            }
        
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
