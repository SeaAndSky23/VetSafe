namespace VetSafe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            string? rol = Conexion.ValidarLogin(txtuser.Text.Trim(), txtclave.Text);

            if (rol == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "VetSafe",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Inicio frm = new Inicio();
            frm.Show();
            this.Hide();
        }
    }
}
