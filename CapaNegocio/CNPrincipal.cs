using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNPrincipal
    {
        // ════════════════════════════════════════════════════════════
        // 1. LISTAR CATEGORÍAS
        // ════════════════════════════════════════════════════════════
        public static DataTable ListarCategorias()
        {
            CDPrincipal Datos = new CDPrincipal();
            return Datos.ListarCategorias();
        }

        // ════════════════════════════════════════════════════════════
        // 2. BUSCAR PRODUCTOS (nombre/código + categoría)
        // ════════════════════════════════════════════════════════════
        public static DataTable BuscarProductos(string busqueda, int idCategoria)
        {
            CDPrincipal Datos = new CDPrincipal();
            return Datos.BuscarProductos(busqueda, idCategoria);
        }

        // ════════════════════════════════════════════════════════════
        // 3. LISTAR CLIENTES
        // ════════════════════════════════════════════════════════════
        public static DataTable ListarClientes()
        {
            CDPrincipal Datos = new CDPrincipal();
            return Datos.ListarClientes();
        }

        // ════════════════════════════════════════════════════════════
        // 4. REGISTRAR VENTA COMPLETA
        //    Maneja la transacción: encabezado → detalle × n líneas
        //    Devuelve el idventa generado, o -1 si falló
        // ════════════════════════════════════════════════════════════
        public static int RegistrarVenta(
            int idUsuario,
            int idCliente,
            string serie,
            string numDocumento,
            string tipoDocumento,
            decimal subtotal,
            decimal iva,
            decimal total,
            DataTable dtDetalle)      // cols requeridas: idproducto, cantidad, precio, total
        {
            CDPrincipal Datos = new CDPrincipal();

            // 4a. Insertar encabezado → obtenemos el idventa
            int idVenta = Datos.RegistrarVenta(
                idUsuario, idCliente,
                serie, numDocumento, tipoDocumento,
                subtotal, iva, total);

            if (idVenta <= 0)
                return -1;

            // 4b. Insertar cada línea del carrito
            foreach (DataRow row in dtDetalle.Rows)
            {
                string resultado = Datos.RegistrarDetalleVenta(
                    idVenta,
                    Convert.ToInt32(row["idproducto"]),
                    Convert.ToInt32(row["cantidad"]),
                    Convert.ToDecimal(row["precio"]),
                    Convert.ToDecimal(row["total"]));

                if (resultado != "OK")
                    return -1;   // algo falló en el detalle
            }

            return idVenta;
        }

        // ════════════════════════════════════════════════════════════
        // 5. OBTENER NUM DE CAJA
        // ════════════════════════════════════════════════════════════
        public static DataTable ObtenerUltimoNumDoc(string serie)
        {
            CDPrincipal Datos = new CDPrincipal();
            return Datos.ObtenerUltimoNumDoc(serie);
        }


        // ═══════════════════════════════════════════════════════════
        // 5. OBTENER PRODUCTOS BAJOS EN STOCK
        // ════════════════════════════════════════════════════════════

        public static DataTable ObtenerProductosStockBajo(int limite)
        {
            CDPrincipal Datos = new CDPrincipal();
            return Datos.ObtenerProductosStockBajo(limite);
        }
    }
}