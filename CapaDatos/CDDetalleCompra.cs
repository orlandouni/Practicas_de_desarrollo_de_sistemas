using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDDetalleCompra
    {
        public int idcompra { get; set; }
        public int idproducto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal total { get; set; }

        // Guarda el detalle y actualiza stock en un solo SP
        public string Guardar(CDDetalleCompra det)
        {
            string resul = "";
            using (SqlConnection con = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spguardar_detalle_compra", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idcompra", det.idcompra);
                    cmd.Parameters.AddWithValue("@idproducto", det.idproducto);
                    cmd.Parameters.AddWithValue("@cantidad", det.cantidad);
                    cmd.Parameters.AddWithValue("@precio", det.precio);
                    cmd.Parameters.AddWithValue("@total", det.total);

                    resul = cmd.ExecuteNonQuery() >= 1 ? "OK" : "Error al guardar detalle";
                }
                catch (Exception ex) { resul = ex.Message; }
            }
            return resul;
        }

        // Productos filtrados por proveedor
        public DataTable ObtenerPorProveedor(int idproveedor)
        {
            DataTable dt = new DataTable("productos");
            using (SqlConnection con = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spproductos_por_proveedor", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproveedor", idproveedor);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception) { dt = null; throw; }
            }
            return dt;
        }
    }
}