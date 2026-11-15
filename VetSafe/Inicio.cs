using System;
using System.Drawing;
using System.Windows.Forms;

namespace VetSafe
{
    public partial class Inicio : Form
    {
        private readonly string _usuario;
        private readonly string _rol;
        private Button? _botonActivo;

        private static readonly Color ColorMenuActivo = Color.FromArgb(4, 84, 101);

        // Constructor sin parámetros (lo necesita el diseñador de Visual Studio)
        public Inicio() : this("", "")
        {
        }

        public Inicio(string usuario, string rol)
        {
            InitializeComponent();
            _usuario = usuario;
            _rol = rol;

            this.Load += Inicio_Load;
            this.FormClosed += (s, e) => Application.Exit();   // Form1 quedó oculto, cerramos todo

            // Menú lateral (nombres originales del diseñador)
            btninicio.Click += (s, e) => Abrir(new ucInicio(_usuario), btninicio);   // INICIO
            btnclientes.Click += (s, e) => Abrir(new ucClientes(), btnclientes);         // CLIENTES
            btnmascotas.Click += (s, e) => Abrir(new ucMascotas(), btnmascotas);         // MASCOTAS
            btncitas.Click += (s, e) => Abrir(new ucCitas(), btncitas);            // CITAS
            btnhisclini.Click += (s, e) => Abrir(new ucHistorias(), btnhisclini);        // HISTORIAS CLINICAS
            btninventario.Click += (s, e) => Abrir(new ucInventario(), btninventario);       // INVENTARIO
            btnpagos.Click += (s, e) => Abrir(new ucPagos(), btnpagos);            // PAGOS
            btnpersonal.Click += (s, e) => Abrir(new ucPersonal(), btnpersonal);     // PERSONAL
            btnreportes.Click += (s, e) => Abrir(new ucReportes(), btnreportes);     // REPORTES
            button9.Click += (s, e) => this.Close();                             // SALIR
        }

        private void Inicio_Load(object? sender, EventArgs e)
        {
            // Pantalla que se muestra al entrar
            Abrir(new ucInicio(_usuario), btninicio);
        }

        /// <summary>
        /// Reemplaza lo que haya en el panel de contenido por el UserControl indicado
        /// y resalta el botón del menú.
        /// </summary>
        private void Abrir(UserControl modulo, Button boton)
        {
            pnlContenido.SuspendLayout();

            // Quitar y liberar el módulo anterior
            while (pnlContenido.Controls.Count > 0)
            {
                Control anterior = pnlContenido.Controls[0];
                pnlContenido.Controls.RemoveAt(0);
                anterior.Dispose();
            }

            modulo.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(modulo);
            pnlContenido.ResumeLayout();

            ResaltarBoton(boton);
        }

        private void ResaltarBoton(Button boton)
        {
            if (_botonActivo != null)
                _botonActivo.BackColor = Color.Transparent;

            boton.BackColor = ColorMenuActivo;
            _botonActivo = boton;
        }
    }
}