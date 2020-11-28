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
    public partial class AgregarCliente : Form
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

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
            CatalogoClientes ventana = new CatalogoClientes();
            ventana.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CatalogoClientes ventana = new CatalogoClientes();
            ventana.Show();
            this.Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" | txtApellidos.Text == "" | txttelefono.Text == "")
            {
                MessageBox.Show("Ningun campo puede quedar vacio");
            }
            else
            {
                clsClientes Registro = new clsClientes();

                
                Registro.Nombre = txtNombre.Text;
                Registro.Apellidos = txtApellidos.Text;
                Registro.Numero_telefonico = txttelefono.Text;
              


                DaoClientes userRegi = new DaoClientes();
                if (userRegi.MAgregarClientes(Registro))
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
    }
}
