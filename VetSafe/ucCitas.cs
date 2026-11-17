using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace VetSafe
{
    public partial class ucCitas : UserControl
    {
        private int _idCita = 0;          // 0 = cita nueva
        private bool _cargando = false;   // evita eventos mientras se llenan los combos

        public ucCitas()
        {
            InitializeComponent();

            this.Load += ucCitas_Load;

            cboCliente.SelectedIndexChanged += (s, e) => { if (!_cargando) CargarMascotas(); };
            btnNuevo.Click += (s, e) => NuevaCita();
            btnGuardar.Click += (s, e) => GuardarCita();
            btnCancelarCita.Click += (s, e) => CancelarCita();
            btnBuscar.Click += (s, e) => CargarCitas();
            txtBuscar.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; CargarCitas(); }
            };
            dtpFiltro.ValueChanged += (s, e) => { if (!_cargando) CargarCitas(); };
            chkTodas.CheckedChanged += (s, e) =>
            {
                dtpFiltro.Enabled = !chkTodas.Checked;
                if (!_cargando) CargarCitas();
            };
            cboFiltroEstado.SelectedIndexChanged += (s, e) => { if (!_cargando) CargarCitas(); };
            dgvCitas.CellClick += dgvCitas_CellClick;
            dgvCitas.CellFormatting += dgvCitas_CellFormatting;
        }

        private void ucCitas_Load(object? sender, EventArgs e)
        {
            // No consultar la base de datos cuando se está en el diseñador de VS
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            ConfigurarGrilla();

            _cargando = true;
            cboEstado.Items.AddRange(new object[] { "Programada", "Atendida", "Cancelada" });
            cboFiltroEstado.Items.AddRange(new object[] { "Todos", "Programada", "Atendida", "Cancelada" });
            cboFiltroEstado.SelectedIndex = 0;
            dtpFiltro.Value = DateTime.Today;
            _cargando = false;

            CargarCombos();
            NuevaCita();
            CargarCitas();
        }

        // ---------------------------------------------------------------
        //  Estilo de la grilla (igual que ucInicio)
        // ---------------------------------------------------------------
        private void ConfigurarGrilla()
        {
            var g = dgvCitas;

            g.ReadOnly = true;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.RowHeadersVisible = false;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        // ---------------------------------------------------------------
        //  Carga de combos
        // ---------------------------------------------------------------
        private void CargarCombos()
        {
            try
            {
                _cargando = true;

                cboCliente.DisplayMember = "texto";
                cboCliente.ValueMember = "id_cliente";
                cboCliente.DataSource = Conexion.Consultar(@"
                    SELECT id_cliente, dni + ' - ' + nombres + ' ' + apellidos AS texto
                    FROM dbo.Cliente
                    ORDER BY apellidos, nombres;");

                cboVeterinario.DisplayMember = "texto";
                cboVeterinario.ValueMember = "id_trabajador";
                cboVeterinario.DataSource = Conexion.Consultar(@"
                    SELECT id_trabajador,
                           nombres + ' ' + apellido_paterno + ' ' + apellido_materno AS texto
                    FROM dbo.Trabajador
                    WHERE estado = 1
                    ORDER BY nombres, apellido_paterno;");

                cboServicio.DisplayMember = "nombre";
                cboServicio.ValueMember = "id_servicio";
                cboServicio.DataSource = Conexion.Consultar(@"
                    SELECT id_servicio, nombre
                    FROM dbo.Servicio
                    WHERE estado = 1
                    ORDER BY nombre;");
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar los datos del formulario:\n" + ex.Message);
            }
            finally
            {
                _cargando = false;
            }
        }

        /// <summary>Carga en el combo las mascotas del cliente seleccionado.</summary>
        private void CargarMascotas()
        {
            if (cboCliente.SelectedValue is not int idCliente)
            {
                cboMascota.DataSource = null;
                return;
            }

            try
            {
                cboMascota.DisplayMember = "nombre";
                cboMascota.ValueMember = "id_mascota";
                cboMascota.DataSource = Conexion.Consultar(
                    "SELECT id_mascota, nombre FROM dbo.Mascota WHERE id_cliente = @c ORDER BY nombre;",
                    new SqlParameter("@c", idCliente));
                cboMascota.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar las mascotas:\n" + ex.Message);
            }
        }

        // ---------------------------------------------------------------
        //  Listado de citas
        // ---------------------------------------------------------------
        private void CargarCitas()
        {
            try
            {
                string estado = cboFiltroEstado.SelectedItem?.ToString() ?? "Todos";

                DataTable citas = Conexion.Consultar(@"
                    SELECT c.id_cita,
                           c.id_mascota,
                           c.id_trabajador,
                           c.id_servicio,
                           m.id_cliente,
                           c.fecha_hora_programada                         AS [Fecha y hora],
                           m.nombre                                        AS [Mascota],
                           cl.nombres + ' ' + cl.apellidos                 AS [Cliente],
                           t.nombres + ' ' + t.apellido_paterno            AS [Veterinario],
                           s.nombre                                        AS [Servicio],
                           c.motivo                                        AS [Motivo],
                           c.estado                                        AS [Estado]
                    FROM dbo.Cita c
                    INNER JOIN dbo.Mascota    m  ON m.id_mascota    = c.id_mascota
                    INNER JOIN dbo.Cliente    cl ON cl.id_cliente   = m.id_cliente
                    INNER JOIN dbo.Trabajador t  ON t.id_trabajador = c.id_trabajador
                    INNER JOIN dbo.Servicio   s  ON s.id_servicio   = c.id_servicio
                    WHERE (@todas = 1 OR CAST(c.fecha_hora_programada AS DATE) = @fecha)
                      AND (@estado = 'Todos' OR c.estado = @estado)
                      AND (@q = ''
                           OR m.nombre LIKE '%' + @q + '%'
                           OR cl.nombres + ' ' + cl.apellidos LIKE '%' + @q + '%'
                           OR cl.dni LIKE '%' + @q + '%')
                    ORDER BY c.fecha_hora_programada;",
                    new SqlParameter("@todas", chkTodas.Checked ? 1 : 0),
                    new SqlParameter("@fecha", SqlDbType.Date) { Value = dtpFiltro.Value.Date },
                    new SqlParameter("@estado", estado),
                    new SqlParameter("@q", txtBuscar.Text.Trim()));

                dgvCitas.DataSource = citas;

                foreach (string col in new[] { "id_cita", "id_mascota", "id_trabajador", "id_servicio", "id_cliente" })
                    if (dgvCitas.Columns.Contains(col))
                        dgvCitas.Columns[col].Visible = false;

                if (dgvCitas.Columns.Contains("Fecha y hora"))
                    dgvCitas.Columns["Fecha y hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                dgvCitas.ClearSelection();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudieron cargar las citas:\n" + ex.Message);
            }
        }

        /// <summary>Colorea el estado de la cita.</summary>
        private void dgvCitas_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvCitas.Columns[e.ColumnIndex].Name != "Estado") return;

            switch (e.Value.ToString())
            {
                case "Atendida":
                    e.CellStyle.ForeColor = Color.FromArgb(30, 132, 73);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    break;
                case "Cancelada":
                    e.CellStyle.ForeColor = Color.FromArgb(192, 57, 43);
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    break;
            }
        }

        // ---------------------------------------------------------------
        //  Formulario
        // ---------------------------------------------------------------
        private void NuevaCita()
        {
            _idCita = 0;
            _cargando = true;

            cboCliente.SelectedIndex = -1;
            cboMascota.DataSource = null;
            cboVeterinario.SelectedIndex = -1;
            cboServicio.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today;
            dtpHora.Value = DateTime.Today.AddHours(9);
            txtMotivo.Clear();
            cboEstado.SelectedItem = "Programada";
            cboEstado.Enabled = false;          // las citas nuevas siempre nacen "Programada"
            btnCancelarCita.Enabled = false;
            btnGuardar.Text = "GUARDAR";

            _cargando = false;
            dgvCitas.ClearSelection();
            cboCliente.Focus();
        }

        private void dgvCitas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCitas.Rows[e.RowIndex].DataBoundItem is not DataRowView fila) return;

            try
            {
                _cargando = true;

                _idCita = Convert.ToInt32(fila["id_cita"]);

                cboCliente.SelectedValue = Convert.ToInt32(fila["id_cliente"]);
                CargarMascotas();
                cboMascota.SelectedValue = Convert.ToInt32(fila["id_mascota"]);
                cboVeterinario.SelectedValue = Convert.ToInt32(fila["id_trabajador"]);
                cboServicio.SelectedValue = Convert.ToInt32(fila["id_servicio"]);

                DateTime fecha = Convert.ToDateTime(fila["Fecha y hora"]);
                dtpFecha.Value = fecha.Date;
                dtpHora.Value = DateTime.Today.Add(fecha.TimeOfDay);

                txtMotivo.Text = fila["Motivo"] == DBNull.Value ? "" : fila["Motivo"].ToString();
                cboEstado.SelectedItem = fila["Estado"].ToString();
                cboEstado.Enabled = true;

                btnCancelarCita.Enabled = fila["Estado"].ToString() == "Programada";
                btnGuardar.Text = "ACTUALIZAR";
            }
            finally
            {
                _cargando = false;
            }
        }

        // ---------------------------------------------------------------
        //  Guardar (INSERT / UPDATE)
        // ---------------------------------------------------------------
        private void GuardarCita()
        {
            // Validaciones
            if (cboCliente.SelectedValue == null)
            {
                Aviso("Seleccione un cliente de la lista."); cboCliente.Focus(); return;
            }
            if (cboMascota.SelectedValue == null)
            {
                Aviso("Seleccione la mascota."); cboMascota.Focus(); return;
            }
            if (cboVeterinario.SelectedValue == null)
            {
                Aviso("Seleccione el veterinario."); cboVeterinario.Focus(); return;
            }
            if (cboServicio.SelectedValue == null)
            {
                Aviso("Seleccione el servicio."); cboServicio.Focus(); return;
            }

            // Fecha + hora (sin segundos)
            DateTime fechaHora = dtpFecha.Value.Date
                .AddHours(dtpHora.Value.Hour)
                .AddMinutes(dtpHora.Value.Minute);

            string estado = cboEstado.SelectedItem?.ToString() ?? "Programada";

            if (_idCita == 0 && fechaHora < DateTime.Now)
            {
                Aviso("La fecha y hora de la cita no pueden estar en el pasado.");
                return;
            }

            if (_idCita != 0 && EstadoActualEnBD(_idCita) == "Atendida")
            {
                Aviso("Una cita ya atendida no se puede modificar.");
                return;
            }

            object motivo = string.IsNullOrWhiteSpace(txtMotivo.Text)
                ? DBNull.Value
                : txtMotivo.Text.Trim();

            try
            {
                if (_idCita == 0)
                {
                    Conexion.Ejecutar(@"
                        INSERT INTO dbo.Cita
                            (id_mascota, id_trabajador, id_servicio, fecha_hora_programada, motivo, estado)
                        VALUES
                            (@mascota, @trabajador, @servicio, @fecha, @motivo, 'Programada');",
                        new SqlParameter("@mascota", cboMascota.SelectedValue),
                        new SqlParameter("@trabajador", cboVeterinario.SelectedValue),
                        new SqlParameter("@servicio", cboServicio.SelectedValue),
                        new SqlParameter("@fecha", SqlDbType.DateTime) { Value = fechaHora },
                        new SqlParameter("@motivo", SqlDbType.NVarChar, 200) { Value = motivo });

                    Informar("Cita registrada correctamente.");
                }
                else
                {
                    Conexion.Ejecutar(@"
                        UPDATE dbo.Cita
                        SET id_mascota            = @mascota,
                            id_trabajador         = @trabajador,
                            id_servicio           = @servicio,
                            fecha_hora_programada = @fecha,
                            motivo                = @motivo,
                            estado                = @estado
                        WHERE id_cita = @id;",
                        new SqlParameter("@mascota", cboMascota.SelectedValue),
                        new SqlParameter("@trabajador", cboVeterinario.SelectedValue),
                        new SqlParameter("@servicio", cboServicio.SelectedValue),
                        new SqlParameter("@fecha", SqlDbType.DateTime) { Value = fechaHora },
                        new SqlParameter("@motivo", SqlDbType.NVarChar, 200) { Value = motivo },
                        new SqlParameter("@estado", estado),
                        new SqlParameter("@id", _idCita));

                    Informar("Cita actualizada correctamente.");
                }

                NuevaCita();
                CargarCitas();
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                // Índice único UX_Cita_trabajador_fechahora
                Aviso("Ese veterinario ya tiene una cita programada en esa fecha y hora.");
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo guardar la cita:\n" + ex.Message);
            }
        }

        // ---------------------------------------------------------------
        //  Cancelar cita (estado = 'Cancelada')
        // ---------------------------------------------------------------
        private void CancelarCita()
        {
            if (_idCita == 0) return;

            var r = MessageBox.Show("¿Desea cancelar esta cita?", "VetSafe",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                int filas = Conexion.Ejecutar(
                    "UPDATE dbo.Cita SET estado = 'Cancelada' WHERE id_cita = @id AND estado = 'Programada';",
                    new SqlParameter("@id", _idCita));

                if (filas == 0)
                    Aviso("Solo se pueden cancelar citas en estado Programada.");
                else
                    Informar("Cita cancelada.");

                NuevaCita();
                CargarCitas();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo cancelar la cita:\n" + ex.Message);
            }
        }

        private static string? EstadoActualEnBD(int idCita)
        {
            return Conexion.ValorUnico(
                "SELECT estado FROM dbo.Cita WHERE id_cita = @id;",
                new SqlParameter("@id", idCita)) as string;
        }

        // ---------------------------------------------------------------
        //  Mensajes
        // ---------------------------------------------------------------
        private static void Aviso(string msg) =>
            MessageBox.Show(msg, "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        private static void Informar(string msg) =>
            MessageBox.Show(msg, "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static void MostrarError(string msg) =>
            MessageBox.Show(msg, "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}