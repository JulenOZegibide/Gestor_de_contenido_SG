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
        //variables globales
        public static ArrayList listaBloques = new ArrayList();
        public static ArrayList listaPaginas = new ArrayList();
        int altura = 0;

        public Pagina(int paginaId, string nombrePagina)
        {
            InitializeComponent();

            //Para evitar que el usuario de la aplicacion cambie el tamaño de la pestaña
            this.FormBorderStyle = FormBorderStyle.None;
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
                //int paginaId = BDPaginas.buscarIdPagina(tituloPagina);
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

                bloque.Controls.Add(nombre);               

                bloque.BackColor = Color.FromArgb(255, 255, 255);
                bloque.Width = 1260;
                bloque.Height = 300;
                bloque.Top = Convert.ToInt16(altura);
                bloque.Left = 7;
                bloque.Click += delegate (object send, EventArgs ea) { Controlador.mostrarBloque(sender, e, nombre.Text); this.Hide(); };
                contenedor.Controls.Add(bloque);

                ClaseBloque obloque = new ClaseBloque(nombre.Text, Convert.ToInt16(pagina_id.Text));
               
                altura = altura + 305;

                BDBloques.insertarBloque(obloque);
                nombre_bloque.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarMenu();
        }

        private void borrarPagina_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Ten cuidado, al borrar esta pagina borraras todos los bloques con sus respectivas columnas y elementos que contiene, estas seguro de querer borrar esta pagina", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirmar == DialogResult.Yes)
            {
                BDPaginas.borrarPagina(pagina_id.Text);
                this.Close();             
            }
        }

        private void Pagina_Activated(object sender, EventArgs e)
        {
            pagina_id.Visible = false;
            altura = 0;

            //limpiar la lista de bloques y los bloques que contiene la pagina para evitar repetidos
            listaBloques.Clear();
            contenedor.Controls.Clear();

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
                    bloque.Width = 1260;
                    bloque.Height = 300;
                    bloque.Top = Convert.ToInt16(altura);
                    bloque.Left = 7;
                    bloque.Click += delegate (object send, EventArgs ea) { Controlador.mostrarBloque(sender, e, nombre.Text); this.Hide(); };
                    contenedor.Controls.Add(bloque);

                    altura = altura + 305;
                }
                listaBloques.Clear();
            }
            else
            {
                listaBloques = new ArrayList();
            }
        }
    }
}
