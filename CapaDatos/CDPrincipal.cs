using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDPrincipal
    {
        // ════════════════════════════════════════════════════════════
        // 1. CARGAR CATEGORÍAS
        // ════════════════════════════════════════════════════════════
        public DataTable ListarCategorias()
        {
            DataTable dt = new DataTable("categoria");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("splistar_categorias", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar categorías: " + ex.Message);
                }
            }
            return dt;
        }

        // ════════════════════════════════════════════════════════════
        // 2. Buscar PRODUCTOS (búsqueda por  código)
        // ════════════════════════════════════════════════════════════
        public DataTable BuscarProductos(string codigo, int idCategoria)
        {
            DataTable dt = new DataTable("producto");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spbuscar_productos_pos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@codigo", codigo.Trim());
                    // ← ya no se manda @idcategoria

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar productos: " + ex.Message);
                }
            }
            return dt;
        }

        // ════════════════════════════════════════════════════════════
        // 3. OBTENER CLIENTES
        // ════════════════════════════════════════════════════════════
        public DataTable ListarClientes()
        {
            DataTable dt = new DataTable("cliente");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("splistar_clientes", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar clientes: " + ex.Message);
                }
            }
            return dt;
        }

        // ════════════════════════════════════════════════════════════
        // 4. REGISTRAR ENCABEZADO DE VENTA → devuelve idventa
        // ════════════════════════════════════════════════════════════
        public int RegistrarVenta(int idUsuario, int idCliente, string serie,
                                  string numDocumento, string tipoDocumento,
                                  decimal subtotal, decimal iva, decimal total)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spregistrar_venta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idusuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idcliente", idCliente);
                    cmd.Parameters.AddWithValue("@serie", serie);
                    cmd.Parameters.AddWithValue("@num_documento", numDocumento);
                    cmd.Parameters.AddWithValue("@tipo_documento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@iva", iva);
                    cmd.Parameters.AddWithValue("@total", total);

                    // SP retorna el id con SELECT SCOPE_IDENTITY()
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar venta: " + ex.Message);
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        // 5. REGISTRAR UNA LÍNEA DE DETALLE + DESCUENTA STOCK
        // ════════════════════════════════════════════════════════════
        public string RegistrarDetalleVenta(int idVenta, int idProducto,
                                            int cantidad, decimal precio, decimal total)
        {
            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spregistrar_detalle_venta", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idventa", idVenta);
                    cmd.Parameters.AddWithValue("@idproducto", idProducto);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@total", total);

                    return cmd.ExecuteNonQuery() > 0 ? "OK" : "No se insertó el detalle";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        // ════════════════════════════════════════════════════════════
        // 6. OBTENER EL NUMERO DE CAJA Y DE RECIBO
        // ════════════════════════════════════════════════════════════
        public DataTable ObtenerUltimoNumDoc(string serie)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spultimo_num_documento", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@serie", serie);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener número de documento: " + ex.Message);
                }
            }
            return dt;
        }


        // ════════════════════════════════════════════════════════════
        // 7. OBTENER LA CANTIDAD DE PRODUCTO
        // ════════════════════════════════════════════════════════════
        public DataTable ObtenerProductosStockBajo(int limite)
        {
            DataTable dt = new DataTable("producto");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spproductos_stock_bajo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@limite", limite);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al verificar stock: " + ex.Message);
                }
            }
            return dt;
        }
    }
}