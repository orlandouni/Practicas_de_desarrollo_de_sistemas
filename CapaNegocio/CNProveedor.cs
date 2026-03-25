using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CNProveedor
    {
        public static DataTable Listar()
        {
            CDProveedor Datos = new CDProveedor();
            return Datos.Listar();
        }

        public static string Guardar( string telefono, string direccion, string estado, string nombre)
        {
            CDProveedor Datos = new CDProveedor();
            
            Datos.Telefono = telefono;
            Datos.Direccion = direccion;
            Datos.Estado = estado;
            Datos.Nombre = nombre;

            return Datos.Guardar(Datos);
        }

        public static string Editar(int idproveedor, string telefono, string direccion, string estado, string nombre)
        {
            CDProveedor Datos = new CDProveedor();
            Datos.idproveedor= idproveedor;
            Datos.Telefono = telefono;
            Datos.Direccion = direccion;
            Datos.Estado = estado;
            Datos.Nombre = nombre;

            return Datos.Editar(Datos);
        }

        public static string Eliminar(int idproveedor)
        {
            CDProveedor Datos = new CDProveedor();
            Datos.idproveedor = idproveedor;
            return Datos.Eliminar(Datos);
        }

        public static DataTable Buscar(string texto)
        {
            CDProveedor Datos = new CDProveedor();
            return Datos.Buscar(texto);
        }
    }
}
