using CapaNegocio;
using System;
using System.Data;
using System.Windows.Forms;
using static CapaNegocio.CNCompra;

namespace CapaPresentacion
{
    public partial class FRMCompra : Form
    {
        // Propiedades públicas que asigna FRMListadoCompra
        public bool esNuevo { get; set; }
        public int idcompra { get; set; }

        // Tabla en memoria que acumula el detalle
        private DataTable dtDetalle = new DataTable();

        public FRMCompra()
        {
            InitializeComponent();
        }

        // ── Carga inicial ──────────────────────────────────────
        private void FRMCompra_Load(object sender, EventArgs e)
        {
            CargarProveedores();
            InicializarTablaDetalle();

            if (esNuevo)
            {
                dtpFecha.Value = DateTime.Now;
                lblTitulo.Text = "Nueva Compra";
                btnGuardar.Text = "Guardar";
            }
            else
            {
                lblTitulo.Text = "Editar Compra";
                btnGuardar.Text = "Actualizar";
                CargarDatosEditar();
            }
        }

        // ── Proveedores en el ComboBox ─────────────────────────
        private void CargarProveedores()
        {
            DataTable dt = CNProveedor.Listar();
            cboProveedor.DataSource = dt;
            cboProveedor.DisplayMember = "Nombre";       // columna visible
            cboProveedor.ValueMember = "idproveedor";  // valor interno
            cboProveedor.SelectedIndex = -1;
        }

        // ── Al cambiar proveedor, carga sus productos ──────────
        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProveedor.SelectedIndex < 0) return;

            int idproveedor = Convert.ToInt32(cboProveedor.SelectedValue);
            DataTable dt = CNProducto.ListarPorProveedor(idproveedor);

            cboProducto.DataSource = dt;
            cboProducto.DisplayMember = "nombre";
            cboProducto.ValueMember = "idproducto";
            cboProducto.SelectedIndex = -1;
        }

        // ── Al seleccionar producto, rellena precio ────────────
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex < 0) return;

            DataRowView fila = (DataRowView)cboProducto.SelectedItem;
            txtPrecio.Text = fila["precio_compra"].ToString();
            txtCantidad.Focus();
        }

        // ── Tabla en memoria para el detalle ───────────────────
        private void InicializarTablaDetalle()
        {
            dtDetalle.Columns.Add("idproducto", typeof(int));
            dtDetalle.Columns.Add("producto", typeof(string));
            dtDetalle.Columns.Add("cantidad", typeof(int));
            dtDetalle.Columns.Add("precio", typeof(decimal));
            dtDetalle.Columns.Add("total", typeof(decimal));

            dgvDetalle.DataSource = dtDetalle;

            // Oculta la columna técnica en la grilla
            dgvDetalle.Columns["idproducto"].Visible = false;
        }

        // ── Agregar producto al detalle ────────────────────────
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un producto.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio no es válido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idproducto = Convert.ToInt32(cboProducto.SelectedValue);
            string nombre = cboProducto.Text;
            decimal total = cantidad * precio;

            // Evita duplicados: si ya está, suma la cantidad
            foreach (DataRow row in dtDetalle.Rows)
            {
                if (Convert.ToInt32(row["idproducto"]) == idproducto)
                {
                    row["cantidad"] = Convert.ToInt32(row["cantidad"]) + cantidad;
                    row["total"] = Convert.ToDecimal(row["precio"])
                                      * Convert.ToInt32(row["cantidad"]);
                    RecalcularTotales();
                    return;
                }
            }

            dtDetalle.Rows.Add(idproducto, nombre, cantidad, precio, total);
            RecalcularTotales();

            // Limpia campos para el siguiente producto
            cboProducto.SelectedIndex = -1;
            txtCantidad.Text = "";
            txtPrecio.Text = "";
        }

        // ── Quitar fila seleccionada del detalle ───────────────
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow == null) return;

            int index = dgvDetalle.CurrentRow.Index;
            dtDetalle.Rows[index].Delete();
            RecalcularTotales();
        }

        // ── Subtotal / IVA / Total ─────────────────────────────
        private void RecalcularTotales()
        {
            decimal subtotal = 0;
            foreach (DataRow row in dtDetalle.Rows)
                if (row.RowState != DataRowState.Deleted)
                    subtotal += Convert.ToDecimal(row["total"]);

            decimal iva = subtotal * 0.12m;   // ajusta el % según tu país
            decimal total = subtotal + iva;

            txtSubtotal.Text = subtotal.ToString("F2");
            txtIVA.Text = iva.ToString("F2");
            txtTotal.Text = total.ToString("F2");
        }

        // ── Guardar compra completa ────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboProveedor.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un proveedor.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Agregue al menos un producto al detalle.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtNumDoc.Text, out int numDoc))
            {
                MessageBox.Show("Ingrese un número de documento válido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ── 1. Cabecera ──
                Compra compra = new Compra
                {
                    fecha = dtpFecha.Value,
                    num_documento = numDoc,
                    tipo_documento = cboTipoDoc.Text,
                    subtotal = Convert.ToDecimal(txtSubtotal.Text),
                    iva = Convert.ToDecimal(txtIVA.Text),
                    total = Convert.ToDecimal(txtTotal.Text),
                    estado = "Activo",
                    idusuario = 1,
                    idproveedor = Convert.ToInt32(cboProveedor.SelectedValue)
                };

                string resCompra;
                int idCompraGenerado;

                resCompra = CNCompra.GuardarRetornarId(compra, out idCompraGenerado);

                if (esNuevo)
                {
                    resCompra = CNCompra.GuardarRetornarId(compra, out idCompraGenerado);
                }
                else
                {
                    compra.idcompra = idcompra;
                    resCompra = CNCompra.Editar(compra);
                    idCompraGenerado = idcompra;
                }

                if (resCompra != "OK")
                {
                    MessageBox.Show(resCompra, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // ── 2. Detalle ──
                foreach (DataRow fila in dtDetalle.Rows)
                {
                    DetalleCompra det = new DetalleCompra
                    {
                        IdCompra = idCompraGenerado,
                        IdProducto = Convert.ToInt32(fila["idproducto"]),
                        Cantidad = Convert.ToInt32(fila["cantidad"]),
                        Precio = Convert.ToDecimal(fila["precio"]),
                        Total = Convert.ToDecimal(fila["total"])
                    };

                    string resDet = CNDetalleCompra.Guardar(det);

                    if (resDet != "OK")
                    {
                        MessageBox.Show("Error en detalle: " + resDet);
                        return;
                    }
                }

                MessageBox.Show("Compra registrada correctamente.",
                    "Sistema Ventas", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Cargar datos al editar ─────────────────────────────
        private void CargarDatosEditar()
        {
            DataTable dt = CNCompra.BuscarPorId(idcompra);
            if (dt == null || dt.Rows.Count == 0) return;

            DataRow r = dt.Rows[0];
            dtpFecha.Value = Convert.ToDateTime(r["fecha"]);
            txtNumDoc.Text = r["num_documento"].ToString();
            cboTipoDoc.Text = r["tipo_documento"].ToString();
            cboProveedor.SelectedValue = r["idproveedor"];
            txtSubtotal.Text = r["subtotal"].ToString();
            txtIVA.Text = r["iva"].ToString();
            txtTotal.Text = r["total"].ToString();

            // Carga el detalle existente
            DataTable dtDet = CNDetalleCompra.Listar(idcompra);
            foreach (DataRow fila in dtDet.Rows)
            {
                dtDetalle.Rows.Add(
                    fila["idproducto"],
                    fila["producto"],
                    fila["cantidad"],
                    fila["precio"],
                    fila["total"]);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}