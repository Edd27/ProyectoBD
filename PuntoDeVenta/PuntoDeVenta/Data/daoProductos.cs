using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuntoDeVenta.Objects;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PuntoDeVenta.Data
{
  public  class daoProductos
    {
        /// <summary>
        /// Metodo que obtiene todos los productos dentro de la base de datos
        /// </summary>
        /// <returns></returns>
        /// retorna una lista con todos los productos
        public List<clsProductos> ObtenerProductos() {


            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                string strSQL = "select * from producto";
                comando = new MySqlCommand(strSQL, conexxion);
                MySqlDataReader dr = comando.ExecuteReader();
                List<clsProductos> listprod = new List<clsProductos>();

                while (dr.Read())
                {
                    clsProductos x = new clsProductos();

                    x.IDproducto = dr.GetInt32(0);
                    x.Producto = dr.GetString(1);
                    x.Descripcion = dr.GetString(2);
                    x.Tipo = dr.GetString(3);
                    x.Talla = dr.GetString(4);
                    x.Precio = dr.GetDouble(5);
                    x.IDinventario = dr.GetInt16(6);
                    listprod.Add(x);
                }




                return listprod;



            }
            catch (Exception)
            {

                return new List<clsProductos>();
            }
            finally {

                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }
        
        }

        /// <summary>
        /// Metodo para obtener un producto que se encuentre en la base de datos
        ///Recibe como parametro un int que este sera el id a buscar
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        /// retorna un producto que su id sea igual al que se recibio en el parametro
        /// retorna un producto vacio si no se encontro alguno
        public clsProductos ObtenerProducto(int codigo)
        {


            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                string strSQL = "select * from producto where idProducto = @numero";
                comando = new MySqlCommand(strSQL, conexxion);
                comando.Parameters.AddWithValue("@numero",codigo);
                MySqlDataReader dr = comando.ExecuteReader();
              
                clsProductos x = new clsProductos();

                while (dr.Read())
                {
                   

                    x.IDproducto = dr.GetInt32(0);
                    x.Producto = dr.GetString(1);
                    x.Descripcion = dr.GetString(2);
                    x.Tipo = dr.GetString(3);
                    x.Talla = dr.GetString(4);
                    x.Precio = dr.GetDouble(5);
                    x.IDinventario = dr.GetInt16(6);
                   
                }




                return x;



            }
            catch (Exception)
            {

                return new clsProductos();
            }
            finally
            {

                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }

        }

        /// <summary>
        /// Metodo para agregar un producto dentro de la base de datos
        /// se recibe un producto el cual sera agregado
        /// </summary>
        /// <param name="nuevo"></param>
        /// <returns></returns>
        /// retorna un true si el producto fue agregado correctamente
        /// retorna un false si el producto no se pudo agregar
        public bool AgregarProducto(clsProductos nuevo) {

            MySqlConnection cn = new MySqlConnection();
            MySqlCommand cm= new MySqlCommand(); 

            try
            {
                cn.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root ";
                cn.Open();

                String srt = "insert into producto values(@ID,@Prod,@Desc,@Tipo,@Talla,@Precio,@inventario)";
                cm = new MySqlCommand(srt, cn);
                cm.Parameters.AddWithValue("@ID", nuevo.IDproducto);
                cm.Parameters.AddWithValue("@Prod", nuevo.Producto);
                cm.Parameters.AddWithValue("@Desc", nuevo.Descripcion);
                cm.Parameters.AddWithValue("@Tipo", nuevo.Tipo);
                cm.Parameters.AddWithValue("@Talla", nuevo.Talla);
                cm.Parameters.AddWithValue("@Precio", nuevo.Precio);
                cm.Parameters.AddWithValue("@inventario", nuevo.IDinventario);
                cm.ExecuteNonQuery();
                return true;



            }
            catch (Exception ex)
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
        /// Metodo para modificar un producto de la base de datos
        /// Se recibe un producto el cual es el que sera modificado
        /// </summary>
        /// <param name="nuevo"></param>
        /// <returns></returns>
        /// retorna un true si el producto fue modificado correctamente
        /// retorna un false si el producto no pudo ser modificado
        public bool ModificarProducto(clsProductos nuevo)
        {

            MySqlConnection cn = new MySqlConnection();
            MySqlCommand cm = new MySqlCommand();

            try
            {
                cn.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root ";
                cn.Open();

                String srt = " UPDATE producto SET Producto=@Prod,Descripcion=@Desc,Tipo=@Tipo,Talla=@Talla,Precio=@Precio,idInventario=@inventario where idProducto= @ID";
                cm = new MySqlCommand(srt, cn);
                cm.Parameters.AddWithValue("@ID", nuevo.IDproducto);
                cm.Parameters.AddWithValue("@Prod", nuevo.Producto);
                cm.Parameters.AddWithValue("@Desc", nuevo.Descripcion);
                cm.Parameters.AddWithValue("@Tipo", nuevo.Tipo);
                cm.Parameters.AddWithValue("@Talla", nuevo.Talla);
                cm.Parameters.AddWithValue("@Precio", nuevo.Precio);
                cm.Parameters.AddWithValue("@inventario", nuevo.IDinventario);
                cm.ExecuteNonQuery();
                return true;



            }
            catch (Exception)
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

        /// <summary>
        /// Metodo que elimina un producto de la base de datos
        /// Recibe como parametro un int que sera el id del producto a eliminar
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        /// retorna un true si el producto se elimino correctamente
        /// retorna un false si el producto no se pudo eliminar
        public bool EliminarProducto(int codigo) {

            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                string strSQL = "Delete from producto where idProducto = @numero";
                comando = new MySqlCommand(strSQL, conexxion);
                comando.Parameters.AddWithValue("@numero", codigo);
                comando.ExecuteNonQuery();

                




                return true;



            }
            catch (Exception)
            {

                return false;
            }
            finally
            {

                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }



        }

        /// <summary>
        /// Metodo que busca productos en base a palabras claves
        /// Recibe como parametro un string que seran las palabras o la palabra clave a buscar
        /// </summary>
        /// <param name="palabras"></param>
        /// <returns></returns>
        /// retorna una lista con todos los productos encontrados con esa palabra
        public List<clsProductos> BuscarProductos(String palabras)
        {


            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                string strSQL = "SELECT * FROM producto where producto like concat( @texto ,'%')";
                comando = new MySqlCommand(strSQL, conexxion);
                comando.Parameters.AddWithValue("@texto", palabras);
                MySqlDataReader dr = comando.ExecuteReader();
                List<clsProductos> listprod = new List<clsProductos>();

                while (dr.Read())
                {
                    clsProductos x = new clsProductos();

                    x.IDproducto = dr.GetInt32(0);
                    x.Producto = dr.GetString(1);
                    x.Descripcion = dr.GetString(2);
                    x.Tipo = dr.GetString(3);
                    x.Talla = dr.GetString(4);
                    x.Precio = dr.GetDouble(5);
                    x.IDinventario = dr.GetInt16(6);
                    listprod.Add(x);
                }




                return listprod;



            }
            catch (Exception)
            {

                return new List<clsProductos>();
            }
            finally
            {

                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }

        }
        /// <summary>
        /// Metodo para llenar la tabla de finanzas
        /// Se recibe dos fechas
        /// </summary>
        /// <param name="nuevo"></param>
        /// <returns></returns>
        /// retorna una lista con los datos
        /// retorna una lista vacia 
        public List<clsEtadistico> llenarTabla(string fecha1, string fecha2)
        {


            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                string strSQL = "select count(total)as ventas,(select nombre from usuarios where Usuarios_IDusuario=IDusuario )as nombre, " +
                    "total from ventas where fecha between('2020-05-19')and('2020-05-20') GROUP BY Usuarios_IDusuario; ";
                comando = new MySqlCommand(strSQL, conexxion);
                MySqlDataReader dr = comando.ExecuteReader();
                List<clsEtadistico> listprod = new List<clsEtadistico>();
                while (dr.Read())
                {
                    clsEtadistico x = new clsEtadistico();
                    //MessageBox.Show(dr.GetString(0) + " " + dr.GetString(1));
                    x.Ventas = dr.GetInt32(0);
                    x.Nombre = dr.GetString(1);
                    x.Total = dr.GetInt32(2);
                    listprod.Add(x);
                   
                }
                return listprod;
            }
            catch (Exception)
            {

                return new List<clsEtadistico>() ;
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
