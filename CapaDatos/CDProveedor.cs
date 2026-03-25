using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDProveedor
    {
        public int idproveedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }


        public DataTable Listar()
        {
            DataTable resul = new DataTable("proveedor");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("splistar_proveedores", conexion);
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

        public string Guardar(CDProveedor prov)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("spguardar_proveedor", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@telefono", prov.Telefono);
                Cmd.Parameters.AddWithValue("@direccion", prov.Direccion);
                Cmd.Parameters.AddWithValue("@estado", prov.Estado);
                Cmd.Parameters.AddWithValue("@nombre", prov.Nombre);

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

        public string Editar(CDProveedor prov)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("speditar_proveedor", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idproveedor", prov.idproveedor);
                Cmd.Parameters.AddWithValue("@telefono", prov.Telefono);
                Cmd.Parameters.AddWithValue("@direccion", prov.Direccion);
                Cmd.Parameters.AddWithValue("@estado", prov.Estado);
                Cmd.Parameters.AddWithValue("@nombre", prov.Nombre);

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

        public string Eliminar(CDProveedor prov)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("speliminar_proveedor", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idproveedor", prov.idproveedor);

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

        public DataTable Buscar(string texto)
        {
            DataTable resul = new DataTable("proveedor");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("spbuscar_proveedor", conexion);
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

    }

}
