using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDCompra
    {
        public int idcompra { get; set; }
        public DateTime fecha { get; set; }
        public int num_documento { get; set; }
        public string tipo_documento { get; set; }
        public decimal subtotal { get; set; }
        public decimal iva { get; set; }
        public decimal total { get; set; }
        public string estado { get; set; }
        public int idusuario { get; set; }
        public int idproveedor { get; set; }






        public DataTable Listar()
        {
            DataTable resul = new DataTable("compra");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("splistar_compras", conexion);
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

        // 
        public int Guardar(CDCompra comp)
        {
            int idGenerado = -1;
            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spguardar_compra", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@fecha", comp.fecha);
                    cmd.Parameters.AddWithValue("@num_documento", comp.num_documento);
                    cmd.Parameters.AddWithValue("@tipo_documento", comp.tipo_documento);
                    cmd.Parameters.AddWithValue("@subtotal", comp.subtotal);
                    cmd.Parameters.AddWithValue("@iva", comp.iva);
                    cmd.Parameters.AddWithValue("@total", comp.total);
                    cmd.Parameters.AddWithValue("@estado", comp.estado);
                    cmd.Parameters.AddWithValue("@idusuario", comp.idusuario);
                    cmd.Parameters.AddWithValue("@idproveedor", comp.idproveedor);

                    // ExecuteScalar lee el SELECT SCOPE_IDENTITY() del SP
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        idGenerado = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return idGenerado;
        }

        public string Editar(CDCompra comp)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("speditar_compras", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idcompra", comp.idcompra);
                Cmd.Parameters.AddWithValue("@fecha", comp.fecha);
                Cmd.Parameters.AddWithValue("@num_documento", comp.num_documento);
                Cmd.Parameters.AddWithValue("@tipo_documento", comp.tipo_documento);
                Cmd.Parameters.AddWithValue("@subtotal", comp.subtotal);
                Cmd.Parameters.AddWithValue("@iva", comp.iva);
                Cmd.Parameters.AddWithValue("@total", comp.total);
                Cmd.Parameters.AddWithValue("@estado", comp.estado);
                Cmd.Parameters.AddWithValue("@idusuario", comp.idusuario);
                Cmd.Parameters.AddWithValue("@idproveedor", comp.idproveedor);

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

        public string Eliminar(CDCompra comp)
        {
            string resul = "";
            SqlConnection conexion = new SqlConnection();

            try
            {
                conexion.ConnectionString = Conexion.Conn;
                conexion.Open();

                SqlCommand Cmd = new SqlCommand("speliminar_compra", conexion);
                Cmd.CommandType = CommandType.StoredProcedure;

                Cmd.Parameters.AddWithValue("@idcompra", comp.idcompra);

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
            DataTable resul = new DataTable("compra");
            SqlConnection conexion = new SqlConnection(Conexion.Conn);

            try
            {
                SqlCommand cmd = new SqlCommand("spbuscar_compra", conexion);
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