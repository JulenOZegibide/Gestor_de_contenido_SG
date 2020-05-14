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
        private int contador;
        Panel contenedor;

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

            //tamaño del contenedor grande
            contenedorGrande.Size = new Size(1364,708);

            //tamaño del contenedor pequeño
            contenedor = new Panel();
            contenedor.Size = new Size(1260, 708);
            contenedor.MaximumSize = new Size(1260, 3000);
            contenedor.Left = 53;
            contenedor.AutoSize = true;

            contenedorGrande.Controls.Add(contenedor);
        }

        private void crear_columna_Click(object sender, EventArgs e)
        {
            //si el campo nombre_columna no esta vacio se creara la columna
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

        public enum Direction
        {
            Any,
            Horizontal,
            Vertical
        }

        //primera parte de la funcion para que un elemento se pueda mover
        public void controlMovible(Control control)
        {
            controlMovible(control, Direction.Any);
        }

        //segunda parte de la funcion para que una columna se pueda mover
        public void controlMovible(Control control, Direction direction)
        {
            controlMovible(control, control, direction);
        }

        //tercera parte de la funcion para que una columna se pueda mover
        public void controlMovible(Control control, Control container, Direction direction)
        {
            bool Dragging = false;
            Point DragStart = Point.Empty;

            //funcion para cuando clickas sobre la columna para modificar la posicion del elemento
            control.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                Dragging = true;
                DragStart = new Point(e.X, e.Y);
                control.Capture = true;
            };

            //funcion para cuando se deja de clickar sobre la columna para modificar la posicion del elemento
            control.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                Dragging = false;
                control.Capture = false;

                BDColumnas.actualizarPosicion(control.Left, control.Top, control.Controls[0].Text.ToString());
            };

            //funcion que al estar clickando permite modificar la posicion de la columna
            control.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                //hacer que la columna que se quiere mover se site sobre el resto
                control.BringToFront();

                //metodo para que el elemento no pueda sobrepasar el ancho del contenedor de la columna
                container = (Control)sender;
                Rectangle panelcontenedor = container.Parent.ClientRectangle;

                if (Dragging)
                {
                    if (direction != Direction.Vertical)
                        control.Left = Math.Min(Math.Max(0, e.X + control.Left - DragStart.X), panelcontenedor.Right - container.Width);

                    if (direction != Direction.Horizontal)
                        control.Top = Math.Max(0, e.Y + control.Top - DragStart.Y);
                }
            };
        }

        public void pintarBloques()
        {
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

                    //Propiedades que tendra la columna al ser creada
                    panel1.BorderStyle = BorderStyle.FixedSingle;
                    panel1.Name = "columna" + contador;
                    panel1.Size = new Size(ocolumna.ancho, ocolumna.alto);

                    if (ocolumna.ancho + ocolumna.espacio_izquierda > 1260)
                    {
                        int espacioNuevo = 1260 - ocolumna.ancho;
                        panel1.Left = espacioNuevo;
                        BDColumnas.actualizarPosicion(espacioNuevo, ocolumna.espacio_arriba, ocolumna.titulo);
                    }
                    else
                    { 
                        panel1.Left = ocolumna.espacio_izquierda;
                    }
                    
                    panel1.Top = ocolumna.espacio_arriba;
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
                                    imagen.Size = new Size(imageWidth, imageHeight);
                                    imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                                    imagen.Width = oelemento.ancho;
                                    imagen.Height = oelemento.alto;
                                    imagen.Enabled = false;

                                    panel1.Controls.Add(imagen);
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
                                    video.Width = oelemento.ancho;
                                    video.Height = oelemento.alto;
                                    video.Enabled = false;

                                    panel1.Controls.Add(video);
                                    break;

                                case "p":
                                    Label parrafo = new Label();
                                    parrafo.Text = oelemento.contenido;

                                    //propiedades del parrafo
                                    parrafo.Top = oelemento.espacio_arriba;
                                    parrafo.Left = oelemento.espacio_izquierda;
                                    parrafo.Name = oelemento.id.ToString();
                                    parrafo.Width = oelemento.ancho;
                                    parrafo.Height = oelemento.alto;
                                    parrafo.Enabled = false;

                                    panel1.Controls.Add(parrafo);
                                    break;

                                case "title":
                                    Label titulo = new Label();
                                    titulo.Text = oelemento.contenido;

                                    //propiedades del titulo
                                    titulo.Top = oelemento.espacio_arriba;
                                    titulo.Left = oelemento.espacio_izquierda;
                                    titulo.Name = oelemento.id.ToString();
                                    titulo.Font = new Font("Arial", 16);
                                    titulo.Width = oelemento.ancho;
                                    titulo.Height = oelemento.alto;
                                    titulo.Enabled = false;

                                    panel1.Controls.Add(titulo);
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
                    panel1.DoubleClick += delegate (object send, EventArgs ea) { Controlador.mostrarColumna(send, ea, ocolumna.titulo, panel1.Width, panel1.Height); Hide(); };
                    controlMovible(panel1);
                }
                listaColumnas.Clear();
            }
            else
            {
                listaColumnas = new ArrayList();
            }
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
            panel1.Top = 30;
            panel1.Name = "columna" + contador;
            panel1.Size = new Size(200, 160);
            panel1.AutoSize = true;
            panel1.MaximumSize = new Size(contenedor.Width, 1500);
            panel1.MinimumSize = new Size(200, 160);

            //crear objeto de la clase columna 
            ClaseColumna ocolumna = new ClaseColumna(nombre.Text, panel1.Width, Convert.ToInt16(bloque_id.Text), 160, 0, 0);

            this.Controls.Add(panel1);

            contenedor.Controls.Add(panel1);

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
            //ventana para confirmar que se quiere borrar el bloque
            DialogResult confirmar = MessageBox.Show("Ten cuidado, al borrar este bloque borraras todas las columnas con sus respectivos elementos que contiene, estas seguro de querer borrar este bloque", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //si a la ventana de confirmar se le responde con un si se borrara el bloque de base de datos
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
