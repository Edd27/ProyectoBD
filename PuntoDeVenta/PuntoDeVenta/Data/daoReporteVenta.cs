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

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=bd; pwd=12345";
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

        public List<clsReporteVenta2> GenerarReporte2(string mes, string anio)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=bd; pwd=12345";
            conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "SELECT u.IdUsuario, CONCAT(u.Nombre,' ',u.Apellidos) AS Nombre, (SELECT COUNT(*) FROM VENTAS v WHERE v.Usuarios_IDusuario = u.IDusuario)AS Ventas, (SELECT SUM(v.Total) FROM Ventas v WHERE v.Usuarios_IDusuario = u.IDusuario)AS MontoTotal FROM usuarios u JOIN Ventas v ON u.IDusuario = v.Usuarios_IDusuario WHERE YEAR(v.Fecha) = '"+anio+"' AND MONTH(v.Fecha) = '"+mes+"' ORDER BY MontoTotal DESC";
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsReporteVenta2> lista = new List<clsReporteVenta2>();
            MySqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                clsReporteVenta2 obj = new clsReporteVenta2();
                obj.IDEmpleado = dr.GetInt32("IdUsuario");
                obj.Empleado = dr.GetString("Nombre");
                obj.Ventas = dr.GetInt32("Ventas");
                obj.MontoTotal = dr.GetInt32("MontoTotal");

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
