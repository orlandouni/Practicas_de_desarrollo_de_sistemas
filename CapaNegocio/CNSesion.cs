using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class CNSesion
    {
        public static int IdUsuario { get; set; }
        public static string Usuario { get; set; }
        public static string Rol { get; set; }
        public static int IdSesion { get; set; }

        CDSesion cd = new CDSesion();

        public int IniciarSesion(int idUsuario)
        {
            IdSesion = cd.IniciarSesion(idUsuario);
            return IdSesion;
        }

        public void CerrarSesion()
        {
            if (IdSesion > 0)
                cd.CerrarSesion(IdSesion);
        }
        public static DataTable Listar()
        {
            return new CDSesion().Listar();
        }

        public static DataTable Filtrar(string nombreUsuario, DateTime? fecha)
        {
            return new CDSesion().Filtrar(nombreUsuario, fecha);
        }


    }
}
