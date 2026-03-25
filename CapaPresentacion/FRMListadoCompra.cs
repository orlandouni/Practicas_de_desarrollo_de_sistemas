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
    public partial class FRMListadoCompra : Form
    {
        public FRMListadoCompra()
        {
            InitializeComponent();
        }

        public void Mostrar()
        {
            this.dlistado.DataSource = CNCompra.Listar();
        }

        private void dlistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FRMCompra compra = new FRMCompra();
            compra.Show();
        }

        private void ListadoCompra_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btneliminar_Click(object sender, EventArgs e)
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
                        // AQUÍ ESTABA EL ERROR: Cambiamos "idcliente" por "idproducto"
                        int idcompra = Convert.ToInt32(
                            dlistado.CurrentRow.Cells["idcompra"].Value);

                        // Enviamos el idproducto a la Capa de Negocio
                        string respuesta = CNCompra.Eliminar(idcompra);

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
                // Si el nombre de la columna en tu BD no es exactamente "idproducto", 
                // este mensaje te lo dirá.
                MessageBox.Show("Error al intentar eliminar: " + ex.Message);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
