namespace Gestor_de_contenido_SG
{
    partial class Circuito
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
            this.lista_circuitos = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.titulo_circuito = new System.Windows.Forms.TextBox();
            this.volver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).BeginInit();
            this.SuspendLayout();
            // 
            // lista_circuitos
            // 
            this.lista_circuitos.FormattingEnabled = true;
            this.lista_circuitos.Items.AddRange(new object[] {
            "Crear circuito padre"});
            this.lista_circuitos.Location = new System.Drawing.Point(12, 40);
            this.lista_circuitos.Name = "lista_circuitos";
            this.lista_circuitos.Size = new System.Drawing.Size(254, 238);
            this.lista_circuitos.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Crear circuito";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Titulo";
            // 
            // titulo_circuito
            // 
            this.titulo_circuito.Location = new System.Drawing.Point(81, 9);
            this.titulo_circuito.Name = "titulo_circuito";
            this.titulo_circuito.Size = new System.Drawing.Size(100, 20);
            this.titulo_circuito.TabIndex = 4;
            // 
            // volver
            // 
            this.volver.Image = global::Gestor_de_contenido_SG.Properties.Resources._return;
            this.volver.Location = new System.Drawing.Point(243, 9);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(23, 25);
            this.volver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.volver.TabIndex = 15;
            this.volver.TabStop = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // Circuito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 318);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.titulo_circuito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lista_circuitos);
            this.Name = "Circuito";
            this.Text = "Crear circuito";
            this.Load += new System.EventHandler(this.Circuito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lista_circuitos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titulo_circuito;
        private System.Windows.Forms.PictureBox volver;
    }
}