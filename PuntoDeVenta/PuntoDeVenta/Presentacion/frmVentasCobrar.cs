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
    public partial class frmVentasCobrar : Form
    {
        bool accion;
        double total;
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
        public frmVentasCobrar(double total)
        {
            InitializeComponent();
            lblTotal.Text = total + "";
            this.total = total;
        }
        /// <summary>
        /// Cierra la ventana indicando que se realiza la transacción
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            double ingreso=int.Parse(textBox1.Text);
            if (ingreso>=total)
            {
                accion = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Dinero recibido insuficiente.");
            }
        }

        /// <summary>
        /// Abre esta ventana
        /// </summary>
        /// <returns>Verdadero si se acepta la transacción y falso lo contrario</returns>
        public bool abrir()
        {
            this.ShowDialog();
            return accion;
        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            accion = false;
            this.Close();
        }



        /// <summary>
        /// minimiza la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            accion = false;
            this.Close();
        }

        /// <summary>
        /// Validar solo números
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Realiza el cálculo del cambio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null)
            {
                textBox1.Text = "0";
                textBox1.SelectionStart = 0;
                textBox1.SelectionLength = textBox1.Text.Length;
            }
            double ingreso = int.Parse(textBox1.Text);
            lblCambio.Text = (ingreso - total) + "";
        }
    }
}
