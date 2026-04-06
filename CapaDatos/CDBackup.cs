using System;
using System.Data.SqlClient;
using System.IO;

namespace CapaDatos
{
    public class CDBackup
    {
        /// <summary>
        /// Ejecuta BACKUP DATABASE hacia la ruta indicada.
        /// Retorna la ruta completa del archivo .bak generado.
        /// </summary>
        public string RealizarBackup(string carpetaDestino)
        {
            // Obtiene el nombre de la BD desde el connection string
            var builder = new SqlConnectionStringBuilder(Conexion.Conn);
            string nombreBD = builder.InitialCatalog;

            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            string nombreArchivo = $"{nombreBD}_{timestamp}.bak";
            string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

            string sql = $@"
                BACKUP DATABASE [{nombreBD}]
                TO DISK = N'{rutaCompleta}'
                WITH FORMAT,
                     MEDIANAME = 'Respaldo',
                     NAME = 'Respaldo completo - {nombreBD}';";

            using (SqlConnection con = new SqlConnection(Conexion.Conn))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                cmd.CommandTimeout = 300; // 5 minutos
                cmd.ExecuteNonQuery();
            }

            return rutaCompleta;
        }
    }
}