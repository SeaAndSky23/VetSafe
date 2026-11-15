using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace VetSafe
{
    /// <summary>
    /// Módulo PERSONAL: pestaña Trabajadores (tabla Trabajador) y pestaña Usuarios (tablas Usuario + Rol).
    /// El diseño visual está en ucPersonal.Designer.cs.
    /// </summary>
    public partial class ucPersonal : UserControl
    {
        // Si ya tienes una clase de conexión (la de ucClientes), reemplaza esta cadena por la tuya.
        private const string CadenaConexion =
            @"Server=.\SQLEXPRESS;Database=SistemaVeterinaria;Trusted_Connection=True;TrustServerCertificate=True;";

        private int idTrabajadorSel = 0;
        private int idUsuarioSel = 0;

        public ucPersonal()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void ucPersonal_Load(object sender, EventArgs e)
        {
            CargarTrabajadores();
        }

        private void tabPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPersonal.SelectedTab == tabUsuarios)
            {
                LimpiarUsuario();
                CargarRoles();
                CargarUsuarios();
            }
            else
            {
                CargarTrabajadores();
            }
        }

        // =====================================================================
        //  ACCESO A DATOS
        // =====================================================================
        private static DataTable Consultar(string sql, params SqlParameter[] ps)
        {
            using var cn = new SqlConnection(CadenaConexion);
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(ps);
            var dt = new DataTable();
            new SqlDataAdapter(cmd).Fill(dt);
            return dt;
        }

        private static int Ejecutar(string sql, params SqlParameter[] ps)
        {
            using var cn = new SqlConnection(CadenaConexion);
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(ps);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        private static void MostrarError(Exception ex, string duplicado)
        {
            if (ex is SqlException sql && (sql.Number == 2627 || sql.Number == 2601))
                MessageBox.Show(duplicado, "Dato duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Ocurrió un error: " + ex.Message, "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void Aviso(string msg) =>
            MessageBox.Show(msg, "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Information);

        private static string Hash(string texto)
        {
            // SHA-256 en Base64 = 44 caracteres, cabe en Usuario.contrasena (varchar(50)).
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(texto)));
        }

        private static bool SoloDigitos(string s, int largo) =>
            s.Length == largo && s.All(char.IsAsciiDigit);

        // =====================================================================
        //  TRABAJADORES
        // =====================================================================
        private void CargarTrabajadores()
        {
            try
            {
                dgvTrab.DataSource = Consultar(
                    @"SELECT id_trabajador, dni AS DNI, nombres AS Nombres,
                             apellido_paterno AS [Ap. paterno], apellido_materno AS [Ap. materno],
                             telefono AS Teléfono, direccion AS Dirección, estado AS Activo
                      FROM Trabajador ORDER BY apellido_paterno, nombres");
                dgvTrab.Columns["id_trabajador"]!.Visible = false;
            }
            catch (Exception ex) { MostrarError(ex, ""); }
        }

        private void LimpiarTrabajador()
        {
            idTrabajadorSel = 0;
            txtDni.Clear(); txtNombres.Clear(); txtApPat.Clear();
            txtApMat.Clear(); txtTelefono.Clear(); txtDireccion.Clear();
            chkEstadoTrab.Checked = true;
            dgvTrab.ClearSelection();
            txtDni.Focus();
        }

        private bool ValidarTrabajador()
        {
            if (!SoloDigitos(txtDni.Text.Trim(), 8))
            { Aviso("El DNI debe tener 8 dígitos numéricos."); txtDni.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            { Aviso("Ingresa los nombres."); txtNombres.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtApPat.Text))
            { Aviso("Ingresa el apellido paterno."); txtApPat.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtApMat.Text))
            { Aviso("Ingresa el apellido materno."); txtApMat.Focus(); return false; }
            if (!SoloDigitos(txtTelefono.Text.Trim(), 9))
            { Aviso("El teléfono debe tener 9 dígitos numéricos."); txtTelefono.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            { Aviso("Ingresa la dirección."); txtDireccion.Focus(); return false; }
            return true;
        }

        private void dgvTrab_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvTrab.Rows[e.RowIndex];
            idTrabajadorSel = Convert.ToInt32(r.Cells["id_trabajador"].Value);
            txtDni.Text = r.Cells["DNI"].Value?.ToString()?.Trim();
            txtNombres.Text = r.Cells["Nombres"].Value?.ToString();
            txtApPat.Text = r.Cells["Ap. paterno"].Value?.ToString();
            txtApMat.Text = r.Cells["Ap. materno"].Value?.ToString();
            txtTelefono.Text = r.Cells["Teléfono"].Value?.ToString()?.Trim();
            txtDireccion.Text = r.Cells["Dirección"].Value?.ToString();
            chkEstadoTrab.Checked = Convert.ToBoolean(r.Cells["Activo"].Value);
        }

        private void btnNuevoTrab_Click(object? sender, EventArgs e)
        {
            LimpiarTrabajador();
        }

        private void btnGuardarTrab_Click(object? sender, EventArgs e)
        {
            if (!ValidarTrabajador()) return;
            try
            {
                var ps = new[]
                {
                    new SqlParameter("@id", idTrabajadorSel),
                    new SqlParameter("@dni", txtDni.Text.Trim()),
                    new SqlParameter("@nom", txtNombres.Text.Trim()),
                    new SqlParameter("@pat", txtApPat.Text.Trim()),
                    new SqlParameter("@mat", txtApMat.Text.Trim()),
                    new SqlParameter("@tel", txtTelefono.Text.Trim()),
                    new SqlParameter("@dir", txtDireccion.Text.Trim()),
                    new SqlParameter("@est", chkEstadoTrab.Checked)
                };

                if (idTrabajadorSel == 0)
                    Ejecutar(@"INSERT INTO Trabajador (dni, nombres, apellido_paterno, apellido_materno, telefono, direccion, estado)
                               VALUES (@dni, @nom, @pat, @mat, @tel, @dir, @est)", ps);
                else
                    Ejecutar(@"UPDATE Trabajador SET dni=@dni, nombres=@nom, apellido_paterno=@pat,
                                      apellido_materno=@mat, telefono=@tel, direccion=@dir, estado=@est
                               WHERE id_trabajador=@id", ps);

                MessageBox.Show("Trabajador guardado correctamente.", "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTrabajador();
                CargarTrabajadores();
            }
            catch (Exception ex) { MostrarError(ex, "Ya existe un trabajador con ese DNI."); }
        }

        private void btnBajaTrab_Click(object? sender, EventArgs e)
        {
            if (idTrabajadorSel == 0) { Aviso("Selecciona un trabajador de la lista."); return; }
            if (MessageBox.Show("¿Dar de baja a este trabajador? También se desactivará su usuario.",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                // Baja lógica: no se borra porque Cita, Consulta y Usuario hacen referencia al trabajador.
                Ejecutar(@"UPDATE Trabajador SET estado = 0 WHERE id_trabajador = @id;
                           UPDATE Usuario SET estado = 0 WHERE id_trabajador = @id;",
                         new SqlParameter("@id", idTrabajadorSel));
                LimpiarTrabajador();
                CargarTrabajadores();
            }
            catch (Exception ex) { MostrarError(ex, ""); }
        }

        // =====================================================================
        //  USUARIOS
        // =====================================================================
        private void CargarRoles()
        {
            try
            {
                cboRol.DataSource = Consultar("SELECT id_rol, nombre_rol FROM Rol ORDER BY nombre_rol");
                cboRol.DisplayMember = "nombre_rol";
                cboRol.ValueMember = "id_rol";
                cboRol.SelectedIndex = -1;
            }
            catch (Exception ex) { MostrarError(ex, ""); }
        }

        /// <param name="soloSinUsuario">true = solo trabajadores activos que aún no tienen usuario (modo nuevo).</param>
        private void CargarComboTrabajadores(bool soloSinUsuario)
        {
            try
            {
                string sql = @"SELECT t.id_trabajador,
                                      t.apellido_paterno + ' ' + t.apellido_materno + ', ' + t.nombres AS nombre
                               FROM Trabajador t ";
                if (soloSinUsuario)
                    sql += @"WHERE t.estado = 1
                               AND NOT EXISTS (SELECT 1 FROM Usuario u WHERE u.id_trabajador = t.id_trabajador) ";
                sql += "ORDER BY t.apellido_paterno, t.nombres";

                cboTrabajador.DataSource = Consultar(sql);
                cboTrabajador.DisplayMember = "nombre";
                cboTrabajador.ValueMember = "id_trabajador";
                cboTrabajador.SelectedIndex = -1;
            }
            catch (Exception ex) { MostrarError(ex, ""); }
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsu.DataSource = Consultar(
                    @"SELECT u.id_usuario, u.id_trabajador, u.id_rol,
                             u.nombre_usuario AS Usuario,
                             t.apellido_paterno + ' ' + t.apellido_materno + ', ' + t.nombres AS Trabajador,
                             r.nombre_rol AS Rol, u.estado AS Activo
                      FROM Usuario u
                      JOIN Trabajador t ON t.id_trabajador = u.id_trabajador
                      JOIN Rol r ON r.id_rol = u.id_rol
                      ORDER BY t.apellido_paterno, t.nombres");
                dgvUsu.Columns["id_usuario"]!.Visible = false;
                dgvUsu.Columns["id_trabajador"]!.Visible = false;
                dgvUsu.Columns["id_rol"]!.Visible = false;
            }
            catch (Exception ex) { MostrarError(ex, ""); }
        }

        private void LimpiarUsuario()
        {
            idUsuarioSel = 0;
            CargarComboTrabajadores(true);
            cboTrabajador.Enabled = true;
            cboRol.SelectedIndex = -1;
            txtUsuario.Clear();
            txtContrasena.Clear();
            chkEstadoUsu.Checked = true;
            dgvUsu.ClearSelection();
        }

        private void dgvUsu_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var r = dgvUsu.Rows[e.RowIndex];
            idUsuarioSel = Convert.ToInt32(r.Cells["id_usuario"].Value);

            CargarComboTrabajadores(false);
            cboTrabajador.SelectedValue = Convert.ToInt32(r.Cells["id_trabajador"].Value);
            cboTrabajador.Enabled = false;   // un usuario no cambia de trabajador
            cboRol.SelectedValue = Convert.ToInt32(r.Cells["id_rol"].Value);
            txtUsuario.Text = r.Cells["Usuario"].Value?.ToString();
            txtContrasena.Clear();
            chkEstadoUsu.Checked = Convert.ToBoolean(r.Cells["Activo"].Value);
        }

        private void btnNuevoUsu_Click(object? sender, EventArgs e)
        {
            LimpiarUsuario();
        }

        private void btnGuardarUsu_Click(object? sender, EventArgs e)
        {
            if (cboTrabajador.SelectedValue == null)
            { Aviso("Selecciona un trabajador (si no aparece, primero regístralo en la pestaña Trabajadores)."); return; }
            if (cboRol.SelectedValue == null)
            { Aviso("Selecciona un rol."); return; }
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            { Aviso("Ingresa el nombre de usuario."); txtUsuario.Focus(); return; }
            if (idUsuarioSel == 0 && txtContrasena.Text.Length < 6)
            { Aviso("La contraseña debe tener al menos 6 caracteres."); txtContrasena.Focus(); return; }
            if (idUsuarioSel != 0 && txtContrasena.Text.Length > 0 && txtContrasena.Text.Length < 6)
            { Aviso("La contraseña debe tener al menos 6 caracteres."); txtContrasena.Focus(); return; }

            try
            {
                var ps = new List<SqlParameter>
                {
                    new("@id", idUsuarioSel),
                    new("@trab", Convert.ToInt32(cboTrabajador.SelectedValue)),
                    new("@rol", Convert.ToInt32(cboRol.SelectedValue)),
                    new("@usr", txtUsuario.Text.Trim()),
                    new("@est", chkEstadoUsu.Checked)
                };

                if (idUsuarioSel == 0)
                {
                    ps.Add(new SqlParameter("@pass", Hash(txtContrasena.Text)));
                    Ejecutar(@"INSERT INTO Usuario (id_trabajador, id_rol, nombre_usuario, contrasena, estado)
                               VALUES (@trab, @rol, @usr, @pass, @est)", ps.ToArray());
                }
                else if (txtContrasena.Text.Length > 0)
                {
                    ps.Add(new SqlParameter("@pass", Hash(txtContrasena.Text)));
                    Ejecutar(@"UPDATE Usuario SET id_rol=@rol, nombre_usuario=@usr, contrasena=@pass, estado=@est
                               WHERE id_usuario=@id", ps.ToArray());
                }
                else
                {
                    Ejecutar(@"UPDATE Usuario SET id_rol=@rol, nombre_usuario=@usr, estado=@est
                               WHERE id_usuario=@id", ps.ToArray());
                }

                MessageBox.Show("Usuario guardado correctamente.", "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarUsuario();
                CargarUsuarios();
            }
            catch (Exception ex) { MostrarError(ex, "Ese nombre de usuario ya existe o el trabajador ya tiene un usuario."); }
        }

        private void btnBajaUsu_Click(object? sender, EventArgs e)
        {
            if (idUsuarioSel == 0) { Aviso("Selecciona un usuario de la lista."); return; }
            try
            {
                // Baja lógica: Comprobante y Movimiento_Inventario referencian al usuario.
                Ejecutar("UPDATE Usuario SET estado = 0 WHERE id_usuario = @id",
                         new SqlParameter("@id", idUsuarioSel));
                LimpiarUsuario();
                CargarUsuarios();
            }
            catch (Exception ex) { MostrarError(ex, ""); }
        }
    }
}