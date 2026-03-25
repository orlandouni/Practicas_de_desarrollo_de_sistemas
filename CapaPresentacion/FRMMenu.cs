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
    public partial class FRMMenu : Form
    {
        public FRMMenu()
        {
            InitializeComponent();
            this.FormClosing += FRMMenu_FormClosing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRMLogin login = new FRMLogin();

            FRMBitacora form = new FRMBitacora();
            form.Show();


        }

        private void FRMMenu_Load(object sender, EventArgs e)
        {

        }


        private void FRMMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CNSesion sesion = new CNSesion();
                sesion.CerrarSesion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cerrando sesión: " + ex.Message);
            }
        }


        private void bntClientes_Click(object sender, EventArgs e)
        {
            FRMListadoClientes form = new FRMListadoClientes();
            form.Show();


        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            FRMLogin form = new FRMLogin();
            form.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FRMLogin login = new FRMLogin();

            FRMBitacora form = new FRMBitacora();
            form.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // 🔴 cerrar sesión en BD
                CNSesion sesion = new CNSesion();
                sesion.CerrarSesion();

                // 🔴 limpiar datos estáticos
                CNSesion.IdSesion = 0;
                CNSesion.IdUsuario = 0;
                CNSesion.Usuario = null;
                CNSesion.Rol = null;

                // 🔴 abrir login
                FRMLogin login = new FRMLogin();
                login.Show();

                // 🔴 cerrar menú actual
                this.Hide();   // o this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cerrando sesión: " + ex.Message);
            }
        }


        private void label14_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔴 cerrar sesión en BD
                CNSesion sesion = new CNSesion();
                sesion.CerrarSesion();

                // 🔴 limpiar datos estáticos
                CNSesion.IdSesion = 0;
                CNSesion.IdUsuario = 0;
                CNSesion.Usuario = null;
                CNSesion.Rol = null;

                // 🔴 abrir login
                FRMLogin login = new FRMLogin();
                login.Show();

                // 🔴 cerrar menú actual
                this.Hide();   // o this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cerrando sesión: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FRMListadoClientes form = new FRMListadoClientes();
            form.Show();
        }

        private void btnproveedor_Click(object sender, EventArgs e)
        {
            FRMProveedor form = new FRMProveedor();
            form.Show();
        }

        private void btnproductos_Click(object sender, EventArgs e)
        {
            FRMListadoProducto form = new FRMListadoProducto();
            form.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FRMListadoEmpleados form = new FRMListadoEmpleados();
            form.Show();
        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            FRMListadoEmpleados form = new FRMListadoEmpleados();
            form.Show();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            FRMProveedor form = new FRMProveedor();
            form.Show();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            FRMListadoProducto form = new FRMListadoProducto();
            form.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            FRMPrincipal form = new FRMPrincipal();
            form.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            FRMPrincipal form = new FRMPrincipal();
            form.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            FRMListadoCompra form = new FRMListadoCompra();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRMListadoCompra form = new FRMListadoCompra();
            form.Show();
        }
    }
}
