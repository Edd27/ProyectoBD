using PuntoDeVenta.Data;
using PuntoDeVenta.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta.Presentacion
{
    public partial class CatalogoClientes : Form
    {
        int poc;
        clsClientes clientes;
        public CatalogoClientes()
        {
            InitializeComponent();
            dgEmpleados.DataSource = new DaoClientes().Mmostrarclientes();
        }
        public void openFromMenu(clsClientes clientes)
        {
            this.Show();
            this.clientes = clientes;
        }
        private void pbMaximizar_Click(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            //   MenuPrincipal ventana = new MenuPrincipal();
            this.Visible = false;
            // ventana.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
