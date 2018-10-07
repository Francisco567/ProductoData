namespace CapaPresentacion
{
    partial class FrmRegistroGerente
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroGerente));
            this.pnlRegistroGerente = new System.Windows.Forms.Panel();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtRegistrarNegocio = new System.Windows.Forms.Button();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lbRegistrarNegocio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNegocio = new System.Windows.Forms.TextBox();
            this.lbRegistroPersonal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.txtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape10 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape9 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape8 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape7 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnRegresar = new System.Windows.Forms.PictureBox();
            this.ToolRegresar = new System.Windows.Forms.ToolTip(this.components);
            this.pnlRegistroGerente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegresar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRegistroGerente
            // 
            this.pnlRegistroGerente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.pnlRegistroGerente.Controls.Add(this.btnRegresar);
            this.pnlRegistroGerente.Controls.Add(this.txtUsuario);
            this.pnlRegistroGerente.Controls.Add(this.txtRegistrarNegocio);
            this.pnlRegistroGerente.Controls.Add(this.txtContraseña);
            this.pnlRegistroGerente.Controls.Add(this.lbRegistrarNegocio);
            this.pnlRegistroGerente.Controls.Add(this.label3);
            this.pnlRegistroGerente.Controls.Add(this.txtNegocio);
            this.pnlRegistroGerente.Controls.Add(this.lbRegistroPersonal);
            this.pnlRegistroGerente.Controls.Add(this.label1);
            this.pnlRegistroGerente.Controls.Add(this.btnGuardar);
            this.pnlRegistroGerente.Controls.Add(this.txtCorreo);
            this.pnlRegistroGerente.Controls.Add(this.txtTelefono);
            this.pnlRegistroGerente.Controls.Add(this.txtDireccion);
            this.pnlRegistroGerente.Controls.Add(this.cmbSexo);
            this.pnlRegistroGerente.Controls.Add(this.txtNombre);
            this.pnlRegistroGerente.Controls.Add(this.txtApellidoPaterno);
            this.pnlRegistroGerente.Controls.Add(this.txtApellidoMaterno);
            this.pnlRegistroGerente.Controls.Add(this.txtDNI);
            this.pnlRegistroGerente.Controls.Add(this.lbTitulo);
            this.pnlRegistroGerente.Controls.Add(this.shapeContainer1);
            this.pnlRegistroGerente.Location = new System.Drawing.Point(3, 2);
            this.pnlRegistroGerente.Name = "pnlRegistroGerente";
            this.pnlRegistroGerente.Size = new System.Drawing.Size(953, 521);
            this.pnlRegistroGerente.TabIndex = 0;
            this.pnlRegistroGerente.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.pnlRegistroGerente.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtUsuario.Location = new System.Drawing.Point(263, 362);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(203, 24);
            this.txtUsuario.TabIndex = 24;
            this.txtUsuario.Text = "Nombre de Usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // txtRegistrarNegocio
            // 
            this.txtRegistrarNegocio.BackColor = System.Drawing.Color.Yellow;
            this.txtRegistrarNegocio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRegistrarNegocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtRegistrarNegocio.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistrarNegocio.ForeColor = System.Drawing.Color.Black;
            this.txtRegistrarNegocio.Location = new System.Drawing.Point(38, 442);
            this.txtRegistrarNegocio.Name = "txtRegistrarNegocio";
            this.txtRegistrarNegocio.Size = new System.Drawing.Size(157, 34);
            this.txtRegistrarNegocio.TabIndex = 23;
            this.txtRegistrarNegocio.Text = "Registrarse";
            this.txtRegistrarNegocio.UseVisualStyleBackColor = false;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtContraseña.Location = new System.Drawing.Point(506, 362);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(235, 24);
            this.txtContraseña.TabIndex = 22;
            this.txtContraseña.Text = "Ingrese una Contraseña";
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // lbRegistrarNegocio
            // 
            this.lbRegistrarNegocio.AutoSize = true;
            this.lbRegistrarNegocio.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistrarNegocio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lbRegistrarNegocio.Location = new System.Drawing.Point(56, 316);
            this.lbRegistrarNegocio.Name = "lbRegistrarNegocio";
            this.lbRegistrarNegocio.Size = new System.Drawing.Size(189, 23);
            this.lbRegistrarNegocio.TabIndex = 20;
            this.lbRegistrarNegocio.Text = "Datos de su Cuenta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Britannic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(0)))), ((int)(((byte)(125)))));
            this.label3.Location = new System.Drawing.Point(31, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 41);
            this.label3.TabIndex = 19;
            this.label3.Text = "*";
            // 
            // txtNegocio
            // 
            this.txtNegocio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtNegocio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNegocio.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNegocio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtNegocio.Location = new System.Drawing.Point(28, 362);
            this.txtNegocio.Name = "txtNegocio";
            this.txtNegocio.Size = new System.Drawing.Size(211, 24);
            this.txtNegocio.TabIndex = 18;
            this.txtNegocio.Text = "Nombre de Tu Negocio";
            this.txtNegocio.Enter += new System.EventHandler(this.txtNegocio_Enter);
            this.txtNegocio.Leave += new System.EventHandler(this.txtNegocio_Leave);
            // 
            // lbRegistroPersonal
            // 
            this.lbRegistroPersonal.AutoSize = true;
            this.lbRegistroPersonal.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRegistroPersonal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lbRegistroPersonal.Location = new System.Drawing.Point(56, 73);
            this.lbRegistroPersonal.Name = "lbRegistroPersonal";
            this.lbRegistroPersonal.Size = new System.Drawing.Size(171, 23);
            this.lbRegistroPersonal.TabIndex = 17;
            this.lbRegistroPersonal.Text = "Datos Personales";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(0)))), ((int)(((byte)(125)))));
            this.label1.Location = new System.Drawing.Point(31, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 41);
            this.label1.TabIndex = 16;
            this.label1.Text = "*";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Yellow;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(38, 265);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(157, 34);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // txtCorreo
            // 
            this.txtCorreo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreo.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtCorreo.Location = new System.Drawing.Point(695, 202);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(184, 24);
            this.txtCorreo.TabIndex = 14;
            this.txtCorreo.Text = "Correo Electrónico";
            this.txtCorreo.Enter += new System.EventHandler(this.txtCorreo_Enter);
            this.txtCorreo.Leave += new System.EventHandler(this.txtCorreo_Leave);
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTelefono.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtTelefono.Location = new System.Drawing.Point(28, 202);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(179, 24);
            this.txtTelefono.TabIndex = 13;
            this.txtTelefono.Text = "Teléfono / Celular";
            this.txtTelefono.Enter += new System.EventHandler(this.txtTelefono_Enter);
            this.txtTelefono.Leave += new System.EventHandler(this.txtTelefono_Leave);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtDireccion.Location = new System.Drawing.Point(475, 202);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(162, 24);
            this.txtDireccion.TabIndex = 12;
            this.txtDireccion.Text = "Dirección";
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            this.txtDireccion.Enter += new System.EventHandler(this.txtDireccion_Enter);
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            // 
            // cmbSexo
            // 
            this.cmbSexo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.cmbSexo.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSexo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "Masculino",
            "Femenino"});
            this.cmbSexo.Location = new System.Drawing.Point(283, 201);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(121, 25);
            this.cmbSexo.TabIndex = 11;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombre.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtNombre.Location = new System.Drawing.Point(38, 123);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(162, 24);
            this.txtNombre.TabIndex = 10;
            this.txtNombre.Text = "Nombre";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtApellidoPaterno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellidoPaterno.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoPaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtApellidoPaterno.Location = new System.Drawing.Point(475, 123);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(162, 24);
            this.txtApellidoPaterno.TabIndex = 9;
            this.txtApellidoPaterno.Text = "Apellido Paterno";
            this.txtApellidoPaterno.Enter += new System.EventHandler(this.txtApellidoPaterno_Enter);
            this.txtApellidoPaterno.Leave += new System.EventHandler(this.txtApellidoPaterno_Leave);
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtApellidoMaterno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApellidoMaterno.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoMaterno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtApellidoMaterno.Location = new System.Drawing.Point(267, 123);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(162, 24);
            this.txtApellidoMaterno.TabIndex = 8;
            this.txtApellidoMaterno.Text = "Apellido Materno";
            this.txtApellidoMaterno.Enter += new System.EventHandler(this.txtApellidoMaterno_Enter);
            this.txtApellidoMaterno.Leave += new System.EventHandler(this.txtApellidoMaterno_Leave);
            // 
            // txtDNI
            // 
            this.txtDNI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(70)))));
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDNI.Font = new System.Drawing.Font("Britannic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.txtDNI.Location = new System.Drawing.Point(695, 123);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(162, 24);
            this.txtDNI.TabIndex = 1;
            this.txtDNI.Text = "Numero de DNI";
            this.txtDNI.Enter += new System.EventHandler(this.txtDNI_Enter);
            this.txtDNI.Leave += new System.EventHandler(this.txtDNI_Leave);
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Britannic Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lbTitulo.Location = new System.Drawing.Point(294, 7);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(327, 38);
            this.lbTitulo.TabIndex = 0;
            this.lbTitulo.Text = "Registra Tu Negocio";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape10,
            this.lineShape9,
            this.lineShape8,
            this.lineShape7,
            this.lineShape6,
            this.lineShape5,
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(953, 521);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape10
            // 
            this.lineShape10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape10.Enabled = false;
            this.lineShape10.Name = "lineShape10";
            this.lineShape10.X1 = 506;
            this.lineShape10.X2 = 735;
            this.lineShape10.Y1 = 397;
            this.lineShape10.Y2 = 397;
            // 
            // lineShape9
            // 
            this.lineShape9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape9.Enabled = false;
            this.lineShape9.Name = "lineShape9";
            this.lineShape9.X1 = 263;
            this.lineShape9.X2 = 465;
            this.lineShape9.Y1 = 396;
            this.lineShape9.Y2 = 397;
            // 
            // lineShape8
            // 
            this.lineShape8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape8.Enabled = false;
            this.lineShape8.Name = "lineShape8";
            this.lineShape8.X1 = 28;
            this.lineShape8.X2 = 230;
            this.lineShape8.Y1 = 395;
            this.lineShape8.Y2 = 396;
            // 
            // lineShape7
            // 
            this.lineShape7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape7.Enabled = false;
            this.lineShape7.Name = "lineShape7";
            this.lineShape7.X1 = 696;
            this.lineShape7.X2 = 880;
            this.lineShape7.Y1 = 233;
            this.lineShape7.Y2 = 233;
            // 
            // lineShape6
            // 
            this.lineShape6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape6.Enabled = false;
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 698;
            this.lineShape6.X2 = 859;
            this.lineShape6.Y1 = 158;
            this.lineShape6.Y2 = 159;
            // 
            // lineShape5
            // 
            this.lineShape5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape5.Enabled = false;
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 470;
            this.lineShape5.X2 = 629;
            this.lineShape5.Y1 = 162;
            this.lineShape5.Y2 = 162;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape4.Enabled = false;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 475;
            this.lineShape4.X2 = 630;
            this.lineShape4.Y1 = 231;
            this.lineShape4.Y2 = 230;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape3.Enabled = false;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 265;
            this.lineShape3.X2 = 424;
            this.lineShape3.Y1 = 159;
            this.lineShape3.Y2 = 159;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape2.Enabled = false;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 35;
            this.lineShape2.X2 = 194;
            this.lineShape2.Y1 = 230;
            this.lineShape2.Y2 = 230;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.lineShape1.Enabled = false;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 36;
            this.lineShape1.X2 = 195;
            this.lineShape1.Y1 = 159;
            this.lineShape1.Y2 = 159;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegresar.Image")));
            this.btnRegresar.Location = new System.Drawing.Point(3, 10);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(47, 38);
            this.btnRegresar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRegresar.TabIndex = 25;
            this.btnRegresar.TabStop = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // ToolRegresar
            // 
            this.ToolRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ToolRegresar.ForeColor = System.Drawing.Color.White;
            this.ToolRegresar.ToolTipTitle = "Regresar";
            // 
            // FrmRegistroGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(959, 526);
            this.Controls.Add(this.pnlRegistroGerente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegistroGerente";
            this.Text = "FrmRegistrarAdmin";
            this.Load += new System.EventHandler(this.FrmRegistroGerente_Load);
            this.pnlRegistroGerente.ResumeLayout(false);
            this.pnlRegistroGerente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegresar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRegistroGerente;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.TextBox txtDNI;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidoPaterno;
        private System.Windows.Forms.TextBox txtApellidoMaterno;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.TextBox txtDireccion;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape7;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lbRegistrarNegocio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNegocio;
        private System.Windows.Forms.Label lbRegistroPersonal;
        private System.Windows.Forms.Label label1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape8;
        private System.Windows.Forms.Button txtRegistrarNegocio;
        private System.Windows.Forms.TextBox txtContraseña;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape10;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape9;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox btnRegresar;
        private System.Windows.Forms.ToolTip ToolRegresar;
    }
}