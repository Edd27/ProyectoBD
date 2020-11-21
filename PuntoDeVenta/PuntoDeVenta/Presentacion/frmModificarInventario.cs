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
    public partial class frmModificarInventario : Form
    {
        int id;
        List<clsInventario> listInven = new List<clsInventario>();
        public frmModificarInventario(int ID)
        {
            InitializeComponent();
            id = ID;
        }

        /// <summary>
        /// Metodo de click del boton cerrar, este cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Metodo de click del boton minimizar, este minimiza la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Metodo que se ejecuta al momento de cargar la ventana, sirve para cargar
        /// todos los datos necesarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModificarInventario_Load(object sender, EventArgs e)
        {
            cargarInventarios();
            cargar();
        }

        /// <summary>
        /// Metodo de click del boton modificar, este obtiene todos los datos
        /// de los campos y modifica el producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbDesc.Text == "" | tbID.Text == "" | tbPrecio.Text == "" | tbProducto.Text == "" | tbTalla.Text == "" | tbTipo.Text == "" | cbAlmacen.SelectedIndex == -1)
                {
                    MessageBox.Show("Faltaron datos por llenar");
                }
                else
                {

                    clsProductos x = new clsProductos();
                    x.IDproducto = int.Parse(tbID.Text);
                    x.Producto = tbProducto.Text;
                    x.Precio = double.Parse(tbPrecio.Text);
                    x.Talla = tbTalla.Text;
                    x.Descripcion = tbDesc.Text;
                    x.IDinventario = listInven[cbAlmacen.SelectedIndex].IDinventario;
                    x.Tipo = tbTipo.Text;

                    if (new daoProductos().ModificarProducto(x))
                    {
                        MessageBox.Show("Se modifico correctamente");
                        this.Close();

                    }
                    else
                    {
                      

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al momento de modificar, verifique sus datos");

            }
           
        }

        /// <summary>
        /// Metodo que carga el producto a modificar
        /// </summary>
        public void cargar()
        {
            clsProductos producto= new clsProductos();
            producto = new daoProductos().ObtenerProducto(id);

            tbID.Text = "" + producto.IDproducto;
            tbDesc.Text = producto.Descripcion;
            tbPrecio.Text = "" + producto.Precio;
            tbTalla.Text = producto.Talla;
            tbTipo.Text = producto.Tipo;
            tbProducto.Text = producto.Producto;

            cbAlmacen.SelectedIndex = producto.IDinventario-1;

        }

        /// <summary>
        /// Metodo que carga todos los inventarios que se tienen agregados
        /// </summary>

        public void cargarInventarios()
        {
            listInven = new daoInventario().ObtenerTodos();

            for (int i = 0; i < listInven.Count; i++)
            {
                cbAlmacen.Items.Add(listInven[i].Nombre);
            }

        }

        private void tbDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < tbPrecio.Text.Length; i++)
            {
                if (tbPrecio.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
    }
    

   
}
