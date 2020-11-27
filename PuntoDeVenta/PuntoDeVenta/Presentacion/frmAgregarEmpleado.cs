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
    public partial class frmAgregarEmpleado : Form
    {
        public frmAgregarEmpleado()
        {
            InitializeComponent();
            cbAdministrador.SelectedIndex=1;
        }

        /// <summary>
        /// Agrega a un nuevo empleado mandando los datos de las cajas de texto a la 
        /// base de datos             
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "" | txtNombre.Text == "" | txtApellidos.Text == "" | txtPassword.Text == "")
            {
                MessageBox.Show("Ningun campo puede quedar vacio");
            }
            else
            {
                clsUsuarios Registro = new clsUsuarios();

                Registro.Login = txtLogin.Text;
                Registro.Nombre = txtNombre.Text;
                Registro.Apellidos = txtApellidos.Text;
                Registro.Password = txtPassword.Text;
                Registro.Administrador = Convert.ToBoolean(cbAdministrador.Text);


                DaoUsuarios userRegi = new DaoUsuarios();
                if (userRegi.MAgregarUsuario(Registro))
                {
                    MessageBox.Show("Se ha agregado correctamente el empleado");
                    CatalogoEmpleados ventana = new CatalogoEmpleados();
                    ventana.Show();
                    this.Visible = false;
                }
                else
                {

                    MessageBox.Show("Algo salio mal: Puede que tus datos esten mal o que ese nombre de usuario ya este Registrado");
                }
            }
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {

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
        /// Se minimiza la ventana
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
