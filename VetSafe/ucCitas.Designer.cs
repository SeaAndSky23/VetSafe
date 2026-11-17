namespace VetSafe
{
    partial class ucCitas
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelForm = new Panel();
            lblCliente = new Label();
            cboCliente = new ComboBox();
            lblMascota = new Label();
            cboMascota = new ComboBox();
            lblVeterinario = new Label();
            cboVeterinario = new ComboBox();
            lblServicio = new Label();
            cboServicio = new ComboBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblHora = new Label();
            dtpHora = new DateTimePicker();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            lblEstado = new Label();
            cboEstado = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnCancelarCita = new Button();
            panelFiltro = new Panel();
            lblFiltroFecha = new Label();
            dtpFiltro = new DateTimePicker();
            chkTodas = new CheckBox();
            lblFiltroEstado = new Label();
            cboFiltroEstado = new ComboBox();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvCitas = new DataGridView();
            panelForm.SuspendLayout();
            panelFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.Location = new Point(17, 21);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(179, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTIÓN DE CITAS";
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.WhiteSmoke;
            panelForm.Controls.Add(lblCliente);
            panelForm.Controls.Add(cboCliente);
            panelForm.Controls.Add(lblMascota);
            panelForm.Controls.Add(cboMascota);
            panelForm.Controls.Add(lblVeterinario);
            panelForm.Controls.Add(cboVeterinario);
            panelForm.Controls.Add(lblServicio);
            panelForm.Controls.Add(cboServicio);
            panelForm.Controls.Add(lblFecha);
            panelForm.Controls.Add(dtpFecha);
            panelForm.Controls.Add(lblHora);
            panelForm.Controls.Add(dtpHora);
            panelForm.Controls.Add(lblMotivo);
            panelForm.Controls.Add(txtMotivo);
            panelForm.Controls.Add(lblEstado);
            panelForm.Controls.Add(cboEstado);
            panelForm.Controls.Add(btnNuevo);
            panelForm.Controls.Add(btnGuardar);
            panelForm.Controls.Add(btnCancelarCita);
            panelForm.Location = new Point(20, 60);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(711, 220);
            panelForm.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCliente.Location = new Point(15, 19);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(50, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // cboCliente
            // 
            cboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCliente.Location = new Point(95, 15);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(250, 23);
            cboCliente.TabIndex = 1;
            // 
            // lblMascota
            // 
            lblMascota.AutoSize = true;
            lblMascota.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMascota.Location = new Point(15, 59);
            lblMascota.Name = "lblMascota";
            lblMascota.Size = new Size(58, 15);
            lblMascota.TabIndex = 2;
            lblMascota.Text = "Mascota:";
            // 
            // cboMascota
            // 
            cboMascota.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMascota.Location = new Point(95, 55);
            cboMascota.Name = "cboMascota";
            cboMascota.Size = new Size(250, 23);
            cboMascota.TabIndex = 2;
            // 
            // lblVeterinario
            // 
            lblVeterinario.AutoSize = true;
            lblVeterinario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVeterinario.Location = new Point(365, 19);
            lblVeterinario.Name = "lblVeterinario";
            lblVeterinario.Size = new Size(74, 15);
            lblVeterinario.TabIndex = 4;
            lblVeterinario.Text = "Veterinario:";
            // 
            // cboVeterinario
            // 
            cboVeterinario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVeterinario.Location = new Point(450, 15);
            cboVeterinario.Name = "cboVeterinario";
            cboVeterinario.Size = new Size(240, 23);
            cboVeterinario.TabIndex = 3;
            // 
            // lblServicio
            // 
            lblServicio.AutoSize = true;
            lblServicio.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblServicio.Location = new Point(365, 59);
            lblServicio.Name = "lblServicio";
            lblServicio.Size = new Size(54, 15);
            lblServicio.TabIndex = 6;
            lblServicio.Text = "Servicio:";
            // 
            // cboServicio
            // 
            cboServicio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboServicio.Location = new Point(450, 55);
            cboServicio.Name = "cboServicio";
            cboServicio.Size = new Size(240, 23);
            cboServicio.TabIndex = 4;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(15, 99);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(42, 15);
            lblFecha.TabIndex = 8;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(95, 95);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(150, 23);
            dtpFecha.TabIndex = 5;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHora.Location = new Point(365, 99);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(37, 15);
            lblHora.TabIndex = 10;
            lblHora.Text = "Hora:";
            // 
            // dtpHora
            // 
            dtpHora.CustomFormat = "HH:mm";
            dtpHora.Format = DateTimePickerFormat.Custom;
            dtpHora.Location = new Point(450, 95);
            dtpHora.Name = "dtpHora";
            dtpHora.ShowUpDown = true;
            dtpHora.Size = new Size(100, 23);
            dtpHora.TabIndex = 6;
            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMotivo.Location = new Point(15, 139);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new Size(49, 15);
            lblMotivo.TabIndex = 12;
            lblMotivo.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            txtMotivo.Location = new Point(95, 135);
            txtMotivo.MaxLength = 200;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.Size = new Size(595, 23);
            txtMotivo.TabIndex = 7;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.Location = new Point(15, 179);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(46, 15);
            lblEstado.TabIndex = 14;
            lblEstado.Text = "Estado:";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Location = new Point(95, 175);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(150, 23);
            cboEstado.TabIndex = 8;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(6, 108, 129);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(300, 172);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 32);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(6, 108, 129);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(400, 172);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 32);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelarCita
            // 
            btnCancelarCita.BackColor = Color.FromArgb(192, 57, 43);
            btnCancelarCita.Cursor = Cursors.Hand;
            btnCancelarCita.FlatAppearance.BorderSize = 0;
            btnCancelarCita.FlatStyle = FlatStyle.Flat;
            btnCancelarCita.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancelarCita.ForeColor = Color.White;
            btnCancelarCita.Location = new Point(500, 172);
            btnCancelarCita.Name = "btnCancelarCita";
            btnCancelarCita.Size = new Size(140, 32);
            btnCancelarCita.TabIndex = 11;
            btnCancelarCita.Text = "CANCELAR CITA";
            btnCancelarCita.UseVisualStyleBackColor = false;
            // 
            // panelFiltro
            // 
            panelFiltro.BackColor = Color.WhiteSmoke;
            panelFiltro.Controls.Add(lblFiltroFecha);
            panelFiltro.Controls.Add(dtpFiltro);
            panelFiltro.Controls.Add(chkTodas);
            panelFiltro.Controls.Add(lblFiltroEstado);
            panelFiltro.Controls.Add(cboFiltroEstado);
            panelFiltro.Controls.Add(txtBuscar);
            panelFiltro.Controls.Add(btnBuscar);
            panelFiltro.Location = new Point(20, 295);
            panelFiltro.Name = "panelFiltro";
            panelFiltro.Size = new Size(711, 40);
            panelFiltro.TabIndex = 2;
            // 
            // lblFiltroFecha
            // 
            lblFiltroFecha.AutoSize = true;
            lblFiltroFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiltroFecha.Location = new Point(12, 12);
            lblFiltroFecha.Name = "lblFiltroFecha";
            lblFiltroFecha.Size = new Size(42, 15);
            lblFiltroFecha.TabIndex = 0;
            lblFiltroFecha.Text = "Fecha:";
            // 
            // dtpFiltro
            // 
            dtpFiltro.CustomFormat = "dd/MM/yyyy";
            dtpFiltro.Format = DateTimePickerFormat.Custom;
            dtpFiltro.Location = new Point(58, 8);
            dtpFiltro.Name = "dtpFiltro";
            dtpFiltro.Size = new Size(105, 23);
            dtpFiltro.TabIndex = 0;
            // 
            // chkTodas
            // 
            chkTodas.AutoSize = true;
            chkTodas.Location = new Point(172, 10);
            chkTodas.Name = "chkTodas";
            chkTodas.Size = new Size(60, 19);
            chkTodas.TabIndex = 1;
            chkTodas.Text = "Todas";
            chkTodas.UseVisualStyleBackColor = true;
            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFiltroEstado.Location = new Point(242, 12);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new Size(46, 15);
            lblFiltroEstado.TabIndex = 3;
            lblFiltroEstado.Text = "Estado:";
            // 
            // cboFiltroEstado
            // 
            cboFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroEstado.Location = new Point(292, 8);
            cboFiltroEstado.Name = "cboFiltroEstado";
            cboFiltroEstado.Size = new Size(110, 23);
            cboFiltroEstado.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(412, 8);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Mascota, cliente o DNI";
            txtBuscar.Size = new Size(190, 23);
            txtBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(6, 108, 129);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(610, 6);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(92, 28);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvCitas
            // 
            dgvCitas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCitas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.Location = new Point(20, 345);
            dgvCitas.Name = "dgvCitas";
            dgvCitas.Size = new Size(711, 340);
            dgvCitas.TabIndex = 3;
            // 
            // ucCitas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(dgvCitas);
            Controls.Add(panelFiltro);
            Controls.Add(panelForm);
            Controls.Add(lblTitulo);
            Name = "ucCitas";
            Size = new Size(751, 703);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            panelFiltro.ResumeLayout(false);
            panelFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel panelForm;
        private Label lblCliente;
        private ComboBox cboCliente;
        private Label lblMascota;
        private ComboBox cboMascota;
        private Label lblVeterinario;
        private ComboBox cboVeterinario;
        private Label lblServicio;
        private ComboBox cboServicio;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblHora;
        private DateTimePicker dtpHora;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Label lblEstado;
        private ComboBox cboEstado;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnCancelarCita;
        private Panel panelFiltro;
        private Label lblFiltroFecha;
        private DateTimePicker dtpFiltro;
        private CheckBox chkTodas;
        private Label lblFiltroEstado;
        private ComboBox cboFiltroEstado;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvCitas;
    }
}