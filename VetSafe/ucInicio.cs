using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VetSafe
{
    public partial class ucInicio : UserControl
    {
        private readonly string _usuario;

        // Constructor sin parámetros (lo necesita el diseñador)
        public ucInicio() : this("")
        {
        }

        public ucInicio(string usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            this.Load += ucInicio_Load;
            btnactualizar.Click += (s, e) => CargarInicio();   // botón "Actualizar"
        }

        private void ucInicio_Load(object? sender, EventArgs e)
        {
            // No consultar la base de datos cuando se está en el diseñador de VS
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            label1.Text = string.IsNullOrWhiteSpace(_usuario)
                ? "BIENVENIDO"
                : $"BIENVENIDO, {_usuario.ToUpper()}";

            btnactualizar.Text = "Actualizar";
            ConfigurarGrilla();
            CargarInicio();
        }

        /// <summary>Estilo de la grilla de citas pendientes.</summary>
        private void ConfigurarGrilla()
        {
            var g = dataGridView1;

            // La grilla ocupa todo el panel (con un margen de 10 px)
            panel4.Padding = new Padding(10);
            g.Dock = DockStyle.Fill;

            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.RowHeadersVisible = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Las columnas se ajustan una por una al cargar los datos
            g.ScrollBars = ScrollBars.Both;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            g.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.EnableHeadersVisualStyles = false;

            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(6, 108, 129);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            g.ColumnHeadersHeight = 32;
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(6, 108, 129);
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 247, 249);
        }

        /// <summary>Carga el contador de citas de hoy y la lista de citas pendientes.</summary>
        private void CargarInicio()
        {
            try
            {
                object? hoy = Conexion.ValorUnico(@"
                    SELECT COUNT(*)
                    FROM dbo.Cita
                    WHERE estado = 'Programada'
                      AND CAST(fecha_hora_programada AS DATE) = CAST(GETDATE() AS DATE);");
                label3.Text = hoy?.ToString() ?? "0";

                DataTable citas = Conexion.Consultar(@"
                    SELECT c.id_cita,
                           c.fecha_hora_programada                    AS [Fecha y hora],
                           m.nombre                                   AS [Mascota],
                           cl.nombres + ' ' + cl.apellidos            AS [Cliente],
                           cl.celular                                 AS [Celular],
                           t.nombres + ' ' + t.apellido_paterno       AS [Veterinario],
                           s.nombre                                   AS [Servicio],
                           c.motivo                                   AS [Motivo]
                    FROM dbo.Cita c
                    INNER JOIN dbo.Mascota  m  ON m.id_mascota    = c.id_mascota
                    INNER JOIN dbo.Cliente  cl ON cl.id_cliente   = m.id_cliente
                    INNER JOIN dbo.Trabajador t ON t.id_trabajador = c.id_trabajador
                    INNER JOIN dbo.Servicio s  ON s.id_servicio   = c.id_servicio
                    WHERE c.estado = 'Programada'
                      AND c.fecha_hora_programada >= CAST(GETDATE() AS DATE)
                    ORDER BY c.fecha_hora_programada;");

                dataGridView1.DataSource = citas;

                if (dataGridView1.Columns.Contains("id_cita"))
                    dataGridView1.Columns["id_cita"].Visible = false;

                if (dataGridView1.Columns.Contains("Fecha y hora"))
                    dataGridView1.Columns["Fecha y hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                // Cada columna se ajusta a su contenido (texto + encabezado)
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.MinimumWidth = 70;
                }

                // "Motivo" toma el espacio que sobre
                if (dataGridView1.Columns.Contains("Motivo"))
                {
                    dataGridView1.Columns["Motivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["Motivo"].MinimumWidth = 150;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las citas:\n" + ex.Message, "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}