namespace CapaPresentacion
{
    partial class FRMBackup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblRutaLabel = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnAbrirCarpeta = new System.Windows.Forms.Button();
            this.lblUltimoBackup = new System.Windows.Forms.Label();
            this.lblUltimaRestauracion = new System.Windows.Forms.Label();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 70);
            this.panel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Historic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(15, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(328, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Respaldo de Base de Datos";
            // 
            // lblRutaLabel
            // 
            this.lblRutaLabel.AutoSize = true;
            this.lblRutaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRutaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.lblRutaLabel.Location = new System.Drawing.Point(30, 100);
            this.lblRutaLabel.Name = "lblRutaLabel";
            this.lblRutaLabel.Size = new System.Drawing.Size(141, 20);
            this.lblRutaLabel.TabIndex = 1;
            this.lblRutaLabel.Text = "Carpeta de destino:";
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRuta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.txtRuta.Location = new System.Drawing.Point(30, 128);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(430, 25);
            this.txtRuta.TabIndex = 2;
            // 
            // btnExaminar
            // 
            this.btnExaminar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExaminar.FlatAppearance.BorderSize = 0;
            this.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExaminar.ForeColor = System.Drawing.Color.White;
            this.btnExaminar.Location = new System.Drawing.Point(468, 128);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(100, 26);
            this.btnExaminar.TabIndex = 3;
            this.btnExaminar.Text = "Cambiar";
            this.btnExaminar.UseVisualStyleBackColor = false;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(30, 172);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(220, 35);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "Realizar Respaldo Ahora";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnAbrirCarpeta
            // 
            this.btnAbrirCarpeta.BackColor = System.Drawing.Color.LightGray;
            this.btnAbrirCarpeta.FlatAppearance.BorderSize = 0;
            this.btnAbrirCarpeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCarpeta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCarpeta.Location = new System.Drawing.Point(30, 213);
            this.btnAbrirCarpeta.Name = "btnAbrirCarpeta";
            this.btnAbrirCarpeta.Size = new System.Drawing.Size(220, 35);
            this.btnAbrirCarpeta.TabIndex = 5;
            this.btnAbrirCarpeta.Text = "📁 Ver carpeta de respaldos";
            this.btnAbrirCarpeta.UseVisualStyleBackColor = false;
            this.btnAbrirCarpeta.Click += new System.EventHandler(this.btnAbrirCarpeta_Click);
            // 
            // lblUltimoBackup
            // 
            this.lblUltimoBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoBackup.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblUltimoBackup.Location = new System.Drawing.Point(264, 172);
            this.lblUltimoBackup.Name = "lblUltimoBackup";
            this.lblUltimoBackup.Size = new System.Drawing.Size(304, 40);
            this.lblUltimoBackup.TabIndex = 6;
            this.lblUltimoBackup.Visible = false;
            // 
            // lblUltimaRestauracion
            // 
            this.lblUltimaRestauracion.AutoSize = true;
            this.lblUltimaRestauracion.Location = new System.Drawing.Point(31, 348);
            this.lblUltimaRestauracion.Name = "lblUltimaRestauracion";
            this.lblUltimaRestauracion.Size = new System.Drawing.Size(35, 13);
            this.lblUltimaRestauracion.TabIndex = 7;
            this.lblUltimaRestauracion.Text = "label1";
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(171)))), ((int)(((byte)(93)))));
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.ForeColor = System.Drawing.Color.White;
            this.btnRestaurar.Location = new System.Drawing.Point(34, 287);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(198, 42);
            this.btnRestaurar.TabIndex = 8;
            this.btnRestaurar.Text = "Restaurar BD";
            this.btnRestaurar.UseVisualStyleBackColor = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click_1);
            // 
            // FRMBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 370);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.lblUltimaRestauracion);
            this.Controls.Add(this.lblUltimoBackup);
            this.Controls.Add(this.btnAbrirCarpeta);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.lblRutaLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FRMBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Respaldo de Base de Datos";
            this.Load += new System.EventHandler(this.FRMBackup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblRutaLabel;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnAbrirCarpeta;
        private System.Windows.Forms.Label lblUltimoBackup;
        private System.Windows.Forms.Label lblUltimaRestauracion;
        private System.Windows.Forms.Button btnRestaurar;
    }
}