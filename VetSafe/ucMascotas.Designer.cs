namespace VetSafe
{
    partial class ucMascotas
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
            lbltitulo = new Label();
            panelForm = new Panel();
            btneliminar = new Button();
            btnguardar = new Button();
            btnnuevo = new Button();
            txtcolor = new TextBox();
            lblcolor = new Label();
            dtpnacimiento = new DateTimePicker();
            lblnacimiento = new Label();
            cbosexo = new ComboBox();
            lblsexo = new Label();
            txtnombre = new TextBox();
            lblnombre = new Label();
            cboraza = new ComboBox();
            lblraza = new Label();
            cboespecie = new ComboBox();
            lblespecie = new Label();
            cbocliente = new ComboBox();
            lblcliente = new Label();
            lblbuscar = new Label();
            txtbuscar = new TextBox();
            dgvmascotas = new DataGridView();
            panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvmascotas).BeginInit();
            SuspendLayout();
            // 
            // lbltitulo
            // 
            lbltitulo.AutoSize = true;
            lbltitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbltitulo.Location = new Point(17, 16);
            lbltitulo.Name = "lbltitulo";
            lbltitulo.Size = new Size(116, 28);
            lbltitulo.TabIndex = 0;
            lbltitulo.Text = "MASCOTAS";
            // 
            // panelForm
            // 
            panelForm.BackColor = Color.WhiteSmoke;
            panelForm.Controls.Add(btneliminar);
            panelForm.Controls.Add(btnguardar);
            panelForm.Controls.Add(btnnuevo);
            panelForm.Controls.Add(txtcolor);
            panelForm.Controls.Add(lblcolor);
            panelForm.Controls.Add(dtpnacimiento);
            panelForm.Controls.Add(lblnacimiento);
            panelForm.Controls.Add(cbosexo);
            panelForm.Controls.Add(lblsexo);
            panelForm.Controls.Add(txtnombre);
            panelForm.Controls.Add(lblnombre);
            panelForm.Controls.Add(cboraza);
            panelForm.Controls.Add(lblraza);
            panelForm.Controls.Add(cboespecie);
            panelForm.Controls.Add(lblespecie);
            panelForm.Controls.Add(cbocliente);
            panelForm.Controls.Add(lblcliente);
            panelForm.Location = new Point(20, 56);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(711, 190);
            panelForm.TabIndex = 1;
            // 
            // lblcliente
            // 
            lblcliente.AutoSize = true;
            lblcliente.Location = new Point(20, 23);
            lblcliente.Name = "lblcliente";
            lblcliente.Size = new Size(47, 15);
            lblcliente.TabIndex = 0;
            lblcliente.Text = "Cliente:";
            // 
            // cbocliente
            // 
            cbocliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbocliente.FormattingEnabled = true;
            cbocliente.Location = new Point(110, 20);
            cbocliente.Name = "cbocliente";
            cbocliente.Size = new Size(240, 23);
            cbocliente.TabIndex = 1;
            // 
            // lblespecie
            // 
            lblespecie.AutoSize = true;
            lblespecie.Location = new Point(380, 23);
            lblespecie.Name = "lblespecie";
            lblespecie.Size = new Size(48, 15);
            lblespecie.TabIndex = 2;
            lblespecie.Text = "Especie:";
            // 
            // cboespecie
            // 
            cboespecie.DropDownStyle = ComboBoxStyle.DropDownList;
            cboespecie.FormattingEnabled = true;
            cboespecie.Location = new Point(450, 20);
            cboespecie.Name = "cboespecie";
            cboespecie.Size = new Size(240, 23);
            cboespecie.TabIndex = 3;
            // 
            // lblnombre
            // 
            lblnombre.AutoSize = true;
            lblnombre.Location = new Point(20, 63);
            lblnombre.Name = "lblnombre";
            lblnombre.Size = new Size(54, 15);
            lblnombre.TabIndex = 4;
            lblnombre.Text = "Nombre:";
            // 
            // txtnombre
            // 
            txtnombre.Location = new Point(110, 60);
            txtnombre.MaxLength = 60;
            txtnombre.Name = "txtnombre";
            txtnombre.Size = new Size(240, 23);
            txtnombre.TabIndex = 5;
            // 
            // lblraza
            // 
            lblraza.AutoSize = true;
            lblraza.Location = new Point(380, 63);
            lblraza.Name = "lblraza";
            lblraza.Size = new Size(36, 15);
            lblraza.TabIndex = 6;
            lblraza.Text = "Raza:";
            // 
            // cboraza
            // 
            cboraza.DropDownStyle = ComboBoxStyle.DropDownList;
            cboraza.FormattingEnabled = true;
            cboraza.Location = new Point(450, 60);
            cboraza.Name = "cboraza";
            cboraza.Size = new Size(240, 23);
            cboraza.TabIndex = 7;
            // 
            // lblsexo
            // 
            lblsexo.AutoSize = true;
            lblsexo.Location = new Point(20, 103);
            lblsexo.Name = "lblsexo";
            lblsexo.Size = new Size(34, 15);
            lblsexo.TabIndex = 8;
            lblsexo.Text = "Sexo:";
            // 
            // cbosexo
            // 
            cbosexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbosexo.FormattingEnabled = true;
            cbosexo.Items.AddRange(new object[] { "Macho", "Hembra" });
            cbosexo.Location = new Point(110, 100);
            cbosexo.Name = "cbosexo";
            cbosexo.Size = new Size(240, 23);
            cbosexo.TabIndex = 9;
            // 
            // lblnacimiento
            // 
            lblnacimiento.AutoSize = true;
            lblnacimiento.Location = new Point(380, 103);
            lblnacimiento.Name = "lblnacimiento";
            lblnacimiento.Size = new Size(64, 15);
            lblnacimiento.TabIndex = 10;
            lblnacimiento.Text = "Nacimiento:";
            // 
            // dtpnacimiento
            // 
            dtpnacimiento.Format = DateTimePickerFormat.Short;
            dtpnacimiento.Location = new Point(450, 100);
            dtpnacimiento.Name = "dtpnacimiento";
            dtpnacimiento.ShowCheckBox = true;
            dtpnacimiento.Size = new Size(240, 23);
            dtpnacimiento.TabIndex = 11;
            // 
            // lblcolor
            // 
            lblcolor.AutoSize = true;
            lblcolor.Location = new Point(20, 143);
            lblcolor.Name = "lblcolor";
            lblcolor.Size = new Size(39, 15);
            lblcolor.TabIndex = 12;
            lblcolor.Text = "Color:";
            // 
            // txtcolor
            // 
            txtcolor.Location = new Point(110, 140);
            txtcolor.MaxLength = 40;
            txtcolor.Name = "txtcolor";
            txtcolor.Size = new Size(240, 23);
            txtcolor.TabIndex = 13;
            // 
            // btnnuevo
            // 
            btnnuevo.BackColor = Color.FromArgb(6, 108, 129);
            btnnuevo.Cursor = Cursors.Hand;
            btnnuevo.FlatAppearance.BorderSize = 0;
            btnnuevo.FlatStyle = FlatStyle.Flat;
            btnnuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnnuevo.ForeColor = Color.White;
            btnnuevo.Location = new Point(380, 138);
            btnnuevo.Name = "btnnuevo";
            btnnuevo.Size = new Size(96, 33);
            btnnuevo.TabIndex = 14;
            btnnuevo.Text = "NUEVO";
            btnnuevo.UseVisualStyleBackColor = false;
            // 
            // btnguardar
            // 
            btnguardar.BackColor = Color.FromArgb(6, 108, 129);
            btnguardar.Cursor = Cursors.Hand;
            btnguardar.FlatAppearance.BorderSize = 0;
            btnguardar.FlatStyle = FlatStyle.Flat;
            btnguardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnguardar.ForeColor = Color.White;
            btnguardar.Location = new Point(484, 138);
            btnguardar.Name = "btnguardar";
            btnguardar.Size = new Size(104, 33);
            btnguardar.TabIndex = 15;
            btnguardar.Text = "GUARDAR";
            btnguardar.UseVisualStyleBackColor = false;
            // 
            // btneliminar
            // 
            btneliminar.BackColor = Color.FromArgb(170, 50, 50);
            btneliminar.Cursor = Cursors.Hand;
            btneliminar.FlatAppearance.BorderSize = 0;
            btneliminar.FlatStyle = FlatStyle.Flat;
            btneliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btneliminar.ForeColor = Color.White;
            btneliminar.Location = new Point(596, 138);
            btneliminar.Name = "btneliminar";
            btneliminar.Size = new Size(94, 33);
            btneliminar.TabIndex = 16;
            btneliminar.Text = "ELIMINAR";
            btneliminar.UseVisualStyleBackColor = false;
            // 
            // lblbuscar
            // 
            lblbuscar.AutoSize = true;
            lblbuscar.Location = new Point(20, 267);
            lblbuscar.Name = "lblbuscar";
            lblbuscar.Size = new Size(47, 15);
            lblbuscar.TabIndex = 2;
            lblbuscar.Text = "Buscar:";
            // 
            // txtbuscar
            // 
            txtbuscar.Location = new Point(75, 264);
            txtbuscar.Name = "txtbuscar";
            txtbuscar.PlaceholderText = "Mascota, DNI o nombre del cliente";
            txtbuscar.Size = new Size(300, 23);
            txtbuscar.TabIndex = 3;
            // 
            // dgvmascotas
            // 
            dgvmascotas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvmascotas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvmascotas.Location = new Point(20, 300);
            dgvmascotas.Name = "dgvmascotas";
            dgvmascotas.Size = new Size(711, 383);
            dgvmascotas.TabIndex = 4;
            // 
            // ucMascotas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(dgvmascotas);
            Controls.Add(txtbuscar);
            Controls.Add(lblbuscar);
            Controls.Add(panelForm);
            Controls.Add(lbltitulo);
            Name = "ucMascotas";
            Size = new Size(751, 703);
            panelForm.ResumeLayout(false);
            panelForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvmascotas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbltitulo;
        private Panel panelForm;
        private Label lblcliente;
        private ComboBox cbocliente;
        private Label lblespecie;
        private ComboBox cboespecie;
        private Label lblnombre;
        private TextBox txtnombre;
        private Label lblraza;
        private ComboBox cboraza;
        private Label lblsexo;
        private ComboBox cbosexo;
        private Label lblnacimiento;
        private DateTimePicker dtpnacimiento;
        private Label lblcolor;
        private TextBox txtcolor;
        private Button btnnuevo;
        private Button btnguardar;
        private Button btneliminar;
        private Label lblbuscar;
        private TextBox txtbuscar;
        private DataGridView dgvmascotas;
    }
}