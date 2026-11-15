using System.Data;
using Microsoft.Data.SqlClient;

namespace VetSafe
{
    public partial class ucClientes : UserControl
    {
        // Mueve esto a una clase Conexion cuando tengas más módulos.
        private const string CadenaConexion =
            @"Server=.\SQLEXPRESS;Database=SistemaVeterinaria;Trusted_Connection=True;TrustServerCertificate=True;";

        private int idSeleccionado = 0; // 0 = cliente nuevo

        public ucClientes()
        {
            InitializeComponent();

            // Solo dígitos en DNI y celular
            txtDni.KeyPress += SoloNumeros_KeyPress;
            txtCelular.KeyPress += SoloNumeros_KeyPress;
        }

        private void ucClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            ModoNuevo();
        }

        // ---------------------------------------------------------------
        // Carga y búsqueda
        // ---------------------------------------------------------------
        private void CargarClientes(string filtro = "")
        {
            try
            {
                const string sql = @"
                    SELECT id_cliente, dni, nombres, apellidos, celular, fecha_registro
                    FROM Cliente
                    WHERE @filtro = ''
                       OR dni       LIKE @patron
                       OR nombres   LIKE @patron
                       OR apellidos LIKE @patron
                    ORDER BY apellidos, nombres";

                using var cn = new SqlConnection(CadenaConexion);
                using var da = new SqlDataAdapter(sql, cn);
                da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
                da.SelectCommand.Parameters.AddWithValue("@patron", "%" + filtro + "%");

                var tabla = new DataTable();
                da.Fill(tabla);
                dgvClientes.DataSource = tabla;

                ConfigurarColumnas();
                lblTotal.Text = $"Total: {tabla.Rows.Count} cliente(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la lista de clientes:\n" + ex.Message,
                    "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvClientes.Columns.Count == 0) return;

            dgvClientes.Columns["id_cliente"].Visible = false;
            dgvClientes.Columns["dni"].HeaderText = "DNI";
            dgvClientes.Columns["nombres"].HeaderText = "Nombres";
            dgvClientes.Columns["apellidos"].HeaderText = "Apellidos";
            dgvClientes.Columns["celular"].HeaderText = "Celular";
            dgvClientes.Columns["fecha_registro"].HeaderText = "Fecha de registro";
            dgvClientes.Columns["fecha_registro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text.Trim());
        }

        // ---------------------------------------------------------------
        // Selección de un cliente de la lista
        // ---------------------------------------------------------------
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvClientes.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt32(fila.Cells["id_cliente"].Value);
            txtDni.Text = fila.Cells["dni"].Value?.ToString()?.Trim();
            txtNombres.Text = fila.Cells["nombres"].Value?.ToString();
            txtApellidos.Text = fila.Cells["apellidos"].Value?.ToString();
            txtCelular.Text = fila.Cells["celular"].Value?.ToString()?.Trim();

            btnGuardar.Text = "ACTUALIZAR";
            btnEliminar.Enabled = true;
        }

        // ---------------------------------------------------------------
        // Botones
        // ---------------------------------------------------------------
        private void btnNuevo_Click(object sender, EventArgs e) => ModoNuevo();

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            ModoNuevo();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                using var cn = new SqlConnection(CadenaConexion);
                cn.Open();

                string sql = idSeleccionado == 0
                    ? @"INSERT INTO Cliente (dni, nombres, apellidos, celular)
                        VALUES (@dni, @nombres, @apellidos, @celular)"
                    : @"UPDATE Cliente
                        SET dni = @dni, nombres = @nombres, apellidos = @apellidos, celular = @celular
                        WHERE id_cliente = @id";

                using var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@dni", txtDni.Text.Trim());
                cmd.Parameters.AddWithValue("@nombres", txtNombres.Text.Trim());
                cmd.Parameters.AddWithValue("@apellidos", txtApellidos.Text.Trim());
                cmd.Parameters.AddWithValue("@celular", txtCelular.Text.Trim());
                if (idSeleccionado != 0)
                    cmd.Parameters.AddWithValue("@id", idSeleccionado);

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    idSeleccionado == 0 ? "Cliente registrado correctamente." : "Cliente actualizado correctamente.",
                    "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarClientes(txtBuscar.Text.Trim());
                ModoNuevo();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Ya existe un cliente registrado con ese DNI.",
                    "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo guardar el cliente:\n" + ex.Message,
                    "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un cliente de la lista.", "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show(
                $"¿Eliminar al cliente {txtNombres.Text} {txtApellidos.Text}?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            try
            {
                using var cn = new SqlConnection(CadenaConexion);
                cn.Open();
                using var cmd = new SqlCommand("DELETE FROM Cliente WHERE id_cliente = @id", cn);
                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                cmd.ExecuteNonQuery();

                CargarClientes(txtBuscar.Text.Trim());
                ModoNuevo();
            }
            catch (SqlException ex) when (ex.Number == 547) // violación de llave foránea
            {
                MessageBox.Show(
                    "No se puede eliminar: el cliente tiene mascotas o comprobantes registrados.",
                    "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el cliente:\n" + ex.Message,
                    "VetSafe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------------------------------------------------------------
        // Auxiliares
        // ---------------------------------------------------------------
        private void ModoNuevo()
        {
            idSeleccionado = 0;
            txtDni.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCelular.Clear();
            dgvClientes.ClearSelection();
            btnGuardar.Text = "GUARDAR";
            btnEliminar.Enabled = false;
            txtDni.Focus();
        }

        private bool Validar()
        {
            string dni = txtDni.Text.Trim();
            string cel = txtCelular.Text.Trim();

            if (dni.Length != 8 || !dni.All(char.IsDigit))
                return Aviso("El DNI debe tener exactamente 8 dígitos.", txtDni);

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
                return Aviso("Ingresa los nombres del cliente.", txtNombres);

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
                return Aviso("Ingresa los apellidos del cliente.", txtApellidos);

            if (cel.Length != 9 || !cel.All(char.IsDigit))
                return Aviso("El celular debe tener exactamente 9 dígitos.", txtCelular);

            return true;
        }

        private static bool Aviso(string mensaje, Control campo)
        {
            MessageBox.Show(mensaje, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campo.Focus();
            return false;
        }

        private void SoloNumeros_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}