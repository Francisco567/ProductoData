using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaAplicacion;
using System.Data.SqlClient;
using CapaDominio;

namespace CapaPresentacion
{
    public partial class FrmLoginGerente : Form
    {
        public FrmLoginGerente()
        {
            InitializeComponent();
        }

        //Mover formulario
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam,int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LimeGreen;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.LimeGreen;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LimeGreen;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private  void txtContraseña_leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.LimeGreen;
                txtContraseña.UseSystemPasswordChar =  false;

            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            LoginGerenteServicio LGerenteCA = new LoginGerenteServicio();//CapaAplicacion
            Gerente gerente = new Gerente();//CapaDominio

            SqlDataReader Login;
            gerente.GerenteUser = txtUsuario.Text;//asignamos el valor a la Variable usuario
            gerente.GerentePassword = txtContraseña.Text;
            Login = LGerenteCA.InisiarSesion(gerente);//hacemos una referencia a su funcion en la capa de Aplicacion

            if (Login.Read() == true)
            {
                this.Hide();
                FrmDashboard FDash = new FrmDashboard();
                FDash.Show();
            }
            else
            {
                MessageBox.Show("Ingresa los datos correctos", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

      /* private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmLogin
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);

        }*/

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegistroGerente FDash = new FrmRegistroGerente();
            FDash.Show();
        }
    }
}
