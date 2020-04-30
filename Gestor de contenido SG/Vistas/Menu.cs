using Gestor_de_contenido_SG.FuncionesBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_contenido_SG
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void actualizarPaginaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Controlador.FormularioCrearPagina();
            this.Hide();
        }

        private void crearCircuitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controlador.crearCircuito();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void Menu_Activated(object sender, EventArgs e)
        {
            //limpiar la lista de paginas y las paginas que contiene el menu de actualizar paginas para evitar repetidos
            Pagina.listaPaginas.Clear();
            actualizar_pagina.DropDownItems.Clear();

            //se rellena desde base de datos la lista de paginas
            Pagina.listaPaginas = BDPaginas.buscarPaginas();

            //si la lista de paginas no esta vacia se pintaran dentro del boton desplegable 'actualizar pagina' del menu
            if (Pagina.listaPaginas != null)
            {
                foreach (ClasePagina opagina in Pagina.listaPaginas)
                {
                    ToolStripMenuItem pagina = new ToolStripMenuItem();
                    pagina.Text = opagina.titulo;
                    pagina.BackColor = Color.White;
                    pagina.Dock = DockStyle.Left;

                    //funcion que se llama al clickar encima de una pagina de dicho menu
                    pagina.Click += delegate (object send, EventArgs ea) { Controlador.mostrarPagina(opagina.id, opagina); this.Hide(); };

                    actualizar_pagina.DropDownItems.Add(pagina);
                }                
            }
        }
    }
}
