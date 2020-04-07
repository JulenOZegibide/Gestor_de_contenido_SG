using System;
using System.Collections.Generic;
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
        // Punto de entrada principal para la aplicación.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Bloque("1","1"));
        }

        public static OleDbConnection Conectar()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\F540U\\Desktop\\Gestor de contenido SG\\Gestor de contenido SG\\Base de datos\\BD_ManualSG.accdb";

            BDConexion = new OleDbConnection(connectionString);

            return BDConexion;
        }

        public static void FormularioCrearPagina()
        {
            CrearPagina nuevapagina = new CrearPagina();

            nuevapagina.Show();
        }

        public static void mostrarPagina(int paginaId, ClasePagina opagina)
        {
            string nombrePagina = opagina.titulo;

            Pagina pagina = new Pagina(paginaId, nombrePagina);

            pagina.Show();
        }

        public static void crearCircuito()
        {
            Circuito circuito = new Circuito();

            circuito.Show();
        }

        public static void mostrarBloque(object sender, EventArgs e, string id, string nombre)
        {
            Bloque bloque = new Bloque(id, nombre);

            bloque.Show();
        }

        public static void mostrarColumna(object sender, EventArgs e, string id, string nombre)
        {
            Columna columna = new Columna(id, nombre);

            columna.Show();
        }
    }
}
