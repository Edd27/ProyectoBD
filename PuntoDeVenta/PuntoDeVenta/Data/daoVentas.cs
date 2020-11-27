using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuntoDeVenta.Objects;

namespace PuntoDeVenta.Data
{
    public class daoVentas
    {
        /// <summary>
        /// Crea una transacción, e inserta todos los datos de las ventas y reporte de ventas
        /// </summary>
        /// <param name="venta"></param>
        /// <param name="productos"></param>
        /// <returns>True si funcionó, false si nó</returns>
        public bool insertar(clsVentas venta, List<clsListaProductos> productos)
        {
            MySqlConnection cn = new MySqlConnection();
            MySqlCommand cm = new MySqlCommand();
            try
            {
                cn.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                cn.Open();
                MySqlTransaction trans = cn.BeginTransaction();

                try
                {

                    String str = "Insert into ventas(Fecha,Total,Usuarios_IDusuario) values(@Fecha,@Total,@Usuario)";
                    cm = new MySqlCommand(str, cn);
                    cm.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    cm.Parameters.AddWithValue("@Total", venta.Total);
                    cm.Parameters.AddWithValue("@Usuario", venta.Usuarios_IDusuario);
                    Console.WriteLine(venta.Usuarios_IDusuario);
                    cm.ExecuteNonQuery();

                    str = "SELECT LAST_INSERT_ID() as lastid";
                    cm = new MySqlCommand(str, cn);
                    String id = cm.ExecuteScalar().ToString();
                    str = "Insert into reporte_de_Ventas values(@IDProducto,@IDVenta,@PrecioUnitario,@Cantidad)";

                    foreach (clsListaProductos reporte in productos)
                    {
                        cm = new MySqlCommand(str, cn);
                        cm.Parameters.AddWithValue("@IDProducto", reporte.IdProducto);
                        cm.Parameters.AddWithValue("@IDVenta", id);
                        cm.Parameters.AddWithValue("@PrecioUnitario", reporte.Precio);
                        cm.Parameters.AddWithValue("@Cantidad", reporte.Cantidad);
                        cm.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                cm.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }
    }
}
