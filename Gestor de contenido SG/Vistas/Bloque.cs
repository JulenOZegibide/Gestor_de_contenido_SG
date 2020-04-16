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
        public static ArrayList listaColumnas = new ArrayList();
        bool allowResize = false;
        private int altura = 50;      
        private int contador;

        public Bloque(string id, string nombre)
        {
            InitializeComponent();

            //metodos caracteristicos de esta pestaña
            WindowState = FormWindowState.Maximized;
            this.FormClosing += new FormClosingEventHandler(Controlador.volveraPagina);

            bloque_id.Text = id;
            nombre_bloque.Text = nombre;

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
                columna_id.Text = (Convert.ToInt16(columna_id.Text) + 1).ToString();
            }
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            pintarBloques();
        }

        public void pintarBloques()
        {
            //busca el id maximo de todas las columnas para a la hora de insertar una columna tenga como texto el id
            int idMaximo = BDColumnas.buscarIdColumnaMax();

            //se rellena la lista de columnas desde base de datos para posteriormente recorrerla
            listaColumnas = BDColumnas.buscarColumnas(bloque_id.Text);

            if (listaColumnas != null)
            {
                foreach (ClaseColumna ocolumna in listaColumnas)
                {
                    //caja de texto donde se guarda el nombre de la columna
                    Label nombre = new Label();
                    nombre.Text = ocolumna.titulo;
                    nombre.AutoSize = true;
                    nombre.Font = new Font("Arial", 16);
                    nombre.BorderStyle = BorderStyle.FixedSingle;

                    //se crea la columna y el elemento que le permite cambiar de tamaño, aparte de funciones necesarias para el correcto funcionamiento
                    ComponentResourceManager resources = new ComponentResourceManager(typeof(Bloque));
                    Panel panel1 = new Panel();
                    PictureBox pictureBox1 = new PictureBox();
                    panel1.SuspendLayout();
                    ((ISupportInitialize)(pictureBox1)).BeginInit();
                    this.SuspendLayout();

                    //regla de 3 para pasar de % a pixeles
                    int anchoEnPixeles = (ocolumna.ancho * contenedor.Width) / 100;

                    //Propiedades que tendra la columna al ser creada
                    panel1.BackColor = Color.WhiteSmoke;
                    panel1.BorderStyle = BorderStyle.FixedSingle;
                    panel1.Controls.Add(pictureBox1);
                    panel1.Top = altura;
                    panel1.Name = "columna" + contador;
                    panel1.Size = new Size(anchoEnPixeles, 100);
                    panel1.TabIndex = 0;
                    AutoSize = true;
                    panel1.Controls.Add(nombre);
                    panel1.MaximumSize = new Size(contenedor.Width, 1500);
                    panel1.MinimumSize = new Size(200, 100);

                    // id_columna
                    Label id_columna = new Label();
                    id_columna.Text = ocolumna.id.ToString();
                    panel1.Controls.Add(id_columna);

                    //crear objeto de la clase columna 
                    ClaseColumna ocolumnaDesdeBD = new ClaseColumna(nombre.Text, panel1.Width, Convert.ToInt16(bloque_id.Text));

                    //elemento para poder cambiar el tamaño de una columna
                    pictureBox1.BackColor = Color.DarkRed;
                    pictureBox1.Anchor = ((AnchorStyles)((AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom)));
                    pictureBox1.Cursor = Cursors.SizeWE;
                    pictureBox1.Left = ocolumnaDesdeBD.ancho - 10;
                    pictureBox1.Name = "pictureBox" + contador;
                    pictureBox1.TabIndex = 1;
                    pictureBox1.TabStop = false;
                    pictureBox1.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, panel1); };
                    pictureBox1.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, panel1, pictureBox1); };
                    pictureBox1.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, panel1, ocolumnaDesdeBD); };

                    //metodos para el correcto funcionamiento de las columnas
                    panel1.AutoSize = true;
                    this.Controls.Add(panel1);
                    this.Load += new EventHandler(this.Form2_Load);
                    panel1.ResumeLayout(false);
                    panel1.PerformLayout();
                    ((ISupportInitialize)(pictureBox1)).EndInit();
                    this.ResumeLayout(false);

                    //añade un evento cuando se hace click sobre una columna
                    panel1.Click += delegate (object send, EventArgs ea) { Controlador.mostrarColumna(send, ea, id_columna.Text, nombre.Text); Hide(); };

                    contenedor.Controls.Add(panel1);

                    contador++;

                    //rellena la lista de elementos desde base de datos para posteriormente recorrela
                    Columna.listaElementos = BDElementos.buscarElementos(id_columna.Text);
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
                                    imagen.Image = Image.FromFile(oelemento.contenido);

                                    //propiedades de la imagen
                                    imagen.Top = alturaelementos;
                                    imagen.AutoSize = true;

                                    panel1.Controls.Add(imagen);

                                    alturaelementos += imagen.Height;
                                    break;

                                case "video":
                                    PictureBox video = new PictureBox();
                                    video.Image = Image.FromFile(@"..\..\Imagenes\video.png");

                                    //propiedades del video
                                    video.Top = alturaelementos;
                                    video.AutoSize = true;

                                    panel1.Controls.Add(video);

                                    alturaelementos += video.Height;
                                    break;

                                case "p":
                                    Label parrafo = new Label();
                                    parrafo.Text = oelemento.contenido;

                                    //propiedades del parrafo
                                    parrafo.Top = alturaelementos;
                                    parrafo.AutoSize = true;
                                    parrafo.MaximumSize = new Size(panel1.Width, 300);

                                    panel1.Controls.Add(parrafo);

                                    alturaelementos += parrafo.Height;
                                    break;

                                case "title":
                                    Label titulo = new Label();
                                    titulo.Text = oelemento.contenido;

                                    //propiedades del titulo
                                    titulo.Top = alturaelementos;
                                    titulo.AutoSize = true;
                                    titulo.Font = new Font("Arial", 16);

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
                    pictureBox1.MinimumSize = new Size(20, panel1.Height);

                    altura += panel1.Height + 20;
                }
                listaColumnas.Clear();
            }
            else
            {
                listaColumnas = new ArrayList();
            }

            columna_id.Text = (idMaximo + 1).ToString();
        }

        //funcion para cuando clickas en el lateral para modificar el ancho de la columna
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e, Panel panel1)
        {
            allowResize = true;
            panel1.AutoSize = false;
        }

        //funcion para cuando se deja de clickar en el lateral para modificar el ancho de la columna
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e, Panel panel1,ClaseColumna ocolumna)
        {
            allowResize = false;

            //calcular ancho en porcentaje,usando la regla de 3
            int ancho = (100 * panel1.Width) / contenedor.Width;

            //buscar el id de la columna que se quiere modificar en base de datos y posteriormente se actualiza ese valor
            int id = BDColumnas.buscarIdColumna(ocolumna.titulo.ToString());
            BDColumnas.actualizarAncho(ancho.ToString(),id);

            //codigo para a la hora de cambiar el ancho de la columna se cambie su contenido tambien
            int alturaelementos = 30;
            for (int x = 3; x<panel1.Controls.Count; x++)
            {
                panel1.Controls[x].MaximumSize = new Size(panel1.Width,panel1.Height);

                panel1.Controls[x].Top = alturaelementos;
                alturaelementos += panel1.Controls[x].Height;
                panel1.Height = alturaelementos;
            }

            //Lo hago para que no se monten los bloques uno encima del otro, aun que no se si es la manera idonea de hacerlo
            contenedor.Controls.Clear();
            altura = 50;
            pintarBloques();
        }

        //funcion que al estar clickando permite modificar el ancho de la columna
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e, Panel panel1, PictureBox pictureBox1)
        {
            if (allowResize)
            {
                //panel1.Height = pictureBox1.Top + e.Y;
                panel1.Width = pictureBox1.Left + e.X;
            }
        }

        private void crearColumna()
        {
            //caja de texto donde se guarda el nombre de la columna
            Label nombre = new Label();
            nombre.Text = nombre_columna.Text;

            //se crea la columna y el elemento que le permite cambiar de tamaño, aparte de funciones necesarias para el correcto funcionamiento
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Bloque));
            Panel panel1 = new Panel();
            PictureBox pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((ISupportInitialize)(pictureBox1)).BeginInit();
            this.SuspendLayout();

            //Propiedades que tendra la columna al ser creada
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Top = altura;
            panel1.Name = "columna" + contador;
            panel1.Size = new Size(200, 160);
            panel1.TabIndex = 0;
            panel1.AutoSize = true;
            panel1.Controls.Add(nombre);
            panel1.MaximumSize = new Size(contenedor.Width-50, 500);
            panel1.MinimumSize = new Size(200, 160);
            //
            // id_columna
            Label id_columna = new Label();
            id_columna.Text = columna_id.Text;
            panel1.Controls.Add(id_columna);

            //calcular ancho en porcentaje,usando la regla de 3
            int ancho = (100 * panel1.Width) / contenedor.Width;

            //crear objeto de la clase columna 
            ClaseColumna ocolumna = new ClaseColumna(nombre.Text, ancho, Convert.ToInt16(bloque_id.Text));

            //elemento para poder cambiar el tamaño de una columna
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            pictureBox1.Cursor = Cursors.SizeWE;
            pictureBox1.Height = panel1.Height;
            pictureBox1.Left = 190;
            pictureBox1.Name = "pictureBox" + contador;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseDown(send, ea, panel1); }; pictureBox1.MouseMove += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseMove(send, ea, panel1, pictureBox1); };
            pictureBox1.MouseUp += delegate (object send, MouseEventArgs ea) { this.pictureBox1_MouseUp(send, ea, panel1,ocolumna); };

            //
            this.Controls.Add(panel1);
            this.Load += new EventHandler(this.Form2_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)(pictureBox1)).EndInit();
            this.ResumeLayout(false);

            //añade un evento cuando se hace click sobre una columna
            panel1.Click += delegate (object send, EventArgs ea) { Controlador.mostrarColumna(send, ea, id_columna.Text, nombre.Text); Hide(); };

            contenedor.Controls.Add(panel1);

            altura += panel1.Height + 20;

            contador++;

            BDColumnas.insertarColumna(ocolumna);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarPagina();
        }
    }
}
