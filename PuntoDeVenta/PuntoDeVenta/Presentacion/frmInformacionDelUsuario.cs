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
    public partial class frmInformacionDelUsuario : Form
    {
        clsUsuarios us = new clsUsuarios();
        public frmInformacionDelUsuario(clsUsuarios us)
        {
            this.us = us;
            InitializeComponent();
            lbladministrador.Text = us.Administrador.ToString();
            lblapellido.Text = us.Apellidos.ToString();
            lblid.Text = us.IDusuario.ToString();
            lbllNombre.Text = us.Nombre.ToString();
            lblpasword.Text = us.Password.ToString();
            lblUsuario.Text = us.Login.ToString();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInformacionDelUsuario_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
