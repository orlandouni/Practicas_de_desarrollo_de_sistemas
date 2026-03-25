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
using ZXing;

namespace CapaPresentacion
{
    public partial class FRMRegistrarProducto : Form
    {
        public bool Insert = false;
        public bool Edit = false;
        public FRMRegistrarProducto()
        {
            InitializeComponent();
        }

        private void labelR_Click(object sender, EventArgs e)
        {

        }

        public Bitmap GenerarCodigoBarras(string codigo)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.CODE_128;

            return writer.Write(codigo);
        }

       

        private void txtidcliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nombre_Click(object sender, EventArgs e)
        {

        }

        private void txtapellidos_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtcodigo.Text))
            {
                pictureCodigo.Image = GenerarCodigoBarras(txtcodigo.Text);
            }
        }

        private void rbtninactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void rbtnactivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txttelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string estado = rbtnactivo.Checked ? "ACTIVO" : "INACTIVO";

         

            try
            {
                // 1. Validar que los campos obligatorios no estén vacíos
                if (string.IsNullOrWhiteSpace(this.txtnombre.Text) || string.IsNullOrWhiteSpace(this.txtcodigo.Text))
                {
                    MessageBox.Show("Ingrese los datos del producto (Nombre y Código son obligatorios)", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detener la ejecución si faltan datos
                }

                string rpta = "";

                // 2. Lógica para Insertar
                if (this.Insert == true)
                {
                    rpta = CNProducto.Guardar(
                        txtcodigo.Text.Trim(),                  // 1. string codigo
                        txtnombre.Text.Trim(),                  // 2. string nombre
                        txtdescripcion.Text.Trim(),             // 3. string descripcion
                        txttalla.Text.Trim(),                   // 4. string talla
                        txtcolor.Text.Trim(),                   // 5. string color
                        Convert.ToDecimal(txtcomprado.Text),    // 6. decimal precio_compra
                        Convert.ToDecimal(txtvendido.Text),     // 7. decimal precio_venta
                        Convert.ToInt32(txtstock.Text),         // 8. int stock
                        Convert.ToInt32(txtidcategoria.Text),   // 9. int idcategoria
                        Convert.ToInt32(cmbProveedor.SelectedValue)   // 9. int idproveedor

                    );
                }
                // 3. Lógica para Editar
                else if (this.Edit == true)
                {
                    rpta = CNProducto.Editar(
                        Convert.ToInt32(this.txtidproducto.Text), 
                        txtcodigo.Text.Trim(),                    
                        txtnombre.Text.Trim(),                    
                        txtdescripcion.Text.Trim(),               
                        txttalla.Text.Trim(),                    
                        txtcolor.Text.Trim(),                    
                        Convert.ToDecimal(txtcomprado.Text),      
                        Convert.ToDecimal(txtvendido.Text),       
                        Convert.ToInt32(txtstock.Text),          
                        estado,                                  
                        Convert.ToInt32(txtidcategoria.Text),
                        Convert.ToInt32(cmbProveedor.SelectedValue)

                    );
                }

                // 4. Evaluar el resultado
                if (rpta.Equals("OK"))
                {
                    MessageBox.Show("Operación realizada con éxito", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Insert = false;
                    this.Edit = false;

                    FRMListadoProducto form = new FRMListadoProducto();
                    form.Show();
                    this.Close(); // Es mejor usar Close() en lugar de Hide() para liberar memoria
                }
                else
                {
                    MessageBox.Show("Error al procesar: " + rpta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Asegúrese de escribir números válidos en Precios, Stock e ID Categoría.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRMRegistrarProducto_Load(object sender, EventArgs e)
        {
            this.CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                cmbProveedor.DataSource = CNProveedor.Listar(); // Debe traer DataTable
                cmbProveedor.DisplayMember = "nombre";   // lo que ve el usuario
                cmbProveedor.ValueMember = "idproveedor"; // el ID real

                cmbProveedor.SelectedIndex = -1; // nada seleccionado al inicio
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message);
            }
        }
        private void txtcolor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttalla_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureCodigo_Click(object sender, EventArgs e)
        {

        }

        private void btndescargar_Click_1(object sender, EventArgs e)
        {
            if (pictureCodigo.Image != null)
            {
                SaveFileDialog guardar = new SaveFileDialog();
                guardar.Filter = "Imagen PNG|*.png";
                guardar.Title = "Guardar código de barras";
                guardar.FileName = txtcodigo.Text + ".png";

                if (guardar.ShowDialog() == DialogResult.OK)
                {
                    pictureCodigo.Image.Save(guardar.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("Código de barras guardado correctamente");
                }
            }
            else
            {
                MessageBox.Show("Primero genere un código de barras");
            }
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}