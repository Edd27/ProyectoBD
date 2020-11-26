using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentacion;
using PuntoDeVenta.Objects;

namespace PuntoDeVenta.Presentacion
{
    public partial class MenuPrincipal : Form
    {

        clsUsuarios usuario;

       /// <summary>
       /// Crecacion de los componentes, se crea un usuario que es el que recibe al momento de logearse
       /// </summary>
       /// <param name="us"></param>
        public MenuPrincipal(clsUsuarios us)
        {
            InitializeComponent();
            usuario = us;
        }


        /// <summary>
        /// Metodo del timer que da el valor de la hora y fecha a los labels asignados para esa funcion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dddd:MMMM:yyy");
        }

        /// <summary>
        /// Cierra la ventana y tambien finaliza la ejecucion del programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Metodo de click del boton de inventario
        /// Al momento que se le da click muestra la interfaz del inventario
        /// y deja de mostrar la interfaz de menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario invent = new Inventario();
            this.Visible = false;
            invent.ShowDialog();
            this.Visible = true;
        }

        /// <summary>
        /// Metodo de click del boton de ventas
        /// Al momento que se le da click muestra la interfaz de ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas(usuario);
            ventas.Show();
        }
        /// <summary>
        ///Metodo de click del boton de usuarios
        ///Al momento que se le da click muestra la interfaz de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            CatalogoEmpleados ventana = new CatalogoEmpleados();
            ventana.openFromMenu(usuario);
            ventana.Show();
        }

        /// <summary>
        /// Metodo que se ejecuta al momento que se carga la interfaz, este asigna 
        /// al label el nombre del usuario y verifica si es administrados o no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lbUsuario.Text = usuario.Nombre;

            if (usuario.Administrador== false)
            {
                btnUsuarios.Enabled = false;
            }
        }

        /// <summary>
        ///Metodo de click del boton de usuarios
        ///Al momento que se le da click muestra la interfaz de ajustes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAhustes_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmAjustes objAjustes = new frmAjustes(usuario);
            objAjustes.ShowDialog();
            this.Visible = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        ///Metodo de click del boton de usuarios
        ///Al momento que se le da click muestra la interfaz de finanzas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticos_Click(object sender, EventArgs e)
        {
            this.Visible = false;
         
            new frmFinanzasPorCliente().ShowDialog();
            this.Visible = true;
        }
    }
}
