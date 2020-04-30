namespace Gestor_de_contenido_SG
{
    partial class Bloque
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
            this.bloque_id = new System.Windows.Forms.Label();
            this.nombre_columna = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.crear_columna = new System.Windows.Forms.Button();
            this.nombre_bloque = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.volver = new System.Windows.Forms.PictureBox();
            this.borrarBloque = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrarBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // bloque_id
            // 
            this.bloque_id.AutoSize = true;
            this.bloque_id.Location = new System.Drawing.Point(326, 8);
            this.bloque_id.Name = "bloque_id";
            this.bloque_id.Size = new System.Drawing.Size(35, 13);
            this.bloque_id.TabIndex = 0;
            this.bloque_id.Text = "label1";
            // 
            // nombre_columna
            // 
            this.nombre_columna.Location = new System.Drawing.Point(175, 6);
            this.nombre_columna.Name = "nombre_columna";
            this.nombre_columna.Size = new System.Drawing.Size(100, 20);
            this.nombre_columna.TabIndex = 9;
            this.nombre_columna.Tag = "txt_nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Tag = "";
            this.label2.Text = "Nombre";
            // 
            // crear_columna
            // 
            this.crear_columna.Location = new System.Drawing.Point(150, 32);
            this.crear_columna.Name = "crear_columna";
            this.crear_columna.Size = new System.Drawing.Size(95, 23);
            this.crear_columna.TabIndex = 7;
            this.crear_columna.Text = "Crear columna";
            this.crear_columna.UseVisualStyleBackColor = true;
            this.crear_columna.Click += new System.EventHandler(this.crear_columna_Click);
            // 
            // nombre_bloque
            // 
            this.nombre_bloque.AutoSize = true;
            this.nombre_bloque.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_bloque.Location = new System.Drawing.Point(436, 16);
            this.nombre_bloque.Name = "nombre_bloque";
            this.nombre_bloque.Size = new System.Drawing.Size(115, 39);
            this.nombre_bloque.TabIndex = 10;
            this.nombre_bloque.Text = "label3";
            // 
            // contenedor
            // 
            this.contenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedor.AutoScroll = true;
            this.contenedor.Location = new System.Drawing.Point(53, 64);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(840, 374);
            this.contenedor.TabIndex = 11;
            // 
            // volver
            // 
            this.volver.Image = global::Gestor_de_contenido_SG.Properties.Resources._return;
            this.volver.Location = new System.Drawing.Point(24, 9);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(23, 25);
            this.volver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.volver.TabIndex = 16;
            this.volver.TabStop = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // borrarBloque
            // 
            this.borrarBloque.Image = global::Gestor_de_contenido_SG.Properties.Resources.papelera;
            this.borrarBloque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.borrarBloque.Location = new System.Drawing.Point(85, 9);
            this.borrarBloque.Name = "borrarBloque";
            this.borrarBloque.Size = new System.Drawing.Size(23, 25);
            this.borrarBloque.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.borrarBloque.TabIndex = 19;
            this.borrarBloque.TabStop = false;
            this.borrarBloque.Click += new System.EventHandler(this.borrarBloque_Click);
            // 
            // Bloque
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(934, 450);
            this.Controls.Add(this.borrarBloque);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.nombre_bloque);
            this.Controls.Add(this.nombre_columna);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.crear_columna);
            this.Controls.Add(this.bloque_id);
            this.Name = "Bloque";
            this.Text = "Bloque";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrarBloque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bloque_id;
        private System.Windows.Forms.TextBox nombre_columna;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button crear_columna;
        private System.Windows.Forms.Label nombre_bloque;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.PictureBox volver;
        private System.Windows.Forms.PictureBox borrarBloque;
    }

}