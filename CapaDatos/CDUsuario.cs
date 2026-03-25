
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Guardar(CDUsuario cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("spguardar_usuario", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@usuario", cli.usuario);
                Cmd.Parameters.AddWithValue("@pass", cli.pass);
                Cmd.Parameters.AddWithValue("@rol", cli.rol);
                Cmd.Parameters.AddWithValue("@estado", cli.estado);
                Cmd.Parameters.AddWithValue("@idempleado", cli.idempleado);

                resul = Cmd.ExecuteNonQuery() > 0 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
            return resul;
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


    }
}