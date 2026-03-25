using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FRMListadoClientes : Form
    {
        

        public FRMListadoClientes()
        {
            InitializeComponent();
            EstiloFormulario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlistado.SelectedRows.Count > 0)
                {
                    DialogResult opcion = MessageBox.Show(
                        "¿Realmente desea eliminar el registro?",
                        "Sistema Ventas",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question);

                    if (opcion == DialogResult.OK)
                    {
                        int idcliente = Convert.ToInt32(
                            dlistado.CurrentRow.Cells["idcliente"].Value);

                        string respuesta = CNCliente.Eliminar(idcliente);

                        if (respuesta == "OK")
                        {
                            MessageBox.Show("Registro eliminado correctamente",
                                "Sistema Ventas",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Mostrar();
                        }
                        else
                        {
                            MessageBox.Show(respuesta,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro",
                        "Sistema Ventas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void FRMListadoClientes_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            Mostrar();
        }

        public void Mostrar()
        {
            this.dlistado.DataSource = CNCliente.Listar();
        }

        public void BuscarNombre()
        {
            this.dlistado.DataSource = CNCliente.BuscarNombre(txtbuscar.Text);
        }

        public void BuscarTelefono()
        {
            this.dlistado.DataSource = CNCliente.BuscarTelefono(txtbuscar.Text);
        }


        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FRMRegistrarCliente form = new FRMRegistrarCliente();

            form.Insert = true;
            form.Show();
            this.Hide();
        }

        private void btnbuscar_Click_1(object sender, EventArgs e)
        {
            if (rbtnnombre.Checked)
            {
                BuscarNombre();
            }
            else if (rbtntelefono.Checked)
            {
                BuscarTelefono();
            }
            else
            {
                MessageBox.Show("Seleccione un criterio de busqueda", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            FRMRegistrarCliente form = new FRMRegistrarCliente();

            form.Edit = true;

            form.txtidcliente.Text = this.dlistado.CurrentRow.Cells["idcliente"].Value.ToString();
            form.txtnombre.Text = this.dlistado.CurrentRow.Cells["nombre"].Value.ToString();
            form.txtapellidos.Text = this.dlistado.CurrentRow.Cells["apellidos"].Value.ToString();
            form.txttelefono.Text = this.dlistado.CurrentRow.Cells["telefono"].Value.ToString();

            string estado = this.dlistado.CurrentRow.Cells["estado"].Value.ToString();

            if (estado == "ACTIVO")
            {
                form.rbtnactivo.Checked = true;
            }
            else
            {
                form.rbtninactivo.Checked = true;
            }


            form.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dlistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbtnnombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtntelefono_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
