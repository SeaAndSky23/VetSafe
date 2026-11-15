namespace VetSafe
{
    partial class ucInicio
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
            btnactualizar = new Button();
            panel4 = new Panel();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnactualizar
            // 
            btnactualizar.BackColor = SystemColors.ControlLightLight;
            btnactualizar.Cursor = Cursors.Hand;
            btnactualizar.Location = new Point(637, 199);
            btnactualizar.Name = "btnactualizar";
            btnactualizar.Size = new Size(96, 33);
            btnactualizar.TabIndex = 7;
            btnactualizar.Text = "ACTUALIZAR";
            btnactualizar.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(dataGridView1);
            panel4.Location = new Point(39, 238);
            panel4.Name = "panel4";
            panel4.Size = new Size(694, 443);
            panel4.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(46, 65);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(613, 322);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(17, 21);
            label1.Name = "label1";
            label1.Size = new Size(140, 28);
            label1.TabIndex = 5;
            label1.Text = "BIENVENIDO ";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(301, 24);
            panel3.Name = "panel3";
            panel3.Size = new Size(152, 111);
            panel3.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label3.Location = new Point(60, 44);
            label3.Name = "label3";
            label3.Size = new Size(33, 37);
            label3.TabIndex = 1;
            label3.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(30, 13);
            label2.Name = "label2";
            label2.Size = new Size(91, 19);
            label2.TabIndex = 0;
            label2.Text = "Citas de hoy";
            // 
            // ucInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(btnactualizar);
            Controls.Add(panel4);
            Controls.Add(label1);
            Controls.Add(panel3);
            Name = "ucInicio";
            Size = new Size(751, 703);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnactualizar;
        private Panel panel4;
        private DataGridView dataGridView1;
        private Label label1;
        private Panel panel3;
        private Label label3;
        private Label label2;
    }
}
