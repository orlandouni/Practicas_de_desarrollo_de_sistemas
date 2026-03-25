using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDEmpleado
    {
        public int idempleado { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        // ============================================
        // LISTAR
        // ============================================
        public DataTable Listar()
        {
            DataTable resul = new DataTable("empleado");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("spmostrar_empleado", conexion);
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

        // ============================================
        // BUSCAR
        // ============================================
        public DataTable Buscar(string texto)
        {
            DataTable resul = new DataTable("empleado");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("spbuscar_empleado", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@texto", texto);

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


        // ============================================
        // GUARDAR
        // ============================================
        public string Guardar(CDEmpleado emp)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("spinsertar_empleado", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@nombre", emp.Nombre);
                Cmd.Parameters.AddWithValue("@apellidos", emp.Apellidos);
                Cmd.Parameters.AddWithValue("@rfc", emp.Rfc);
                Cmd.Parameters.AddWithValue("@telefono", emp.Telefono);
                Cmd.Parameters.AddWithValue("@direccion", emp.Direccion);
                Cmd.Parameters.AddWithValue("@estado", emp.Estado);

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

        // ============================================
        // EDITAR
        // ============================================
        public string Editar(CDEmpleado emp)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("speditar_empleado", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idempleado", emp.idempleado);
                Cmd.Parameters.AddWithValue("@nombre", emp.Nombre);
                Cmd.Parameters.AddWithValue("@apellidos", emp.Apellidos);
                Cmd.Parameters.AddWithValue("@rfc", emp.Rfc);
                Cmd.Parameters.AddWithValue("@telefono", emp.Telefono);
                Cmd.Parameters.AddWithValue("@direccion", emp.Direccion);
                Cmd.Parameters.AddWithValue("@estado", emp.Estado);

                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo editar el registro";
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

        // ============================================
        // ELIMINAR
        // ============================================
        public string Eliminar(CDEmpleado emp)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("speliminar_empleado", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idempleado", emp.idempleado);

                resul = Cmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
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
    }
}