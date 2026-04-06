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
                cmd.CommandTimeout = 300;
                cmd.ExecuteNonQuery();
            }

            return rutaCompleta;
        }

        /// <summary>
        /// Restaura la BD desde un archivo .bak.
        /// Cierra conexiones activas antes de restaurar (modo SINGLE_USER).
        /// </summary>
        public void RestaurarBackup(string rutaArchivoBak)
        {
            if (!File.Exists(rutaArchivoBak))
                throw new FileNotFoundException("No se encontró el archivo de respaldo.", rutaArchivoBak);

            var builder = new SqlConnectionStringBuilder(Conexion.Conn);
            string nombreBD = builder.InitialCatalog;

            // Conectar a master para poder cerrar la BD de destino
            var masterBuilder = new SqlConnectionStringBuilder(Conexion.Conn);
            masterBuilder.InitialCatalog = "master";

            // 1. Poner en modo SINGLE_USER para desconectar usuarios activos
            string sqlSingleUser = $@"
                ALTER DATABASE [{nombreBD}]
                SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

            // 2. Restaurar
            string sqlRestore = $@"
                RESTORE DATABASE [{nombreBD}]
                FROM DISK = N'{rutaArchivoBak}'
                WITH REPLACE, RECOVERY;";

            // 3. Volver a MULTI_USER
            string sqlMultiUser = $@"
                ALTER DATABASE [{nombreBD}]
                SET MULTI_USER;";

            using (SqlConnection con = new SqlConnection(masterBuilder.ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(sqlSingleUser, con))
                {
                    cmd.CommandTimeout = 60;
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(sqlRestore, con))
                {
                    cmd.CommandTimeout = 600; // 10 minutos
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(sqlMultiUser, con))
                {
                    cmd.CommandTimeout = 60;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}