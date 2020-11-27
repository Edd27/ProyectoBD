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
    public partial class frmFinanzasPorCliente : Form
    {
        /// <summary>
        /// Estas son los componentes que utilizaremos, como los productos
        /// </summary>
        daoProductos objDaoProductos = new daoProductos();
        clsProductos Productos = new clsProductos();
        string cad=""; 
        public frmFinanzasPorCliente()
        {
            //incializamos la lista 
            InitializeComponent();
            agregarComponentes();

        }
        /// <summary>
        /// Ponemos todos los componentes en el combo box
        /// </summary>
        void agregarComponentes()
        {
            List<clsProductos> myProductos = objDaoProductos.ObtenerProductos();
            int ln = myProductos.Count();
            for (int i = 0; i < ln; i++)
            {
                string cad = myProductos[i].Producto.ToString();
                // cbProductos.Items.Add(cad);
            }


        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnproducto_Click(object sender, EventArgs e)
        {
          //  cad += cbProductos.SelectedIndex.ToString();
            cad += "\n";
          //  TextCosa.Text = cad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cad = fecha1.Value.ToString();
            string cad2 =fecha2.Value.ToString();
            List<clsEtadistico> cosas= objDaoProductos.llenarTabla(cad,cad2);
            
                
            
            dataGridView1.DataSource = cosas;
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
