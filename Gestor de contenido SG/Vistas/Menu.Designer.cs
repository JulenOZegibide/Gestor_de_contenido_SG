namespace Gestor_de_contenido_SG
{
    partial class Menu
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
            this.crearCircuitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CrearPaginatoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizar_pagina = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // crearCircuitoToolStripMenuItem
            // 
            this.crearCircuitoToolStripMenuItem.Name = "crearCircuitoToolStripMenuItem";
            this.crearCircuitoToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.crearCircuitoToolStripMenuItem.Text = "Crear Circuito";
            this.crearCircuitoToolStripMenuItem.Click += new System.EventHandler(this.crearCircuitoToolStripMenuItem_Click);
            // 
            // CrearPaginatoolStripMenuItem1
            // 
            this.CrearPaginatoolStripMenuItem1.Name = "CrearPaginatoolStripMenuItem1";
            this.CrearPaginatoolStripMenuItem1.Size = new System.Drawing.Size(86, 20);
            this.CrearPaginatoolStripMenuItem1.Text = "Crear Pagina";
            this.CrearPaginatoolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // actualizar_pagina
            // 
            this.actualizar_pagina.Name = "actualizar_pagina";
            this.actualizar_pagina.Size = new System.Drawing.Size(110, 20);
            this.actualizar_pagina.Text = "Actualizar Pagina";
            this.actualizar_pagina.Click += new System.EventHandler(this.actualizarPaginaToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearCircuitoToolStripMenuItem,
            this.CrearPaginatoolStripMenuItem1,
            this.actualizar_pagina});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem crearCircuitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearPaginatoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem actualizar_pagina;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}