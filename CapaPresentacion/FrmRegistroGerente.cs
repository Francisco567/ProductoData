using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmRegistroGerente : Form
    {
        public FrmRegistroGerente()
        {
            InitializeComponent();
        }

        //Mover formulario
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);

        private void lbTitulo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmRegistroGerente_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Nombre")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LimeGreen;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.LimeGreen;
            }
        }

        //siguiente
        private void txtApellidoMaterno_Enter(object sender, EventArgs e)
        {
            if (txtApellidoMaterno.Text == "Apellido Materno")
            {
                txtApellidoMaterno.Text = "";
                txtApellidoMaterno.ForeColor = Color.LimeGreen;
            }
        }

        private void txtApellidoMaterno_Leave(object sender, EventArgs e)
        {
            if (txtApellidoMaterno.Text == "")
            {
                txtApellidoMaterno.Text = "Apellido Materno";
                txtApellidoMaterno.ForeColor = Color.LimeGreen;
            }
        }
        //siguiente
        private void txtApellidoPaterno_Enter(object sender, EventArgs e)
        {
            if (txtApellidoPaterno.Text == "Apellido Paterno")
            {
                txtApellidoPaterno.Text = "";
                txtApellidoPaterno.ForeColor = Color.LimeGreen;
            }
        }

        private void txtApellidoPaterno_Leave(object sender, EventArgs e)
        {
            if (txtApellidoPaterno.Text == "")
            {
                txtApellidoPaterno.Text = "Apellido Paterno";
                txtApellidoPaterno.ForeColor = Color.LimeGreen;
            }
        }
        //siguiente
        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "Numero de DNI")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.LimeGreen;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                txtDNI.Text = "Numero de DNI";
                txtDNI.ForeColor = Color.LimeGreen;
            }
        }
        //siguiente
        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Teléfono / Celular")
            {
                txtTelefono.Text = "";
                txtTelefono.ForeColor = Color.LimeGreen;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "Teléfono / Celular";
                txtTelefono.ForeColor = Color.LimeGreen;
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }
        //siguiente
        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Dirección")
            {
                txtDireccion.Text = "";
                txtDireccion.ForeColor = Color.LimeGreen;
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "Dirección";
                txtDireccion.ForeColor = Color.LimeGreen;
            }
        }
        //siguiente
        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo Electrónico")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.LimeGreen;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Correo Electrónico";
                txtCorreo.ForeColor = Color.LimeGreen;
            }
        }
        //siguiente
        private void txtNegocio_Enter(object sender, EventArgs e)
        {
            if (txtNegocio.Text == "Nombre de Tu Negocio")
            {
                txtNegocio.Text = "";
                txtNegocio.ForeColor = Color.LimeGreen;
            }
        }

        private void txtNegocio_Leave(object sender, EventArgs e)
        {
            if (txtNegocio.Text == "")
            {
                txtNegocio.Text = "Nombre de Tu Negocio";
                txtNegocio.ForeColor = Color.LimeGreen;
            }
        }
        //siguiente
        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }
        //siguiente
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Nombre de Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LimeGreen;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Nombre de Usuario";
                txtUsuario.ForeColor = Color.LimeGreen;
            }
        }
        //siguiente
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Ingrese una Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LimeGreen;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Ingrese una Contraseña";
                txtContraseña.ForeColor = Color.LimeGreen;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoginGerente FDash = new FrmLoginGerente();
            FDash.Show();
        }
    }
}
