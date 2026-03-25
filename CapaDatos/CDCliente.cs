using System.Data;
using System;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDCliente
    {
        public int idcliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }

        public string Buscar { get; set; }

        public DataTable Listar()
        {
            DataTable resul = new DataTable("cliente");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("splistar_clientes", conexion);
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

        public string Guardar(CDCliente cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("spguardar_cliente", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
                Cmd.Parameters.AddWithValue("@apellidos", cli.Apellidos);
                Cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                Cmd.Parameters.AddWithValue("@estado", cli.Estado);

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


        public string Editar(CDCliente cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();
                SqlCommand Cmd = new SqlCommand("speditar_cliente", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idcliente", cli.idcliente);
                Cmd.Parameters.AddWithValue("@nombre", cli.Nombre);
                Cmd.Parameters.AddWithValue("@apellidos", cli.Apellidos);
                Cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                Cmd.Parameters.AddWithValue("@estado", cli.Estado);

                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo editar el registro";

            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }

        public string Eliminar(CDCliente cli)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();
            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();
                SqlCommand Cmd = new SqlCommand("speliminar_cliente", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idcliente", cli.idcliente);

                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";

            }
            catch (Exception ex)
            {
                resul = ex.Message;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resul;
        }

        public DataTable BuscarNombre(CDCliente cli)
        {
            DataTable resul = new DataTable("cliente");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand("spbuscar_cliente_nombre", conexion);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@nombre", cli.Buscar);

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


        public DataTable BuscarTelefono(CDCliente cli)
        {
            DataTable resul = new DataTable("cliente");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand("spbuscar_cliente_telefono", conexion);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@telefono", cli.Buscar);

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

    }
}