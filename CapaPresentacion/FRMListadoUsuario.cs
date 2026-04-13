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
    public partial class FRMListadoUsuario : Form
    {
        public FRMListadoUsuario()
        {
            InitializeComponent();
        }

        private void dgvlistado_DoubleClick(object sender, EventArgs e)
        {

        }

        private void FRMListadoUsuario_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();

        }

        public void Mostrar()
        {
            this.dgvlistado.DataSource = CNUsuario.Listar();
        }

        public void BuscarNombre()
        {
            this.dgvlistado.DataSource = CNUsuario.BuscarNombre(txtbuscar.Text);
        }

        public void BuscarUsuario()
        {
            this.dgvlistado.DataSource = CNUsuario.BuscarNombreUsuario(txtbuscar.Text);
        }



        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rbtnnombre.Checked)
            {
                this.BuscarNombre();
            }
            else if (rbtnusuario.Checked)
            {
                this.BuscarUsuario();
            }
            else
            {
                MessageBox.Show("Ingrese un criterio de busqueda",
                    "Sistema de ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FRMRegistrarUsuario form = new FRMRegistrarUsuario();

            form.Show();
            form.Insert = true;
            form.Edit = false;
            this.Hide();

        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            FRMRegistrarUsuario form = new FRMRegistrarUsuario();
            form.Edit = true;
            form.Insert = false;

            form.txtidusuario.Text = dgvlistado.CurrentRow.Cells["idusuario"].Value.ToString();
            form.txtidempleado.Text = dgvlistado.CurrentRow.Cells["idempleado"].Value.ToString();
          
            form.txtusuario.Text = dgvlistado.CurrentRow.Cells["usuario"].Value.ToString();
            form.txtpassword.Text = dgvlistado.CurrentRow.Cells["pass"].Value.ToString();
            form.cboacceso.Text = dgvlistado.CurrentRow.Cells["rol"].Value.ToString();

            string estado = dgvlistado.CurrentRow.Cells["estado"].Value.ToString();
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

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult op;
                op = MessageBox.Show("Realmente desea eliminar el registro",
                    "Sistema de ventas",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);

                if (dgvlistado.SelectedRows.Count > 0)
                {
                    if (op == DialogResult.OK)
                    {
                        string idusuario = dgvlistado.CurrentRow.Cells["idusuario"].Value.ToString();
                        CNUsuario.Eliminar(Convert.ToInt32(idusuario.ToString()));
                        MessageBox.Show("Registro eliminado",
                            "Sistema de ventas",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        this.Mostrar();
                    }
                }
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
