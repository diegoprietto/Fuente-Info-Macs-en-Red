namespace FuenteMacs
{
    partial class FPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            this.web = new System.Windows.Forms.WebBrowser();
            this.btNavegarEstadisticas = new System.Windows.Forms.Button();
            this.btObenerDatosWireless = new System.Windows.Forms.Button();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // web
            // 
            this.web.Location = new System.Drawing.Point(10, 12);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(826, 546);
            this.web.TabIndex = 0;
            this.web.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btNavegarEstadisticas
            // 
            this.btNavegarEstadisticas.Location = new System.Drawing.Point(842, 12);
            this.btNavegarEstadisticas.Name = "btNavegarEstadisticas";
            this.btNavegarEstadisticas.Size = new System.Drawing.Size(142, 43);
            this.btNavegarEstadisticas.TabIndex = 17;
            this.btNavegarEstadisticas.Text = "Navegar hasta Wireless Statistics";
            this.btNavegarEstadisticas.UseVisualStyleBackColor = true;
            this.btNavegarEstadisticas.Click += new System.EventHandler(this.btNavegarEstadisticas_Click);
            // 
            // btObenerDatosWireless
            // 
            this.btObenerDatosWireless.Location = new System.Drawing.Point(842, 61);
            this.btObenerDatosWireless.Name = "btObenerDatosWireless";
            this.btObenerDatosWireless.Size = new System.Drawing.Size(142, 43);
            this.btObenerDatosWireless.TabIndex = 19;
            this.btObenerDatosWireless.Text = "Obtener MACs de la tabla de Estadisticas";
            this.btObenerDatosWireless.UseVisualStyleBackColor = true;
            this.btObenerDatosWireless.Click += new System.EventHandler(this.btObenerDatosWireless_Click);
            // 
            // reloj
            // 
            this.reloj.Interval = 1000;
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(842, 110);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(275, 448);
            this.textBox1.TabIndex = 20;
            // 
            // FPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 577);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btObenerDatosWireless);
            this.Controls.Add(this.btNavegarEstadisticas);
            this.Controls.Add(this.web);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuente Info Macs en Red";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Button btNavegarEstadisticas;
        private System.Windows.Forms.Button btObenerDatosWireless;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.TextBox textBox1;
    }
}

