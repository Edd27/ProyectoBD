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
    public partial class CatalogoClientes : Form
    {
        int poc;
        clsClientes clientes;
        public CatalogoClientes()
        {
            InitializeComponent();
            dgEmpleados.DataSource = new DaoClientes().Mmostrarclientes();
        }
        public void openFromMenu(clsClientes clientes)
        {
            this.Show();
            this.clientes = clientes;
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
            //   MenuPrincipal ventana = new MenuPrincipal();
            this.Visible = false;
            // ventana.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCliente ventana = new AgregarCliente();
            ventana.Show();
            this.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DaoClientes usuario = new DaoClientes();
            poc = dgEmpleados.CurrentRow.Index;
            int ID = int.Parse(dgEmpleados[0, poc].Value.ToString());
            usuario.MtraerClientes(ID);
            List<clsClientes> lista = usuario.MtraerClientes(ID);
            ModificarCliente ventena = new ModificarCliente(lista);
            ventena.Show();
            this.Visible = false;
        }

        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CatalogoClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            poc = dgEmpleados.CurrentRow.Index;
            String clientes = dgEmpleados[1, poc].Value.ToString();


            // Da la opcion si quieres o no eliminar al empleado seleccionado, si precionas "Si" lo elimina 
            //y si precionas "No" se cancela y arroja un mensaje
            if (MessageBox.Show("Seguro que quiere eliminar a " + clientes + "?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DaoClientes userRegi = new DaoClientes();
                poc = dgEmpleados.CurrentRow.Index;
                int ID = int.Parse(dgEmpleados[0, poc].Value.ToString());

                /* if (ID == this.clientes.ID)
                {
                    MessageBox.Show("No se puede eliminar el usuario que está en uso del sistema.");
                }
                else */ if (userRegi.MEliminarCliente(ID))
                {
                    dgEmpleados.DataSource = new DaoClientes().Mmostrarclientes();
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
    }
}
