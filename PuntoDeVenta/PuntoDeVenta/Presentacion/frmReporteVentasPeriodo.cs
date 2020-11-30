using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Objects;
using PuntoDeVenta.Data;

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

        private void btnGenerarRepP_Click(object sender, EventArgs e)
        {
            string fechaInicio = dtpInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpFin.Value.ToString("yyyy-MM-dd");

            daoReporteVenta reporte = new daoReporteVenta();

            dtwRepsPeriodo.DataSource = reporte.GenerarReporte(fechaInicio, fechaFin);

        }
    }
}
