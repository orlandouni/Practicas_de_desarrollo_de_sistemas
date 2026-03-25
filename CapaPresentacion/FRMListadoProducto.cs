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
    public partial class FRMListadoProducto : Form
    {
        public FRMListadoProducto()
        {
            InitializeComponent();
            EstiloFormulario();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dlistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FRMListadoProducto_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }
        public void Mostrar()
        {
            this.dlistado.DataSource = CNProducto.Listar();
        }


        public void BuscarNombre()
        {
            this.dlistado.DataSource = CNProducto.BuscarNombre(txtbuscar.Text);
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

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            FRMRegistrarProducto form = new FRMRegistrarProducto();

            form.Insert = true;
            form.Show();
            this.Hide();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            FRMRegistrarProducto form = new FRMRegistrarProducto();

            form.Edit = true;

            form.txtidproducto.Text = this.dlistado.CurrentRow.Cells["idproducto"].Value.ToString();
            form.txtnombre.Text = this.dlistado.CurrentRow.Cells["nombre"].Value.ToString();
            form.txtcodigo.Text = this.dlistado.CurrentRow.Cells["codigo"].Value.ToString();
            form.txtdescripcion.Text = this.dlistado.CurrentRow.Cells["descripcion"].Value.ToString();
            form.txtcolor.Text = this.dlistado.CurrentRow.Cells["color"].Value.ToString();
            form.txtvendido.Text = this.dlistado.CurrentRow.Cells["precio_venta"].Value.ToString();
            form.txtcomprado.Text = this.dlistado.CurrentRow.Cells["precio_compra"].Value.ToString();
            form.txtstock.Text = this.dlistado.CurrentRow.Cells["stock"].Value.ToString();
            form.txtidcategoria.Text = this.dlistado.CurrentRow.Cells["idcategoria"].Value.ToString();
            form.txttalla.Text = this.dlistado.CurrentRow.Cells["talla"].Value.ToString();
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
                        int idproducto = Convert.ToInt32(
                            dlistado.CurrentRow.Cells["idproducto"].Value);

                        // Enviamos el idproducto a la Capa de Negocio
                        string respuesta = CNProducto.Eliminar(idproducto);

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
    }
}