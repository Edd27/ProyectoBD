using System;

using System.Drawing;
using System.Linq;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using PuntoDeVenta.Presentacion;
using PuntoDeVenta.Data;
using PuntoDeVenta.Objects;
using MySql.Data.MySqlClient;
namespace Presentacion
{
    public partial class FormLogin : Form
    {
         
           
        public FormLogin()
        {
            InitializeComponent();
        }

     

        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Placeholder or WaterMark
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        #endregion 

        private void btncerrar_Click(object sender, EventArgs e)
        {
            //Boton para cerrar la aplicacion
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            //Boton para minimizar
            this.WindowState = FormWindowState.Minimized;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {


         

            //Se valida que los campos de los texbox no esten vacios 

            if (!txtuser.Text.Equals("") | !txtpass.Text.Equals(""))
            {
                //Se obtiene los datos de los texbox y se mandan al metodo DaoUsuarios
                int id = new DaoUsuarios().logear(txtuser.Text,txtpass.Text);

                if (id > 0)
                {
                        //Se manda llamadar al metodo DaoUsuarios
                    clsUsuarios us = new DaoUsuarios().obtenerUsuario(id);
                    //Se lleva al menu principal 
                  
                    MenuPrincipal obj= new MenuPrincipal(us);
                    obj.Show();
                    this.Visible = false;
                }
                else
                {
                    //Se manda un mensaje de error de datos incorrectos
                  Datoserror da=  new Datoserror();
                    da.Show();
                 
                }
            }


        }

        private void linkpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
