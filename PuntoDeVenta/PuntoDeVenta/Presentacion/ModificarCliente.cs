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
    public partial class ModificarCliente : Form
    {
        public ModificarCliente()
        {
            InitializeComponent();
        }
        public ModificarCliente(List<clsClientes> algo)
        {
            InitializeComponent();
            txtID.Text = Convert.ToString(algo[0].ID);
            txtNombre.Text = algo[0].Nombre;
            txtApellidos.Text = algo[0].Apellidos;
            txttelefono.Text = algo[0].Numero_telefonico;
            
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ( txtNombre.Text == "" | txtApellidos.Text == "" | txttelefono.Text == "")
            {
                MessageBox.Show("Ningun campo puede quedar vacio");
            }
            else
            {
                clsClientes Registro = new clsClientes();
                Registro.ID = Convert.ToInt32(txtID.Text);
                Registro.Nombre = txtNombre.Text;
                Registro.Apellidos = txtApellidos.Text;
                Registro.Numero_telefonico= txttelefono.Text;


                DaoClientes modifica = new DaoClientes();
                if (modifica.MmodificarClientes(Registro))
                {
                    MessageBox.Show("Se ha modificado correctamente el empleado");
                    CatalogoClientes ventana = new CatalogoClientes();
                    ventana.Show();
                    this.Visible = false;
                }
                else
                {

                    MessageBox.Show("Algo salio mal");
                }
            }
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CatalogoClientes ventana = new CatalogoClientes();
            ventana.Show();
            this.Visible = false;
        }
    }
}
