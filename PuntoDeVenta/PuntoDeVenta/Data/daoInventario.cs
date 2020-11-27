using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuntoDeVenta.Objects;
using MySql.Data.MySqlClient;

namespace PuntoDeVenta.Data
{
  public  class daoInventario
    {
        /// <summary>
        /// Metodo que obtiene todos los inventarios registrados, se obtiene su ID, Nombre y descripcion
        /// </summary>
        /// <returns></returns>
        /// Se retorna una lista de todos los inventarios encontrados
        public List<clsInventario> ObtenerTodos() {

            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
                conexxion.ConnectionString= "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                string strSQL = "select * from inventario";
                comando = new MySqlCommand(strSQL, conexxion);
                MySqlDataReader dr = comando.ExecuteReader();
                List<clsInventario> listinvent = new List<clsInventario>();

                while (dr.Read())
                {
                    clsInventario x = new clsInventario();
                    x.IDinventario = dr.GetInt32(0);
                    x.Nombre = dr.GetString(1);
                    x.Descripcion = dr.GetString(2);
                    listinvent.Add(x);
                }


           

                return listinvent;


            }
            catch (Exception)
            {
                return new List<clsInventario>();
            }
            finally
            {
                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }



        }

        /// <summary>
        /// Metodo que agrega un nuevo inventario a la base de datos, con ello recibe como parametro
        /// un objeto de inventario que sera el que se agregara
        /// </summary>
        /// <param name="invent"></param>
        /// <returns></returns>
        /// Retorna un true si el inventario fue agregado con exito a la base de datos
        /// Retorna un false si no se pudo agregar el inventario
        public bool AgregarInventario(clsInventario invent)
        {

            MySqlConnection cn = new MySqlConnection();
            MySqlCommand cm = new MySqlCommand();



            try
            {
                cn.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                cn.Open();
                String str = "Insert into inventario values(@ID,@Nombre,@Des)";
                cm = new MySqlCommand(str, cn);

                cm.Parameters.AddWithValue("@ID", invent.IDinventario);
                cm.Parameters.AddWithValue("@Nombre", invent.Nombre);
                cm.Parameters.AddWithValue("@Des", invent.Descripcion);
                cm.ExecuteNonQuery();

                return true;


            }
            catch (Exception)
            {

                return false;
            }
            finally {
                cm.Dispose();
                cn.Close();
                cn.Dispose();

            }
        }


        /// <summary>
        /// Metodo que obtiene un solo inventario de la base de datos basandose en su id, por ello el metodo
        /// recibe un valor de tipo int que sera el id con el que se obtendra el inventario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Retorna el inventario encontrado, y si no encuentra nada, retorna un objeto vacio

        public clsInventario ObtenerInventario(int id)
        {

            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                string strSQL = "select * from inventario where idinventario=@codigo";
                comando = new MySqlCommand(strSQL, conexxion);
                comando.Parameters.AddWithValue("@codigo",id);
                MySqlDataReader dr = comando.ExecuteReader();
               
                clsInventario x = new clsInventario();

                while (dr.Read())
                {
                    
                    x.IDinventario = dr.GetInt32(0);
                    x.Nombre = dr.GetString(1);
                    x.Descripcion = dr.GetString(2);
               
                }




                return x;


            }
            catch (Exception)
            {
                return new clsInventario();
            }
            finally
            {
                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }



        }

    }
}
