using CapaNegocio;
using System;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FRMBackup : Form
    {
        private readonly CNBackup _cn = new CNBackup();

        // Carpeta por defecto — puedes cambiarla
        private string _carpetaDestino = @"C:\Respaldos\POS";

        public FRMBackup()
        {
            InitializeComponent();
        }

        private void FRMBackup_Load(object sender, EventArgs e)
        {
            // Verificar que el usuario logueado sea ADMIN
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
        }

        // Cambiar carpeta destino
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

        // Realizar backup
        private void btnBackup_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
                "¿Deseas realizar un respaldo de la base de datos ahora?",
                "Confirmar respaldo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion != DialogResult.Yes) return;

            btnBackup.Enabled = false;
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
                btnBackup.Enabled = true;
                btnBackup.Text = "💾  Realizar Respaldo Ahora";
            }
        }

        // Abrir carpeta en el Explorador de Windows
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
    }
}