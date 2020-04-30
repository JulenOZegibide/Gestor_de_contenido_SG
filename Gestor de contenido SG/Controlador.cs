using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Gestor_de_contenido_SG
{
    static class Controlador
    {
        public static OleDbConnection BDConexion;
        public static CrearPagina nuevapagina;
        public static Menu menu;
        public static Pagina pagina;
        public static Circuito circuito;
        public static Bloque bloque;
        public static Columna columna;

        // Punto de entrada principal para la aplicación.
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //Application.Run(new Columna("6", "columna2", 1260, 570));
                //Application.Run(new Bloque("11", "bloque1"));
                Application.Run(menu = new Menu());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public static OleDbConnection Conectar()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"..\..\Base de datos\\BD_ManualSG.accdb";

            BDConexion = new OleDbConnection(connectionString);

            return BDConexion;
        }

        public static void FormularioCrearPagina()
        {
            nuevapagina = new CrearPagina();
           
            nuevapagina.Show();
        }

        public static void mostrarMenu()
        {
            menu.Show();
        }

        public static void mostrarPagina()
        {
            pagina.Show();
        }

        public static void mostrarBloque()
        {
            bloque.Show();
        }

        public static void cerrarPaginaActual(object sender, FormClosingEventArgs e)
        {
            mostrarMenu();
        }

        public static void volveraPagina(object sender, FormClosingEventArgs e)
        {
            mostrarPagina();
        }

        public static void volveraBloque(object sender, FormClosingEventArgs e)
        {
            mostrarBloque();
        }

        public static void mostrarPagina(int paginaId, ClasePagina opagina)
        {
            string nombrePagina = opagina.titulo;

            pagina = new Pagina(paginaId, nombrePagina);

            pagina.Show();
        }

        public static void crearCircuito()
        {
            circuito = new Circuito();

            circuito.Show();
        }

        public static void mostrarBloque(object sender, EventArgs e, string nombre)
        {
            bloque = new Bloque(nombre);

            bloque.Show();
        }

        public static void mostrarColumna(object sender, EventArgs e, string nombre, int anchoColumna, int altoColumna)
        {
            columna = new Columna(nombre, anchoColumna, altoColumna);

            columna.Show();
        }
    }
}
