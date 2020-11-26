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
    public partial class CatalogoEmpleados : Form
    {
        int poc;
        clsUsuarios usuario;
        public CatalogoEmpleados()
        {
            InitializeComponent();
            /// <summary>
            /// Aquí se llena la tabla de empleados con los datos de la base de datos

            dgEmpleados.DataSource = new DaoUsuarios().MmostrarEmpleados();
        }

        /// <summary>
        /// Abre esta ventana desde el menú principal
        /// </summary>
        /// <param name="usuario"></param>
        public void openFromMenu(clsUsuarios usuario)
        {
            this.Show();
            this.usuario = usuario;
        }

        /// <summary>
        /// Abre una ventana nueva para agregar empleados

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            frmAgregarEmpleado ventana = new frmAgregarEmpleado();
            ventana.Show();
            this.Visible = false;
        }
        /// <summary>
        /// Se cierra la ventana actual
        private void btnRegresar_Click(object sender, EventArgs e)
        {
           // MenuPrincipal ventana = new MenuPrincipal();
            this.Visible = false;
            // ventana.Show();
        }

        /// <summary>
        /// Carga la hora y la fecha en los labels
        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dddd:MMMM:yyy");
        }

        /// <summary>
        /// Abre una ventana nueva cargando los datos del usuario seleccionado en la                           
        /// tabla
        private void btnModificar_Click(object sender, EventArgs e)
        {
            DaoUsuarios usuario = new DaoUsuarios();
            poc = dgEmpleados.CurrentRow.Index;
            int Id= int.Parse(dgEmpleados[0, poc].Value.ToString());
            usuario.MtraerEmpleado(Id);
            List<clsUsuarios> lista = usuario.MtraerEmpleado(Id);
            frmModificarEmpleado ventena = new frmModificarEmpleado(lista);
            ventena.Show();
            this.Visible = false;

        }

        /// <summary>
        /// Elimina al empleado seleccionado en la tabla
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            poc = dgEmpleados.CurrentRow.Index;
            String usuario = dgEmpleados[1, poc].Value.ToString();


            // Da la opcion si quieres o no eliminar al empleado seleccionado, si precionas "Si" lo elimina 
            //y si precionas "No" se cancela y arroja un mensaje
            if (MessageBox.Show("Seguro que quiere eliminar a " + usuario + "?", "Notificación",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes) { 
            DaoUsuarios userRegi = new DaoUsuarios();
            poc = dgEmpleados.CurrentRow.Index;
            int ID = int.Parse(dgEmpleados[0, poc].Value.ToString());

            if (ID==this.usuario.IDusuario)
            {
                    MessageBox.Show("No se puede eliminar el usuario que está en uso del sistema.");
            }
            else if (userRegi.MEliminarUsuario(ID))
            {
                dgEmpleados.DataSource = new DaoUsuarios().MmostrarEmpleados();
                MessageBox.Show("Se ha eliminado correctamente el empleado");

            }
            else
            {

                MessageBox.Show("Algo salio mal");
            }
            }
            else
            {
                MessageBox.Show("Cancelado");
            }

        }

        /// <summary>
        /// Busca a los empleados que concidan con lo que se ingresa en la caja de texto
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            clsMuestraEmpleados obj = new clsMuestraEmpleados();
            obj.Nombre = txtBuscarE.Text;

            dgEmpleados.DataSource = new DaoUsuarios().MBuscarEmpleados(obj);
            

           
        }

        /// <summary>
        /// Minimiza la ventana
        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Minimiza o maximiza la ventana
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
        /// Cierra la ventana actual
        private void btncerrar_Click(object sender, EventArgs e)
        {
         //   MenuPrincipal ventana = new MenuPrincipal();
            this.Visible = false;
           // ventana.Show();
        }
    }
}
