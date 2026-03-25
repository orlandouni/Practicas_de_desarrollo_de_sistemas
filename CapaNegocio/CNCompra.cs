using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNCompra
    {

        public class Compra
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
        }
        public static DataTable Listar()
        {
            CDCompra Datos = new CDCompra();
            return Datos.Listar();
        }

        public static string GuardarRetornarId(Compra compra, out int idGenerado)
        {
            idGenerado = -1;

            try
            {
                CDCompra datos = new CDCompra
                {
                    fecha = compra.fecha,
                    num_documento = compra.num_documento,
                    tipo_documento = compra.tipo_documento,
                    subtotal = compra.subtotal,
                    iva = compra.iva,
                    total = compra.total,
                    estado = compra.estado,
                    idusuario = compra.idusuario,
                    idproveedor = compra.idproveedor
                };

                idGenerado = datos.Guardar(datos);

                return idGenerado > 0 ? "OK" : "Error al guardar";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string Editar(Compra comp)
        {
            CDCompra datos = new CDCompra
            {
                idcompra = comp.idcompra,
                fecha = comp.fecha,
                num_documento = comp.num_documento,
                tipo_documento = comp.tipo_documento,
                subtotal = comp.subtotal,
                iva = comp.iva,
                total = comp.total,
                estado = comp.estado,
                idusuario = comp.idusuario,
                idproveedor = comp.idproveedor
            };

            return datos.Editar(datos);
        }

        public static string Eliminar(int idcompra)
        {
            CDCompra Datos = new CDCompra();
            Datos.idcompra = idcompra;

            return Datos.Eliminar(Datos);
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            CDProducto Datos = new CDProducto();
            Datos.BuscarTexto = textobuscar;

            return Datos.BuscarNombre(Datos);
        }

        public static DataTable BuscarPorId(int idcompra)
        {
            CDCompra datos = new CDCompra();
            return datos.BuscarPorId(idcompra);
        }
    }
}