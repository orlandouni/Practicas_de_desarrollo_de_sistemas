using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FRMListadoEmpleados : Form
    {
        public FRMListadoEmpleados()
        {
            InitializeComponent();
        }

        private void MostrarEmpleados()
        {
            dgvlistado.DataSource = CNEmpleado.Listar();
        }

        private void FRMListadoEmpleados_Load(object sender, EventArgs e)
        {

            MostrarEmpleados();
            EstiloFormulario();
        }

        private void EstiloFormulario()
        {

            // 🔥 Quitar líneas
            dgvlistado.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvlistado.RowHeadersVisible = false;
            dgvlistado.GridColor = Color.White;
            dgvlistado.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Filas alternadas suaves
            dgvlistado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rbtnnombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarEmpleado()
        {
            dgvlistado.DataSource = CNEmpleado.Buscar(txtbuscar.Text);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text.Trim() == "")
            {
                MostrarEmpleados();
            }
            else
            {
                BuscarEmpleado();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvlistado.CurrentRow != null)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar a este empleado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    int id = Convert.ToInt32(
                        dgvlistado.CurrentRow.Cells["idempleado"].Value);

                    CNEmpleado.Eliminar(id);

                    MessageBox.Show("Empleado eliminado correctamente",
                                    "Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    MostrarEmpleados();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado primero.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }



        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dgvlistado.CurrentRow != null)
            {
                FRMRegistrarEmpleado frm = new FRMRegistrarEmpleado();
                frm.IsEditar = true;

                frm.txtidempleado.Text = dgvlistado.CurrentRow.Cells["idempleado"].Value.ToString();
                frm.txtnombre.Text = dgvlistado.CurrentRow.Cells["nombre"].Value.ToString();
                frm.txtapellidos.Text = dgvlistado.CurrentRow.Cells["apellidos"].Value.ToString();
                frm.txtdni.Text = dgvlistado.CurrentRow.Cells["rfc"].Value.ToString();
                frm.txttelefono.Text = dgvlistado.CurrentRow.Cells["telefono"].Value.ToString();
                frm.txtdireccion.Text = dgvlistado.CurrentRow.Cells["direccion"].Value.ToString();

                string estado = dgvlistado.CurrentRow.Cells["estado"].Value.ToString();

                if (estado == "ACTIVO")
                    frm.rbtnactivo.Checked = true;
                else
                    frm.rbtninactivo.Checked = true;

                frm.ShowDialog();

                MostrarEmpleados();
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FRMRegistrarEmpleado frm = new FRMRegistrarEmpleado();
            frm.IsEditar = false;
            frm.ShowDialog();

            MostrarEmpleados();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}