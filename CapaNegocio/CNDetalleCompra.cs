using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNDetalleCompra
    {
        public class DetalleCompra
        {
            public int idcompra { get; set; }
            public int idproducto { get; set; }
            public int cantidad { get; set; }
            public decimal precio { get; set; }
            public decimal total { get; set; }
        }

        // Guarda todos los detalles de una compra (lista)
        public static string GuardarDetalles(System.Collections.Generic.List<DetalleCompra> detalles)
        {
            CDDetalleCompra datos = new CDDetalleCompra();
            foreach (var d in detalles)
            {
                string r = datos.Guardar(new CDDetalleCompra
                {
                    idcompra = d.idcompra,
                    idproducto = d.idproducto,
                    cantidad = d.cantidad,
                    precio = d.precio,
                    total = d.total
                });
                if (r != "OK") return r; // detiene si hay error
            }
            return "OK";
        }

        // Productos disponibles según proveedor seleccionado
        public static DataTable ProductosPorProveedor(int idproveedor)
        {
            CDDetalleCompra datos = new CDDetalleCompra();
            return datos.ObtenerPorProveedor(idproveedor);
        }

        // Lista de proveedores para el combo
        public static DataTable ListarProveedores()
        {
            CDProveedor datos = new CDProveedor();
            return datos.Listar();
        }
    }
}