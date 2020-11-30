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
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnRepPeriodo_Click(object sender, EventArgs e)
        {
            frmReporteVentasPeriodo window = new frmReporteVentasPeriodo();
            window.Show();
            this.Close();
        }

        private void btnRepEmpleado_Click(object sender, EventArgs e)
        {
            frmReporteVentaEmpleado nueva = new frmReporteVentaEmpleado();
            nueva.Show();
            this.Close();
        }
    }
}
