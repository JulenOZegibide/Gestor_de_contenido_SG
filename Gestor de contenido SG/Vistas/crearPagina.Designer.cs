namespace Gestor_de_contenido_SG
{
    partial class CrearPagina
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
            this.label1 = new System.Windows.Forms.Label();
            this.titulo_pagina = new System.Windows.Forms.TextBox();
            this.lista_circuitos = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "titulo";
            // 
            // titulo_pagina
            // 
            this.titulo_pagina.Location = new System.Drawing.Point(65, 22);
            this.titulo_pagina.Name = "titulo_pagina";
            this.titulo_pagina.Size = new System.Drawing.Size(115, 20);
            this.titulo_pagina.TabIndex = 1;
            // 
            // lista_circuitos
            // 
            this.lista_circuitos.FormattingEnabled = true;
            this.lista_circuitos.Location = new System.Drawing.Point(12, 66);
            this.lista_circuitos.Name = "lista_circuitos";
            this.lista_circuitos.Size = new System.Drawing.Size(216, 95);
            this.lista_circuitos.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Crear pagina";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // volver
            // 
            this.volver.Image = global::Gestor_de_contenido_SG.Properties.Resources._return;
            this.volver.Location = new System.Drawing.Point(205, 17);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(23, 25);
            this.volver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.volver.TabIndex = 15;
            this.volver.TabStop = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // CrearPagina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 211);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lista_circuitos);
            this.Controls.Add(this.titulo_pagina);
            this.Controls.Add(this.label1);
            this.Name = "CrearPagina";
            this.Text = "Crear pagina";
            this.Load += new System.EventHandler(this.crearPagina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titulo_pagina;
        private System.Windows.Forms.ListBox lista_circuitos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox volver;
    }
}