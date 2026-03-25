using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNProducto
    {
        public static DataTable Listar()
        {
            CDProducto Datos = new CDProducto();
            return Datos.Listar();
        }

        public static string Guardar(string codigo, string nombre, string descripcion, string talla,
                                     string color, decimal precio_compra, decimal precio_venta,
                                     int stock, int idcategoria, int idproveedor)
        {
            CDProducto Datos = new CDProducto();
            Datos.Codigo = codigo;
            Datos.Nombre = nombre;
            Datos.Descripcion = descripcion;
            Datos.Talla = talla;
            Datos.Color = color;
            Datos.Precio_Compra = precio_compra;
            Datos.Precio_Venta = precio_venta;
            Datos.Stock = stock;
            Datos.IdCategoria = idcategoria;
            Datos.IdProveedor = idproveedor;


            // Nota: Estado y Fecha_Ingreso no se envían aquí porque la BD 
            // los asigna automáticamente por defecto al insertar.

            return Datos.Guardar(Datos);
        }

        public static string Editar(int idproducto, string codigo, string nombre, string descripcion,
                                    string talla, string color, decimal precio_compra, decimal precio_venta,
                                    int stock, string estado, int idcategoria, int idproveedor)
        {
            CDProducto Datos = new CDProducto();
            Datos.IdProducto = idproducto;
            Datos.Codigo = codigo;
            Datos.Nombre = nombre;
            Datos.Descripcion = descripcion;
            Datos.Talla = talla;
            Datos.Color = color;
            Datos.Precio_Compra = precio_compra;
            Datos.Precio_Venta = precio_venta;
            Datos.Stock = stock;
            Datos.Estado = estado;
            Datos.IdCategoria = idcategoria;
            Datos.IdProveedor = idproveedor;


            return Datos.Editar(Datos);
        }

        public static string Eliminar(int idproducto)
        {
            CDProducto Datos = new CDProducto();
            Datos.IdProducto = idproducto;

            return Datos.Eliminar(Datos);
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            CDProducto Datos = new CDProducto();
            Datos.BuscarTexto = textobuscar;

            return Datos.BuscarNombre(Datos);
        }

        public static DataTable ListarPorProveedor(int idproveedor)
        {
            CDProducto datos = new CDProducto();
            return datos.ListarPorProveedor(idproveedor);
        }
    }
}