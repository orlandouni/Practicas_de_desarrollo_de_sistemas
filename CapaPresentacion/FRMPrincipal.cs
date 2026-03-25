using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FRMPrincipal : Form
    {
        // ─── Carrito en memoria ──────────────────────────────────────
        private DataTable dtCarrito = new DataTable();

        // ─── Producto encontrado actualmente ────────────────────────
        private int _idProductoActual = 0;
        private string _nombreActual = "";
        private string _tallaActual = "";
        private string _colorActual = "";
        private decimal _precioActual = 0;
        private int _stockActual = 0;
        private readonly string SERIE_CAJA = "F001"; // se configura una vez

        // ─── Usuario logueado ────────────────────────────────────────
        private int idUsuarioActual = 0;

        // ─── Lista de notificaciones ─────────────────────────────
        private List<string> _notificaciones = new List<string>();

        public FRMPrincipal()
        {
            InitializeComponent();
            idUsuarioActual = CNSesion.IdUsuario;
        }

        // ════════════════════════════════════════════════════════════
        // CARGA INICIAL
        // ════════════════════════════════════════════════════════════
        private void FRMPrincipal_Load(object sender, EventArgs e)
        {
            InicializarCarrito();
            ConfigurarDGVCarrito();
            CargarClientes();
            LimpiarPanelProducto();
            EstilizarDGV();

            // Items del combo tipo documento
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("Boleta");
            cmbTipoDocumento.Items.Add("Factura");
            cmbTipoDocumento.SelectedIndex = 0;

            // Mostrar el usuario conectado
            lblUsuarioConectado.Text = $"Usuario: {CNSesion.Usuario}";

            // Foco en el código al abrir
            txtCodigo.Focus();



            // Notificaciones
            this.Controls.Add(pnlNotificaciones);
            pnlNotificaciones.BringToFront();
            lblNotificaciones.Cursor = Cursors.Hand;
            lblNotificaciones.Click += lblNotificaciones_Click;

            pnlNotificaciones.Visible = false;
            pnlNotificaciones.Size = new Size(260, 280);
            pnlNotificaciones.BackColor = Color.White;
            pnlNotificaciones.BorderStyle = BorderStyle.FixedSingle;

            // Cerrar panel si se hace clic fuera
            this.Click += (s, ev) =>
            {
                if (pnlNotificaciones.Visible)
                    pnlNotificaciones.Visible = false;
            };

            VerificarStockBajo();
            ActualizarBadge();
        }

        // ════════════════════════════════════════════════════════════
        // INICIALIZAR CARRITO
        // ════════════════════════════════════════════════════════════
        private void InicializarCarrito()
        {
            dtCarrito.Columns.Add("idproducto", typeof(int));
            dtCarrito.Columns.Add("nombre", typeof(string));
            dtCarrito.Columns.Add("talla", typeof(string));
            dtCarrito.Columns.Add("color", typeof(string));
            dtCarrito.Columns.Add("precio", typeof(decimal));
            dtCarrito.Columns.Add("cantidad", typeof(int));
            dtCarrito.Columns.Add("total", typeof(decimal));
        }

        private void ConfigurarDGVCarrito()
        {
            dgvCarrito.DataSource = dtCarrito;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;

            // Ocultar columna técnica
            dgvCarrito.Columns["idproducto"].Visible = false;

            // Cabeceras
            dgvCarrito.Columns["nombre"].HeaderText = "Producto";
            dgvCarrito.Columns["talla"].HeaderText = "Talla";
            dgvCarrito.Columns["color"].HeaderText = "Color";
            dgvCarrito.Columns["precio"].HeaderText = "P. Unit.";
            dgvCarrito.Columns["cantidad"].HeaderText = "Cant.";
            dgvCarrito.Columns["total"].HeaderText = "Total";
        }

        // ════════════════════════════════════════════════════════════
        // CARGAR CLIENTES
        // ════════════════════════════════════════════════════════════
        private void CargarClientes()
        {
            try
            {
                DataTable dt = CNPrincipal.ListarClientes();
                cmbCliente.DataSource = dt;
                cmbCliente.DisplayMember = "nombreCompleto";
                cmbCliente.ValueMember = "idcliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        // BUSCAR PRODUCTO — Enter en txtCodigo
        // ════════════════════════════════════════════════════════════
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProducto();
                e.SuppressKeyPress = true;
            }
        }

        // ════════════════════════════════════════════════════════════
        // BUSCAR PRODUCTO — clic en btnBuscar
        // ════════════════════════════════════════════════════════════
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarProducto();
        }

        // ════════════════════════════════════════════════════════════
        // LÓGICA DE BÚSQUEDA
        // ════════════════════════════════════════════════════════════
        private void BuscarProducto()
        {
            string codigo = txtCodigo.Text.Trim();

            if (codigo == "")
            {
                MessageBox.Show("Ingresa o escanea un código.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable dt = CNPrincipal.BuscarProductos(codigo, 0);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"No se encontró ningún producto con el código: {codigo}",
                        "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarPanelProducto();
                    return;
                }

                DataRow row = dt.Rows[0];

                // Guardar datos en variables privadas
                _idProductoActual = Convert.ToInt32(row["idproducto"]);
                _nombreActual = row["nombre"].ToString();
                _tallaActual = row["talla"].ToString();
                _colorActual = row["color"].ToString();
                _precioActual = Convert.ToDecimal(row["precio_venta"]);
                _stockActual = Convert.ToInt32(row["stock"]);

                // Mostrar en labels del groupBox1
                lblNombreProducto.Text = _nombreActual;
                lblTallaColor.Text = $"Talla: {_tallaActual}   |   Color: {_colorActual}";
                lblPrecioProducto.Text = _precioActual.ToString("C");
                lblStockProducto.Text = $"Stock disponible: {_stockActual}";
                lblStockProducto.ForeColor = _stockActual > 0
                    ? Color.FromArgb(15, 110, 86)
                    : Color.Red;

                nudCantidad.Minimum = 1;
                nudCantidad.Maximum = _stockActual;
                nudCantidad.Value = 1;
                btnAgregar.Enabled = _stockActual > 0;

                // Foco en cantidad para agilizar
                nudCantidad.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        // LIMPIAR PANEL DE PRODUCTO
        // ════════════════════════════════════════════════════════════
        private void LimpiarPanelProducto()
        {
            _idProductoActual = 0;
            _nombreActual = "";
            _tallaActual = "";
            _colorActual = "";
            _precioActual = 0;
            _stockActual = 0;

            lblNombreProducto.Text = "—";
            lblTallaColor.Text = "—";
            lblPrecioProducto.Text = "—";
            lblStockProducto.Text = "—";
            lblStockProducto.ForeColor = SystemColors.ControlText;
            nudCantidad.Value = 1;
            btnAgregar.Enabled = false;
            txtCodigo.Clear();
            txtCodigo.Focus();
        }

        private string GenerarNumDocumento()
        {
            try
            {
                // Obtiene el último número de esta serie y le suma 1
                DataTable dt = CNPrincipal.ObtenerUltimoNumDoc(SERIE_CAJA);
                int ultimo = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
                return (ultimo + 1).ToString("D8"); // ej: 00000001, 00000002...
            }
            catch
            {
                return "00000001";
            }
        }

        // ════════════════════════════════════════════════════════════
        // AGREGAR AL CARRITO
        // ════════════════════════════════════════════════════════════
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (_idProductoActual == 0) return;

            int cantidad = (int)nudCantidad.Value;

            DataRow[] filas = dtCarrito.Select($"idproducto = {_idProductoActual}");

            if (filas.Length > 0)
            {
                int nuevaCant = Convert.ToInt32(filas[0]["cantidad"]) + cantidad;

                if (nuevaCant > _stockActual)
                {
                    MessageBox.Show($"No puedes agregar más de {_stockActual} unidades en total.",
                        "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                filas[0]["cantidad"] = nuevaCant;
                filas[0]["total"] = nuevaCant * _precioActual;
            }
            else
            {
                dtCarrito.Rows.Add(
                    _idProductoActual,
                    _nombreActual,
                    _tallaActual,
                    _colorActual,
                    _precioActual,
                    cantidad,
                    cantidad * _precioActual
                );
            }

            dgvCarrito.Refresh();
            ActualizarTotales();
            LimpiarPanelProducto(); // listo para el siguiente escaneo
        }

        // ════════════════════════════════════════════════════════════
        // CALCULAR TOTALES
        // ════════════════════════════════════════════════════════════
        private void ActualizarTotales()
        {
            decimal subtotal = 0;
            foreach (DataRow row in dtCarrito.Rows)
                subtotal += Convert.ToDecimal(row["total"]);

            decimal iva = subtotal * 0.16m;
            decimal total = subtotal + iva;

            lblSubtotal.Text = $"Subtotal: {subtotal:C}";
            lblIVA.Text = $"IVA 16%:  {iva:C}";
            lblTotal.Text = $"Total:    {total:C}";
            btnCobrar.Text = $"Cobrar  {total:C}";
        }

        // ════════════════════════════════════════════════════════════
        // COBRAR
        // ════════════════════════════════════════════════════════════
        private void btnCobrar_Click_1(object sender, EventArgs e)
        {
            if (dtCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un cliente.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = 0;
            foreach (DataRow row in dtCarrito.Rows)
                subtotal += Convert.ToDecimal(row["total"]);

            decimal iva = subtotal * 0.16m;
            decimal total = subtotal + iva;

            DialogResult confirm = MessageBox.Show(
                $"¿Confirmar venta por {total:C}?",
                "Confirmar cobro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                // Serie y número se generan automático
                string serie = SERIE_CAJA;
                string numDoc = GenerarNumDocumento();

                int idVenta = CNPrincipal.RegistrarVenta(
                    idUsuarioActual,
                    Convert.ToInt32(cmbCliente.SelectedValue),
                    serie,
                    numDoc,
                    cmbTipoDocumento.Text,
                    subtotal,
                    iva,
                    total,
                    dtCarrito);

                if (idVenta > 0)
                {
                    MessageBox.Show(
                        $"Venta #{idVenta} registrada.\nDocumento: {serie}-{numDoc}\nTotal: {total:C}",
                        "Venta exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LimpiarTodo();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la venta.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ════════════════════════════════════════════════════════════
        // LIMPIAR TODO DESPUÉS DE COBRAR
        // ════════════════════════════════════════════════════════════
        private void LimpiarTodo()
        {
            dtCarrito.Rows.Clear();
            lblSubtotal.Text = "Subtotal: $0.00";
            lblIVA.Text = "IVA 16%:  $0.00";
            lblTotal.Text = "Total:    $0.00";
            btnCobrar.Text = "Cobrar";
           
            LimpiarPanelProducto();
        }

        // ════════════════════════════════════════════════════════════
        // MANDAR NOTIFICACION SI STOCK BAJO
        // ════════════════════════════════════════════════════════════
        private void VerificarStockBajo()
        {
            try
            {
                DataTable dt = CNPrincipal.ObtenerProductosStockBajo(5);

                if (dt == null || dt.Rows.Count == 0) return;

                foreach (DataRow row in dt.Rows)
                    _notificaciones.Add($"Stock bajo: {row["nombre"]} ({row["stock"]} uds.)");

                ActualizarBadge();
            }
            catch { }
        }
        // ════════════════════════════════════════════════════════════
        // BADGE DEL ÍCONO DE NOTIFICACIONES
        // ════════════════════════════════════════════════════════════
        private void ActualizarBadge()
        {
            int total = _notificaciones.Count;
            lblNotificaciones.Text = total > 0 ? $"🔔 {total}" : "🔔";
            lblNotificaciones.ForeColor = total > 0
                ? Color.FromArgb(255, 220, 50)   // amarillo si hay alertas
                : Color.White;
        }

        // ════════════════════════════════════════════════════════════
        // ABRIR / CERRAR PANEL DE NOTIFICACIONES
        // ════════════════════════════════════════════════════════════
        private void lblNotificaciones_Click(object sender, EventArgs e)
        {
            if (pnlNotificaciones.Visible)
            {
                pnlNotificaciones.Visible = false;
                return;
            }

            // Posicionar justo debajo del label
            Point pos = panel2.PointToScreen(lblNotificaciones.Location);
            Point relativo = this.PointToClient(pos);
            pnlNotificaciones.Location = new Point(
                relativo.X - pnlNotificaciones.Width + lblNotificaciones.Width,
                relativo.Y + lblNotificaciones.Height + 2);

            RenderizarNotificaciones();
            pnlNotificaciones.Visible = true;
            pnlNotificaciones.BringToFront();
        }

        // ════════════════════════════════════════════════════════════
        // RENDERIZAR NOTIFICACIONES DENTRO DEL PANEL
        // ════════════════════════════════════════════════════════════
        private void RenderizarNotificaciones()
        {
            pnlNotificaciones.Controls.Clear();
            pnlNotificaciones.BackColor = Color.White;
            pnlNotificaciones.Padding = new Padding(0);

            // ── Encabezado ──────────────────────────────────────────
            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 36,
                BackColor = Color.FromArgb(26, 58, 110)
            };

            Label titulo = new Label
            {
                Text = $"Notificaciones ({_notificaciones.Count})",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };

            Button btnCerrar = new Button
            {
                Text = "✕",
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Right,
                Width = 36,
                Font = new Font("Segoe UI", 9f),
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => pnlNotificaciones.Visible = false;

            header.Controls.Add(titulo);
            header.Controls.Add(btnCerrar);
            pnlNotificaciones.Controls.Add(header);

            // ── Sin notificaciones ───────────────────────────────────
            if (_notificaciones.Count == 0)
            {
                Label vacio = new Label
                {
                    Text = "Sin notificaciones",
                    ForeColor = Color.FromArgb(150, 150, 150),
                    Font = new Font("Segoe UI", 9f),
                    AutoSize = false,
                    Size = new Size(pnlNotificaciones.Width, 50),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlNotificaciones.Controls.Add(vacio);
                return;
            }

            // ── Lista de notificaciones ──────────────────────────────
            FlowLayoutPanel lista = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(6),
                Margin = new Padding(0)
            };

            foreach (string notif in _notificaciones)
            {
                Panel item = new Panel
                {
                    Width = pnlNotificaciones.Width - 24,
                    Height = 48,
                    BackColor = Color.FromArgb(245, 248, 255),
                    Margin = new Padding(0, 0, 0, 4),
                    Cursor = Cursors.Default
                };

                // Ícono de advertencia
                Label icono = new Label
                {
                    Text = "⚠",
                    ForeColor = Color.FromArgb(180, 120, 0),
                    Font = new Font("Segoe UI", 13f),
                    Location = new Point(8, 12),
                    Size = new Size(24, 24) // 👈 tamaño fijo
                };
                // Texto
                Label texto = new Label
                {
                    Text = notif,
                    ForeColor = Color.FromArgb(26, 58, 110),
                    Font = new Font("Segoe UI", 8.5f),
                    Location = new Point(40, 6), // 👈 más espacio
                    Size = new Size(item.Width - 50, 36),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                item.Controls.Add(icono);
                item.Controls.Add(texto);
                lista.Controls.Add(item);
            }

            // ── Botón limpiar ────────────────────────────────────────
            Button btnLimpiar = new Button
            {
                Text = "Limpiar notificaciones",
                Dock = DockStyle.Bottom,
                Height = 32,
                BackColor = Color.FromArgb(240, 244, 255),
                ForeColor = Color.FromArgb(26, 58, 110),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5f),
                Cursor = Cursors.Hand
            };
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(200, 216, 245);
            btnLimpiar.Click += (s, e) =>
            {
                _notificaciones.Clear();
                ActualizarBadge();
                pnlNotificaciones.Visible = false;
            };

            pnlNotificaciones.Controls.Add(btnLimpiar); // primero bottom
            pnlNotificaciones.Controls.Add(lista);      // luego fill
            pnlNotificaciones.Controls.Add(header);     // al final top
        }

        // ════════════════════════════════════════════════════════════
        // Hcer bonit DGV
        // ════════════════════════════════════════════════════════════
        private void EstilizarDGV()
        {
            // ─── Sin bordes ni líneas ────────────────────────────────────
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.GridColor = Color.White;
            dgvCarrito.ScrollBars = ScrollBars.Vertical;

            // ─── Fondo ──────────────────────────────────────────────────
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.DefaultCellStyle.BackColor = Color.White;
            dgvCarrito.DefaultCellStyle.ForeColor = Color.FromArgb(26, 58, 110);
            dgvCarrito.DefaultCellStyle.Font = new Font("Segoe UI", 9f);
            dgvCarrito.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dgvCarrito.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 58, 110);
            dgvCarrito.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);

            // ─── Filas alternas ──────────────────────────────────────────
            dgvCarrito.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 255);
            dgvCarrito.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(26, 58, 110);
            dgvCarrito.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dgvCarrito.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 58, 110);

            // ─── Cabecera ────────────────────────────────────────────────
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvCarrito.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(26, 58, 110);
            dgvCarrito.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgvCarrito.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 8, 4, 8);
            dgvCarrito.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvCarrito.ColumnHeadersHeight = 36;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCarrito.Columns["precio"].HeaderText = "$";

            // ─── Filas ───────────────────────────────────────────────────
            dgvCarrito.RowTemplate.Height = 34;
            dgvCarrito.RowTemplate.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
        }

    // ─── Comportamiento ───────────────────────

            // ════════════════════════════════════════════════════════════
            // EVENTOS VACÍOS QUE EL DESIGNER YA REGISTRÓ
            // ════════════════════════════════════════════════════════════
        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void splitContainer1_Panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtSerie_TextChanged(object sender, EventArgs e) { }
        private void dgvCarrito_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e) { }
        private void btnMenuHam_Click(object sender, EventArgs e) {
            FRMMenu frm = new FRMMenu();
            
            frm.Show();
            this.Hide();
        }

        private void lblSubtotal_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUsuarioConectado_Click(object sender, EventArgs e)
        {

        }
    }
}