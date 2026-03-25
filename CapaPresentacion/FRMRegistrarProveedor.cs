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
    public partial class FRMRegistrarProveedor : Form
    {
        public bool IsEditar = false;
        public FRMRegistrarProveedor()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string estado = rbtnactivo.Checked ? "ACTIVO" : "INACTIVO";

            if (IsEditar == false)
            {
                // INSERTAR
                CNProveedor.Guardar(
                   
                    txttelefono.Text,
                    txtdireccion.Text,
                    estado,
                    txtnombre.Text
                );

                MessageBox.Show("Proveedor registrado correctamente");
            }
            else
            {
                // EDITAR
                CNProveedor.Editar(
                    Convert.ToInt32(txtidproveedor.Text),
                    txttelefono.Text,
                    txtdireccion.Text,
                    estado,
                    txtnombre.Text
                );

                MessageBox.Show("Proveedor editado correctamente");
            }

            this.Close();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
