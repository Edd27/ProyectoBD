using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuntoDeVenta.Objects;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta.Data
{
    public class daoReporteVenta
    {

        public List<clsReporteVenta> GenerarReporte(string fechaInicio, string fechaFin)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=12345678";
            conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "SELECT v.IDVenta, v.Fecha, v.Total, u.Nombre FROM Ventas v JOIN Usuarios u ON u.IDusuario = v.Usuarios_IDusuario WHERE Fecha BETWEEN '" + fechaInicio +"' AND '" + fechaFin + "' ORDER BY Fecha ASC ";
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsReporteVenta> lista = new List<clsReporteVenta>();
            MySqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                clsReporteVenta obj = new clsReporteVenta();
                obj.IDReporte = dr.GetInt32("IDVenta");
                obj.Fecha = dr.GetString("Fecha");
                obj.MontoTotal = dr.GetInt32("Total");
                obj.Empleado = dr.GetString("Nombre");

                lista.Add(obj);
            }
            comando.Dispose();

            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
            conexxion.Close();
            conexxion.Dispose();
            return lista;
        }

    }
}
