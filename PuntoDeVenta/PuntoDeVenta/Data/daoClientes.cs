using MySql.Data.MySqlClient;
using PuntoDeVenta.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PuntoDeVenta.Data
{


    class DaoClientes
    {

        /// <summary>
        /// Metodo que agrega todos los datos de un empleado a la base de datos
        /// Recibe un parametro de tipo clsUsuarios
        /// </summary>
        /// <param name="agrega"></param>
        /// <returns></returns>
        /// Retorna un true si el empleado fue agregado con exito a la base de datos
        /// Retorna un false si no se pudo agregar el empleado

        public bool MAgregarClientes(clsClientes agrega)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();

                /// AGREGAR EL REGISTRO A LA BASE DE DATOS
                string strSQL = "insert into clientes values (@ID,@Nombre,@Apellidos,@numero_telefonico)";
                comando = new MySqlCommand(strSQL, conexxion);

                comando.Parameters.AddWithValue("@ID", null);
                comando.Parameters.AddWithValue("@Nombre", agrega.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", agrega.Apellidos);
                comando.Parameters.AddWithValue("@numero_telefonico", agrega.Numero_telefonico);
                // comando.Parameters.AddWithValue("@numero_telefonico", agrega.numero_telefonico);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }
            /// FINALIZAMOS LA CONEXION CERRAMOS TODO

        }


        /// <summary>
        /// Metodo que muestra el ID, el Nombre y los Apellidos de los empleados
        /// </summary>
        /// <returns></returns>
        /// Se retorna una lista de todos los Empleados encontrados
        public List<clsMuestraClientes> Mmostrarclientes()
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
            conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "select * from clientes";
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsMuestraClientes> lista = new List<clsMuestraClientes>();
            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                clsMuestraClientes obj = new clsMuestraClientes();
                obj.ID = dr.GetInt32("ID");
                obj.Nombre = dr.GetString("Nombre");
                obj.Apellidos = dr.GetString("Apellidos");
                obj.Numero_telefonico = dr.GetString("Numero_telefonico");

                lista.Add(obj);
            }
            comando.Dispose();

            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
            conexxion.Close();
            conexxion.Dispose();
            return lista;
        }


        /// <summary>
        /// Metodo que Elimina un empleado de la base de datos
        /// Recibe un parametro de tipo int
        /// </summary>
        /// <param name="llaveP"></param>
        /// <returns></returns>
        /// Retorna un true si el empleado fue eliminado con exito de la base de datos
        /// Retorna un false si no se pudo eliminar el empleado
        public bool MEliminarCliente(int llaveP)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();

                /// ELIMINA EL REGISTRO DE LA BASE DE DATOS
                string strSQL = "delete from clientes where ID = " + llaveP;
                comando = new MySqlCommand(strSQL, conexxion);
                comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }
            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
        }


        /// <summary>
        /// Metodo que extrae todos los datos un empleado de la base de datos
        /// Recibe un parametro de tipo int
        /// </summary>
        /// <param name="idE"></param>
        /// <returns></returns>
        /// Retorna una lista de todos los datos de un Empleado encontrado
        public List<clsClientes> MtraerClientes(int idE)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
            conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "select * from clientes where ID = " + idE;
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsClientes> lista = new List<clsClientes>();
            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                clsClientes obj = new clsClientes();
                obj.ID = dr.GetInt32("ID");
                obj.Nombre = dr.GetString("Nombre");
                obj.Apellidos = dr.GetString("Apellidos");
                
                

                //comando.Parameters.AddWithValue("@Administrador", agrega.Administrador);

                lista.Add(obj);
            }
            comando.Dispose();

            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
            conexxion.Close();
            conexxion.Dispose();
            return lista;
        }

        /// <summary>
        /// Metodo que Modifica un empleado de la base de datos
        /// Recibe un parametro de tipo clsUsuarios
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// Retorna un true si el empleado fue Modificado con exito en la base de datos
        /// Retorna un false si no se pudo Modificar el empleado
        public bool MmodificarClientes(clsClientes obj)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();

                /// AGREGAR LA ACTUALIZACION A LA BASE DE DATOS
                string strSQL = "Update clientes Set Nombre='" + obj.Nombre + "' , Apellidos='" + obj.Apellidos  + " Where ID=" + obj.ID;
                comando = new MySqlCommand(strSQL, conexxion);
                comando.ExecuteNonQuery();



                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();
            }
            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
        }


        /// <summary>
        /// Metodo que Busca y trae el ID, el Nombre y los Apellidos de los empleados de la base de datos
        /// Recibe un parametro de tipo clsMuestraEmpleados
        /// </summary>
        /// <param name="Busqueda"></param>
        /// <returns></returns>
        /// Retorna una lista de los empleados encontrados en la base de datos
        public List<clsMuestraClientes> MBuscarClientes(clsMuestraClientes Busqueda)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
            conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "select ID, Nombre, Apellidos, Numero_telefonico from usuarios where Nombre like'" + Busqueda.Nombre + "%'";
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsMuestraClientes> lista = new List<clsMuestraClientes>();
            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                clsMuestraClientes objB = new clsMuestraClientes();
                objB.ID = dr.GetInt32("ID");
                objB.Nombre = dr.GetString("Nombre");
                objB.Apellidos = dr.GetString("Apellidos");


                lista.Add(objB);
            }
            comando.Dispose();

            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
            conexxion.Close();
            conexxion.Dispose();


            return lista;
        }




        /// <summary>
        /// Metodo que valida las credenciales insertadas por el usuario 
        /// Recibe dos parámetros de tipo String
        /// </summary>
        /// <param name="Usuario"></param>
        /// /// <param name="Contra"></param>
        /// <returns></returns>
        /// Retorna el id del usuario logueado




        /// <summary>
        /// Metodo obtiene los datos de un empleado de la base de datps
        /// Recibe un parámetro de tipo int
        /// </summary>
        /// <param name="idE"></param>
        /// <returns></returns>
        /// Retorna eun objeto de tipo clsUsuarios con los datos del empleado 
        public clsClientes obtenerCliente(int idE)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {


                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
                string strSQL = "select * from clientes where IDusuario = " + idE;
                comando = new MySqlCommand(strSQL, conexxion);
                List<clsClientes> lista = new List<clsClientes>(); MySqlDataReader dr = comando.ExecuteReader();
                clsClientes obj = new clsClientes();
                while (dr.Read())
                {

                    obj.ID = dr.GetInt32("IDusuario");
                    obj.Nombre = dr.GetString("Nombre");
                    obj.Apellidos = dr.GetString("Apellidos");
                    


                    //comando.Parameters.AddWithValue("@Administrador", agrega.Administrador);

                }

                return obj;

            }
            catch (Exception)
            {

                return new clsClientes();
            }
            finally
            {
                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();

            }

            /// FINALIZAMOS LA CONEXION CERRAMOS TODO


        }

    }
}
