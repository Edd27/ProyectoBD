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
    public partial class frmAjustes : Form
    {
        clsUsuarios us = new clsUsuarios();
        public frmAjustes(clsUsuarios us)
        {
            this.us = us;
            InitializeComponent();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado objEmpleado = new frmAgregarEmpleado();
            objEmpleado.Show();
            this.Visible=false;

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            MenuPrincipal objMenuPrincipal = new MenuPrincipal(us);
            objMenuPrincipal.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MenuPrincipal objMenuPrincipal = new MenuPrincipal(us);
            //objMenuPrincipal.Show();
            //this.Visible = false;
            this.Close();
        }

        private void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            frmCerrar objCerrar = new frmCerrar();
            objCerrar.Show();
            //this.Close();
        }

        private void btnInformacionDelUsuario_Click(object sender, EventArgs e)
        {
            frmInformacionDelUsuario objInformacion = new frmInformacionDelUsuario(us);
            objInformacion.Show();
        }
    }
}
