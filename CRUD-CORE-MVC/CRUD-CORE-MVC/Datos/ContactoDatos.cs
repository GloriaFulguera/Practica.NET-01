using CRUD_CORE_MVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_CORE_MVC.Datos
{
    public class ContactoDatos
    {

        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>();

            //instancia de Clase conexion para poder utilizar el metodo que obtiene la conexion
            var cn = new Conexion();

            //Conexion a BD
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //Ejecuto el procedure de la Base de Datos
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer cada registro de la tabla
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new ContactoModel()
                        {
                            idContacto = Convert.ToInt32(dr["idContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Email = dr["Email"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }

        public ContactoModel Obtener(int idContacto)
        {
            var oContacto = new ContactoModel();

            //instancia de Clase conexion para poder utilizar el metodo que obtiene la conexion
            var cn = new Conexion();

            //Conexion a BD
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                //Ejecuto el procedure de la Base de Datos
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("idContacto", idContacto);
                cmd.CommandType = CommandType.StoredProcedure;
                //Leer el registro de la tabla o lo que devuelve el SP
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.idContacto = Convert.ToInt32(dr["idContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Email = dr["Email"].ToString();
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto)
        {
            bool rta;

            try
            {
                //instancia de Clase conexion para poder utilizar el metodo que obtiene la conexion
                var cn = new Conexion();

                //Conexion a BD
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //Ejecuto el procedure de la Base de Datos
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Email", oContacto.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rta = false;
            }
            
            return rta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool rta;

            try
            {
                //instancia de Clase conexion para poder utilizar el metodo que obtiene la conexion
                var cn = new Conexion();

                //Conexion a BD
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //Ejecuto el procedure de la Base de Datos
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("idContacto", oContacto.idContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Email", oContacto.Email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rta = false;
            }

            return rta;
        }

        public bool Eliminar(int idContacto)
        {
            bool rta;

            try
            {
                //instancia de Clase conexion para poder utilizar el metodo que obtiene la conexion
                var cn = new Conexion();

                //Conexion a BD
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    //Ejecuto el procedure de la Base de Datos
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("idContacto", idContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rta = false;
            }

            return rta;
        }
    }
}
 