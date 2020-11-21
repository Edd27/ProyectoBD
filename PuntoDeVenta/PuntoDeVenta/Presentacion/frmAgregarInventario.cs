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
    public partial class frmAgregarInventario : Form
    {
        List<clsInventario> listInven;
        public frmAgregarInventario()
        {
            InitializeComponent();
            listInven = new List<clsInventario>();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Metodo de click del boton cerrar, sirve para cerrar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Metodo de  click del boton agregar, sirve par agregar los nuevos productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if (tbDes.Text == "" | tbID.Text == "" | tbPrecio.Text == "" | tbProducto.Text == "" | tbTalla.Text == "" | tbTipo.Text == "" | cbAlmacen.SelectedIndex == -1)
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
                    x.Descripcion = tbDes.Text;
                    x.IDinventario = listInven[cbAlmacen.SelectedIndex].IDinventario;
                    x.Tipo = tbTipo.Text;


                    if (agregar(x))
                    {
                        MessageBox.Show("Agregado correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error, verifique sus datos de entrada");
                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error, verifique sus datos de entrada");
            }

          
        }

        /// <summary>
        /// Metodo que se ejecuta al momento de que se carga el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmAgregarInventario_Load(object sender, EventArgs e)
        {
            cargar();
            if (cbAlmacen.Items.Count!=0)
            {
                cbAlmacen.SelectedIndex = 0;
            }
           
        }


        /// <summary>
        /// Metodo para agregar un nuevo producto, en el recibe el nuevo producto a añadir
        /// y lo manda al dao de productos
        /// </summary>
        /// <param name="nuevo"></param>
        /// <returns></returns>
        /// Retorna un true si el objeto fue añadido a la base de datos
        /// Retorna un false si no se pudo agregar
        public bool agregar(clsProductos nuevo) {
            try
            {
                return new daoProductos().AgregarProducto(nuevo);

            }
            catch (Exception)
            {

                return false;
            }
        
        }


        /// <summary>
        /// Metodo donde se cargan los datos de todos los inventarios que se tienen
        /// Se añaden al combobox
        /// </summary>
        public void cargar() {
            cbAlmacen.Items.Clear();
            listInven = new daoInventario().ObtenerTodos();

            for (int i = 0; i < listInven.Count; i++)
            {
                cbAlmacen.Items.Add(listInven[i].Nombre);
            }
        
        }

        /// <summary>
        /// Se llama al formulario del nuevo inventario, este es para agregar nuevos inventarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new frmNuevoInventario().ShowDialog();
            this.Visible = true;
            cargar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void tbTalla_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMaterial_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {

        }

        private void lblCantidad_Click(object sender, EventArgs e)
        {

        }

        private void lblMaterial_Click(object sender, EventArgs e)
        {

        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
             if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {

                e.Handled = true;
            }
        }
        /// <summary>
        /// Metodo para que solo valide numeros con decimales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    


