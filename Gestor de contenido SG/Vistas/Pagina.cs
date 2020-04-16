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

            WindowState = FormWindowState.Maximized;

            //se rellenan las etiquetas con el nombre y el id de la pagina
            nombre_pagina.Text = nombrePagina;
            pagina_id.Text = paginaId.ToString();

            //funcion que se llama al cerrar la ventana
            this.FormClosing += new FormClosingEventHandler(Controlador.cerrarPaginaActual);
        }

        public static void crearPagina(string tituloPagina, int circuitoId)
        {   
            //si el texto del titulo de la pagina no esta vacio se inserta en la base de datos y se muestra esa pagina
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
            //si el texto del nombre del bloque no esta vacio se pinta en la pagina y se inserta en base datos
            if (String.IsNullOrEmpty(nombre_bloque.Text) || String.IsNullOrWhiteSpace(nombre_bloque.Text))
            {
                MessageBox.Show("Introduce un nombre valido");
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
                bloque.Click += delegate (object send, EventArgs ea) { Controlador.mostrarBloque(sender, e, id_bloque.Text, nombre.Text); this.Hide(); };
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

            //se busca el id de bloque maximo en base de datos para la hora de crear un nuevo bloque dicho bloque lleve la etiqueta con el id correspondiente
            int idMaximo = BDBloques.buscarIdBloqueMax();

            //se rellena la lista de bloques desde base de datos
            listaBloques = BDBloques.buscarBloques(pagina_id.Text);

            //si la lista de bloques no esta vacia se recorre dicha lista y se pintan los diferentes bloques en la pagina
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
                    bloque.Click += delegate (object send, EventArgs ea) { Controlador.mostrarBloque(sender, e, id_bloque.Text, nombre.Text); this.Hide(); };
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

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarMenu();
        }
    }
}
