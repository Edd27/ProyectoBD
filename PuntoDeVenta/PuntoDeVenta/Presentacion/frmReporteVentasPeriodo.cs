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
    public partial class frmReporteVentasPeriodo : Form
    {
        public frmReporteVentasPeriodo()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReporteVentasPeriodo_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
