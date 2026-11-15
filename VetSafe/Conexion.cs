using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VetSafe
{
    /// <summary>
    /// Conexión centralizada a la base de datos SistemaVeterinaria (SQL Server).
    /// Requiere el paquete NuGet: Microsoft.Data.SqlClient
    /// </summary>
    internal static class Conexion
    {
        // CAMBIA el valor de Server según tu instancia (míralo en la ventana de login de SSMS):
        //   "."                      -> instancia por defecto local
        //   "localhost\\SQLEXPRESS"  -> SQL Server Express
        //   "NOMBRE-PC\\SQLEXPRESS"  -> nombre de tu equipo
        private const string Servidor = "localhost\\SQLEXPRESS";
        private const string BaseDatos = "SistemaVeterinaria";

        // Autenticación de Windows (la misma con la que entras a SSMS)
        public static readonly string CadenaConexion =
            $"Server={Servidor};Database={BaseDatos};User Id=sa;Password=baekseung_mari23;TrustServerCertificate=True;";

        /// <summary>Devuelve una conexión nueva (sin abrir). Úsala dentro de un bloque using.</summary>
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        /// <summary>Prueba si se puede conectar a la base de datos.</summary>
        public static bool Probar(out string mensaje)
        {
            try
            {
                using var cn = ObtenerConexion();
                cn.Open();
                mensaje = "Conexión exitosa.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = "No se pudo conectar: " + ex.Message;
                return false;
            }
        }

        /// <summary>Ejecuta un SELECT y devuelve los datos en un DataTable (ideal para DataGridView).</summary>
        public static DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            var tabla = new DataTable();
            using var cn = ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            if (parametros != null) cmd.Parameters.AddRange(parametros);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            return tabla;
        }

        /// <summary>Ejecuta INSERT / UPDATE / DELETE y devuelve las filas afectadas.</summary>
        public static int Ejecutar(string sql, params SqlParameter[] parametros)
        {
            using var cn = ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            if (parametros != null) cmd.Parameters.AddRange(parametros);
            cn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>Ejecuta una consulta que devuelve un solo valor (COUNT, SUM, etc.).</summary>
        public static object? ValorUnico(string sql, params SqlParameter[] parametros)
        {
            using var cn = ObtenerConexion();
            using var cmd = new SqlCommand(sql, cn);
            if (parametros != null) cmd.Parameters.AddRange(parametros);
            cn.Open();
            return cmd.ExecuteScalar();
        }

        /// <summary>
        /// Valida usuario y contraseña. Devuelve el nombre del rol si es correcto, o null si no.
        /// </summary>
        public static string? ValidarLogin(string usuario, string contrasena)
        {
            const string sql = @"
                SELECT r.nombre_rol
                FROM dbo.Usuario u
                INNER JOIN dbo.Rol r ON r.id_rol = u.id_rol
                WHERE u.nombre_usuario = @usuario
                  AND u.contrasena = @contrasena
                  AND u.estado = 1;";

            var resultado = ValorUnico(sql,
                new SqlParameter("@usuario", SqlDbType.NVarChar, 40) { Value = usuario },
                new SqlParameter("@contrasena", SqlDbType.VarChar, 50) { Value = contrasena });

            return resultado as string;
        }
    }
}
