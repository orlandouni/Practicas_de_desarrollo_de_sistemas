using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDProducto
    {
        // Propiedades de la tabla
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public decimal Precio_Compra { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }


        // Propiedad auxiliar para el buscador
        public string BuscarTexto { get; set; }


        // --- MÉTODOS CRUD ---

        public DataTable Listar()
        {
            DataTable dt = new DataTable("producto");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("splistar_productos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar los productos: " + ex.Message);
                }
            }
            return dt;
        }

        public string Guardar(CDProducto obj)
        {
            string resul = "";
            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("spguardar_producto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@talla", obj.Talla);
                    cmd.Parameters.AddWithValue("@color", obj.Color);
                    cmd.Parameters.AddWithValue("@precio_compra", obj.Precio_Compra);
                    cmd.Parameters.AddWithValue("@precio_venta", obj.Precio_Venta);
                    cmd.Parameters.AddWithValue("@stock", obj.Stock);
                    cmd.Parameters.AddWithValue("@idcategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("@idproveedor", obj.IdProveedor);


                    resul = cmd.ExecuteNonQuery() > 0 ? "OK" : "No se pudo insertar el registro";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        return "La categoria no existe";
                    }
                    else
                    {
                        return ex.Message;
                    }
                }
            }
            return resul;
        }

        public string Editar(CDProducto obj)
        {
            string resul = "";
            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("speditar_producto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idproducto", obj.IdProducto);
                    cmd.Parameters.AddWithValue("@codigo", obj.Codigo);
                    cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@talla", obj.Talla);
                    cmd.Parameters.AddWithValue("@color", obj.Color);
                    cmd.Parameters.AddWithValue("@precio_compra", obj.Precio_Compra);
                    cmd.Parameters.AddWithValue("@precio_venta", obj.Precio_Venta);
                    cmd.Parameters.AddWithValue("@stock", obj.Stock);
                    cmd.Parameters.AddWithValue("@estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@idcategoria", obj.IdCategoria);
                    cmd.Parameters.AddWithValue("@idproveedor", obj.IdProveedor);


                    resul = cmd.ExecuteNonQuery() > 0 ? "OK" : "No se pudo editar el registro";
                }
                catch (Exception ex)
                {
                    resul = ex.Message;
                }
            }
            return resul;
        }

        public string Eliminar(CDProducto obj)
        {
            string resul = "";
            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    conexion.Open();
                    // Llama al SP de borrado lógico (o puedes cambiarlo a sp_Producto_EliminarFisico)
                    SqlCommand cmd = new SqlCommand("speliminar_producto", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idproducto", obj.IdProducto);

                    resul = cmd.ExecuteNonQuery() > 0 ? "OK" : "No se pudo eliminar el registro";
                }
                catch (Exception ex)
                {
                    resul = ex.Message;
                }
            }
            return resul;
        }

        public DataTable BuscarNombre(CDProducto obj)
        {
            DataTable dt = new DataTable("producto");

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spbuscar_producto_nombre", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Le enviamos la nueva propiedad BuscarTexto
                    cmd.Parameters.AddWithValue("@nombre", obj.BuscarTexto);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al buscar producto por nombre: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ListarPorProveedor(int idproveedor)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_listar_productos_por_proveedor", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idproveedor", idproveedor);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar productos por proveedor: " + ex.Message);
                }
            }

            return dt;
        }


    }
}