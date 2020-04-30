namespace Gestor_de_contenido_SG
{
    partial class Pagina
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.crear_bloque = new System.Windows.Forms.Button();
            this.bloque_id = new System.Windows.Forms.TextBox();
            this.contenedor = new System.Windows.Forms.Panel();
            this.nombre_bloque = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre_pagina = new System.Windows.Forms.Label();
            this.pagina_id = new System.Windows.Forms.TextBox();
            this.volver = new System.Windows.Forms.PictureBox();
            this.borrarPagina = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrarPagina)).BeginInit();
            this.SuspendLayout();
            // 
            // crear_bloque
            // 
            this.crear_bloque.Location = new System.Drawing.Point(152, 32);
            this.crear_bloque.Name = "crear_bloque";
            this.crear_bloque.Size = new System.Drawing.Size(95, 23);
            this.crear_bloque.TabIndex = 0;
            this.crear_bloque.Text = "Crear Bloque";
            this.crear_bloque.UseVisualStyleBackColor = true;
            this.crear_bloque.Click += new System.EventHandler(this.button1_Click);
            // 
            // bloque_id
            // 
            this.bloque_id.Location = new System.Drawing.Point(300, 6);
            this.bloque_id.Name = "bloque_id";
            this.bloque_id.Size = new System.Drawing.Size(24, 20);
            this.bloque_id.TabIndex = 3;
            this.bloque_id.Tag = "txt_nombre";
            // 
            // contenedor
            // 
            this.contenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedor.AutoScroll = true;
            this.contenedor.Location = new System.Drawing.Point(15, 76);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(900, 234);
            this.contenedor.TabIndex = 4;
            // 
            // nombre_bloque
            // 
            this.nombre_bloque.Location = new System.Drawing.Point(177, 6);
            this.nombre_bloque.Name = "nombre_bloque";
            this.nombre_bloque.Size = new System.Drawing.Size(100, 20);
            this.nombre_bloque.TabIndex = 6;
            this.nombre_bloque.Tag = "txt_nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Tag = "";
            this.label2.Text = "Nombre";
            // 
            // nombre_pagina
            // 
            this.nombre_pagina.AutoSize = true;
            this.nombre_pagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_pagina.Location = new System.Drawing.Point(436, 16);
            this.nombre_pagina.Name = "nombre_pagina";
            this.nombre_pagina.Size = new System.Drawing.Size(115, 39);
            this.nombre_pagina.TabIndex = 7;
            this.nombre_pagina.Text = "label3";
            // 
            // pagina_id
            // 
            this.pagina_id.Location = new System.Drawing.Point(363, 6);
            this.pagina_id.Name = "pagina_id";
            this.pagina_id.Size = new System.Drawing.Size(24, 20);
            this.pagina_id.TabIndex = 8;
            this.pagina_id.Tag = "txt_nombre";
            // 
            // volver
            // 
            this.volver.Image = global::Gestor_de_contenido_SG.Properties.Resources._return;
            this.volver.Location = new System.Drawing.Point(24, 9);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(23, 25);
            this.volver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.volver.TabIndex = 14;
            this.volver.TabStop = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // borrarPagina
            // 
            this.borrarPagina.Image = global::Gestor_de_contenido_SG.Properties.Resources.papelera;
            this.borrarPagina.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.borrarPagina.Location = new System.Drawing.Point(85, 9);
            this.borrarPagina.Name = "borrarPagina";
            this.borrarPagina.Size = new System.Drawing.Size(23, 25);
            this.borrarPagina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.borrarPagina.TabIndex = 18;
            this.borrarPagina.TabStop = false;
            this.borrarPagina.Click += new System.EventHandler(this.borrarPagina_Click);
            // 
            // Pagina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(931, 334);
            this.Controls.Add(this.borrarPagina);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.pagina_id);
            this.Controls.Add(this.nombre_pagina);
            this.Controls.Add(this.nombre_bloque);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.bloque_id);
            this.Controls.Add(this.crear_bloque);
            this.Name = "Pagina";
            this.Text = "Pagina";
            this.Activated += new System.EventHandler(this.Pagina_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrarPagina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button crear_bloque;
        private System.Windows.Forms.TextBox bloque_id;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.TextBox nombre_bloque;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nombre_pagina;
        private System.Windows.Forms.TextBox pagina_id;
        private System.Windows.Forms.PictureBox volver;
        private System.Windows.Forms.PictureBox borrarPagina;
    }
}

