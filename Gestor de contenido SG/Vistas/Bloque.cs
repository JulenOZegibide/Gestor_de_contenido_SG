using Gestor_de_contenido_SG.Clases;
using Gestor_de_contenido_SG.FuncionesBD;
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
    public partial class Bloque : Form
    {
        //variables globales
        public static ArrayList listaColumnas = new ArrayList();
        private int altura = 50;
        private int contador;
        private int anchoTotal = 0;
        private int columnaAlta = 0;

        public Bloque(string titulo)
        {
            InitializeComponent();

            //metodos caracteristicos de esta pestaña
            WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(Controlador.volveraPagina);

            //buscar el id correspondiente a ese titulo
            int idBloque = BDBloques.buscarIdBloque(titulo);

            bloque_id.Text = idBloque.ToString();
            nombre_bloque.Text = titulo;

            //Para evitar que el usuario de la aplicacion cambie el tamaño de la pestaña
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void crear_columna_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nombre_columna.Text) || String.IsNullOrWhiteSpace(nombre_columna.Text))
            {
                MessageBox.Show("Introduce un nombre valido");
            }
            else
            {
                crearColumna();
                nombre_columna.Text = "";
            }
        }

        public void Form2_Load(object sender, EventArgs e)
        {

        }

        public void pintarBloques()
        {
            altura = 0;

            //limpiar la lista de columnas y las columnas que contiene el bloque para evitar repetidos
            listaColumnas.Clear();
            contenedor.Controls.Clear();

            //se rellena la lista de columnas desde base de datos para posteriormente recorrerla
            listaColumnas = BDColumnas.buscarColumnas(bloque_id.Text);

            if (listaColumnas != null)
            {
                foreach (ClaseColumna ocolumna in listaColumnas)
                {
                    //se crea la columna, aparte de funciones necesarias para el correcto funcionamiento
                    Panel panel1 = new Panel();

                    //propiedades para posicionar las columnas en horizontal y no en vertical ESTA SIN TERMINAR
                    if (anchoTotal + ocolumna.ancho < 1260)
                    {
                        panel1.Left = anchoTotal;
                        panel1.Top = altura;
                        anchoTotal += ocolumna.ancho;                       
                        if (ocolumna.alto > columnaAlta)
                        {
                            columnaAlta = ocolumna.alto;
                        }                           
                    }
                    else
                    {
                        anchoTotal = 0;
                        panel1.Top = altura + columnaAlta;
                        panel1.Left = anchoTotal;
                        anchoTotal += ocolumna.ancho;
                    }



                    //Propiedades que tendra la columna al ser creada
                    panel1.BorderStyle = BorderStyle.FixedSingle;
                    //panel1.Top = altura;
                    panel1.Name = "columna" + contador;
                    panel1.Size = new Size(ocolumna.ancho, ocolumna.alto);
                    panel1.MaximumSize = new Size(1260, 570);
                    panel1.MinimumSize = new Size(200, 100);
                    panel1.BackColor = Color.Transparent;

                    //caja de texto donde se guarda el nombre de la columna
                    Label nombre = new Label();
                    nombre.Text = ocolumna.titulo;
                    nombre.AutoSize = true;
                    nombre.Font = new Font("Arial", 22, FontStyle.Bold);
                    nombre.Location = new Point(30, 30);
                    nombre.Visible = false;

                    panel1.Controls.Add(nombre);

                    this.Controls.Add(panel1);

                    contenedor.Controls.Add(panel1);

                    contador++;

                    //rellena la lista de elementos desde base de datos para posteriormente recorrela
                    Columna.listaElementos = BDElementos.buscarElementos(ocolumna.id.ToString());
                    if (Columna.listaElementos != null)
                    {
                        int alturaelementos = 30;

                        foreach (ClaseElemento oelemento in Columna.listaElementos)
                        {
                            string tipo = oelemento.tipo;

                            switch (tipo)
                            {
                                case "img":

                                    PictureBox imagen = new PictureBox();
                                    imagen.Image = Image.FromFile(@"..\..\ImagenesBD\\" + oelemento.contenido);

                                    Bitmap img = new Bitmap(Image.FromFile(@"..\..\ImagenesBD\\" + oelemento.contenido));

                                    var imageHeight = img.Height;
                                    var imageWidth = img.Width;

                                    //propiedades de la imagen
                                    imagen.Top = oelemento.espacio_arriba;
                                    imagen.Left = oelemento.espacio_izquierda;
                                    imagen.Name = oelemento.id.ToString();
                                    imagen.MaximumSize = new Size(panel1.Width, 500);
                                    imagen.Size = new Size(imageWidth, imageHeight);
                                    imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                                    imagen.Width = oelemento.ancho;

                                    panel1.Controls.Add(imagen);

                                    alturaelementos += imagen.Height;
                                    break;

                                case "video":
                                    PictureBox video = new PictureBox();
                                    video.Image = Image.FromFile(@"..\..\Imagenes\play.png");

                                    //propiedades del video
                                    video.Top = oelemento.espacio_arriba;
                                    video.Left = oelemento.espacio_izquierda;
                                    video.Name = oelemento.id.ToString();
                                    video.BorderStyle = BorderStyle.FixedSingle;
                                    video.SizeMode = PictureBoxSizeMode.CenterImage;
                                    video.MaximumSize = new Size(panel1.Width, 500);
                                    video.MinimumSize = new Size(240, 135);
                                    video.Width = oelemento.ancho;
                                    video.Height = oelemento.ancho / 2;

                                    panel1.Controls.Add(video);

                                    alturaelementos += video.Height;
                                    break;

                                case "p":
                                    Label parrafo = new Label();
                                    parrafo.Text = oelemento.contenido;

                                    //propiedades del parrafo
                                    parrafo.Top = oelemento.espacio_arriba;
                                    parrafo.Left = oelemento.espacio_izquierda;
                                    parrafo.Name = oelemento.id.ToString();
                                    parrafo.MaximumSize = new Size(oelemento.ancho, 300);
                                    parrafo.MinimumSize = new Size(10, 10);
                                    parrafo.AutoSize = true;
                                    parrafo.Width = oelemento.ancho;

                                    panel1.Controls.Add(parrafo);

                                    alturaelementos += parrafo.Height;
                                    break;

                                case "title":
                                    Label titulo = new Label();
                                    titulo.Text = oelemento.contenido;

                                    //propiedades del titulo
                                    titulo.Top = oelemento.espacio_arriba;
                                    titulo.Left = oelemento.espacio_izquierda;
                                    titulo.Name = oelemento.id.ToString();
                                    titulo.AutoSize = true;
                                    titulo.Font = new Font("Arial", 16);
                                    titulo.MaximumSize = new Size(panel1.Width, 300);
                                    titulo.MinimumSize = new Size(10, 10);
                                    titulo.Width = oelemento.ancho;

                                    panel1.Controls.Add(titulo);

                                    alturaelementos += titulo.Height;
                                    break;
                            }
                        }
                        Columna.listaElementos.Clear();
                    }
                    else
                    {
                        Columna.listaElementos = new ArrayList();
                    }
                    panel1.MinimumSize = new Size(200, panel1.Height);

                    //añade un evento cuando se hace click sobre una columna
                    panel1.Click += delegate (object send, EventArgs ea) { Controlador.mostrarColumna(send, ea, ocolumna.titulo, panel1.Width, panel1.Height); Hide(); };
                    for (int x = 0; x < panel1.Controls.Count; x++)
                    {
                        panel1.Controls[x].Click += delegate (object send, EventArgs ea) { Controlador.mostrarColumna(send, ea, ocolumna.titulo, panel1.Width, panel1.Height); Hide(); };
                    }

                    //altura += panel1.Height + 20;
                }
                listaColumnas.Clear();
            }
            else
            {
                listaColumnas = new ArrayList();
            }
        }

        public int calcularAltura(Label texto)
        {
            Graphics g = texto.CreateGraphics();
            return Convert.ToInt16(g.MeasureString(texto.Text, texto.Font).Width);
        }

        private void crearColumna()
        {
            //se crea la columna y el elemento que le permite cambiar de tamaño, aparte de funciones necesarias para el correcto funcionamiento
            Panel panel1 = new Panel();

            //caja de texto donde se guarda el nombre de la columna
            Label nombre = new Label();
            nombre.Text = nombre_columna.Text;
            nombre.AutoSize = true;
            nombre.Font = new Font("Arial", 22, FontStyle.Bold);
            nombre.Location = new Point(30, 30);
            nombre.Visible = false;

            panel1.Controls.Add(nombre);

            //Propiedades que tendra la columna al ser creada
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Top = altura;
            panel1.Name = "columna" + contador;
            panel1.Size = new Size(200, 160);
            panel1.AutoSize = true;
            panel1.MaximumSize = new Size(contenedor.Width, 1500);
            panel1.MinimumSize = new Size(200, 160);

            //crear objeto de la clase columna 
            ClaseColumna ocolumna = new ClaseColumna(nombre.Text, panel1.Width, Convert.ToInt16(bloque_id.Text), 160);

            this.Controls.Add(panel1);

            //añade un evento cuando se hace click sobre una columna
            panel1.Click += delegate (object send, EventArgs ea) { Controlador.mostrarColumna(send, ea, nombre.Text, panel1.Width, panel1.Height); Hide(); };

            contenedor.Controls.Add(panel1);

            altura += panel1.Height + 20;

            contador++;

            BDColumnas.insertarColumna(ocolumna);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Hide();
            Controlador.mostrarPagina();
        }

        private void borrarBloque_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Ten cuidado, al borrar este bloque borraras todas las columnas con sus respectivos elementos que contiene, estas seguro de querer borrar este bloque", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirmar == DialogResult.Yes)
            {
                BDBloques.borrarBloque(bloque_id.Text);
                this.Close();
            }
        }

        private void Bloque_Activated(object sender, EventArgs e)
        {
            pintarBloques();
        }
    }
}
