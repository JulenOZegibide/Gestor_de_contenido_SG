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
            this.label1 = new System.Windows.Forms.Label();
            this.lista_circuitos = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.titulo_circuito = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crear circuito";
            // 
            // lista_circuitos
            // 
            this.lista_circuitos.FormattingEnabled = true;
            this.lista_circuitos.Items.AddRange(new object[] {
            "Crear circuito padre"});
            this.lista_circuitos.Location = new System.Drawing.Point(12, 92);
            this.lista_circuitos.Name = "lista_circuitos";
            this.lista_circuitos.Size = new System.Drawing.Size(215, 173);
            this.lista_circuitos.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 283);
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
            this.label2.Location = new System.Drawing.Point(31, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Titulo";
            // 
            // titulo_circuito
            // 
            this.titulo_circuito.Location = new System.Drawing.Point(81, 57);
            this.titulo_circuito.Name = "titulo_circuito";
            this.titulo_circuito.Size = new System.Drawing.Size(100, 20);
            this.titulo_circuito.TabIndex = 4;
            // 
            // Circuito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 318);
            this.Controls.Add(this.titulo_circuito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lista_circuitos);
            this.Controls.Add(this.label1);
            this.Name = "Circuito";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Circuito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lista_circuitos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titulo_circuito;
    }
}