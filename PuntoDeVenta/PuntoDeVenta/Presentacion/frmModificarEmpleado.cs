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
    public partial class frmModificarEmpleado : Form
    {

        /// <summary>
        /// Carga los datos del empleado seleccionado para modificarlos
        /// Recibe una lista de tipo clsUsuarios
        /// </summary>
        /// <param name="algo"></param>
        public frmModificarEmpleado(List<clsUsuarios> algo)
        {
            InitializeComponent();
            txtID.Text = Convert.ToString(algo[0].IDusuario);
            txtLogin.Text = algo[0].Login;
            txtNombre.Text = algo[0].Nombre;
            txtApellidos.Text = algo[0].Apellidos;
            txtPassword.Text = algo[0].Password;
            cbAdministrador.Text = Convert.ToString(algo[0].Administrador);
        }

        /// <summary>
        /// Manda los datos a la clase clsUsuarios para la modificación en la base    
        /// de datos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" | txtNombre.Text == "" | txtApellidos.Text == "" | txtPassword.Text == "")
            {
                MessageBox.Show("Ningun campo puede quedar vacio");
            }
            else
            {
                clsUsuarios Registro = new clsUsuarios();
                Registro.IDusuario = Convert.ToInt32(txtID.Text);
                Registro.Login = txtLogin.Text;
                Registro.Nombre = txtNombre.Text;
                Registro.Apellidos = txtApellidos.Text;
                Registro.Password = txtPassword.Text;
                Registro.Administrador = Convert.ToBoolean(cbAdministrador.Text);


                DaoUsuarios modifica = new DaoUsuarios();
                if (modifica.MmodificarEmpleado(Registro))
                {
                    MessageBox.Show("Se ha modificado correctamente el empleado");
                    CatalogoEmpleados ventana = new CatalogoEmpleados();
                    ventana.Show();
                    this.Visible = false;
                }
                else
                {

                    MessageBox.Show("Algo salio mal");
                }
            }
        }

        /// <summary>
        /// Se cierra la ventana actual y se abre el catálogo de empleados
        private void button2_Click(object sender, EventArgs e)
        {
            CatalogoEmpleados ventana = new CatalogoEmpleados();
            ventana.Show();
            this.Visible = false;
        }

        /// <summary>
        /// Se cierra la ventana actual y se abre el catálogo de empleados
        private void btncerrar_Click(object sender, EventArgs e)
        {
            CatalogoEmpleados ventana = new CatalogoEmpleados();
            ventana.Show();
            this.Visible = false;
        }

        /// <summary>
        /// Se maximiza o minimiza la ventana
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

        /// <summary>
        /// Se Minimiza la ventana actual
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public static implicit operator frmModificarEmpleado(frmAgregarEmpleado v)
        {
            throw new NotImplementedException();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch
            {

            }
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch
            {

            }
        }
    }
}
