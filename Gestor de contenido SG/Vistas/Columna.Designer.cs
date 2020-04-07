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
            this.SuspendLayout();
            // 
            // columna_id
            // 
            this.columna_id.AutoSize = true;
            this.columna_id.Location = new System.Drawing.Point(64, 9);
            this.columna_id.Name = "columna_id";
            this.columna_id.Size = new System.Drawing.Size(35, 13);
            this.columna_id.TabIndex = 0;
            this.columna_id.Text = "label1";
            // 
            // nombre_columna
            // 
            this.nombre_columna.AutoSize = true;
            this.nombre_columna.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_columna.Location = new System.Drawing.Point(316, 9);
            this.nombre_columna.Name = "nombre_columna";
            this.nombre_columna.Size = new System.Drawing.Size(115, 39);
            this.nombre_columna.TabIndex = 11;
            this.nombre_columna.Text = "label3";
            // 
            // Columna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nombre_columna);
            this.Controls.Add(this.columna_id);
            this.Name = "Columna";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Columna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label columna_id;
        private System.Windows.Forms.Label nombre_columna;
    }
}