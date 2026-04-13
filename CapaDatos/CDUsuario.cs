using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDUsuario
    {
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public string pass { get; set; }
        public string rol { get; set; }
        public string estado { get; set; }
        public int idempleado { get; set; }
        public string Buscar { get; set; }

        public DataTable Listar()
        {
            DataTable resul = new DataTable("usuario");
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                SqlCommand cmd = new SqlCommand("splistar_usuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resul);
            }
            catch (Exception ex)
            {
                resul = null;
            }
            return resul;
        }


        public string Guardar(CDUsuario cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spguardar_usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@usuario", cli.usuario);
                cmd.Parameters.AddWithValue("@pass", cli.pass);
                cmd.Parameters.AddWithValue("@rol", cli.rol);
                cmd.Parameters.AddWithValue("@estado", cli.estado);
                cmd.Parameters.AddWithValue("@idempleado", cli.idempleado);

                resul = cmd.ExecuteNonQuery() > 0 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return resul;
        }

        public string Editar(CDUsuario cli)
        {
            string res = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();
                SqlCommand cmd = new SqlCommand("speditar_usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idusuario", cli.idusuario);
                cmd.Parameters.AddWithValue("@usuario", cli.usuario);
                cmd.Parameters.AddWithValue("@pass", cli.pass);
                cmd.Parameters.AddWithValue("@rol", cli.rol);
                cmd.Parameters.AddWithValue("@estado", cli.estado);
                cmd.Parameters.AddWithValue("@idempleado", cli.idempleado);

                res = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se editaron los datos";
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return res;
        }

        public string Eliminar(CDUsuario usu)
        {
            string res = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();
                SqlCommand cmd = new SqlCommand("speliminar_usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idusuario", usu.idusuario);

                res = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminaron los datos";
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open) conexion.Close();
            }
            return res;
        }

        public CDUsuario ObtenerPorUsuario(string nombreUsuario)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("spvalidar_Usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new CDUsuario
                    {
                        idusuario = Convert.ToInt32(reader["idusuario"]),
                        usuario = reader["usuario"].ToString(),
                        pass = reader["pass"].ToString(),
                        rol = reader["rol"].ToString(),
                        estado = reader["estado"].ToString(),
                        idempleado = Convert.ToInt32(reader["idempleado"])
                    };
                }
                return null;
            }
        }

        public DataTable BuscarNombre(CDUsuario usu)
        {
            DataTable resul = new DataTable("usuario");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                SqlCommand cmd = new SqlCommand("spbuscar_usuario_nombre", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", usu.Buscar);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resul);
            }
            catch (Exception ex)
            {
                resul = null;
            }
            return resul;
        }

        public DataTable BuscarNombreUsuario(CDUsuario usu)
        {
            DataTable resul = new DataTable("usuario");
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                SqlCommand cmd = new SqlCommand("spbuscar_usuario_nombre_usuario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreusuario", usu.Buscar);

                SqlDataAdapter sqldat = new SqlDataAdapter(cmd);
                sqldat.Fill(resul);
            }
            catch (Exception ex)
            {
                resul = null;
            }
            return resul;
        }
    }
}