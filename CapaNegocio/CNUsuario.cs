using CapaDatos;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CapaNegocio
{
    public class CNUsuario
    {
        private CDUsuario cdUsuario = new CDUsuario();

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

            // ===== COMPARACION DIRECTA (SIN HASH) =====
            if (usuarioBD.pass != password)
                throw new Exception("Contraseña incorrecta");

            // ===== GUARDAR SESION GLOBAL =====
            CNSesion.IdUsuario = usuarioBD.idusuario;
            CNSesion.Usuario = usuarioBD.usuario;
            CNSesion.Rol = usuarioBD.rol;

            // ===== CREAR SESION EN BD =====
            CNSesion sesion = new CNSesion();
            sesion.IniciarSesion(usuarioBD.idusuario);

            return "OK";
        }

    }
}
