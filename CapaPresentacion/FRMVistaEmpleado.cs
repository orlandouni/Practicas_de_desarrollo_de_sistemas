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
    public partial class FRMVistaEmpleado : Form
    {
        public FRMVistaEmpleado()
        {
            InitializeComponent();
        }

        private void FRMVistaEmpleado_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        public void Mostrar()
        {
            this.dgvlistado.DataSource = CNEmpleado.Listar();
        }

        public void BuscarNombre()
        {
            this.dgvlistado.DataSource = CNEmpleado.Buscar(txtbuscar.Text);
        }

        public void BuscarDni()
        {
            this.dgvlistado.DataSource = CNEmpleado.Buscar(txtbuscar.Text);
        }



        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (rbtnnombre.Checked)
            {
                this.BuscarNombre();
            }
            else if (rbtndni.Checked)
            {
                this.BuscarDni();
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

        private void dgvlistado_DoubleClick(object sender, EventArgs e)
        {
            if (dgvlistado.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
            this.Hide();

        }
    }
}
