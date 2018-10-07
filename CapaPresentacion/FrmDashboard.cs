using CapaDominio;
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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        Gerente gerenteCD = new Gerente();
        

        private void Cambiar_Text(object sender, PaintEventArgs e)
        {
            lbUserName.Text = gerenteCD.GerenteUser;
        }

        //Mover formulario
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);
        

        private void pnlMenuLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDashboard_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Variables para controlar el tamaño del formulario
        int Lx, Ly;

        

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            //maximizar sin tapar barra de tareas
            Lx = this.Location.X;
            Ly = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (pnlMenuLateral.Width == 238)
            {
                pnlMenuLateral.Width = 80;
            }
            else
            {
                pnlMenuLateral.Width = 238;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1120, 570);//Tamaño al que se regresa al presionar el boton restaurar
            this.Location = new Point(Lx, Ly);
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        //abrir formulario dentro de panel
        private void AbrirFormPanel(object Formhijo)
        {
            if (this.pnlContenedor.Controls.Count > 0)
                this.pnlContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlContenedor.Controls.Add(fh);
            this.pnlContenedor.Tag = fh;
            fh.Show();
        }

        

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new FrmProductos());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLoginGerente FLog = new FrmLoginGerente();
            FLog.Show();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new FrmProveedores());
            
        }

        private void pnlContenedor_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            AbrirFormPanel(new FrmProductos());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new FrmReportes());
        }

    }
}
