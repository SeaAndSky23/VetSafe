using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace VetSafe
{
    public partial class ucMascotas : UserControl
    {
        private int _idMascota = 0;     // 0 = registro nuevo
        private bool _cargando = false; // evita eventos en cascada al llenar combos

        public ucMascotas()
        {
            InitializeComponent();

            this.Load += ucMascotas_Load;
            cboespecie.SelectedIndexChanged += cboespecie_SelectedIndexChanged;
            txtbuscar.TextChanged += (s, e) => CargarMascotas();
            dgvmascotas.CellClick += dgvmascotas_CellClick;
            btnnuevo.Click += (s, e) => Nuevo();
            btnguardar.Click += btnguardar_Click;
            btneliminar.Click += btneliminar_Click;
        }

        private void ucMascotas_Load(object? sender, EventArgs e)
        {
            // No consultar la base de datos cuando se está en el diseñador de VS
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            dtpnacimiento.MaxDate = DateTime.Today;   // CK_Mascota_nacimiento: no puede ser futura
            ConfigurarGrilla();
            CargarCombos();
            CargarMascotas();
            Nuevo();
        }

        // ------------------------------------------------------------------
        //  Estilo y carga de datos
        // ------------------------------------------------------------------

        private void ConfigurarGrilla()
        {
            var g = dgvmascotas;

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

        private void CargarCombos()
        {
            try
            {
                _cargando = true;

                // Clientes
                DataTable clientes = Conexion.Consultar(@"
                    SELECT id_cliente,
                           dni + ' - ' + apellidos + ' ' + nombres AS texto
                    FROM dbo.Cliente
                    ORDER BY apellidos, nombres;");
                cbocliente.DisplayMember = "texto";
                cbocliente.ValueMember = "id_cliente";
                cbocliente.DataSource = clientes;

                // Especies
                DataTable especies = Conexion.Consultar(
                    "SELECT id_especie, nombre FROM dbo.Especie ORDER BY nombre;");
                cboespecie.DisplayMember = "nombre";
                cboespecie.ValueMember = "id_especie";
                cboespecie.DataSource = especies;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los datos auxiliares:\n" + ex.Message, "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cargando = false;
            }
        }

        /// <summary>Llena el combo de razas con las razas de la especie indicada.</summary>
        private void CargarRazas(int idEspecie)
        {
            DataTable razas = Conexion.Consultar(
                $"SELECT id_raza, nombre FROM dbo.Raza WHERE id_especie = {idEspecie} ORDER BY nombre;");
            cboraza.DisplayMember = "nombre";
            cboraza.ValueMember = "id_raza";
            cboraza.DataSource = razas;
        }

        private void CargarMascotas()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            try
            {
                string filtro = "";
                string texto = txtbuscar.Text.Trim();
                if (texto.Length > 0)
                {
                    string t = EscaparLike(texto);
                    filtro = $@"WHERE m.nombre    LIKE N'%{t}%'
                                   OR cl.dni      LIKE '%{t}%'
                                   OR cl.nombres  LIKE N'%{t}%'
                                   OR cl.apellidos LIKE N'%{t}%'";
                }

                DataTable dt = Conexion.Consultar($@"
                    SELECT m.id_mascota,
                           m.id_cliente,
                           r.id_especie,
                           m.id_raza,
                           m.sexo                                  AS sexo_cod,
                           m.nombre                                AS [Mascota],
                           e.nombre                                AS [Especie],
                           r.nombre                                AS [Raza],
                           CASE m.sexo WHEN 'M' THEN 'Macho' ELSE 'Hembra' END AS [Sexo],
                           m.fecha_nacimiento                      AS [Nacimiento],
                           m.color                                 AS [Color],
                           cl.dni                                  AS [DNI],
                           cl.nombres + ' ' + cl.apellidos         AS [Cliente]
                    FROM dbo.Mascota m
                    INNER JOIN dbo.Cliente cl ON cl.id_cliente = m.id_cliente
                    INNER JOIN dbo.Raza    r  ON r.id_raza     = m.id_raza
                    INNER JOIN dbo.Especie e  ON e.id_especie  = r.id_especie
                    {filtro}
                    ORDER BY m.nombre;");

                dgvmascotas.DataSource = dt;

                foreach (string col in new[] { "id_mascota", "id_cliente", "id_especie", "id_raza", "sexo_cod" })
                    if (dgvmascotas.Columns.Contains(col))
                        dgvmascotas.Columns[col].Visible = false;

                if (dgvmascotas.Columns.Contains("Nacimiento"))
                    dgvmascotas.Columns["Nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvmascotas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las mascotas:\n" + ex.Message, "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------------
        //  Eventos
        // ------------------------------------------------------------------

        private void cboespecie_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_cargando) return;

            if (cboespecie.SelectedValue is int idEspecie)
                CargarRazas(idEspecie);
            else
                cboraza.DataSource = null;
        }

        private void dgvmascotas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvmascotas.Rows[e.RowIndex].DataBoundItem is not DataRowView fila) return;

            try
            {
                _cargando = true;

                _idMascota = Convert.ToInt32(fila["id_mascota"]);
                cbocliente.SelectedValue = Convert.ToInt32(fila["id_cliente"]);

                int idEspecie = Convert.ToInt32(fila["id_especie"]);
                cboespecie.SelectedValue = idEspecie;
                CargarRazas(idEspecie);
                cboraza.SelectedValue = Convert.ToInt32(fila["id_raza"]);

                txtnombre.Text = fila["Mascota"]?.ToString() ?? "";
                cbosexo.SelectedIndex = fila["sexo_cod"]?.ToString() == "M" ? 0 : 1;

                if (fila["Nacimiento"] is DateTime nac)
                {
                    dtpnacimiento.Value = nac;
                    dtpnacimiento.Checked = true;
                }
                else
                {
                    dtpnacimiento.Checked = false;
                }

                txtcolor.Text = fila["Color"] == DBNull.Value ? "" : fila["Color"].ToString();
            }
            finally
            {
                _cargando = false;
            }

            btnguardar.Text = "ACTUALIZAR";
            btneliminar.Enabled = true;
        }

        private void btnguardar_Click(object? sender, EventArgs e)
        {
            // ----- Validaciones (reflejan las restricciones de la BD) -----
            if (cbocliente.SelectedValue is not int idCliente)
            {
                Aviso("Seleccione el cliente (dueño) de la mascota.");
                cbocliente.Focus();
                return;
            }

            if (cboraza.SelectedValue is not int idRaza)
            {
                Aviso("Seleccione la especie y la raza.");
                cboespecie.Focus();
                return;
            }

            string nombre = txtnombre.Text.Trim();
            if (nombre.Length == 0)
            {
                Aviso("Ingrese el nombre de la mascota.");
                txtnombre.Focus();
                return;
            }
            if (nombre.Length > 60)
            {
                Aviso("El nombre no puede superar los 60 caracteres.");
                txtnombre.Focus();
                return;
            }

            if (cbosexo.SelectedIndex < 0)
            {
                Aviso("Seleccione el sexo de la mascota.");
                cbosexo.Focus();
                return;
            }

            string color = txtcolor.Text.Trim();
            if (color.Length > 40)
            {
                Aviso("El color no puede superar los 40 caracteres.");
                txtcolor.Focus();
                return;
            }

            string sexo = cbosexo.SelectedIndex == 0 ? "M" : "H";
            string fecha = dtpnacimiento.Checked
                ? $"'{dtpnacimiento.Value:yyyy-MM-dd}'"
                : "NULL";
            string colorSql = color.Length == 0 ? "NULL" : $"N'{Escapar(color)}'";

            try
            {
                if (_idMascota == 0)
                {
                    // ExecuteScalar también ejecuta INSERT/UPDATE/DELETE
                    Conexion.ValorUnico($@"
                        INSERT INTO dbo.Mascota (id_cliente, id_raza, nombre, sexo, fecha_nacimiento, color)
                        VALUES ({idCliente}, {idRaza}, N'{Escapar(nombre)}', '{sexo}', {fecha}, {colorSql});");
                    MessageBox.Show("Mascota registrada correctamente.", "VetSafe",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Conexion.ValorUnico($@"
                        UPDATE dbo.Mascota
                        SET id_cliente = {idCliente},
                            id_raza = {idRaza},
                            nombre = N'{Escapar(nombre)}',
                            sexo = '{sexo}',
                            fecha_nacimiento = {fecha},
                            color = {colorSql}
                        WHERE id_mascota = {_idMascota};");
                    MessageBox.Show("Mascota actualizada correctamente.", "VetSafe",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarMascotas();
                Nuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar la mascota:\n" + ex.Message, "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object? sender, EventArgs e)
        {
            if (_idMascota == 0) return;

            try
            {
                // La mascota no se puede borrar si ya tiene citas o consultas (FK)
                object? usos = Conexion.ValorUnico($@"
                    SELECT (SELECT COUNT(*) FROM dbo.Cita     WHERE id_mascota = {_idMascota})
                         + (SELECT COUNT(*) FROM dbo.Consulta WHERE id_mascota = {_idMascota});");

                if (Convert.ToInt32(usos ?? 0) > 0)
                {
                    MessageBox.Show(
                        "Esta mascota tiene citas o historias clínicas registradas y no puede eliminarse.",
                        "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var r = MessageBox.Show("¿Desea eliminar esta mascota?", "VetSafe",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r != DialogResult.Yes) return;

                Conexion.ValorUnico($"DELETE FROM dbo.Mascota WHERE id_mascota = {_idMascota};");

                CargarMascotas();
                Nuevo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la mascota:\n" + ex.Message, "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------------------------------------------------------
        //  Utilidades
        // ------------------------------------------------------------------

        /// <summary>Limpia el formulario para registrar una mascota nueva.</summary>
        private void Nuevo()
        {
            _idMascota = 0;

            try
            {
                _cargando = true;
                cbocliente.SelectedIndex = -1;
                cboespecie.SelectedIndex = -1;
                cboraza.DataSource = null;
                cbosexo.SelectedIndex = -1;
            }
            finally
            {
                _cargando = false;
            }

            txtnombre.Clear();
            txtcolor.Clear();
            dtpnacimiento.Checked = false;
            dgvmascotas.ClearSelection();

            btnguardar.Text = "GUARDAR";
            btneliminar.Enabled = false;
            txtnombre.Focus();
        }

        private static void Aviso(string mensaje) =>
            MessageBox.Show(mensaje, "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        /// <summary>Duplica las comillas simples para armar SQL de texto.</summary>
        private static string Escapar(string s) => s.Replace("'", "''");

        /// <summary>Escapa comillas y comodines para usar el texto dentro de un LIKE.</summary>
        private static string EscaparLike(string s) =>
            Escapar(s).Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
    }
}