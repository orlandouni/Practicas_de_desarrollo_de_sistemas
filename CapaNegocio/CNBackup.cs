using CapaDatos;

namespace CapaNegocio
{
    public class CNBackup
    {
        private readonly CDBackup _cd = new CDBackup();

        /// <summary>
        /// Llama a la capa de datos para hacer el backup.
        /// Retorna la ruta completa del .bak generado.
        /// </summary>
        public string RealizarBackup(string carpetaDestino)
        {
            return _cd.RealizarBackup(carpetaDestino);
        }
    }
}