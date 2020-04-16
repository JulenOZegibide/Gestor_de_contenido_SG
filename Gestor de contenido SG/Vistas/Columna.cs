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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_contenido_SG
{
    public partial class Columna : Form
    {
        public static ArrayList listaElementos = new ArrayList();
        private int altura;

        public Columna(string id, string nombre)
        {            
            InitializeComponent();

            //funcion que se llama al cerrar la ventana
            this.FormClosing += new FormClosingEventHandler(Controlador.volveraPagina);

            //rellena con el id de la columna y su nombre sus respectivos label
            columna_id.Text = id;
            nombre_columna.Text = nombre;

            //Para evitar que el usuario de la aplicacion cambie el tamaño de la pestaña
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void Columna_Load(object sender, EventArgs e)
        {
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
                            imagen.Image = Image.FromFile(oelemento.contenido);

                            //propiedades de la imagen
                            imagen.Top = altura;
                            imagen.AutoSize = true;
                            imagen.Location = new Point((contenedorColumna.Width / 2) - (imagen.Width / 2), altura);

                            contenedorColumna.Controls.Add(imagen);

                            altura += imagen.Height;
                            break;

                        case "video":
                            PictureBox video = new PictureBox();
                            video.Image = Image.FromFile(@"..\..\Imagenes\video.png");

                            //propiedades del video
                            video.Top = altura;
                            video.AutoSize = true;
                            video.Location = new Point((contenedorColumna.Width / 2) - (video.Width / 2), altura);

                            contenedorColumna.Controls.Add(video);

                            altura += video.Height;
                            break;

                        case "p":
                            Label parrafo = new Label();
                            parrafo.Text = oelemento.contenido;

                            //propiedades del parrafo
                            parrafo.Top = altura;
                            parrafo.AutoSize = true;
                            parrafo.MaximumSize = new Size(contenedorColumna.Width, 300);

                            contenedorColumna.Controls.Add(parrafo);

                            altura += parrafo.Height;
                            break;

                        case "title":
                            Label titulo = new Label();
                            titulo.Text = oelemento.contenido;

                            //propiedades del titulo
                            titulo.Top = altura;
                            titulo.AutoSize = true;
                            titulo.Font = new Font("Arial", 16);

                            contenedorColumna.Controls.Add(titulo);

                            altura += titulo.Height;
                            break;
                    }
                }
                listaElementos.Clear();
            }
            else
            {
                listaElementos = new ArrayList();
            }
        }

        private void insertarImagen_Click(object sender, EventArgs e)
        {
            PictureBox imagen = new PictureBox();
                
            OpenFileDialog dialogoBuscarArchivo = new OpenFileDialog();

            //Se crean las opciones de busqueda
            dialogoBuscarArchivo.InitialDirectory = "c:\\";
            dialogoBuscarArchivo.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            //el ShowDialog() muestra el explorador de archivos para que elijas tu archivo. 
            //Cuando le das click a "Aceptar" se devuelve DialogResult.OK 
            //y si das click a "Cancelar" se devuelve una DialogResult.Cancel
            //Si fue un OK, entonces suponemos que hay un archivo. Intentamos abrirlo
            if (dialogoBuscarArchivo.ShowDialog() == DialogResult.OK)
            {
                // propiedades de la imagen
                imagen.Image = new Bitmap(dialogoBuscarArchivo.FileName);
                imagen.Top = altura;
                imagen.AutoSize = true;
                imagen.Location = new Point((contenedorColumna.Width / 2) - (imagen.Width / 2), altura);

                //Añadir la imagen al panel
                contenedorColumna.Controls.Add(imagen);

                //MessageBox.Show(dialogoBuscarArchivo.FileName);

                //imagen.Image.Save(@"Path", ImageFormat.Jpeg);.....PARA GUARDAR LAS IMAGENES EN UNA CARPETA......

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("img", dialogoBuscarArchivo.FileName, Convert.ToInt16(columna_id.Text));
                BDElementos.insertarElemento(oelemento);

                altura += imagen.Height;
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
                video.Image = Image.FromFile(@"..\..\Imagenes\video.png");
                video.Top = altura;
                video.AutoSize = true;
                video.Location = new Point((contenedorColumna.Width / 2) - (video.Width / 2), altura);

                contenedorColumna.Controls.Add(video);

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("video", url, Convert.ToInt16(columna_id.Text));
                BDElementos.insertarElemento(oelemento);

                altura += video.Height;
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
                parrafo.AutoSize = true;
                parrafo.MaximumSize = new Size(contenedorColumna.Width,300);
                contenedorColumna.Controls.Add(parrafo);

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("p", textoParrafo, Convert.ToInt16(columna_id.Text));
                BDElementos.insertarElemento(oelemento);

                altura += parrafo.Height;
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
                titulo.AutoSize = true;
                titulo.Font = new Font("Arial", 16);

                contenedorColumna.Controls.Add(titulo);

                //Añadir elemento a la base de datos
                ClaseElemento oelemento = new ClaseElemento("title", textoTitulo, Convert.ToInt16(columna_id.Text));
                BDElementos.insertarElemento(oelemento);

                altura += titulo.Height;
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarBloque();
        }
    }
}
