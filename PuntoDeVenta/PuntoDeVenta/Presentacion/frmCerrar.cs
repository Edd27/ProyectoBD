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
    public partial class frmCerrar : Form
    {
        public frmCerrar()
        {
            InitializeComponent();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();



        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
