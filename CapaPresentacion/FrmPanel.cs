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
    public partial class FrmPanel : Form
    {
        public FrmPanel()
        {
            InitializeComponent();
        }

        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int lparam);


        private void FrmPanel_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSlide_Click1(object sender, EventArgs e)
        {
            if (pnlMenuVertical.Width == 231)
            {
                pnlMenuVertical.Width = 70;
            }
            else
            {
                pnlMenuVertical.Width =231;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int Lx, Ly;

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            //maximizar sin tapar barra de tareas
            Lx = this.Location.X;
            Ly = this.Location.Y;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnRestarurar.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnRestarurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1120, 570);
            this.Location = new Point(Lx, Ly);
            btnRestarurar.Visible = false;
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

        private void pnlContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        //abrir el formulario con el evento click en el boton Producto
        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormPanel(new FrmProductos());
        }
    }
}
