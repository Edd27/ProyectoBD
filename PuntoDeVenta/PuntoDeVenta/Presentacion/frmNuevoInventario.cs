using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVenta.Data;
using PuntoDeVenta.Objects;

namespace PuntoDeVenta.Presentacion
{
    public partial class frmNuevoInventario : Form
    {
        public frmNuevoInventario()
        {
            InitializeComponent();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!tbNombre.Text.Equals("") | !tbDesc.Text.Equals(""))
            {
                clsInventario x = new clsInventario();
                x.Descripcion = tbDesc.Text;
                x.IDinventario = 0;
                x.Nombre = tbNombre.Text;

                if (agregado(x))
                {
                    MessageBox.Show("Agregado correctamente");
                    tbDesc.Text = "";
                    tbNombre.Text = "";

                }
                else
                {
                    MessageBox.Show("No se pudo agregar");
                }

            }
            else {


                MessageBox.Show("Ingrese todos los datos");
            }


        
        }




        public bool agregado(clsInventario nuevo) {

            return new daoInventario().AgregarInventario(nuevo);
        }

        private void frmNuevoInventario_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
