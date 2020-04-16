namespace Gestor_de_contenido_SG
{
    partial class Columna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.columna_id = new System.Windows.Forms.Label();
            this.nombre_columna = new System.Windows.Forms.Label();
            this.contenedorColumna = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.insertarTitulo = new System.Windows.Forms.Button();
            this.insertarParrafo = new System.Windows.Forms.Button();
            this.insertarVideo = new System.Windows.Forms.Button();
            this.insertarImagen = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).BeginInit();
            this.SuspendLayout();
            // 
            // columna_id
            // 
            this.columna_id.AutoSize = true;
            this.columna_id.Location = new System.Drawing.Point(224, 13);
            this.columna_id.Name = "columna_id";
            this.columna_id.Size = new System.Drawing.Size(35, 13);
            this.columna_id.TabIndex = 0;
            this.columna_id.Text = "label1";
            // 
            // nombre_columna
            // 
            this.nombre_columna.AutoSize = true;
            this.nombre_columna.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_columna.Location = new System.Drawing.Point(396, 9);
            this.nombre_columna.Name = "nombre_columna";
            this.nombre_columna.Size = new System.Drawing.Size(115, 39);
            this.nombre_columna.TabIndex = 11;
            this.nombre_columna.Text = "label3";
            // 
            // contenedorColumna
            // 
            this.contenedorColumna.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.contenedorColumna.Location = new System.Drawing.Point(200, 58);
            this.contenedorColumna.Name = "contenedorColumna";
            this.contenedorColumna.Size = new System.Drawing.Size(812, 456);
            this.contenedorColumna.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.insertarTitulo);
            this.panel1.Controls.Add(this.insertarParrafo);
            this.panel1.Controls.Add(this.insertarVideo);
            this.panel1.Controls.Add(this.insertarImagen);
            this.panel1.Location = new System.Drawing.Point(0, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 505);
            this.panel1.TabIndex = 13;
            // 
            // insertarTitulo
            // 
            this.insertarTitulo.Image = global::Gestor_de_contenido_SG.Properties.Resources.titulo;
            this.insertarTitulo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.insertarTitulo.Location = new System.Drawing.Point(101, 100);
            this.insertarTitulo.Name = "insertarTitulo";
            this.insertarTitulo.Size = new System.Drawing.Size(82, 81);
            this.insertarTitulo.TabIndex = 3;
            this.insertarTitulo.Text = "titulo";
            this.insertarTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.insertarTitulo.UseVisualStyleBackColor = true;
            this.insertarTitulo.Click += new System.EventHandler(this.insertarTitulo_Click);
            // 
            // insertarParrafo
            // 
            this.insertarParrafo.Image = global::Gestor_de_contenido_SG.Properties.Resources.parrafo;
            this.insertarParrafo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.insertarParrafo.Location = new System.Drawing.Point(13, 100);
            this.insertarParrafo.Name = "insertarParrafo";
            this.insertarParrafo.Size = new System.Drawing.Size(82, 81);
            this.insertarParrafo.TabIndex = 2;
            this.insertarParrafo.Text = "parrafo";
            this.insertarParrafo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.insertarParrafo.UseVisualStyleBackColor = true;
            this.insertarParrafo.Click += new System.EventHandler(this.insertarParrafo_Click);
            // 
            // insertarVideo
            // 
            this.insertarVideo.Image = global::Gestor_de_contenido_SG.Properties.Resources.video;
            this.insertarVideo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.insertarVideo.Location = new System.Drawing.Point(101, 13);
            this.insertarVideo.Name = "insertarVideo";
            this.insertarVideo.Size = new System.Drawing.Size(82, 81);
            this.insertarVideo.TabIndex = 1;
            this.insertarVideo.Text = "video";
            this.insertarVideo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.insertarVideo.UseVisualStyleBackColor = true;
            this.insertarVideo.Click += new System.EventHandler(this.insertarVideo_Click);
            // 
            // insertarImagen
            // 
            this.insertarImagen.Image = global::Gestor_de_contenido_SG.Properties.Resources.foto;
            this.insertarImagen.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.insertarImagen.Location = new System.Drawing.Point(13, 13);
            this.insertarImagen.Name = "insertarImagen";
            this.insertarImagen.Size = new System.Drawing.Size(82, 81);
            this.insertarImagen.TabIndex = 0;
            this.insertarImagen.Text = "imagen";
            this.insertarImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.insertarImagen.UseVisualStyleBackColor = true;
            this.insertarImagen.Click += new System.EventHandler(this.insertarImagen_Click);
            // 
            // volver
            // 
            this.volver.Image = global::Gestor_de_contenido_SG.Properties.Resources._return;
            this.volver.Location = new System.Drawing.Point(976, 9);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(23, 25);
            this.volver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.volver.TabIndex = 15;
            this.volver.TabStop = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Columna
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 515);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contenedorColumna);
            this.Controls.Add(this.nombre_columna);
            this.Controls.Add(this.columna_id);
            this.Name = "Columna";
            this.Text = "Columna";
            this.Load += new System.EventHandler(this.Columna_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label columna_id;
        private System.Windows.Forms.Label nombre_columna;
        private System.Windows.Forms.Panel contenedorColumna;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button insertarTitulo;
        private System.Windows.Forms.Button insertarParrafo;
        private System.Windows.Forms.Button insertarVideo;
        private System.Windows.Forms.Button insertarImagen;
        private System.Windows.Forms.PictureBox volver;
    }
}