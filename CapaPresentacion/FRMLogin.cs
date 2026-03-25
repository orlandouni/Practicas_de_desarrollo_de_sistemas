
using System;
using System.Drawing;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FRMLogin : Form
    {

        public bool LoginCorrecto { get; private set; } = false;
        private bool mostrarPassword = false;

        // ===== CAMPOS DE CLASE =====


        public FRMLogin()
        {
            InitializeComponent();
        }
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
          
        }
        private void FRMLogin_Load(object sender, EventArgs e)
        {
            txtcontraseña.UseSystemPasswordChar = true;
        }

        private void btnnigresar_Click(object sender, EventArgs e)
        {
            try
            {
                CNUsuario cn = new CNUsuario();
                string r = cn.Login(txtid.Text, txtcontraseña.Text);

                if (r == "OK")
                {


                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (mostrarPassword)
            {
                txtcontraseña.UseSystemPasswordChar = true;
                mostrarPassword = false;
            }
            else
            {
                txtcontraseña.UseSystemPasswordChar = false;
                mostrarPassword = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}