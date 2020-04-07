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
        }

        private void crearCircuitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controlador.crearCircuito();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            Pagina.listaPaginas = BDPaginas.buscarPaginas();
            if (Pagina.listaPaginas != null)
            {
                foreach (ClasePagina opagina in Pagina.listaPaginas)
                {
                    ToolStripMenuItem pagina = new ToolStripMenuItem();
                    pagina.Text = opagina.titulo;
                    pagina.Click += delegate (object send, EventArgs ea) { Controlador.mostrarPagina(opagina.id, opagina); };

                    actualizar_pagina.DropDownItems.Add(pagina);
                }
            }
        }
    }
}
