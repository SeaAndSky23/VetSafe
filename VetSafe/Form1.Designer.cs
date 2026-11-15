namespace VetSafe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtuser = new TextBox();
            txtclave = new TextBox();
            btningresar = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.image;
            pictureBox1.Location = new Point(418, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(403, 548);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(109, 50);
            label1.Name = "label1";
            label1.Size = new Size(196, 32);
            label1.TabIndex = 1;
            label1.Text = "INICIAR SESION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(26, 37);
            label2.Name = "label2";
            label2.Size = new Size(64, 17);
            label2.TabIndex = 2;
            label2.Text = "USUARIO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(26, 118);
            label3.Name = "label3";
            label3.Size = new Size(94, 17);
            label3.TabIndex = 3;
            label3.Text = "CONTRASEÑA";
            // 
            // txtuser
            // 
            txtuser.Location = new Point(26, 71);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(281, 23);
            txtuser.TabIndex = 4;
            // 
            // txtclave
            // 
            txtclave.Location = new Point(26, 162);
            txtclave.Name = "txtclave";
            txtclave.PasswordChar = '*';
            txtclave.Size = new Size(281, 23);
            txtclave.TabIndex = 5;
            // 
            // btningresar
            // 
            btningresar.BackColor = Color.WhiteSmoke;
            btningresar.Cursor = Cursors.Hand;
            btningresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btningresar.Location = new Point(113, 228);
            btningresar.Name = "btningresar";
            btningresar.Size = new Size(98, 33);
            btningresar.TabIndex = 6;
            btningresar.Text = "INGRESAR";
            btningresar.UseVisualStyleBackColor = false;
            btningresar.Click += btningresar_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btningresar);
            panel1.Controls.Add(txtclave);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtuser);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(33, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(344, 372);
            panel1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 108, 129);
            ClientSize = new Size(821, 548);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VETSAFE";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtuser;
        private TextBox txtclave;
        private Button btningresar;
        private Panel panel1;
    }
}
