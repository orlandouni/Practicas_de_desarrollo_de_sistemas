using System.Data;
using CapaDatos;

namespace CapaNegocio
{

    public class DetalleCompra
    {
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
    }
    public class CNDetalleCompra
    {
        public static string Guardar(DetalleCompra det)
        {
            CDDetalleCompra datos = new CDDetalleCompra
            {
                IdCompra = det.IdCompra,
                IdProducto = det.IdProducto,
                Cantidad = det.Cantidad,
                Precio = det.Precio,
                Total = det.Total
            };

            return datos.Guardar(datos);
        }

        public static DataTable Listar(int idcompra)
        {
            CDDetalleCompra datos = new CDDetalleCompra();
            return datos.Listar(idcompra);
        }
    }
}