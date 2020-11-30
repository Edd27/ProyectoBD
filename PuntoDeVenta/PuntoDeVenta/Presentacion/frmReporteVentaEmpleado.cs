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
    public partial class frmReporteVentaEmpleado : Form
    {
        public frmReporteVentaEmpleado()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            dataGridView1.DataSource = null;
        }

        private void frmReporteVentaEmpleado_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnGenerarRepEmpleado_Click(object sender, EventArgs e)
        {
            string mes = "";
            switch (cmbMes.Text)
            {
                case "Enero":
                    mes = "01";
                    break;
                case "Febrero":
                    mes = "02";
                    break;
                case "Marzo":
                    mes = "03";
                    break;
                case "Abril":
                    mes = "04";
                    break;
                case "Mayo":
                    mes = "05";
                    break;
                case "Junio":
                    mes = "06";
                    break;
                case "Julio":
                    mes = "07";
                    break;
                case "Agosto":
                    mes = "08";
                    break;
                case "Septiembre":
                    mes = "09";
                    break;
                case "Octubre":
                    mes = "10";
                    break;
                case "Noviembre":
                    mes = "11";
                    break;
                case "Diciembre":
                    mes = "12";
                    break;
            }

            daoReporteVenta reporte = new daoReporteVenta();
            dataGridView1.DataSource = reporte.GenerarReporte2(mes, cmbAnio.Text);

        }
    }
}
