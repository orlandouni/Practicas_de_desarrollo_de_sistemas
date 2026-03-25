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
    public partial class FRMProveedor : Form
    {
        public FRMProveedor()
        {
            InitializeComponent();
            EstiloFormulario();
        }

        public void Mostrar()
        {
            this.dlistado.DataSource = CNProveedor.Listar();
        }


        private void FRMProveedor_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EstiloFormulario()
        {



            // ESTILO BOTONES
            EstiloBoton(btnnuevo, Color.FromArgb(40, 167, 69));      // Verde
            EstiloBoton(btneditar, Color.FromArgb(255, 193, 7));     // Amarillo
            EstiloBoton(btneliminar, Color.FromArgb(220, 53, 69));       // Rojo eliminar
            EstiloBoton(btnbuscar, Color.FromArgb(108, 117, 125));   // Gris buscar





            // 🔥 Quitar líneas
            dlistado.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dlistado.RowHeadersVisible = false;
            dlistado.GridColor = Color.White;
            dlistado.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            // Filas alternadas suaves
            dlistado.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        }

        private void EstiloBoton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);

        }

        private void dlistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FRMRegistrarProveedor frm = new FRMRegistrarProveedor();
            frm.IsEditar = false;
            frm.ShowDialog();

            Mostrar();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dlistado.CurrentRow != null)
            {
                FRMRegistrarProveedor frm = new FRMRegistrarProveedor();
                frm.IsEditar = true;

                frm.txtidproveedor.Text = dlistado.CurrentRow.Cells["idproveedor"].Value.ToString();
                frm.txttelefono.Text = dlistado.CurrentRow.Cells["telefono"].Value.ToString();
                frm.txtdireccion.Text = dlistado.CurrentRow.Cells["direccion"].Value.ToString();
                string estado = dlistado.CurrentRow.Cells["estado"].Value.ToString();
                frm.txtnombre.Text = dlistado.CurrentRow.Cells["nombre"].Value.ToString();

                if (estado == "ACTIVO")
                    frm.rbtnactivo.Checked = true;
                else
                    frm.rbtninactivo.Checked = true;

                frm.ShowDialog();

                Mostrar();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dlistado.CurrentRow != null)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Desea eliminar a este proveedor?",
                    "Confirmar eliminación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.OK)
                {
                    int id = Convert.ToInt32(
                        dlistado.CurrentRow.Cells["idproveedor"].Value);

                    CNProveedor.Eliminar(id);

                    MessageBox.Show("Proveedor eliminado correctamente",
                                    "Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    Mostrar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor primero.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void BuscarProveedor()
        {
            dlistado.DataSource = CNProveedor.Buscar(txtbuscar.Text);
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtbuscar.Text.Trim() == "")
            {
                Mostrar();
            }
            else

                BuscarProveedor();
        }
    
        }
    }

