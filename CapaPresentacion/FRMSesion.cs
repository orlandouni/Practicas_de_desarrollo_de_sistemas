using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FRMSesion : Form
    {
        public FRMSesion()
        {
            InitializeComponent();
        }

        private void btnMenuHam_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = !panelMenu.Visible;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        public void MostrarSesiones()
        {
            dlistado.DataSource = null;
            dlistado.Rows.Clear();   // 🔥 fuerza limpieza visual
            dlistado.DataSource = CNSesion.Listar();
            dlistado.Refresh();
        }


        private void dlistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FRMSesion_Load(object sender, EventArgs e)
        {
            MostrarSesiones();
            panelMenu.Visible = false;   // 🔥 OCULTAR AL INICIAR
            MostrarSesiones();

            // 🔥 marcar menú activo
            btnSesion.Font = new Font(btnSesion.Font, FontStyle.Bold);
            btnBitacora.Font = new Font(btnBitacora.Font, FontStyle.Regular);
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            FRMBitacora frm = new FRMBitacora();
            frm.Show();   // abre nueva ventana
            this.Close(); // cierra bitácora
        }

        private void btnsalir_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void fechaSelect_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = null;

            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                nombreUsuario = txtBuscar.Text;

            DateTime? fecha = null;

            if (fechaSelect.Checked)
                fecha = fechaSelect.Value.Date;

            dlistado.DataSource = CNSesion.Filtrar(nombreUsuario, fecha);
        }


    }
}
