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
        bool allowResize = false;
        private int altura = 70;
        private int contador;

        public Bloque(string id, string nombre)
        {
            InitializeComponent();
            bloque_id.Text = id;
            nombre_bloque.Text = nombre;
        }

        private void crear_columna_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nombre_columna.Text) || String.IsNullOrWhiteSpace(nombre_columna.Text))
            {
                MessageBox.Show("Introduce un nombre valido");
                //throw new Exception("Introduce un nombre valido");
            }
            else
            {
                crearColumna();
                columna_id.Text = (Convert.ToInt16(columna_id.Text) + 1).ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            int idMaximo = BDColumnas.buscarIdColumnaMax();

            columna_id.Text = (idMaximo + 1).ToString();
        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            allowResize = true;
        }

        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e, Panel panel1)
        {
            allowResize = false;
            int ancho = (100 * panel1.Width) / contenedor.Width;
            MessageBox.Show(ancho.ToString());
        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e, Panel panel1, PictureBox pictureBox1)
        {
            if (allowResize)
            {
                //panel1.Height = pictureBox1.Top + e.Y;
                panel1.Width = pictureBox1.Left + e.X;
            }
        }

        private void crearColumna()
        {
            Label nombre = new Label();
            nombre.Text = nombre_columna.Text;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bloque));
            Panel panel1 = new System.Windows.Forms.Panel();
            PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(pictureBox1);
            panel1.Top = altura;
            panel1.Name = "panel" + contador;
            panel1.Size = new System.Drawing.Size(200, 160);
            panel1.TabIndex = 0;
            AutoSize = true;
            panel1.Controls.Add(nombre);
            panel1.MaximumSize = new System.Drawing.Size(contenedor.Width, 500);
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            pictureBox1.Cursor = System.Windows.Forms.Cursors.SizeWE;
            pictureBox1.Height = panel1.Height;
            pictureBox1.Left = 190;
            pictureBox1.Name = "pictureBox" + contador;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            pictureBox1.MouseMove += delegate (object sender, MouseEventArgs e) { this.pictureBox1_MouseMove(sender, e, panel1, pictureBox1); };
            pictureBox1.MouseUp += delegate (object sender, MouseEventArgs e) { this.pictureBox1_MouseUp(sender, e, panel1); };
            // 
            // Form1
            // 
            this.Controls.Add(panel1);
            this.Load += new System.EventHandler(this.Form2_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.ResumeLayout(false);
            //
            // id_columna
            //
            Label id_columna = new Label();
            id_columna.Text = columna_id.Text;
            //id_bloque.Visible = false;

            panel1.Controls.Add(id_columna);
            panel1.Click += delegate (object send, EventArgs e) { Controlador.mostrarColumna(send, e, id_columna.Text, nombre.Text); };

            contenedor.Controls.Add(panel1);

            altura += panel1.Width + 20;

            contador++;

            int ancho = (100 * panel1.Width) / contenedor.Width;

            ClaseColumna ocolumna = new ClaseColumna(nombre.Text, ancho, Convert.ToInt16(bloque_id.Text));
            //BDColumnas.insertarColumna(ocolumna);
        }
    }
}
