using System;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNEmpleado
    {
        public static DataTable Listar()
        {
            CDEmpleado Datos = new CDEmpleado();
            return Datos.Listar();
        }

        public static string Guardar(string nombre, string apellidos, string rfc,
                                     string telefono, string direccion, string estado)
        {
            CDEmpleado Datos = new CDEmpleado();
            Datos.Nombre = nombre;
            Datos.Apellidos = apellidos;
            Datos.Rfc = rfc;
            Datos.Telefono = telefono;
            Datos.Direccion = direccion;
            Datos.Estado = estado;

            return Datos.Guardar(Datos);
        }

        public static string Editar(int idempleado, string nombre, string apellidos,
                                    string rfc, string telefono, string direccion, string estado)
        {
            CDEmpleado Datos = new CDEmpleado();
            Datos.idempleado = idempleado;
            Datos.Nombre = nombre;
            Datos.Apellidos = apellidos;
            Datos.Rfc= rfc;
            Datos.Telefono = telefono;
            Datos.Direccion = direccion;
            Datos.Estado = estado;

            return Datos.Editar(Datos);
        }

        public static string Eliminar(int idempleado)
        {
            CDEmpleado Datos = new CDEmpleado();
            Datos.idempleado = idempleado;
            return Datos.Eliminar(Datos);
        }

        public static DataTable Buscar(string texto)
        {
            CDEmpleado Datos = new CDEmpleado();
            return Datos.Buscar(texto);
        }
    }
}