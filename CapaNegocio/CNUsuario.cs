using CapaDatos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace CapaNegocio
{
    public class CNUsuario
    {
        private CDUsuario cdUsuario = new CDUsuario();

        public static DataTable Listar()
        {
            return new CDUsuario().Listar();
        }


        public static string Guardar(string usuario, string password, string acceso, string estado, int idempleado)
        {
            CDUsuario objeto = new CDUsuario();
            objeto.usuario = usuario;
            objeto.pass = password;
            objeto.rol = acceso;
            objeto.estado = estado;
            objeto.idempleado = idempleado;

            return objeto.Guardar(objeto);
        }


        public static string Editar(int idusuario, string usuario, string password, string rol, string estado, int idempleado)
        {
            CDUsuario objeto = new CDUsuario();
            objeto.idusuario = idusuario;
            objeto.usuario = usuario;
            objeto.pass = password;
            objeto.rol = rol;
            objeto.estado = estado;
            objeto.idempleado = idempleado;

            return objeto.Editar(objeto);
        }

        public static string Eliminar(int idusuario)
        {
            CDUsuario objeto = new CDUsuario();
            objeto.idusuario = idusuario;

            return objeto.Eliminar(objeto);
        }

        public static DataTable BuscarNombre(string textobuscar)
        {
            CDUsuario objeto = new CDUsuario();
            objeto.Buscar = textobuscar;

            return objeto.BuscarNombre(objeto);
        }

        public static DataTable BuscarNombreUsuario(string textobuscar)
        {
            CDUsuario objeto = new CDUsuario();
            objeto.Buscar = textobuscar;

            return objeto.BuscarNombreUsuario(objeto);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }

        public string Login(string usuario, string password)
        {
            CDUsuario usuarioBD = cdUsuario.ObtenerPorUsuario(usuario);

            if (usuarioBD == null)
                throw new Exception("Usuario incorrecto");

            if (usuarioBD.estado == "Inactivo")
                throw new Exception("Cuenta suspendida");

            if (usuarioBD.pass != password)
                throw new Exception("Contraseña incorrecta");

            CNSesion.IdUsuario = usuarioBD.idusuario;
            CNSesion.Usuario = usuarioBD.usuario;
            CNSesion.Rol = usuarioBD.rol;

            CNSesion sesion = new CNSesion();
            sesion.IniciarSesion(usuarioBD.idusuario);

            return "OK";
        }
    }
}