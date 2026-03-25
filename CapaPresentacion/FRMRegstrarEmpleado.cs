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
    public partial class FRMRegistrarEmpleado : Form
    {
        public bool IsEditar = false;
        public FRMRegistrarEmpleado()
        {
            InitializeComponent();
        }

        private void labelR_Click(object sender, EventArgs e)
        {

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
                CNEmpleado.Guardar(
                    txtnombre.Text,
                    txtapellidos.Text,
                    txtdni.Text,
                    txttelefono.Text,
                    txtdireccion.Text,
                    estado
                );

                MessageBox.Show("Empleado registrado correctamente");
            }
            else
            {
                // EDITAR
                CNEmpleado.Editar(
                    Convert.ToInt32(txtidempleado.Text),
                    txtnombre.Text,
                    txtapellidos.Text,
                    txtdni.Text,
                    txttelefono.Text,
                    txtdireccion.Text,
                    estado
                );

                MessageBox.Show("Empleado editado correctamente");
            }

            this.Close();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}