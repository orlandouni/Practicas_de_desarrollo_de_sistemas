using CapaDatos;

namespace CapaNegocio
{
    public class CNBackup
    {
        private readonly CDBackup _cd = new CDBackup();

        public string RealizarBackup(string carpetaDestino)
        {
            return _cd.RealizarBackup(carpetaDestino);
        }

        /// <summary>
        /// Valida que el archivo exista y delega la restauración a la capa de datos.
        /// </summary>
        public void RestaurarBackup(string rutaArchivoBak)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivoBak))
                throw new System.ArgumentException("Debes seleccionar un archivo .bak válido.");

            _cd.RestaurarBackup(rutaArchivoBak);
        }
    }
}