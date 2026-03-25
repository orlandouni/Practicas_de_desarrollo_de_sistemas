using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{


    public partial class FRMRegistrarCliente : Form
    {
        public bool Insert = false;
        public bool Edit = false;
        public FRMRegistrarCliente()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FRMRegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private void txtidcliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtninactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrfc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtapellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string estado = "";
            if (rbtnactivo.Checked == true)
            {
                estado = "ACTIVO";
            }
            else
            {
                estado = "INACTIVO";
            }

            try
            {
                if (this.txtnombre.Text == string.Empty || this.txtapellidos.Text == string.Empty)
                {
                    MessageBox.Show("Ingrese los datos del cliente", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.Insert == true)
                    {
                        CNCliente.Guardar(
                            txtnombre.Text,
                            txtapellidos.Text,
                            txttelefono.Text,
                            estado
                        );
                        MessageBox.Show("Cliente registrado correctamente", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (this.Edit == true) 
                    {
                        CNCliente.Editar(Convert.ToInt32(this.txtidcliente.Text),
                            this.txtnombre.Text,
                            this.txtapellidos.Text,
                            this.txttelefono.Text,
                            estado);
                        MessageBox.Show("Cliente editado correctamente", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Insert = false;
                    this.Edit = false;

                    FRMListadoClientes form = new FRMListadoClientes();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }


           
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            FRMListadoClientes form = new FRMListadoClientes();
            this.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
