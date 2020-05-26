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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logo = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // crearCircuitoToolStripMenuItem
            // 
            this.crearCircuitoToolStripMenuItem.AutoSize = false;
            this.crearCircuitoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crearCircuitoToolStripMenuItem.Name = "crearCircuitoToolStripMenuItem";
            this.crearCircuitoToolStripMenuItem.Size = new System.Drawing.Size(100, 38);
            this.crearCircuitoToolStripMenuItem.Text = "Crear Circuito";
            this.crearCircuitoToolStripMenuItem.Click += new System.EventHandler(this.crearCircuitoToolStripMenuItem_Click);
            // 
            // CrearPaginatoolStripMenuItem1
            // 
            this.CrearPaginatoolStripMenuItem1.AutoSize = false;
            this.CrearPaginatoolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.CrearPaginatoolStripMenuItem1.Name = "CrearPaginatoolStripMenuItem1";
            this.CrearPaginatoolStripMenuItem1.Size = new System.Drawing.Size(100, 38);
            this.CrearPaginatoolStripMenuItem1.Text = "Crear Pagina";
            this.CrearPaginatoolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // actualizar_pagina
            // 
            this.actualizar_pagina.AutoSize = false;
            this.actualizar_pagina.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.actualizar_pagina.Name = "actualizar_pagina";
            this.actualizar_pagina.Size = new System.Drawing.Size(128, 38);
            this.actualizar_pagina.Text = "Actualizar Pagina";
            this.actualizar_pagina.Click += new System.EventHandler(this.actualizarPaginaToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearCircuitoToolStripMenuItem,
            this.CrearPaginatoolStripMenuItem1,
            this.actualizar_pagina});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(786, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Image = global::Gestor_de_contenido_SG.Properties.Resources.salir;
            this.pictureBox1.Location = new System.Drawing.Point(740, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // logo
            // 
            this.logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logo.Image = global::Gestor_de_contenido_SG.Properties.Resources.logosg;
            this.logo.Location = new System.Drawing.Point(243, 79);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(283, 231);
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Activated += new System.EventHandler(this.Menu_Activated);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem crearCircuitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CrearPaginatoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem actualizar_pagina;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}