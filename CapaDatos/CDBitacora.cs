using System.Data;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDBitacora
    {
        public int Id { get; set; }
        public string TablaAfectada { get; set; }
        public int IdRegistro { get; set; }
        public string Usuario { get; set; }
        public string FechaHora { get; set; }
        public string TipoOperacion { get; set; }
        public string Campo { get; set; }
        public string ValorAntes { get; set; }
        public string ValorDespues { get; set; }
        public string Buscar { get; set; }


        public DataTable Listar()
        {
            DataTable resul = new DataTable("bitacora");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("splistar_bitacora", conexion);
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

        public DataTable BuscarUsuario(CDBitacora cli)
        {
            DataTable resul = new DataTable("bitacora");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand("spbuscar_bitacora_usuario", conexion);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@usuario", cli.Buscar);

                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(resul);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar cliente por nombre", ex);
                }
            }

            return resul;
        }


        public DataTable BuscarRegistro(CDBitacora cli)
        {
            DataTable resul = new DataTable("bitacora");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand("spbuscar_bitacora_registro", conexion);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@idregistro", cli.Buscar);

                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(resul);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar cliente por Telefono", ex);
                }
            }

            return resul;
        }

        public DataTable Filtrar(string tabla, string operacion)
        {
            DataTable resul = new DataTable("bitacora");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("spfiltrar_bitacora", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@tabla",
                    tabla == "TODOS" ? (object)DBNull.Value : tabla);

                cmd.Parameters.AddWithValue("@operacion",
                    operacion == "TODOS" ? (object)DBNull.Value : operacion);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(resul);
            }

            return resul;
        }

        public DataTable FiltrarPorFecha(DateTime fecha)
        {
            DataTable resul = new DataTable("bitacora");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("spfiltrar_bitacora_fecha", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(resul);
            }

            return resul;
        }


    }
}
