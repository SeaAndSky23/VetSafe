namespace VetSafe
{
    partial class ucClientes
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle estiloEncabezado = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloFilas = new DataGridViewCellStyle();
            lblTitulo = new Label();
            pnlFormulario = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            txtCelular = new TextBox();
            lblCelular = new Label();
            txtApellidos = new TextBox();
            lblApellidos = new Label();
            txtNombres = new TextBox();
            lblNombres = new Label();
            txtDni = new TextBox();
            lblDni = new Label();
            lblDatos = new Label();
            pnlLista = new Panel();
            dgvClientes = new DataGridView();
            lblTotal = new Label();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            pnlFormulario.SuspendLayout();
            pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(6, 108, 129);
            lblTitulo.Location = new Point(12, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(106, 28);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CLIENTES";
            // 
            // pnlFormulario
            // 
            pnlFormulario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFormulario.BackColor = Color.WhiteSmoke;
            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(btnNuevo);
            pnlFormulario.Controls.Add(txtCelular);
            pnlFormulario.Controls.Add(lblCelular);
            pnlFormulario.Controls.Add(txtApellidos);
            pnlFormulario.Controls.Add(lblApellidos);
            pnlFormulario.Controls.Add(txtNombres);
            pnlFormulario.Controls.Add(lblNombres);
            pnlFormulario.Controls.Add(txtDni);
            pnlFormulario.Controls.Add(lblDni);
            pnlFormulario.Controls.Add(lblDatos);
            pnlFormulario.Location = new Point(34, 55);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(683, 175);
            pnlFormulario.TabIndex = 1;
            // 
            // lblDatos
            // 
            lblDatos.AutoSize = true;
            lblDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDatos.Location = new Point(20, 10);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(127, 19);
            lblDatos.TabIndex = 0;
            lblDatos.Text = "Datos del cliente";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(20, 42);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(27, 15);
            lblDni.TabIndex = 1;
            lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(20, 60);
            txtDni.MaxLength = 8;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(150, 23);
            txtDni.TabIndex = 2;
            // 
            // lblNombres
            // 
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(190, 42);
            lblNombres.Name = "lblNombres";
            lblNombres.Size = new Size(56, 15);
            lblNombres.TabIndex = 3;
            lblNombres.Text = "Nombres";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(190, 60);
            txtNombres.MaxLength = 80;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(230, 23);
            txtNombres.TabIndex = 4;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(440, 42);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(56, 15);
            lblApellidos.TabIndex = 5;
            lblApellidos.Text = "Apellidos";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(440, 60);
            txtApellidos.MaxLength = 80;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(230, 23);
            txtApellidos.TabIndex = 6;
            // 
            // lblCelular
            // 
            lblCelular.AutoSize = true;
            lblCelular.Location = new Point(20, 98);
            lblCelular.Name = "lblCelular";
            lblCelular.Size = new Size(44, 15);
            lblCelular.TabIndex = 7;
            lblCelular.Text = "Celular";
            // 
            // txtCelular
            // 
            txtCelular.Location = new Point(20, 116);
            txtCelular.MaxLength = 9;
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(150, 23);
            txtCelular.TabIndex = 8;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(6, 108, 129);
            btnNuevo.Cursor = Cursors.Hand;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(190, 106);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(110, 38);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "NUEVO";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(46, 139, 87);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(310, 106);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(110, 38);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(192, 57, 43);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(430, 106);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 38);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "ELIMINAR";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.Gray;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(550, 106);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(110, 38);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "LIMPIAR";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // pnlLista
            // 
            pnlLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlLista.BackColor = Color.WhiteSmoke;
            pnlLista.Controls.Add(dgvClientes);
            pnlLista.Controls.Add(lblTotal);
            pnlLista.Controls.Add(txtBuscar);
            pnlLista.Controls.Add(lblBuscar);
            pnlLista.Location = new Point(34, 245);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(683, 435);
            pnlLista.TabIndex = 2;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.Location = new Point(20, 14);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(212, 19);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar (DNI, nombre o apellido)";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(20, 38);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(320, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotal.Location = new Point(463, 41);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(200, 15);
            lblTotal.TabIndex = 2;
            lblTotal.Text = "Total: 0 clientes";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            estiloEncabezado.Alignment = DataGridViewContentAlignment.MiddleLeft;
            estiloEncabezado.BackColor = Color.FromArgb(6, 108, 129);
            estiloEncabezado.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            estiloEncabezado.ForeColor = Color.White;
            estiloEncabezado.SelectionBackColor = Color.FromArgb(6, 108, 129);
            estiloEncabezado.SelectionForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle = estiloEncabezado;
            dgvClientes.ColumnHeadersHeight = 34;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            estiloFilas.SelectionBackColor = Color.FromArgb(176, 224, 230);
            estiloFilas.SelectionForeColor = Color.Black;
            dgvClientes.DefaultCellStyle = estiloFilas;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.Location = new Point(20, 75);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.RowTemplate.Height = 28;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(643, 340);
            dgvClientes.TabIndex = 3;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // ucClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(pnlLista);
            Controls.Add(pnlFormulario);
            Controls.Add(lblTitulo);
            Name = "ucClientes";
            Size = new Size(751, 703);
            Load += ucClientes_Load;
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            pnlLista.ResumeLayout(false);
            pnlLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlFormulario;
        private Label lblDatos;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblNombres;
        private TextBox txtNombres;
        private Label lblApellidos;
        private TextBox txtApellidos;
        private Label lblCelular;
        private TextBox txtCelular;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Panel pnlLista;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblTotal;
        private DataGridView dgvClientes;
    }
}