using Gestor_de_contenido_SG.FuncionesBD;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_contenido_SG
{
    public partial class Pagina : Form
    {
        public static ArrayList listaBloques = new ArrayList();
        public static ArrayList listaPaginas = new ArrayList();
        int altura = 0;

        public Pagina(int paginaId, string nombrePagina)
        {
            InitializeComponent();
            nombre_pagina.Text = nombrePagina;
            pagina_id.Text = paginaId.ToString();
        }

        public static void crearPagina(string tituloPagina, int circuitoId)
        {
            if (String.IsNullOrEmpty(tituloPagina) || String.IsNullOrWhiteSpace(tituloPagina))
            {
                MessageBox.Show("Introduce un nombre valido");
            }
            else
            {
                ClasePagina opagina = new ClasePagina(tituloPagina, circuitoId);

                BDPaginas.insertarPagina(opagina);
                int paginaId = BDPaginas.buscarIdPagina(tituloPagina);

                Controlador.mostrarPagina(paginaId, opagina);
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nombre_bloque.Text) || String.IsNullOrWhiteSpace(nombre_bloque.Text))
            {
                MessageBox.Show("Introduce un nombre valido");
                //throw new Exception("Introduce un nombre valido");
            }
            else
            {
                Panel bloque = new Panel();

                Label nombre = new Label();
                nombre.Text = nombre_bloque.Text;
                nombre.Font = new Font("Arial", 24, FontStyle.Bold);
                nombre.Left = (this.Width - nombre.Width) / 2;
                nombre.AutoSize = true;

                Label id_bloque = new Label();
                id_bloque.Text = bloque_id.Text;
                id_bloque.Visible = false;

                bloque.Controls.Add(nombre);
                bloque.Controls.Add(id_bloque);

                bloque.BackColor = Color.FromArgb(255, 255, 255);
                bloque.Width = contenedor.Width - 40;
                bloque.Height = 300;
                bloque.Top = Convert.ToInt16(altura);
                bloque.Click += delegate (object send, EventArgs ea) { Controlador.mostrarBloque(sender, e, id_bloque.Text, nombre.Text); };
                contenedor.Controls.Add(bloque);

                ClaseBloque obloque = new ClaseBloque(nombre.Text, Convert.ToInt16(pagina_id.Text));

                bloque_id.Text = (Convert.ToInt16(bloque_id.Text) + 1).ToString();
                altura = altura + 305;

                BDBloques.insertarBloque(obloque);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bloque_id.Visible = false;
            pagina_id.Visible = false;

            WindowState = FormWindowState.Maximized;

            int idMaximo = BDBloques.buscarIdBloqueMax();

            listaBloques = BDBloques.buscarBloques(pagina_id.Text);

            if (listaBloques != null)
            {
                foreach (ClaseBloque obloque in listaBloques)
                {
                    Panel bloque = new Panel();

                    Label nombre = new Label();
                    nombre.Text = obloque.titulo;
                    nombre.Font = new Font("Arial", 24, FontStyle.Bold);
                    nombre.Left = (this.Width - nombre.Width) / 2;
                    nombre.AutoSize = true;

                    Label id_bloque = new Label();
                    id_bloque.Text = obloque.id.ToString();
                    id_bloque.Visible = false;

                    bloque.Controls.Add(nombre);
                    bloque.Controls.Add(id_bloque);

                    bloque.BackColor = Color.FromArgb(255, 255, 255);
                    bloque.Width = contenedor.Width - 40;
                    bloque.Height = 300;
                    bloque.Top = Convert.ToInt16(altura);
                    bloque.Click += delegate (object send, EventArgs ea) { Controlador.mostrarBloque(sender, e, id_bloque.Text, nombre.Text); };
                    contenedor.Controls.Add(bloque);

                    altura = altura + 305;
                }
                listaBloques.Clear();
            }
            else
            {
                listaBloques = new ArrayList();
            }

            bloque_id.Text = (idMaximo + 1).ToString();
        }
    }
}
