using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmRealizarCompra : Form
    {
        // Tabla temporal del carrito
        private DataTable _carrito;

        public FrmRealizarCompra()
        {
            InitializeComponent();
        }

        // ── Inicialización ──────────────────────────────────────────────
        private void FrmRealizarCompra_Load(object sender, EventArgs e)
        {
            InicializarCarrito();
            CargarProveedores();

            dtpFecha.Value = DateTime.Today;
            cmbTipoDoc.Items.AddRange(new[] { "Factura", "Boleta", "Nota de compra" });
            cmbTipoDoc.SelectedIndex = 0;
        }

        private void InicializarCarrito()
        {
            _carrito = new DataTable();
            _carrito.Columns.Add("idproducto", typeof(int));
            _carrito.Columns.Add("Producto", typeof(string));
            _carrito.Columns.Add("Cantidad", typeof(int));
            _carrito.Columns.Add("Precio", typeof(decimal));
            _carrito.Columns.Add("Total", typeof(decimal));

            dgvCarrito.DataSource = _carrito;
        }

        // ── Proveedores ─────────────────────────────────────────────────
        private void CargarProveedores()
        {
            DataTable dt = CNDetalleCompra.ListarProveedores();
            cmbProveedor.DataSource = dt;
            cmbProveedor.DisplayMember = "nombre";
            cmbProveedor.ValueMember = "idproveedor";
            cmbProveedor.SelectedIndex = -1;
        }

        private void cmbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProveedor.SelectedIndex < 0 || cmbProveedor.SelectedItem == null) return;

            // Leer directo desde el DataRowView
            DataRowView fila = (DataRowView)cmbProveedor.SelectedItem;
            int idprov = Convert.ToInt32(fila["idproveedor"]);
            CargarProductos(idprov);
        }

        // ── Productos ───────────────────────────────────────────────────
        private void CargarProductos(int idproveedor)
        {
            DataTable dt = CNDetalleCompra.ProductosPorProveedor(idproveedor);
            cmbProducto.DataSource = dt;
            cmbProducto.DisplayMember = "nombre";
            cmbProducto.ValueMember = "idproducto";
            cmbProducto.SelectedIndex = -1;
            lblPrecio.Text = "Precio: $0.00";
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex < 0) return;

            DataRowView fila = (DataRowView)cmbProducto.SelectedItem;
            decimal precio = Convert.ToDecimal(fila["precio_compra"]);
            lblPrecio.Text = $"Precio: ${precio:F2}";
        }

        // ── Agregar al carrito ──────────────────────────────────────────
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex < 0)
            { MessageBox.Show("Seleccione un producto."); return; }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            { MessageBox.Show("Ingrese una cantidad válida."); return; }

            DataRowView fila = (DataRowView)cmbProducto.SelectedItem;
            int idproducto = (int)fila["idproducto"];
            string nombre = fila["nombre"].ToString();
            decimal precio = Convert.ToDecimal(fila["precio_compra"]);
            decimal total = precio * cantidad;

            // Si ya existe el producto en el carrito, suma cantidad
            foreach (DataRow row in _carrito.Rows)
            {
                if ((int)row["idproducto"] == idproducto)
                {
                    row["Cantidad"] = (int)row["Cantidad"] + cantidad;
                    row["Subtotal"] = (decimal)row["Subtotal"] + total;
                    ActualizarTotales();
                    return;
                }
            }

            _carrito.Rows.Add(idproducto, nombre, cantidad, precio, total);
            ActualizarTotales();
            txtCantidad.Clear();
        }

        // ── Quitar fila del carrito ─────────────────────────────────────
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null) return;
            int idx = dgvCarrito.CurrentRow.Index;
            _carrito.Rows[idx].Delete();
            ActualizarTotales();
        }

        // ── Totales ─────────────────────────────────────────────────────
        private void ActualizarTotales()
        {
            decimal subtotal = 0;
            foreach (DataRow r in _carrito.Rows)
                if (r.RowState != DataRowState.Deleted)
                    subtotal += (decimal)r["Total"];

            decimal iva = subtotal * 0.12m;
            decimal total = subtotal + iva;

            lblSubtotal.Text = $"Subtotal: ${subtotal:F2}";
            lblIva.Text = $"IVA (12%): ${iva:F2}";
            lblTotal.Text = $"Total: ${total:F2}";
        }

        // ── Guardar compra ──────────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (cmbProveedor.SelectedIndex < 0)
            { MessageBox.Show("Seleccione un proveedor."); return; }
            if (_carrito.Rows.Count == 0)
            { MessageBox.Show("Agregue al menos un producto."); return; }
            if (string.IsNullOrWhiteSpace(txtNumDoc.Text))
            { MessageBox.Show("Ingrese el número de documento."); return; }

            // Calcular totales
            decimal subtotal = 0;
            foreach (DataRow r in _carrito.Rows)
                subtotal += (decimal)r["Total"];        // ← era "Subtotal"

            decimal iva = subtotal * 0.12m;
            decimal total = subtotal + iva;

            // Obtener idproveedor desde SelectedItem
            DataRowView filaprov = (DataRowView)cmbProveedor.SelectedItem;
            int idprov = Convert.ToInt32(filaprov["idproveedor"]);

            // 1️⃣ Guardar cabecera de compra
            var compra = new CNCompra.Compra
            {
                fecha = dtpFecha.Value,
                num_documento = int.Parse(txtNumDoc.Text),
                tipo_documento = cmbTipoDoc.SelectedItem.ToString(),
                subtotal = subtotal,
                iva = iva,
                total = total,
                estado = "REGISTRADA",
                idusuario = CNSesion.IdUsuario,
                idproveedor = idprov              // ← era SelectedValue que fallaba
            };

            string res = CNCompra.GuardarRetornarId(compra, out int idcompra);
            if (res != "OK" || idcompra <= 0)
            { MessageBox.Show("Error al guardar la compra: " + res); return; }

            // 2️⃣ Guardar detalles y actualizar stock
            var detalles = new List<CNDetalleCompra.DetalleCompra>();
            foreach (DataRow r in _carrito.Rows)
            {
                detalles.Add(new CNDetalleCompra.DetalleCompra
                {
                    idcompra = idcompra,
                    idproducto = (int)r["idproducto"],
                    cantidad = (int)r["Cantidad"],
                    precio = (decimal)r["Precio"],
                    total = (decimal)r["Total"]  // ← era "total" en minúscula
                });
            }

            string resDetalle = CNDetalleCompra.GuardarDetalles(detalles);
            if (resDetalle != "OK")
            { MessageBox.Show("Compra guardada pero error en detalle: " + resDetalle); return; }

            MessageBox.Show($"✅ Compra #{idcompra} registrada correctamente.\nStock actualizado.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        // ── Limpiar ─────────────────────────────────────────────────────
        private void LimpiarFormulario()
        {
            InicializarCarrito();
            cmbProveedor.SelectedIndex = -1;
            cmbProducto.DataSource = null;
            txtNumDoc.Clear();
            txtCantidad.Clear();
            lblIva.Text = "IVA (12%): $0.00";
            lblTotal.Text = "Total:     $0.00";
            lblPrecio.Text = "Precio: $0.00";
        }

        private void grpProducto_Enter(object sender, EventArgs e)
        {

        }

        private void grpDocumento_Enter(object sender, EventArgs e)
        {

        }
    }
}