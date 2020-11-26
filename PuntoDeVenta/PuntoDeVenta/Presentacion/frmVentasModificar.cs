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

namespace Presentacion
{
    public partial class frmVentasModificar : Form
    {
        private int cantidad;
        double precio;
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
        public frmVentasModificar(String nombre,double precio)
        {
            InitializeComponent();
            lblBlusa.Text = nombre;
            this.precio = precio;
            int cant = int.Parse(textBox1.Text);
            lblSubtotal.Text = (cant * precio) + "";
            cantidad = -1;
        }

        /// <summary>
        /// Guarda la cantidad digitada, y cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            cantidad = int.Parse(textBox1.Text);
            this.Close();
        }


        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Minimiza la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Abre esta ventana y retorna la cantidad digitada
        /// </summary>
        /// <returns>Cantidad digitada</returns>
        public int obtenerCantidad()
        {
            this.ShowDialog();
            return cantidad;
        }

        /// <summary>
        /// Admitir solo números en el textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Permite solo números en el text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox1.Text == null)
            {
                textBox1.Text = "1";
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
            }
            int cant = int.Parse(textBox1.Text);
            lblSubtotal.Text = (cant * precio)+"";
        }
    }
}
