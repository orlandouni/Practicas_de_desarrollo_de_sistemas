namespace CapaPresentacion
{
    partial class FRMBitacora
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dlistado = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnMenuHam = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnsalir = new System.Windows.Forms.Button();
            this.lblselect = new System.Windows.Forms.Label();
            this.comboTabla = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.fechaSelect = new System.Windows.Forms.DateTimePicker();
            this.comboOperacion = new System.Windows.Forms.ComboBox();
            this.rbtnUsuario = new System.Windows.Forms.RadioButton();
            this.rbtnRegistro = new System.Windows.Forms.RadioButton();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblselect2 = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSesion = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dlistado)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlistado
            // 
            this.dlistado.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dlistado.AllowUserToAddRows = false;
            this.dlistado.AllowUserToDeleteRows = false;
            this.dlistado.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dlistado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dlistado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dlistado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dlistado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dlistado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dlistado.Location = new System.Drawing.Point(15, 160);
            this.dlistado.MultiSelect = false;
            this.dlistado.Name = "dlistado";
            this.dlistado.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dlistado.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dlistado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dlistado.Size = new System.Drawing.Size(787, 261);
            this.dlistado.TabIndex = 0;
            this.dlistado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.panelHeader.Controls.Add(this.btnMenuHam);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Location = new System.Drawing.Point(1, 1);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(820, 52);
            this.panelHeader.TabIndex = 1;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // btnMenuHam
            // 
            this.btnMenuHam.FlatAppearance.BorderSize = 0;
            this.btnMenuHam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHam.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHam.ForeColor = System.Drawing.Color.Transparent;
            this.btnMenuHam.Location = new System.Drawing.Point(727, 3);
            this.btnMenuHam.Name = "btnMenuHam";
            this.btnMenuHam.Size = new System.Drawing.Size(90, 42);
            this.btnMenuHam.TabIndex = 1;
            this.btnMenuHam.Text = "☰";
            this.btnMenuHam.UseVisualStyleBackColor = true;
            this.btnMenuHam.Click += new System.EventHandler(this.btnMenuHam_Click_1);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitulo.Location = new System.Drawing.Point(12, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(142, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🕓Bitácora";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnsalir);
            this.panel1.Controls.Add(this.lblselect);
            this.panel1.Controls.Add(this.comboTabla);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.fechaSelect);
            this.panel1.Controls.Add(this.comboOperacion);
            this.panel1.Controls.Add(this.rbtnUsuario);
            this.panel1.Controls.Add(this.rbtnRegistro);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.lblselect2);
            this.panel1.Location = new System.Drawing.Point(15, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 86);
            this.panel1.TabIndex = 10;
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.Gainsboro;
            this.btnsalir.FlatAppearance.BorderSize = 0;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsalir.Location = new System.Drawing.Point(710, 42);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Size = new System.Drawing.Size(67, 27);
            this.btnsalir.TabIndex = 11;
            this.btnsalir.Text = "&Salir";
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.btnsalir_Click_1);
            // 
            // lblselect
            // 
            this.lblselect.AutoSize = true;
            this.lblselect.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblselect.ForeColor = System.Drawing.Color.DimGray;
            this.lblselect.Location = new System.Drawing.Point(3, 19);
            this.lblselect.Name = "lblselect";
            this.lblselect.Size = new System.Drawing.Size(47, 21);
            this.lblselect.TabIndex = 1;
            this.lblselect.Text = "Tabla";
            this.lblselect.Click += new System.EventHandler(this.lblselect_Click);
            // 
            // comboTabla
            // 
            this.comboTabla.FormattingEnabled = true;
            this.comboTabla.Location = new System.Drawing.Point(4, 43);
            this.comboTabla.Name = "comboTabla";
            this.comboTabla.Size = new System.Drawing.Size(87, 21);
            this.comboTabla.TabIndex = 7;
            this.comboTabla.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DarkGray;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(629, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 26);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // fechaSelect
            // 
            this.fechaSelect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fechaSelect.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaSelect.Location = new System.Drawing.Point(679, 3);
            this.fechaSelect.Name = "fechaSelect";
            this.fechaSelect.Size = new System.Drawing.Size(88, 23);
            this.fechaSelect.TabIndex = 6;
            this.fechaSelect.ValueChanged += new System.EventHandler(this.fechaSelect_ValueChanged);
            // 
            // comboOperacion
            // 
            this.comboOperacion.FormattingEnabled = true;
            this.comboOperacion.Location = new System.Drawing.Point(109, 42);
            this.comboOperacion.Name = "comboOperacion";
            this.comboOperacion.Size = new System.Drawing.Size(120, 21);
            this.comboOperacion.TabIndex = 8;
            this.comboOperacion.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // rbtnUsuario
            // 
            this.rbtnUsuario.AutoSize = true;
            this.rbtnUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.rbtnUsuario.Location = new System.Drawing.Point(250, 43);
            this.rbtnUsuario.Name = "rbtnUsuario";
            this.rbtnUsuario.Size = new System.Drawing.Size(65, 19);
            this.rbtnUsuario.TabIndex = 5;
            this.rbtnUsuario.TabStop = true;
            this.rbtnUsuario.Text = "Usuario";
            this.rbtnUsuario.UseVisualStyleBackColor = true;
            this.rbtnUsuario.CheckedChanged += new System.EventHandler(this.rbtnUsuario_CheckedChanged);
            // 
            // rbtnRegistro
            // 
            this.rbtnRegistro.AutoSize = true;
            this.rbtnRegistro.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnRegistro.ForeColor = System.Drawing.Color.DimGray;
            this.rbtnRegistro.Location = new System.Drawing.Point(334, 43);
            this.rbtnRegistro.Name = "rbtnRegistro";
            this.rbtnRegistro.Size = new System.Drawing.Size(82, 19);
            this.rbtnRegistro.TabIndex = 4;
            this.rbtnRegistro.TabStop = true;
            this.rbtnRegistro.Text = "Id Registro";
            this.rbtnRegistro.UseVisualStyleBackColor = true;
            this.rbtnRegistro.CheckedChanged += new System.EventHandler(this.rbtnRegistro_CheckedChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(427, 43);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(196, 25);
            this.txtBuscar.TabIndex = 3;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblselect2
            // 
            this.lblselect2.AutoSize = true;
            this.lblselect2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblselect2.ForeColor = System.Drawing.Color.DimGray;
            this.lblselect2.Location = new System.Drawing.Point(110, 18);
            this.lblselect2.Name = "lblselect2";
            this.lblselect2.Size = new System.Drawing.Size(86, 21);
            this.lblselect2.TabIndex = 2;
            this.lblselect2.Text = "Operación";
            this.lblselect2.Click += new System.EventHandler(this.lblselect2_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.label1);
            this.panelMenu.Controls.Add(this.label2);
            this.panelMenu.Controls.Add(this.btnSesion);
            this.panelMenu.Controls.Add(this.btnBitacora);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMenu.Location = new System.Drawing.Point(621, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 450);
            this.panelMenu.TabIndex = 11;
            this.panelMenu.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "●";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "●";
            // 
            // btnSesion
            // 
            this.btnSesion.FlatAppearance.BorderSize = 0;
            this.btnSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSesion.Location = new System.Drawing.Point(35, 88);
            this.btnSesion.Name = "btnSesion";
            this.btnSesion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSesion.Size = new System.Drawing.Size(126, 23);
            this.btnSesion.TabIndex = 0;
            this.btnSesion.Text = "Tiempo de sesión";
            this.btnSesion.UseVisualStyleBackColor = true;
            this.btnSesion.Click += new System.EventHandler(this.btnSesion_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.FlatAppearance.BorderSize = 0;
            this.btnBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitacora.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBitacora.Location = new System.Drawing.Point(35, 59);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBitacora.Size = new System.Drawing.Size(126, 23);
            this.btnBitacora.TabIndex = 14;
            this.btnBitacora.Text = "Bitacora";
            this.btnBitacora.UseVisualStyleBackColor = true;
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContenedor.Controls.Add(this.panelMenu);
            this.panelContenedor.Controls.Add(this.dlistado);
            this.panelContenedor.Controls.Add(this.panel1);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(821, 450);
            this.panelContenedor.TabIndex = 2;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCard_Paint);
            // 
            // FRMBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRMBitacora";
            this.Text = "FRMBitacora";
            this.Load += new System.EventHandler(this.FRMBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dlistado)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dlistado;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMenuHam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblselect;
        private System.Windows.Forms.ComboBox comboTabla;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker fechaSelect;
        private System.Windows.Forms.ComboBox comboOperacion;
        private System.Windows.Forms.RadioButton rbtnUsuario;
        private System.Windows.Forms.RadioButton rbtnRegistro;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblselect2;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSesion;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Button btnsalir;
    }
}