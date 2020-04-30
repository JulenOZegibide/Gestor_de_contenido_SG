using Gestor_de_contenido_SG.Clases;
using Gestor_de_contenido_SG.FuncionesBD;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_contenido_SG
{
    public partial class Columna : Form
    {
        //variables globales
        public static ArrayList listaElementos = new ArrayList();
        private int altura;
        public static int espacioArriba;
        public static int espacioIzquierda;
        bool allowResize = false;
        PictureBox bordeInferior;
        PictureBox bordeDerecho;
        bool posibleBorrar = true;

        public Columna(string titulo, int anchoColumna, int altoColumna)
        {
            InitializeComponent();

            //funcion que se llama al cerrar la ventana
            this.FormClosing += new FormClosingEventHandler(Controlador.volveraBloque);

            //buscar el id correspondiente a ese titulo
            int idColumna = BDColumnas.buscarIdColumna(titulo);

            //rellena con el id de la columna y su nombre sus respectivos label
            columna_id.Text = idColumna.ToString();
            nombre_columna.Text = titulo;

            //asigna el ancho y alto del contenedor
            contenedorColumna.Width = anchoColumna;
            contenedorColumna.Height = altoColumna;
            contenedorColumna.Left = 53;

            //Para evitar que el usuario de la aplicacion cambie el tamaño de la pestaña
            this.FormBorderStyle = FormBorderStyle.None;

            //asignar tamaño maximo para el contenedor
            contenedorColumna.MaximumSize = new Size(1260, 570);
            contenedorColumna.MinimumSize = new Size(20, 20);

            //imagenes que permiten cambiar el ancho y el alto del contenedor de la columna
            bordeInferior = new PictureBox();
            bordeInferior.BackColor = Color.Aquamarine;
            //bordeInferior.Width = contenedorColumna.Width;
            bordeInferior.MinimumSize = new Size(1260, 20);
            bordeInferior.AutoSize = false;
            bordeInferior.Height = 20;
            bordeInferior.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Bottom)));
            bordeInferior.Cursor = Cursors.SizeNS;
            bordeInferior.Top = contenedorColumna.Height - 10;

            bordeDerecho = new PictureBox();
            bordeDerecho.BackColor = Color.Aquamarine;
            bordeDerecho.Width = 20;
            //bordeDerecho.Height = contenedorColumna.Height;
            bordeDerecho.MinimumSize = new Size(20, 570);
            bordeDerecho.AutoSize = false;
            bordeDerecho.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
            bordeDerecho.Cursor = Cursors.SizeWE;
            bordeDerecho.Left = contenedorColumna.Width - 10;


            contenedorColumna.Controls.Add(bordeInferior);
            contenedorColumna.Controls.Add(bordeDerecho);
            cambiarAncho(bordeDerecho, contenedorColumna);
            cambiarAlto(bordeInferior, contenedorColumna);
        }

        public enum Direction
        {
            Any,
            Horizontal,
            Vertical
        }

        public void controlMovible(Control control)
        {
            controlMovible(control, Direction.Any);
        }

        public void controlMovible(Control control, Direction direction)
        {
            controlMovible(control, control, direction);
        }

        public void controlMovible(Control control, Control container, Direction direction)
        {
            bool Dragging = false;
            Point DragStart = Point.Empty;
            control.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                Dragging = true;
                DragStart = new Point(e.X, e.Y);
                control.Capture = true;
            };
            control.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                Dragging = false;
                control.Capture = false;

                //regla de 3 para pasar el ancho de pixeles a porcentaje
                espacioIzquierda = (100 * container.Left) / contenedorColumna.Width;
                espacioArriba = (100 * container.Top) / contenedorColumna.Height;

                BDElementos.actualizarPosicion(espacioIzquierda, espacioArriba, Convert.ToInt16(container.Name));
            };
            control.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                //metodo para que el elemento no pueda sobrepasar el ancho del contenedor de la columna
                container = (Control)sender;
                Rectangle panelcontenedor = container.Parent.ClientRectangle;

                if (Dragging)
                {
                    if (direction != Direction.Vertical)
                        container.Left = Math.Min(Math.Max(0, e.X + container.Left - DragStart.X), panelcontenedor.Right - container.Width);

                    if (direction != Direction.Horizontal)
                        container.Top = Math.Min(Math.Max(0, e.Y + container.Top - DragStart.Y), panelcontenedor.Bottom - container.Height);
                }
            };
        }

        public void cambiarAlto(PictureBox bordeInferior, Panel columna)
        {
            bool aumentarAlto = false;

            bordeInferior.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                aumentarAlto = true;
            };
            bordeInferior.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                aumentarAlto = false;
                //columna.AutoSize = true;
                MessageBox.Show(columna.Height.ToString());
                BDColumnas.actualizarAlto(columna.Height, Convert.ToInt16(columna_id.Text));
            };
            bordeInferior.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (aumentarAlto)
                {
                    columna.Height = bordeInferior.Top + e.Y;
                    columna.AutoSize = false;
                }
            };
        }

        public void cambiarAncho(PictureBox bordeDerecho, Panel columna)
        {
            bool aumentarAncho = false;

            bordeDerecho.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                aumentarAncho = true;
                //columna.AutoSize = true;
            };
            bordeDerecho.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                aumentarAncho = false;

                //calcular ancho en porcentaje,usando la regla de 3
                int anchoColumna = (100 * columna.Width) / 1260;

                MessageBox.Show(anchoColumna.ToString());
                BDColumnas.actualizarAncho(anchoColumna, Convert.ToInt16(columna_id.Text));
            };
            bordeDerecho.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                if (aumentarAncho)
                {
                    columna.Width = bordeDerecho.Left + e.X;
                    columna.AutoSize = false;
                }
            };
        }
        //funcion para cuando clickas en el lateral para modificar el ancho de la columna
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e, Control elemento)
        {
            allowResize = true;
        }

        //funcion para cuando se deja de clickar en el lateral para modificar el ancho de la columna
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e, Control elemento, ClaseElemento oelemento)
        {
            allowResize = false;

            //calcular ancho  del elemento en porcentaje,usando la regla de 3
            int ancho = (100 * elemento.Width) / contenedorColumna.Width;

            //actualizar el valor del ancho del elemento en base de datos            
            BDElementos.actualizarAncho(ancho, Convert.ToInt16(elemento.Name));

            //calcular ancho  del elemento en porcentaje,usando la regla de 3
            int anchoColumna = (100 * contenedorColumna.Width) / 1260;
        }

        //funcion que al estar clickando permite modificar el ancho de la columna
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e, Control elemento, PictureBox pictureBox1)
        {
            /*elemento = (Control)sender;
            Rectangle panelcontenedor = elemento.Parent.ClientRectangle;*/

            if (allowResize)
            {
                //elemento.Height = pictureBox1.Top + e.Y;
                //elemento.Width = Math.Min(Math.Max(0, e.X + pictureBox1.Left + e.X), panelcontenedor.Right - pictureBox1.Width);

                elemento.Width = pictureBox1.Left + e.X;
                elemento.Height = pictureBox1.Top + e.Y;

                elemento.AutoSize = false;
            }
        }

        public int calcularAltura(Label texto)
        {
            Graphics g = texto.CreateGraphics();
            return Convert.ToInt16(g.MeasureString(texto.Text, texto.Font).Width);
        }

        private void Columna_Load(object sender, EventArgs e)
        {
            //busca el id maximo de todas los elementos para a la hora de insertar un elemento tenga como nombre el id
            int idMaximo = BDElementos.buscarIdElementoMax();

            //rellena la lista de elementos desde base de datos para posteriormente recorrela
            listaElementos = BDElementos.buscarElementos(columna_id.Text);
            if (listaElementos != null)
            {
                foreach (ClaseElemento oelemento in listaElementos)
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

                            //regla de 3 para pasar de % a pixeles
                            int anchoEnPixelesImg = (oelemento.ancho * contenedorColumna.Width) / 100;

                            //regla de 3 para pasar la posicion de % a pixeles
                            int izquierdaPixelesImagen = (oelemento.espacio_izquierda * contenedorColumna.Width) / 100;
                            int arribaPixelesImagen = (oelemento.espacio_arriba * contenedorColumna.Height) / 100;

                            //propiedades de la imagen
                            imagen.Top = arribaPixelesImagen;
                            imagen.Left = izquierdaPixelesImagen;
                            imagen.Name = oelemento.id.ToString();
                            imagen.BorderStyle = BorderStyle.FixedSingle;
                            imagen.MaximumSize = new Size(contenedorColumna.Width, 500);
                            //imagen.AutoSize = true;
                            imagen.Size = new Size(imageWidth, imageHeight);
                            imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                            imagen.Width = anchoEnPixelesImg;

                            //elemento para poder cambiar el tamaño de la imagen
                            PictureBox pictureBox1 = new PictureBox();
                            pictureBox1.BackColor = Color.DarkRed;
                            //pictureBox1.Height = imagen.Height;
                            pictureBox1.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                            pictureBox1.Cursor = Cursors.SizeNWSE;
                            pictureBox1.Left = imagen.Width - 10;
                            pictureBox1.Top = imagen.Height - 10;
                            pictureBox1.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, imagen); };
                            pictureBox1.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, imagen, pictureBox1); };
                            pictureBox1.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, imagen, oelemento); };

                            imagen.Controls.Add(pictureBox1);

                            //Añadir la imagen al panel
                            contenedorColumna.Controls.Add(imagen);

                            controlMovible(imagen);
                            break;

                        case "video":
                            PictureBox video = new PictureBox();
                            video.Image = Image.FromFile(@"..\..\Imagenes\play.png");

                            //regla de 3 para pasar de % a pixeles
                            int anchoEnPixelesVideo = (oelemento.ancho * contenedorColumna.Width) / 100;

                            //regla de 3 para pasar la posicion de % a pixeles
                            int izquierdaPixelesVideo = (oelemento.espacio_izquierda * contenedorColumna.Width) / 100;
                            int arribaPixelesVideo = (oelemento.espacio_arriba * contenedorColumna.Height) / 100;

                            //propiedades del video
                            video.Top = arribaPixelesVideo;
                            video.Left = izquierdaPixelesVideo;
                            video.Name = oelemento.id.ToString();
                            video.BorderStyle = BorderStyle.FixedSingle;
                            video.SizeMode = PictureBoxSizeMode.CenterImage;
                            video.MaximumSize = new Size(contenedorColumna.Width, 500);
                            video.MinimumSize = new Size(240, 135);
                            video.Width = anchoEnPixelesVideo;
                            video.Height = anchoEnPixelesVideo / 2;

                            //elemento para poder cambiar el tamaño de la imagen
                            PictureBox pictureBox2 = new PictureBox();
                            pictureBox2.BackColor = Color.DarkRed;
                            pictureBox2.Height = video.Height;
                            pictureBox2.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                            pictureBox2.Cursor = Cursors.SizeNWSE;
                            pictureBox2.Left = video.Width - 10;
                            pictureBox2.Top = video.Height - 10;
                            pictureBox2.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, video); };
                            pictureBox2.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, video, pictureBox2); };
                            pictureBox2.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, video, oelemento); };

                            video.Controls.Add(pictureBox2);

                            //Añadir la imagen al panel
                            contenedorColumna.Controls.Add(video);

                            controlMovible(video);
                            break;

                        case "p":
                            Label parrafo = new Label();
                            parrafo.Text = oelemento.contenido;

                            //regla de 3 para pasar de % a pixeles
                            int anchoEnPixelesParrafo = (oelemento.ancho * contenedorColumna.Width) / 100;

                            //regla de 3 para pasar la posicion de % a pixeles
                            int izquierdaPixelesParrafo = (oelemento.espacio_izquierda * contenedorColumna.Width) / 100;
                            int arribaPixelesParrafo = (oelemento.espacio_arriba * contenedorColumna.Height) / 100;

                            //propiedades del parrafo
                            parrafo.Top = arribaPixelesParrafo;
                            parrafo.Left = izquierdaPixelesParrafo;
                            parrafo.Name = oelemento.id.ToString();
                            parrafo.BorderStyle = BorderStyle.FixedSingle;
                            parrafo.MaximumSize = new Size(contenedorColumna.Width, 300);
                            parrafo.MinimumSize = new Size(10, 10);
                            parrafo.Width = anchoEnPixelesParrafo;
                            parrafo.Height = calcularAltura(parrafo);

                            //elemento para poder cambiar el tamaño de la imagen
                            PictureBox pictureBox3 = new PictureBox();
                            pictureBox3.BackColor = Color.DarkRed;
                            pictureBox3.Height = parrafo.Height;
                            pictureBox3.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                            pictureBox3.Cursor = Cursors.SizeNWSE;
                            pictureBox3.Left = parrafo.Width - 10;
                            pictureBox3.Top = parrafo.Height - 10;
                            pictureBox3.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, parrafo); };
                            pictureBox3.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, parrafo, pictureBox3); };
                            pictureBox3.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, parrafo, oelemento); };

                            parrafo.Controls.Add(pictureBox3);

                            //Añadir la imagen al panel
                            contenedorColumna.Controls.Add(parrafo);

                            controlMovible(parrafo);
                            break;

                        case "title":
                            Label titulo = new Label();
                            titulo.Text = oelemento.contenido;

                            //regla de 3 para pasar el ancho de % a pixeles
                            int anchoEnPixelesTitulo = (oelemento.ancho * contenedorColumna.Width) / 100;

                            //regla de 3 para pasar la posicion de % a pixeles
                            int izquierdaPixelesTitulo = (oelemento.espacio_izquierda * contenedorColumna.Width) / 100;
                            int arribaPixelesTitulo = (oelemento.espacio_arriba * contenedorColumna.Height) / 100;

                            //propiedades del titulo
                            titulo.Top = arribaPixelesTitulo;
                            titulo.Left = izquierdaPixelesTitulo;
                            titulo.Name = oelemento.id.ToString();
                            titulo.BorderStyle = BorderStyle.FixedSingle;
                            titulo.AutoSize = true;
                            titulo.Font = new Font("Arial", 16);
                            titulo.MaximumSize = new Size(contenedorColumna.Width, 300);
                            titulo.MinimumSize = new Size(10, 10);
                            titulo.Width = anchoEnPixelesTitulo;

                            //elemento para poder cambiar el tamaño de la imagen
                            PictureBox pictureBox4 = new PictureBox();
                            pictureBox4.BackColor = Color.DarkRed;
                            pictureBox4.Height = titulo.Height;
                            pictureBox4.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                            pictureBox4.Cursor = Cursors.SizeNWSE;
                            pictureBox4.Left = titulo.Width - 10;
                            pictureBox4.Top = titulo.Height - 10;
                            pictureBox4.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, titulo); };
                            pictureBox4.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, titulo, pictureBox4); };
                            pictureBox4.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, titulo, oelemento); };

                            titulo.Controls.Add(pictureBox4);

                            //Añadir la imagen al panel
                            contenedorColumna.Controls.Add(titulo);

                            controlMovible(titulo);
                            break;
                    }
                }
                listaElementos.Clear();
            }
            else
            {
                listaElementos = new ArrayList();
            }

            elemento_id.Text = (idMaximo + 1).ToString();
        }

        private void insertarImagen_Click(object sender, EventArgs e)
        {
            PictureBox imagen = new PictureBox();

            OpenFileDialog dialogoBuscarArchivo = new OpenFileDialog();

            //Se crean las opciones de busqueda
            dialogoBuscarArchivo.InitialDirectory = "c:\\";
            dialogoBuscarArchivo.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; *.bmp)|*.jpg; *.jpeg; *.gif; *.png; *.bmp";

            //el ShowDialog() muestra el explorador de archivos para que elijas tu archivo. 
            //Cuando le das click a "Aceptar" se devuelve DialogResult.OK 
            //y si das click a "Cancelar" se devuelve una DialogResult.Cancel
            //Si fue un OK, entonces suponemos que hay un archivo. Intentamos abrirlo
            if (dialogoBuscarArchivo.ShowDialog() == DialogResult.OK)
            {
                Bitmap img = new Bitmap(dialogoBuscarArchivo.FileName);

                var imageHeight = img.Height;
                var imageWidth = img.Width;

                //propiedades de la imagen
                imagen.Image = new Bitmap(dialogoBuscarArchivo.FileName);
                imagen.Name = elemento_id.Text;
                imagen.Top = altura;
                imagen.AutoSize = true;
                imagen.MaximumSize = new Size(contenedorColumna.Width, 500);
                imagen.Size = new Size(imageWidth, imageHeight);
                imagen.SizeMode = PictureBoxSizeMode.StretchImage;

                //imagen.Location = new Point((contenedorColumna.Width / 2) - (imagen.Width / 2), altura);

                //Guardar imagen en la carpeta ImagenesBD
                imagen.Image.Save(@"..\..\ImagenesBD\\" + dialogoBuscarArchivo.SafeFileName);

                //calcular ancho en porcentaje,usando la regla de 3
                int ancho = (100 * imagen.Width) / contenedorColumna.Width;

                //calcular altura en porcentaje,usando la regla de 3
                int porcentajealtura = (100 * altura) / contenedorColumna.Height;

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("img", dialogoBuscarArchivo.SafeFileName, Convert.ToInt16(columna_id.Text), ancho, 0, porcentajealtura);
                BDElementos.insertarElemento(oelemento);

                //elemento para poder cambiar el tamaño de la imagen
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.BackColor = Color.DarkRed;
                pictureBox1.Height = imagen.Height;
                pictureBox1.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                pictureBox1.Cursor = Cursors.SizeNWSE;
                pictureBox1.Left = imagen.Width - 10;
                pictureBox1.Top = imagen.Height - 10;
                pictureBox1.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, imagen); };
                pictureBox1.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, imagen, pictureBox1); };
                pictureBox1.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, imagen, oelemento); };

                imagen.Controls.Add(pictureBox1);

                //Añadir la imagen al panel
                contenedorColumna.Controls.Add(imagen);

                elemento_id.Text = (Convert.ToInt16(elemento_id.Text) + 1).ToString();

                controlMovible(imagen);
            }
        }

        private void insertarVideo_Click(object sender, EventArgs e)
        {
            string url = Interaction.InputBox("Introduce la url del video que quieres insertar", "Video", "");
            if (String.IsNullOrEmpty(url) || String.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("Introduce una url valida");
            }
            else
            {
                PictureBox video = new PictureBox();

                //propiedades del video
                video.Image = Image.FromFile(@"..\..\Imagenes\play.png");
                video.Top = altura;
                video.Name = elemento_id.Text;
                video.AutoSize = true;
                video.BorderStyle = BorderStyle.FixedSingle;
                video.SizeMode = PictureBoxSizeMode.CenterImage;
                video.MaximumSize = new Size(contenedorColumna.Width, 500);
                video.MinimumSize = new Size(480, 270);

                //calcular ancho en porcentaje,usando la regla de 3
                int ancho = (100 * video.Width) / contenedorColumna.Width;

                //calcular altura en porcentaje,usando la regla de 3
                int porcentajealtura = (100 * altura) / contenedorColumna.Height;

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("video", url, Convert.ToInt16(columna_id.Text), ancho, 0, porcentajealtura);
                BDElementos.insertarElemento(oelemento);

                //elemento para poder cambiar el tamaño de la imagen
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.BackColor = Color.DarkRed;
                pictureBox1.Height = video.Height;
                pictureBox1.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                pictureBox1.Cursor = Cursors.SizeNWSE;
                pictureBox1.Left = video.Width - 10;
                pictureBox1.Top = video.Height - 10;
                pictureBox1.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, video); };
                pictureBox1.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, video, pictureBox1); };
                pictureBox1.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, video, oelemento); };

                video.Controls.Add(pictureBox1);

                //Añadir la imagen al panel
                contenedorColumna.Controls.Add(video);

                altura += video.Height;

                elemento_id.Text = (Convert.ToInt16(elemento_id.Text) + 1).ToString();

                controlMovible(video);
            }
        }

        private void insertarParrafo_Click(object sender, EventArgs e)
        {
            string textoParrafo = Interaction.InputBox("Introduce el parrafo que quieres insertar", "Parrafo", "");
            if (String.IsNullOrEmpty(textoParrafo) || String.IsNullOrWhiteSpace(textoParrafo))
            {
                MessageBox.Show("Introduce un nombre valido");
            }
            else
            {
                Label parrafo = new Label();

                //propiedades del parrafo
                parrafo.Text = textoParrafo;
                parrafo.Top = altura;
                parrafo.Name = elemento_id.Text;
                parrafo.AutoSize = true;
                parrafo.MaximumSize = new Size(contenedorColumna.Width, 300);
                parrafo.MinimumSize = new Size(10, 10);

                //calcular ancho en porcentaje,usando la regla de 3
                int ancho = (100 * parrafo.Width) / contenedorColumna.Width;

                //calcular altura en porcentaje,usando la regla de 3
                int porcentajealtura = (100 * altura) / contenedorColumna.Height;

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("p", textoParrafo, Convert.ToInt16(columna_id.Text), ancho, 0, porcentajealtura);
                BDElementos.insertarElemento(oelemento);

                //elemento para poder cambiar el tamaño de la imagen
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.BackColor = Color.DarkRed;
                pictureBox1.Height = parrafo.Height;
                pictureBox1.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                pictureBox1.Cursor = Cursors.SizeNWSE;
                pictureBox1.Left = parrafo.Width - 10;
                pictureBox1.Top = parrafo.Height - 10;
                pictureBox1.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, parrafo); };
                pictureBox1.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, parrafo, pictureBox1); };
                pictureBox1.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, parrafo, oelemento); };

                parrafo.Controls.Add(pictureBox1);

                //Añadir la imagen al panel
                contenedorColumna.Controls.Add(parrafo);

                elemento_id.Text = (Convert.ToInt16(elemento_id.Text) + 1).ToString();

                controlMovible(parrafo);
            }
        }

        private void insertarTitulo_Click(object sender, EventArgs e)
        {
            string textoTitulo = Interaction.InputBox("Introduce el titulo que quieres insertar", "Titulo", "");
            if (String.IsNullOrEmpty(textoTitulo) || String.IsNullOrWhiteSpace(textoTitulo))
            {
                MessageBox.Show("Introduce un nombre valido");
            }
            else
            {
                Label titulo = new Label();

                //propiedades del titulo
                titulo.Text = textoTitulo;
                titulo.Top = altura;
                titulo.Name = elemento_id.Text;
                titulo.AutoSize = true;
                titulo.Font = new Font("Arial", 16);
                titulo.MaximumSize = new Size(contenedorColumna.Width, 300);
                titulo.MinimumSize = new Size(10, 10);

                //calcular ancho en porcentaje,usando la regla de 3
                int ancho = (100 * titulo.Width) / contenedorColumna.Width;

                //calcular altura en porcentaje,usando la regla de 3
                int porcentajealtura = (100 * altura) / contenedorColumna.Height;

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("title", textoTitulo, Convert.ToInt16(columna_id.Text), ancho, 0, porcentajealtura);
                BDElementos.insertarElemento(oelemento);

                //elemento para poder cambiar el tamaño de la imagen
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.BackColor = Color.DarkRed;
                pictureBox1.Height = titulo.Height;
                pictureBox1.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Bottom)));
                pictureBox1.Cursor = Cursors.SizeNWSE;
                pictureBox1.Left = titulo.Width - 10;
                pictureBox1.Top = titulo.Height - 10;
                pictureBox1.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, titulo); };
                pictureBox1.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, titulo, pictureBox1); };
                pictureBox1.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, titulo, oelemento); };

                titulo.Controls.Add(pictureBox1);

                //Añadir la imagen al panel
                contenedorColumna.Controls.Add(titulo);

                elemento_id.Text = (Convert.ToInt16(elemento_id.Text) + 1).ToString();

                controlMovible(titulo);
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarBloque();
        }

        private void borrar_Click(object sender, EventArgs e)
        {          
            if (posibleBorrar)
            {
                posibleBorrar = false;
                this.Cursor = Cursors.Hand;
               
                for (int x = 2; x < contenedorColumna.Controls.Count; x++)
                {
                    int id = Convert.ToInt16(contenedorColumna.Controls[x].Name);
                    contenedorColumna.Controls[x].Click += delegate (object send, EventArgs ea) { borrarElemento(id, send, e); };
                }
            }
            else
            {
                posibleBorrar = true;
                this.Cursor = Cursors.Default;
            }

        }

        private void borrarElemento(int id, object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            posibleBorrar = true;

            for (int x = 0; x < contenedorColumna.Controls.Count; x++)
            {
                borrarEventoClick(contenedorColumna.Controls[x]);
                contenedorColumna.Controls[x].Enabled = true;
            }

            DialogResult confirmar = MessageBox.Show("El elemento se borrara para siempre, estas seguro de que quieres eliminar este elemento", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirmar == DialogResult.Yes)
            {
                BDElementos.borrarElemento(id);
                contenedorColumna.Controls.Clear();
                Columna_Load(sender, e);
            }          
        }

        private void borrarEventoClick(Control elemento)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
                BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(elemento);
            PropertyInfo pi = elemento.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(elemento, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void borrarColumna_Click(object sender, EventArgs e)
        {
            DialogResult confirmar = MessageBox.Show("Ten cuidado, al borrar esta columna borraras todos los elementos que contiene tambien, estas seguro de querer borrar esta columna", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (confirmar == DialogResult.Yes)
            {
                BDColumnas.borrarColumna(columna_id.Text);
                this.Close();               
            }            
        }
    }
}
