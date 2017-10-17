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
            this.btConfigurar = new System.Windows.Forms.Button();
            this.lsConectados = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCant = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUltimaAct = new System.Windows.Forms.Label();
            this.chPausar = new System.Windows.Forms.CheckBox();
            this.chGuardarBD = new System.Windows.Forms.CheckBox();
            this.msjActualizandoBD = new System.Windows.Forms.Label();
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
            this.btNavegarEstadisticas.Size = new System.Drawing.Size(142, 30);
            this.btNavegarEstadisticas.TabIndex = 17;
            this.btNavegarEstadisticas.Text = "Forzar navegación";
            this.btNavegarEstadisticas.UseVisualStyleBackColor = true;
            this.btNavegarEstadisticas.Click += new System.EventHandler(this.btNavegarEstadisticas_Click);
            // 
            // btObenerDatosWireless
            // 
            this.btObenerDatosWireless.Location = new System.Drawing.Point(842, 48);
            this.btObenerDatosWireless.Name = "btObenerDatosWireless";
            this.btObenerDatosWireless.Size = new System.Drawing.Size(142, 30);
            this.btObenerDatosWireless.TabIndex = 19;
            this.btObenerDatosWireless.Text = "Forzar obtención de datos";
            this.btObenerDatosWireless.UseVisualStyleBackColor = true;
            this.btObenerDatosWireless.Click += new System.EventHandler(this.btObenerDatosWireless_Click);
            // 
            // reloj
            // 
            this.reloj.Interval = 1000;
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // btConfigurar
            // 
            this.btConfigurar.Location = new System.Drawing.Point(990, 12);
            this.btConfigurar.Name = "btConfigurar";
            this.btConfigurar.Size = new System.Drawing.Size(142, 30);
            this.btConfigurar.TabIndex = 21;
            this.btConfigurar.Text = "Configurar";
            this.btConfigurar.UseVisualStyleBackColor = true;
            this.btConfigurar.Click += new System.EventHandler(this.btConfigurar_Click);
            // 
            // lsConectados
            // 
            this.lsConectados.FormattingEnabled = true;
            this.lsConectados.Location = new System.Drawing.Point(842, 84);
            this.lsConectados.Name = "lsConectados";
            this.lsConectados.Size = new System.Drawing.Size(290, 225);
            this.lsConectados.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(842, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Cantidad de conexiones:";
            // 
            // lbCant
            // 
            this.lbCant.AutoSize = true;
            this.lbCant.Location = new System.Drawing.Point(987, 312);
            this.lbCant.Name = "lbCant";
            this.lbCant.Size = new System.Drawing.Size(13, 13);
            this.lbCant.TabIndex = 24;
            this.lbCant.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(842, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Última actualización:";
            // 
            // lbUltimaAct
            // 
            this.lbUltimaAct.AutoSize = true;
            this.lbUltimaAct.Location = new System.Drawing.Point(987, 334);
            this.lbUltimaAct.Name = "lbUltimaAct";
            this.lbUltimaAct.Size = new System.Drawing.Size(10, 13);
            this.lbUltimaAct.TabIndex = 26;
            this.lbUltimaAct.Text = "-";
            // 
            // chPausar
            // 
            this.chPausar.Appearance = System.Windows.Forms.Appearance.Button;
            this.chPausar.Location = new System.Drawing.Point(990, 48);
            this.chPausar.Name = "chPausar";
            this.chPausar.Size = new System.Drawing.Size(142, 30);
            this.chPausar.TabIndex = 27;
            this.chPausar.Text = "Pausar";
            this.chPausar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chPausar.UseVisualStyleBackColor = true;
            this.chPausar.CheckedChanged += new System.EventHandler(this.chPausar_CheckedChanged);
            // 
            // chGuardarBD
            // 
            this.chGuardarBD.AutoSize = true;
            this.chGuardarBD.Location = new System.Drawing.Point(845, 368);
            this.chGuardarBD.Name = "chGuardarBD";
            this.chGuardarBD.Size = new System.Drawing.Size(90, 17);
            this.chGuardarBD.TabIndex = 28;
            this.chGuardarBD.Text = "Actualizar BD";
            this.chGuardarBD.UseVisualStyleBackColor = true;
            // 
            // msjActualizandoBD
            // 
            this.msjActualizandoBD.AutoSize = true;
            this.msjActualizandoBD.ForeColor = System.Drawing.Color.Purple;
            this.msjActualizandoBD.Location = new System.Drawing.Point(842, 400);
            this.msjActualizandoBD.Name = "msjActualizandoBD";
            this.msjActualizandoBD.Size = new System.Drawing.Size(95, 13);
            this.msjActualizandoBD.TabIndex = 29;
            this.msjActualizandoBD.Text = "Actualizando BD...";
            this.msjActualizandoBD.Visible = false;
            // 
            // FPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 577);
            this.Controls.Add(this.msjActualizandoBD);
            this.Controls.Add(this.chGuardarBD);
            this.Controls.Add(this.chPausar);
            this.Controls.Add(this.lbUltimaAct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsConectados);
            this.Controls.Add(this.btConfigurar);
            this.Controls.Add(this.btObenerDatosWireless);
            this.Controls.Add(this.btNavegarEstadisticas);
            this.Controls.Add(this.web);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fuente Info Macs en Red";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser web;
        private System.Windows.Forms.Button btNavegarEstadisticas;
        private System.Windows.Forms.Button btObenerDatosWireless;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Button btConfigurar;
        private System.Windows.Forms.ListBox lsConectados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUltimaAct;
        private System.Windows.Forms.CheckBox chPausar;
        private System.Windows.Forms.CheckBox chGuardarBD;
        private System.Windows.Forms.Label msjActualizandoBD;
    }
}

