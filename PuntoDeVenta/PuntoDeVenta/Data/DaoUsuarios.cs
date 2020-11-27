using MySql.Data.MySqlClient;
using PuntoDeVenta.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PuntoDeVenta.Data
{

    
    class DaoUsuarios
    {
 
        /// <summary>
        /// Metodo que agrega todos los datos de un empleado a la base de datos
        /// Recibe un parametro de tipo clsUsuarios
        /// </summary>
        /// <param name="agrega"></param>
        /// <returns></returns>
        /// Retorna un true si el empleado fue agregado con exito a la base de datos
        /// Retorna un false si no se pudo agregar el empleado

        public bool MAgregarUsuario(clsUsuarios agrega)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();

                /// AGREGAR EL REGISTRO A LA BASE DE DATOS
                string strSQL = "insert into usuarios values (@IDusuario,@Login,@Nombre,@Apellidos,sha(@Password),@Administrador)";
                comando = new MySqlCommand(strSQL, conexxion);

                comando.Parameters.AddWithValue("@IDusuario", null);
                comando.Parameters.AddWithValue("@Login", agrega.Login);
                comando.Parameters.AddWithValue("@Nombre", agrega.Nombre);
                comando.Parameters.AddWithValue("@Apellidos", agrega.Apellidos);
                comando.Parameters.AddWithValue("@Password", agrega.Password);
                comando.Parameters.AddWithValue("@Administrador", agrega.Administrador);
                comando.ExecuteNonQuery();
                   return true;
        }
            catch(Exception e)
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
        public List<clsMuestraEmpleados> MmostrarEmpleados()
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
           
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "select IDusuario, Nombre, Apellidos from usuarios";
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsMuestraEmpleados> lista = new List<clsMuestraEmpleados>();
            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                clsMuestraEmpleados obj = new clsMuestraEmpleados();
                obj.IDusuario = dr.GetInt32("IDusuario");
                obj.Nombre = dr.GetString("Nombre");
                obj.Apellidos = dr.GetString("Apellidos");


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
        public bool MEliminarUsuario(int llaveP)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();

                /// ELIMINA EL REGISTRO DE LA BASE DE DATOS
                string strSQL = "delete from usuarios where IDusuario = " + llaveP;
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
        public List<clsUsuarios> MtraerEmpleado(int idE)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
            conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "select * from usuarios where IDusuario = "+idE;
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsUsuarios> lista = new List<clsUsuarios>();
            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                clsUsuarios obj = new clsUsuarios();
                obj.IDusuario = dr.GetInt32("IDusuario");
                obj.Login= dr.GetString("Login");
                obj.Nombre = dr.GetString("Nombre");
                obj.Apellidos = dr.GetString("Apellidos");
                obj.Password = dr.GetString("Password");
                obj.Administrador = dr.GetBoolean("Administrador");

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
        public bool MmodificarEmpleado(clsUsuarios obj)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            try
            {
                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();

                /// AGREGAR LA ACTUALIZACION A LA BASE DE DATOS
                string strSQL = "Update usuarios Set Login='"+obj.Login+"' , Nombre='"+obj.Nombre+"' , Apellidos='"+obj.Apellidos+"' , Password='"+obj.Password+"' , Administrador="+obj.Administrador+" Where IDusuario="+obj.IDusuario;
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
        public List<clsMuestraEmpleados> MBuscarEmpleados(clsMuestraEmpleados Busqueda)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
            conexxion.Open();
            /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
            string strSQL = "select IDusuario, Nombre, Apellidos from usuarios where Nombre like'"+ Busqueda.Nombre+"%'";
            comando = new MySqlCommand(strSQL, conexxion);
            List<clsMuestraEmpleados> lista = new List<clsMuestraEmpleados>();
            MySqlDataReader dr = comando.ExecuteReader();

            while (dr.Read())
            {
                clsMuestraEmpleados objB = new clsMuestraEmpleados();
                objB.IDusuario = dr.GetInt32("IDusuario");
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

        public int logear(String Usuario, String Contra) {

            clsUsuarios aac = new clsUsuarios();
           
            MySqlConnection Conexion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
            try
            {
                Conexion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                Conexion.Open();

                string consulta = "select * from usuarios where login=@usu and password=SHA(@contra)";

                comando = new MySqlCommand(consulta, Conexion);
                comando.Parameters.AddWithValue("@usu", Usuario);
                comando.Parameters.AddWithValue("@contra", Contra);
                
                MySqlDataReader DaR = comando.ExecuteReader();
                int id=0;
                while (DaR.Read()) {
                    id = DaR.GetInt16(0);
                }
                
                return id;
            }
            catch
            {
                return 0;
            }
            finally
            {
                comando.Dispose();
                Conexion.Close();
                Conexion.Dispose();

            }





        }



        /// <summary>
        /// Metodo obtiene los datos de un empleado de la base de datps
        /// Recibe un parámetro de tipo int
        /// </summary>
        /// <param name="idE"></param>
        /// <returns></returns>
        /// Retorna eun objeto de tipo clsUsuarios con los datos del empleado 
        public clsUsuarios obtenerUsuario(int idE)
        {
            MySqlConnection conexxion = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();

            try
            {
             

                conexxion.ConnectionString = "server=localhost; database=puntodeventa; user=root; pwd=root";
                conexxion.Open();
                /// EXTRAE EL REGISTRO DE LA BASE DE DATOS
                string strSQL = "select * from usuarios where IDusuario = " + idE;
                comando = new MySqlCommand(strSQL, conexxion);
                List<clsUsuarios> lista = new List<clsUsuarios>(); MySqlDataReader dr = comando.ExecuteReader();
                clsUsuarios obj = new clsUsuarios();
                while (dr.Read())
                {

                    obj.IDusuario = dr.GetInt32("IDusuario");
                    obj.Login = dr.GetString("Login");
                    obj.Nombre = dr.GetString("Nombre");
                    obj.Apellidos = dr.GetString("Apellidos");
                    obj.Password = dr.GetString("Password");
                    obj.Administrador = dr.GetBoolean("Administrador");
                 

                    //comando.Parameters.AddWithValue("@Administrador", agrega.Administrador);

                }
               
                return obj;

            }
            catch (Exception)
            {

                return new clsUsuarios();
            }
            finally {
                comando.Dispose();
                conexxion.Close();
                conexxion.Dispose();

            }
           
            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
          
           
        }

    }
}
