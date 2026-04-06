using CapaNegocio;
using System;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FRMBackup : Form
    {
        private readonly CNBackup _cn = new CNBackup();
        private string _carpetaDestino = @"C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\Backup";

        public FRMBackup()
        {
            InitializeComponent();
        }

        private void FRMBackup_Load(object sender, EventArgs e)
        {
            if (CNSesion.Rol?.ToUpper() != "ADMIN")
            {
                MessageBox.Show(
                    "Acceso denegado.\nSolo el administrador puede realizar respaldos.",
                    "Sin permiso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            txtRuta.Text = _carpetaDestino;
            lblUltimoBackup.Visible = false;
            lblUltimaRestauracion.Visible = false;
        }

        // ── Examinar carpeta destino ──────────────────────────────────────────
        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Selecciona la carpeta donde se guardará el respaldo";
                dlg.SelectedPath = _carpetaDestino;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _carpetaDestino = dlg.SelectedPath;
                    txtRuta.Text = _carpetaDestino;
                }
            }
        }

        // ── Realizar Backup ───────────────────────────────────────────────────
        private void btnBackup_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Deseas realizar un respaldo de la base de datos ahora?",
                "Confirmar respaldo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            SetBotonesHabilitados(false);
            btnBackup.Text = "Realizando respaldo...";

            try
            {
                string rutaGenerada = _cn.RealizarBackup(_carpetaDestino);

                lblUltimoBackup.Text = $"✅ Guardado en: {rutaGenerada}";
                lblUltimoBackup.Visible = true;

                MessageBox.Show(
                    $"Respaldo creado exitosamente:\n\n{rutaGenerada}",
                    "Backup exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al crear el respaldo:\n\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SetBotonesHabilitados(true);
                btnBackup.Text = "💾  Realizar Respaldo Ahora";
            }
        }

        // ── Restaurar Backup ──────────────────────────────────────────────────
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            // 1. Seleccionar archivo .bak
            string rutaBak;
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Selecciona el archivo de respaldo";
                dlg.Filter = "Archivos de respaldo (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                dlg.InitialDirectory = _carpetaDestino;

                if (dlg.ShowDialog() != DialogResult.OK) return;
                rutaBak = dlg.FileName;
            }

            // 2. Confirmación con advertencia clara
            var confirmacion = MessageBox.Show(
                $"⚠️  ATENCIÓN: Esta acción reemplazará TODOS los datos actuales de la base de datos " +
                $"con el contenido del siguiente respaldo:\n\n{rutaBak}\n\n" +
                $"Los cambios realizados después de ese respaldo se PERDERÁN.\n\n" +
                $"¿Deseas continuar?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            SetBotonesHabilitados(false);
            btnRestaurar.Text = "Restaurando...";

            try
            {
                _cn.RestaurarBackup(rutaBak);

                lblUltimaRestauracion.Text = $"✅ Restaurado desde: {Path.GetFileName(rutaBak)}  —  {DateTime.Now:dd/MM/yyyy HH:mm}";
                lblUltimaRestauracion.Visible = true;

                MessageBox.Show(
                    "Base de datos restaurada exitosamente.\n\nSe recomienda reiniciar la aplicación.",
                    "Restauración exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al restaurar la base de datos:\n\n{ex.Message}",
                    "Error en restauración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SetBotonesHabilitados(true);
                btnRestaurar.Text = "🔄  Restaurar Respaldo";
            }
        }

        // ── Abrir carpeta ─────────────────────────────────────────────────────
        private void btnAbrirCarpeta_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(_carpetaDestino))
                System.Diagnostics.Process.Start("explorer.exe", _carpetaDestino);
            else
                MessageBox.Show(
                    "La carpeta aún no existe. Realiza un respaldo primero.",
                    "Carpeta no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        // ── Helper ────────────────────────────────────────────────────────────
        private void SetBotonesHabilitados(bool habilitado)
        {
            btnBackup.Enabled = habilitado;
            btnRestaurar.Enabled = habilitado;
            btnExaminar.Enabled = habilitado;
            btnAbrirCarpeta.Enabled = habilitado;
        }

        private void btnRestaurar_Click_1(object sender, EventArgs e)
        {
            // 1. Seleccionar archivo .bak
            string rutaBak;
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Selecciona el archivo de respaldo";
                dlg.Filter = "Archivos de respaldo (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                dlg.InitialDirectory = _carpetaDestino;

                if (dlg.ShowDialog() != DialogResult.OK) return;
                rutaBak = dlg.FileName;
            }

            // 2. Confirmación con advertencia clara
            var confirmacion = MessageBox.Show(
                $"⚠️  ATENCIÓN: Esta acción reemplazará TODOS los datos actuales de la base de datos " +
                $"con el contenido del siguiente respaldo:\n\n{rutaBak}\n\n" +
                $"Los cambios realizados después de ese respaldo se PERDERÁN.\n\n" +
                $"¿Deseas continuar?",
                "Confirmar restauración",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            SetBotonesHabilitados(false);
            btnRestaurar.Text = "Restaurando...";

            try
            {
                _cn.RestaurarBackup(rutaBak);

                lblUltimaRestauracion.Text = $"✅ Restaurado desde: {Path.GetFileName(rutaBak)}  —  {DateTime.Now:dd/MM/yyyy HH:mm}";
                lblUltimaRestauracion.Visible = true;

                MessageBox.Show(
                    "Base de datos restaurada exitosamente.\n\nSe recomienda reiniciar la aplicación.",
                    "Restauración exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al restaurar la base de datos:\n\n{ex.Message}",
                    "Error en restauración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SetBotonesHabilitados(true);
                btnRestaurar.Text = "🔄  Restaurar Respaldo";
            }
        }
    }
}