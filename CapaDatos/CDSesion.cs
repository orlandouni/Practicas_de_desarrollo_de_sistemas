using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDSesion
    {
        public int IniciarSesion(int idUsuario)
        {
            int idSesion = 0;

            using (SqlConnection con = new SqlConnection(Conexion.Conn))
            {
                SqlCommand cmd = new SqlCommand("sp_IniciarSesion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlParameter salida = new SqlParameter("@idSesion", SqlDbType.Int);
                salida.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(salida);

                con.Open();
                cmd.ExecuteNonQuery();

                idSesion = Convert.ToInt32(salida.Value);
            }

            return idSesion;
        }

        public void CerrarSesion(int idSesion)
        {
            using (SqlConnection con = new SqlConnection(Conexion.Conn))
            {
                SqlCommand cmd = new SqlCommand("sp_CerrarSesion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idSesion", idSesion);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable Listar()
        {
            DataTable resul = new DataTable("sesiones_sistema");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("splistar_sesiones", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(resul);
            }
            catch (Exception)
            {
                resul = null;
                throw;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return resul;
        }

        public DataTable Filtrar(string nombreUsuario, DateTime? fecha)
        {
            DataTable resul = new DataTable("sesiones_sistema");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spfiltrar_sesiones", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // nombre usuario
                    if (string.IsNullOrWhiteSpace(nombreUsuario))
                        cmd.Parameters.AddWithValue("@nombreUsuario", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                    // fecha
                    if (fecha.HasValue)
                        cmd.Parameters.AddWithValue("@fecha", fecha.Value);
                    else
                        cmd.Parameters.AddWithValue("@fecha", DBNull.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(resul);
                }
                catch
                {
                    resul = null;
                    throw;
                }
            }

            return resul;
        }




    }
}
