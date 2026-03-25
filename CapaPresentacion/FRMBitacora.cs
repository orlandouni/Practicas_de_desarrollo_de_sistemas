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
    public partial class FRMBitacora : Form
    {
        public FRMBitacora()
        {
            InitializeComponent();
        }

        private void FRMBitacora_Load(object sender, EventArgs e)
        {
            CargarCombos();
            MostrarBitacora();
        }



        public void MostrarBitacora()
        {
            this.dlistado.DataSource = CNBitacora.Listar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void lblSub_Click(object sender, EventArgs e)
        {

        }

        private void panelCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblselect2_Click(object sender, EventArgs e)
        {

        }

        private void lblselect_Click(object sender, EventArgs e)
        {

        }

        private void rbtnUsuario_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtnRegistro_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void fechaSelect_ValueChanged(object sender, EventArgs e)
        {
            dlistado.DataSource = CNBitacora.FiltrarPorFecha(fechaSelect.Value);
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        public void BuscarUsuario()
        {
            this.dlistado.DataSource = CNBitacora.BuscarUsuario(txtBuscar.Text);
        }

        public void BuscarRegistro()
        {
            this.dlistado.DataSource = CNBitacora.BuscarRegistro(txtBuscar.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tabla = comboTabla.SelectedItem?.ToString();
            string operacion = comboOperacion.SelectedItem?.ToString();

            // Si hay radio seleccionado
            if (rbtnUsuario.Checked)
            {
                BuscarUsuario();
            }
            else if (rbtnRegistro.Checked)
            {
                BuscarRegistro();
            }
            else
            {
                // Si no hay radio, solo usa combos
                dlistado.DataSource = CNBitacora.Filtrar(tabla, operacion);
            }
        }

        private void CargarCombos()
        {
            // Combo Tabla
            comboTabla.Items.Clear();
            comboTabla.Items.Add("TODOS");
            comboTabla.Items.Add("cliente");
            comboTabla.Items.Add("proveedor");
            comboTabla.Items.Add("empleado");
            comboTabla.Items.Add("usuario");

            comboTabla.SelectedIndex = 0;

            // Combo Operación
            comboOperacion.Items.Clear();
            comboOperacion.Items.Add("TODOS");
            comboOperacion.Items.Add("INSERT");
            comboOperacion.Items.Add("UPDATE");
            comboOperacion.Items.Add("DELETE");
            comboOperacion.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuHam_Click_1(object sender, EventArgs e)
        {
            panelMenu.Visible = !panelMenu.Visible;
        }
        
        private void btnSesion_Click(object sender, EventArgs e)
        {
            FRMSesion frm = new FRMSesion();
            frm.Show();   // abre nueva ventana
            this.Close(); // cierra bitácora
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
