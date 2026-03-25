using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDDetalleCompra
    {
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public string Guardar(CDDetalleCompra det)
        {
            string res = "";

            using (SqlConnection con = new SqlConnection(Conexion.Conn))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("sp_guardar_detalle_compra", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idcompra", det.IdCompra);
                    cmd.Parameters.AddWithValue("@idproducto", det.IdProducto);
                    cmd.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmd.Parameters.AddWithValue("@precio", det.Precio);
                    cmd.Parameters.AddWithValue("@total", det.Total);

                    res = cmd.ExecuteNonQuery() > 0 ? "OK" : "Error";
                }
                catch (Exception ex)
                {
                    res = ex.Message;
                }
            }

            return res;
        }

        public DataTable Listar(int idcompra)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Conexion.Conn))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_detalle_compra", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idcompra", idcompra);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
    }
}