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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Columna));
            this.columna_id = new System.Windows.Forms.Label();
            this.nombre_columna = new System.Windows.Forms.Label();
            this.contenedorColumna = new System.Windows.Forms.Panel();
            this.acciones = new System.Windows.Forms.Panel();
            this.borrar = new System.Windows.Forms.Button();
            this.insertarTitulo = new System.Windows.Forms.Button();
            this.insertarParrafo = new System.Windows.Forms.Button();
            this.insertarVideo = new System.Windows.Forms.Button();
            this.insertarImagen = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.PictureBox();
            this.elemento_id = new System.Windows.Forms.Label();
            this.borrarColumna = new System.Windows.Forms.PictureBox();
            this.acciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrarColumna)).BeginInit();
            this.SuspendLayout();
            // 
            // columna_id
            // 
            resources.ApplyResources(this.columna_id, "columna_id");
            this.columna_id.Name = "columna_id";
            // 
            // nombre_columna
            // 
            resources.ApplyResources(this.nombre_columna, "nombre_columna");
            this.nombre_columna.Name = "nombre_columna";
            // 
            // contenedorColumna
            // 
            this.contenedorColumna.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.contenedorColumna, "contenedorColumna");
            this.contenedorColumna.Name = "contenedorColumna";
            // 
            // acciones
            // 
            this.acciones.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.acciones.Controls.Add(this.borrar);
            this.acciones.Controls.Add(this.insertarTitulo);
            this.acciones.Controls.Add(this.insertarParrafo);
            this.acciones.Controls.Add(this.insertarVideo);
            this.acciones.Controls.Add(this.insertarImagen);
            resources.ApplyResources(this.acciones, "acciones");
            this.acciones.Name = "acciones";
            // 
            // borrar
            // 
            resources.ApplyResources(this.borrar, "borrar");
            this.borrar.Image = global::Gestor_de_contenido_SG.Properties.Resources.papelera;
            this.borrar.Name = "borrar";
            this.borrar.UseVisualStyleBackColor = true;
            this.borrar.Click += new System.EventHandler(this.borrar_Click);
            // 
            // insertarTitulo
            // 
            resources.ApplyResources(this.insertarTitulo, "insertarTitulo");
            this.insertarTitulo.Image = global::Gestor_de_contenido_SG.Properties.Resources.titulo;
            this.insertarTitulo.Name = "insertarTitulo";
            this.insertarTitulo.UseVisualStyleBackColor = true;
            this.insertarTitulo.Click += new System.EventHandler(this.insertarTitulo_Click);
            // 
            // insertarParrafo
            // 
            resources.ApplyResources(this.insertarParrafo, "insertarParrafo");
            this.insertarParrafo.Image = global::Gestor_de_contenido_SG.Properties.Resources.parrafo;
            this.insertarParrafo.Name = "insertarParrafo";
            this.insertarParrafo.UseVisualStyleBackColor = true;
            this.insertarParrafo.Click += new System.EventHandler(this.insertarParrafo_Click);
            // 
            // insertarVideo
            // 
            resources.ApplyResources(this.insertarVideo, "insertarVideo");
            this.insertarVideo.Image = global::Gestor_de_contenido_SG.Properties.Resources.video;
            this.insertarVideo.Name = "insertarVideo";
            this.insertarVideo.UseVisualStyleBackColor = true;
            this.insertarVideo.Click += new System.EventHandler(this.insertarVideo_Click);
            // 
            // insertarImagen
            // 
            resources.ApplyResources(this.insertarImagen, "insertarImagen");
            this.insertarImagen.Image = global::Gestor_de_contenido_SG.Properties.Resources.foto;
            this.insertarImagen.Name = "insertarImagen";
            this.insertarImagen.UseVisualStyleBackColor = true;
            this.insertarImagen.Click += new System.EventHandler(this.insertarImagen_Click);
            // 
            // volver
            // 
            this.volver.Image = global::Gestor_de_contenido_SG.Properties.Resources._return;
            resources.ApplyResources(this.volver, "volver");
            this.volver.Name = "volver";
            this.volver.TabStop = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // elemento_id
            // 
            resources.ApplyResources(this.elemento_id, "elemento_id");
            this.elemento_id.Name = "elemento_id";
            // 
            // borrarColumna
            // 
            this.borrarColumna.Image = global::Gestor_de_contenido_SG.Properties.Resources.papelera;
            resources.ApplyResources(this.borrarColumna, "borrarColumna");
            this.borrarColumna.Name = "borrarColumna";
            this.borrarColumna.TabStop = false;
            this.borrarColumna.Click += new System.EventHandler(this.borrarColumna_Click);
            // 
            // Columna
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.borrarColumna);
            this.Controls.Add(this.elemento_id);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.acciones);
            this.Controls.Add(this.contenedorColumna);
            this.Controls.Add(this.nombre_columna);
            this.Controls.Add(this.columna_id);
            this.Name = "Columna";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Columna_Load);
            this.acciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.volver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrarColumna)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label columna_id;
        private System.Windows.Forms.Label nombre_columna;
        private System.Windows.Forms.Panel contenedorColumna;
        private System.Windows.Forms.Panel acciones;
        private System.Windows.Forms.Button insertarTitulo;
        private System.Windows.Forms.Button insertarParrafo;
        private System.Windows.Forms.Button insertarVideo;
        private System.Windows.Forms.Button insertarImagen;
        private System.Windows.Forms.PictureBox volver;
        private System.Windows.Forms.Label elemento_id;
        private System.Windows.Forms.Button borrar;
        private System.Windows.Forms.PictureBox borrarColumna;
    }
}