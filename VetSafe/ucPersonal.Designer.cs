namespace VetSafe
{
    partial class ucPersonal
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPersonal = new TabControl();
            tabTrabajadores = new TabPage();
            dgvTrab = new DataGridView();
            pnlTrab = new Panel();
            btnBajaTrab = new Button();
            btnGuardarTrab = new Button();
            btnNuevoTrab = new Button();
            chkEstadoTrab = new CheckBox();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtApMat = new TextBox();
            lblApMat = new Label();
            txtApPat = new TextBox();
            lblApPat = new Label();
            txtNombres = new TextBox();
            lblNombres = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            tabUsuarios = new TabPage();
            dgvUsu = new DataGridView();
            pnlUsu = new Panel();
            btnBajaUsu = new Button();
            btnGuardarUsu = new Button();
            btnNuevoUsu = new Button();
            chkEstadoUsu = new CheckBox();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            cboRol = new ComboBox();
            lblRol = new Label();
            cboTrabajador = new ComboBox();
            lblTrabajador = new Label();
            tabPersonal.SuspendLayout();
            tabTrabajadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTrab).BeginInit();
            pnlTrab.SuspendLayout();
            tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsu).BeginInit();
            pnlUsu.SuspendLayout();
            SuspendLayout();
            // 
            // tabPersonal
            // 
            tabPersonal.Controls.Add(tabTrabajadores);
            tabPersonal.Controls.Add(tabUsuarios);
            tabPersonal.Dock = DockStyle.Fill;
            tabPersonal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabPersonal.Location = new Point(0, 0);
            tabPersonal.Name = "tabPersonal";
            tabPersonal.SelectedIndex = 0;
            tabPersonal.Size = new Size(751, 703);
            tabPersonal.TabIndex = 0;
            tabPersonal.SelectedIndexChanged += tabPersonal_SelectedIndexChanged;
            // 
            // tabTrabajadores
            // 
            tabTrabajadores.Controls.Add(dgvTrab);
            tabTrabajadores.Controls.Add(pnlTrab);
            tabTrabajadores.Location = new Point(4, 32);
            tabTrabajadores.Name = "tabTrabajadores";
            tabTrabajadores.Size = new Size(743, 667);
            tabTrabajadores.TabIndex = 0;
            tabTrabajadores.Text = "Trabajadores";
            // 
            // dgvTrab
            // 
            dgvTrab.AllowUserToAddRows = false;
            dgvTrab.AllowUserToDeleteRows = false;
            dgvTrab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTrab.BackgroundColor = Color.White;
            dgvTrab.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrab.Dock = DockStyle.Fill;
            dgvTrab.Font = new Font("Segoe UI", 9F);
            dgvTrab.Location = new Point(0, 190);
            dgvTrab.MultiSelect = false;
            dgvTrab.Name = "dgvTrab";
            dgvTrab.ReadOnly = true;
            dgvTrab.RowHeadersVisible = false;
            dgvTrab.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrab.Size = new Size(743, 477);
            dgvTrab.TabIndex = 1;
            dgvTrab.CellClick += dgvTrab_CellClick;
            // 
            // pnlTrab
            // 
            pnlTrab.BackColor = Color.White;
            pnlTrab.Controls.Add(btnBajaTrab);
            pnlTrab.Controls.Add(btnGuardarTrab);
            pnlTrab.Controls.Add(btnNuevoTrab);
            pnlTrab.Controls.Add(chkEstadoTrab);
            pnlTrab.Controls.Add(txtDireccion);
            pnlTrab.Controls.Add(lblDireccion);
            pnlTrab.Controls.Add(txtTelefono);
            pnlTrab.Controls.Add(lblTelefono);
            pnlTrab.Controls.Add(txtApMat);
            pnlTrab.Controls.Add(lblApMat);
            pnlTrab.Controls.Add(txtApPat);
            pnlTrab.Controls.Add(lblApPat);
            pnlTrab.Controls.Add(txtNombres);
            pnlTrab.Controls.Add(lblNombres);
            pnlTrab.Controls.Add(txtDni);
            pnlTrab.Controls.Add(lblDni);
            pnlTrab.Dock = DockStyle.Top;
            pnlTrab.Location = new Point(0, 0);
            pnlTrab.Name = "pnlTrab";
            pnlTrab.Size = new Size(743, 190);
            pnlTrab.TabIndex = 0;
            // 
            // btnBajaTrab
            // 
            btnBajaTrab.BackColor = Color.FromArgb(6, 108, 129);
            btnBajaTrab.Cursor = Cursors.Hand;
            btnBajaTrab.FlatStyle = FlatStyle.Flat;
            btnBajaTrab.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnBajaTrab.ForeColor = Color.White;
            btnBajaTrab.Location = new Point(235, 140);
            btnBajaTrab.Name = "btnBajaTrab";
            btnBajaTrab.Size = new Size(100, 35);
            btnBajaTrab.TabIndex = 9;
            btnBajaTrab.Text = "DAR DE BAJA";
            btnBajaTrab.UseVisualStyleBackColor = false;
            btnBajaTrab.Click += btnBajaTrab_Click;
            // 
            // btnGuardarTrab
            // 
            btnGuardarTrab.BackColor = Color.FromArgb(6, 108, 129);
            btnGuardarTrab.Cursor = Cursors.Hand;
            btnGuardarTrab.FlatStyle = FlatStyle.Flat;
            btnGuardarTrab.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGuardarTrab.ForeColor = Color.White;
            btnGuardarTrab.Location = new Point(125, 140);
            btnGuardarTrab.Name = "btnGuardarTrab";
            btnGuardarTrab.Size = new Size(100, 35);
            btnGuardarTrab.TabIndex = 8;
            btnGuardarTrab.Text = "GUARDAR";
            btnGuardarTrab.UseVisualStyleBackColor = false;
            btnGuardarTrab.Click += btnGuardarTrab_Click;
            // 
            // btnNuevoTrab
            // 
            btnNuevoTrab.BackColor = Color.FromArgb(6, 108, 129);
            btnNuevoTrab.Cursor = Cursors.Hand;
            btnNuevoTrab.FlatStyle = FlatStyle.Flat;
            btnNuevoTrab.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnNuevoTrab.ForeColor = Color.White;
            btnNuevoTrab.Location = new Point(15, 140);
            btnNuevoTrab.Name = "btnNuevoTrab";
            btnNuevoTrab.Size = new Size(100, 35);
            btnNuevoTrab.TabIndex = 7;
            btnNuevoTrab.Text = "NUEVO";
            btnNuevoTrab.UseVisualStyleBackColor = false;
            btnNuevoTrab.Click += btnNuevoTrab_Click;
            // 
            // chkEstadoTrab
            // 
            chkEstadoTrab.AutoSize = true;
            chkEstadoTrab.Checked = true;
            chkEstadoTrab.CheckState = CheckState.Checked;
            chkEstadoTrab.Font = new Font("Segoe UI", 9F);
            chkEstadoTrab.Location = new Point(565, 98);
            chkEstadoTrab.Name = "chkEstadoTrab";
            chkEstadoTrab.Size = new Size(60, 19);
            chkEstadoTrab.TabIndex = 6;
            chkEstadoTrab.Text = "Activo";
            chkEstadoTrab.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 10F);
            txtDireccion.Location = new Point(165, 97);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(380, 25);
            txtDireccion.TabIndex = 5;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDireccion.Location = new Point(165, 75);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(61, 15);
            lblDireccion.TabIndex = 0;
            lblDireccion.Text = "Dirección";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 10F);
            txtTelefono.Location = new Point(15, 97);
            txtTelefono.MaxLength = 9;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(130, 25);
            txtTelefono.TabIndex = 4;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.Location = new Point(15, 75);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(56, 15);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono";
            // 
            // txtApMat
            // 
            txtApMat.Font = new Font("Segoe UI", 10F);
            txtApMat.Location = new Point(565, 37);
            txtApMat.MaxLength = 60;
            txtApMat.Name = "txtApMat";
            txtApMat.Size = new Size(160, 25);
            txtApMat.TabIndex = 3;
            // 
            // lblApMat
            // 
            lblApMat.AutoSize = true;
            lblApMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApMat.Location = new Point(565, 15);
            lblApMat.Name = "lblApMat";
            lblApMat.Size = new Size(104, 15);
            lblApMat.TabIndex = 0;
            lblApMat.Text = "Apellido materno";
            // 
            // txtApPat
            // 
            txtApPat.Font = new Font("Segoe UI", 10F);
            txtApPat.Location = new Point(385, 37);
            txtApPat.MaxLength = 60;
            txtApPat.Name = "txtApPat";
            txtApPat.Size = new Size(160, 25);
            txtApPat.TabIndex = 2;
            // 
            // lblApPat
            // 
            lblApPat.AutoSize = true;
            lblApPat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblApPat.Location = new Point(385, 15);
            lblApPat.Name = "lblApPat";
            lblApPat.Size = new Size(101, 15);
            lblApPat.TabIndex = 0;
            lblApPat.Text = "Apellido paterno";
            // 
            // txtNombres
            // 
            txtNombres.Font = new Font("Segoe UI", 10F);
            txtNombres.Location = new Point(165, 37);
            txtNombres.MaxLength = 80;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(200, 25);
            txtNombres.TabIndex = 1;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombres.Location = new Point(165, 15);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(56, 15);
            lblNombres.TabIndex = 0;
            lblNombres.Text = "Nombres";
            // 
            // txtDni
            // 
            txtDni.Font = new Font("Segoe UI", 10F);
            txtDni.Location = new Point(15, 37);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(130, 25);
            txtDni.TabIndex = 0;
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDni.Location = new Point(15, 15);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(30, 15);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI";
            // 
            // tabUsuarios
            // 
            tabUsuarios.Controls.Add(dgvUsu);
            tabUsuarios.Controls.Add(pnlUsu);
            tabUsuarios.Location = new Point(4, 32);
            tabUsuarios.Name = "tabUsuarios";
            tabUsuarios.Size = new Size(743, 667);
            tabUsuarios.TabIndex = 1;
            tabUsuarios.Text = "Usuarios";
            // 
            // dgvUsu
            // 
            dgvUsu.AllowUserToAddRows = false;
            dgvUsu.AllowUserToDeleteRows = false;
            dgvUsu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsu.BackgroundColor = Color.White;
            dgvUsu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsu.Dock = DockStyle.Fill;
            dgvUsu.Font = new Font("Segoe UI", 9F);
            dgvUsu.Location = new Point(0, 190);
            dgvUsu.MultiSelect = false;
            dgvUsu.Name = "dgvUsu";
            dgvUsu.ReadOnly = true;
            dgvUsu.RowHeadersVisible = false;
            dgvUsu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsu.Size = new Size(743, 477);
            dgvUsu.TabIndex = 1;
            dgvUsu.CellClick += dgvUsu_CellClick;
            // 
            // pnlUsu
            // 
            pnlUsu.BackColor = Color.White;
            pnlUsu.Controls.Add(btnBajaUsu);
            pnlUsu.Controls.Add(btnGuardarUsu);
            pnlUsu.Controls.Add(btnNuevoUsu);
            pnlUsu.Controls.Add(chkEstadoUsu);
            pnlUsu.Controls.Add(txtContrasena);
            pnlUsu.Controls.Add(lblContrasena);
            pnlUsu.Controls.Add(txtUsuario);
            pnlUsu.Controls.Add(lblUsuario);
            pnlUsu.Controls.Add(cboRol);
            pnlUsu.Controls.Add(lblRol);
            pnlUsu.Controls.Add(cboTrabajador);
            pnlUsu.Controls.Add(lblTrabajador);
            pnlUsu.Dock = DockStyle.Top;
            pnlUsu.Location = new Point(0, 0);
            pnlUsu.Name = "pnlUsu";
            pnlUsu.Size = new Size(743, 190);
            pnlUsu.TabIndex = 0;
            // 
            // btnBajaUsu
            // 
            btnBajaUsu.BackColor = Color.FromArgb(6, 108, 129);
            btnBajaUsu.Cursor = Cursors.Hand;
            btnBajaUsu.FlatStyle = FlatStyle.Flat;
            btnBajaUsu.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnBajaUsu.ForeColor = Color.White;
            btnBajaUsu.Location = new Point(235, 140);
            btnBajaUsu.Name = "btnBajaUsu";
            btnBajaUsu.Size = new Size(100, 35);
            btnBajaUsu.TabIndex = 6;
            btnBajaUsu.Text = "DESACTIVAR";
            btnBajaUsu.UseVisualStyleBackColor = false;
            btnBajaUsu.Click += btnBajaUsu_Click;
            // 
            // btnGuardarUsu
            // 
            btnGuardarUsu.BackColor = Color.FromArgb(6, 108, 129);
            btnGuardarUsu.Cursor = Cursors.Hand;
            btnGuardarUsu.FlatStyle = FlatStyle.Flat;
            btnGuardarUsu.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnGuardarUsu.ForeColor = Color.White;
            btnGuardarUsu.Location = new Point(125, 140);
            btnGuardarUsu.Name = "btnGuardarUsu";
            btnGuardarUsu.Size = new Size(100, 35);
            btnGuardarUsu.TabIndex = 5;
            btnGuardarUsu.Text = "GUARDAR";
            btnGuardarUsu.UseVisualStyleBackColor = false;
            btnGuardarUsu.Click += btnGuardarUsu_Click;
            // 
            // btnNuevoUsu
            // 
            btnNuevoUsu.BackColor = Color.FromArgb(6, 108, 129);
            btnNuevoUsu.Cursor = Cursors.Hand;
            btnNuevoUsu.FlatStyle = FlatStyle.Flat;
            btnNuevoUsu.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnNuevoUsu.ForeColor = Color.White;
            btnNuevoUsu.Location = new Point(15, 140);
            btnNuevoUsu.Name = "btnNuevoUsu";
            btnNuevoUsu.Size = new Size(100, 35);
            btnNuevoUsu.TabIndex = 4;
            btnNuevoUsu.Text = "NUEVO";
            btnNuevoUsu.UseVisualStyleBackColor = false;
            btnNuevoUsu.Click += btnNuevoUsu_Click;
            // 
            // chkEstadoUsu
            // 
            chkEstadoUsu.AutoSize = true;
            chkEstadoUsu.Checked = true;
            chkEstadoUsu.CheckState = CheckState.Checked;
            chkEstadoUsu.Font = new Font("Segoe UI", 9F);
            chkEstadoUsu.Location = new Point(565, 98);
            chkEstadoUsu.Name = "chkEstadoUsu";
            chkEstadoUsu.Size = new Size(60, 19);
            chkEstadoUsu.TabIndex = 3;
            chkEstadoUsu.Text = "Activo";
            chkEstadoUsu.UseVisualStyleBackColor = true;
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 10F);
            txtContrasena.Location = new Point(235, 97);
            txtContrasena.MaxLength = 30;
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(310, 25);
            txtContrasena.TabIndex = 2;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContrasena.Location = new Point(235, 75);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(191, 15);
            lblContrasena.TabIndex = 0;
            lblContrasena.Text = "Contraseña (vacía = no cambiar)";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 10F);
            txtUsuario.Location = new Point(15, 97);
            txtUsuario.MaxLength = 40;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(200, 25);
            txtUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.Location = new Point(15, 75);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario";
            // 
            // cboRol
            // 
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.Font = new Font("Segoe UI", 10F);
            cboRol.FormattingEnabled = true;
            cboRol.Location = new Point(365, 37);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(180, 25);
            cboRol.TabIndex = 0;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRol.Location = new Point(365, 15);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(26, 15);
            lblRol.TabIndex = 0;
            lblRol.Text = "Rol";
            // 
            // cboTrabajador
            // 
            cboTrabajador.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTrabajador.Font = new Font("Segoe UI", 10F);
            cboTrabajador.FormattingEnabled = true;
            cboTrabajador.Location = new Point(15, 37);
            cboTrabajador.Name = "cboTrabajador";
            cboTrabajador.Size = new Size(330, 25);
            cboTrabajador.TabIndex = 0;
            // 
            // lblTrabajador
            // 
            lblTrabajador.AutoSize = true;
            lblTrabajador.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTrabajador.Location = new Point(15, 15);
            lblTrabajador.Name = "lblTrabajador";
            lblTrabajador.Size = new Size(66, 15);
            lblTrabajador.TabIndex = 0;
            lblTrabajador.Text = "Trabajador";
            // 
            // ucPersonal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(tabPersonal);
            Name = "ucPersonal";
            Size = new Size(751, 703);
            Load += ucPersonal_Load;
            tabPersonal.ResumeLayout(false);
            tabTrabajadores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTrab).EndInit();
            pnlTrab.ResumeLayout(false);
            pnlTrab.PerformLayout();
            tabUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsu).EndInit();
            pnlUsu.ResumeLayout(false);
            pnlUsu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabPersonal;
        private TabPage tabTrabajadores;
        private TabPage tabUsuarios;

        // ---- Trabajadores ----
        private Panel pnlTrab;
        private DataGridView dgvTrab;
        private Label lblDni;
        private Label lblNombres;
        private Label lblApPat;
        private Label lblApMat;
        private Label lblTelefono;
        private Label lblDireccion;
        private TextBox txtDni;
        private TextBox txtNombres;
        private TextBox txtApPat;
        private TextBox txtApMat;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private CheckBox chkEstadoTrab;
        private Button btnNuevoTrab;
        private Button btnGuardarTrab;
        private Button btnBajaTrab;

        // ---- Usuarios ----
        private Panel pnlUsu;
        private DataGridView dgvUsu;
        private Label lblTrabajador;
        private Label lblRol;
        private Label lblUsuario;
        private Label lblContrasena;
        private ComboBox cboTrabajador;
        private ComboBox cboRol;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private CheckBox chkEstadoUsu;
        private Button btnNuevoUsu;
        private Button btnGuardarUsu;
        private Button btnBajaUsu;
    }
}