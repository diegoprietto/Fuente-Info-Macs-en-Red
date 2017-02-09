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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPrincipal));
            this.web = new System.Windows.Forms.WebBrowser();
            this.btInsertExeScript = new System.Windows.Forms.Button();
            this.btNavegar = new System.Windows.Forms.Button();
            this.btLeerValuePorID = new System.Windows.Forms.Button();
            this.btScriptParam = new System.Windows.Forms.Button();
            this.btObtenerHtml = new System.Windows.Forms.Button();
            this.btInnerTextBody = new System.Windows.Forms.Button();
            this.btInnerHtmlBody = new System.Windows.Forms.Button();
            this.btInnerHtmlHead = new System.Windows.Forms.Button();
            this.btAumentar = new System.Windows.Forms.Button();
            this.btReducir = new System.Windows.Forms.Button();
            this.btDesactivarError = new System.Windows.Forms.Button();
            this.btActivarError = new System.Windows.Forms.Button();
            this.btClickear = new System.Windows.Forms.Button();
            this.btIngresarValor = new System.Windows.Forms.Button();
            this.btNavegarEstadisticas = new System.Windows.Forms.Button();
            this.chReintentarWS = new System.Windows.Forms.CheckBox();
            this.btObenerDatosWireless = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // web
            // 
            this.web.Location = new System.Drawing.Point(10, 12);
            this.web.MinimumSize = new System.Drawing.Size(20, 20);
            this.web.Name = "web";
            this.web.Size = new System.Drawing.Size(759, 546);
            this.web.TabIndex = 0;
            this.web.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // btInsertExeScript
            // 
            this.btInsertExeScript.Location = new System.Drawing.Point(777, 44);
            this.btInsertExeScript.Name = "btInsertExeScript";
            this.btInsertExeScript.Size = new System.Drawing.Size(142, 26);
            this.btInsertExeScript.TabIndex = 1;
            this.btInsertExeScript.Text = "Insertar y ejecutar Script";
            this.btInsertExeScript.UseVisualStyleBackColor = true;
            this.btInsertExeScript.Click += new System.EventHandler(this.btInsertExeScript_Click);
            // 
            // btNavegar
            // 
            this.btNavegar.Location = new System.Drawing.Point(777, 12);
            this.btNavegar.Name = "btNavegar";
            this.btNavegar.Size = new System.Drawing.Size(142, 26);
            this.btNavegar.TabIndex = 4;
            this.btNavegar.Text = "Ir a URL...";
            this.btNavegar.UseVisualStyleBackColor = true;
            this.btNavegar.Click += new System.EventHandler(this.btNavegar_Click);
            // 
            // btLeerValuePorID
            // 
            this.btLeerValuePorID.Location = new System.Drawing.Point(779, 76);
            this.btLeerValuePorID.Name = "btLeerValuePorID";
            this.btLeerValuePorID.Size = new System.Drawing.Size(140, 43);
            this.btLeerValuePorID.TabIndex = 5;
            this.btLeerValuePorID.Text = "Leer value de elemento por ID";
            this.btLeerValuePorID.UseVisualStyleBackColor = true;
            this.btLeerValuePorID.Click += new System.EventHandler(this.btLeerValuePorID_Click);
            // 
            // btScriptParam
            // 
            this.btScriptParam.Location = new System.Drawing.Point(777, 125);
            this.btScriptParam.Name = "btScriptParam";
            this.btScriptParam.Size = new System.Drawing.Size(140, 43);
            this.btScriptParam.TabIndex = 6;
            this.btScriptParam.Text = "Ejecutar Script con Parámetros";
            this.btScriptParam.UseVisualStyleBackColor = true;
            this.btScriptParam.Click += new System.EventHandler(this.btScriptParam_Click);
            // 
            // btObtenerHtml
            // 
            this.btObtenerHtml.Location = new System.Drawing.Point(777, 174);
            this.btObtenerHtml.Name = "btObtenerHtml";
            this.btObtenerHtml.Size = new System.Drawing.Size(140, 26);
            this.btObtenerHtml.TabIndex = 7;
            this.btObtenerHtml.Text = "Mostrar HTML";
            this.btObtenerHtml.UseVisualStyleBackColor = true;
            this.btObtenerHtml.Click += new System.EventHandler(this.btObtenerHtml_Click);
            // 
            // btInnerTextBody
            // 
            this.btInnerTextBody.Location = new System.Drawing.Point(775, 206);
            this.btInnerTextBody.Name = "btInnerTextBody";
            this.btInnerTextBody.Size = new System.Drawing.Size(142, 26);
            this.btInnerTextBody.TabIndex = 8;
            this.btInnerTextBody.Text = "InnerText de Body";
            this.btInnerTextBody.UseVisualStyleBackColor = true;
            this.btInnerTextBody.Click += new System.EventHandler(this.btInnerTextBody_Click);
            // 
            // btInnerHtmlBody
            // 
            this.btInnerHtmlBody.Location = new System.Drawing.Point(775, 238);
            this.btInnerHtmlBody.Name = "btInnerHtmlBody";
            this.btInnerHtmlBody.Size = new System.Drawing.Size(142, 26);
            this.btInnerHtmlBody.TabIndex = 9;
            this.btInnerHtmlBody.Text = "InnertHTML de Body";
            this.btInnerHtmlBody.UseVisualStyleBackColor = true;
            this.btInnerHtmlBody.Click += new System.EventHandler(this.btInnerHtmlBody_Click);
            // 
            // btInnerHtmlHead
            // 
            this.btInnerHtmlHead.Location = new System.Drawing.Point(775, 270);
            this.btInnerHtmlHead.Name = "btInnerHtmlHead";
            this.btInnerHtmlHead.Size = new System.Drawing.Size(142, 26);
            this.btInnerHtmlHead.TabIndex = 10;
            this.btInnerHtmlHead.Text = "InnertHTML de Head";
            this.btInnerHtmlHead.UseVisualStyleBackColor = true;
            this.btInnerHtmlHead.Click += new System.EventHandler(this.btInnerHtmlHead_Click);
            // 
            // btAumentar
            // 
            this.btAumentar.Location = new System.Drawing.Point(775, 302);
            this.btAumentar.Name = "btAumentar";
            this.btAumentar.Size = new System.Drawing.Size(142, 26);
            this.btAumentar.TabIndex = 11;
            this.btAumentar.Text = "Aumentar Zoom Body";
            this.btAumentar.UseVisualStyleBackColor = true;
            this.btAumentar.Click += new System.EventHandler(this.btAumentar_Click);
            // 
            // btReducir
            // 
            this.btReducir.Location = new System.Drawing.Point(775, 334);
            this.btReducir.Name = "btReducir";
            this.btReducir.Size = new System.Drawing.Size(142, 26);
            this.btReducir.TabIndex = 12;
            this.btReducir.Text = "Reducir Zoom Body";
            this.btReducir.UseVisualStyleBackColor = true;
            this.btReducir.Click += new System.EventHandler(this.btReducir_Click);
            // 
            // btDesactivarError
            // 
            this.btDesactivarError.Location = new System.Drawing.Point(775, 366);
            this.btDesactivarError.Name = "btDesactivarError";
            this.btDesactivarError.Size = new System.Drawing.Size(142, 43);
            this.btDesactivarError.TabIndex = 13;
            this.btDesactivarError.Text = "Desactivar error y testear con un error";
            this.btDesactivarError.UseVisualStyleBackColor = true;
            this.btDesactivarError.Click += new System.EventHandler(this.btDesactivarError_Click);
            // 
            // btActivarError
            // 
            this.btActivarError.Location = new System.Drawing.Point(775, 415);
            this.btActivarError.Name = "btActivarError";
            this.btActivarError.Size = new System.Drawing.Size(142, 43);
            this.btActivarError.TabIndex = 14;
            this.btActivarError.Text = "Activar error y testear con un error";
            this.btActivarError.UseVisualStyleBackColor = true;
            this.btActivarError.Click += new System.EventHandler(this.btActivarError_Click);
            // 
            // btClickear
            // 
            this.btClickear.Location = new System.Drawing.Point(775, 464);
            this.btClickear.Name = "btClickear";
            this.btClickear.Size = new System.Drawing.Size(142, 43);
            this.btClickear.TabIndex = 15;
            this.btClickear.Text = "Ejecutar clic de un elemento por ID";
            this.btClickear.UseVisualStyleBackColor = true;
            this.btClickear.Click += new System.EventHandler(this.btClickear_Click);
            // 
            // btIngresarValor
            // 
            this.btIngresarValor.Location = new System.Drawing.Point(775, 513);
            this.btIngresarValor.Name = "btIngresarValor";
            this.btIngresarValor.Size = new System.Drawing.Size(142, 45);
            this.btIngresarValor.TabIndex = 16;
            this.btIngresarValor.Text = "Ingresar valor buscando por ID";
            this.btIngresarValor.UseVisualStyleBackColor = true;
            this.btIngresarValor.Click += new System.EventHandler(this.btIngresarValor_Click);
            // 
            // btNavegarEstadisticas
            // 
            this.btNavegarEstadisticas.Location = new System.Drawing.Point(925, 12);
            this.btNavegarEstadisticas.Name = "btNavegarEstadisticas";
            this.btNavegarEstadisticas.Size = new System.Drawing.Size(142, 43);
            this.btNavegarEstadisticas.TabIndex = 17;
            this.btNavegarEstadisticas.Text = "Navegar hasta Wireless Statistics";
            this.btNavegarEstadisticas.UseVisualStyleBackColor = true;
            this.btNavegarEstadisticas.Click += new System.EventHandler(this.btNavegarEstadisticas_Click);
            // 
            // chReintentarWS
            // 
            this.chReintentarWS.AutoSize = true;
            this.chReintentarWS.Location = new System.Drawing.Point(925, 61);
            this.chReintentarWS.Name = "chReintentarWS";
            this.chReintentarWS.Size = new System.Drawing.Size(138, 17);
            this.chReintentarWS.TabIndex = 18;
            this.chReintentarWS.Text = "Reintentar ante un error";
            this.chReintentarWS.UseVisualStyleBackColor = true;
            // 
            // btObenerDatosWireless
            // 
            this.btObenerDatosWireless.Location = new System.Drawing.Point(925, 84);
            this.btObenerDatosWireless.Name = "btObenerDatosWireless";
            this.btObenerDatosWireless.Size = new System.Drawing.Size(142, 43);
            this.btObenerDatosWireless.TabIndex = 19;
            this.btObenerDatosWireless.Text = "Obtener MACs de la tabla de Estadisticas";
            this.btObenerDatosWireless.UseVisualStyleBackColor = true;
            this.btObenerDatosWireless.Click += new System.EventHandler(this.btObenerDatosWireless_Click);
            // 
            // FPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 577);
            this.Controls.Add(this.btObenerDatosWireless);
            this.Controls.Add(this.chReintentarWS);
            this.Controls.Add(this.btNavegarEstadisticas);
            this.Controls.Add(this.btIngresarValor);
            this.Controls.Add(this.btClickear);
            this.Controls.Add(this.btActivarError);
            this.Controls.Add(this.btDesactivarError);
            this.Controls.Add(this.btReducir);
            this.Controls.Add(this.btAumentar);
            this.Controls.Add(this.btInnerHtmlHead);
            this.Controls.Add(this.btInnerHtmlBody);
            this.Controls.Add(this.btInnerTextBody);
            this.Controls.Add(this.btObtenerHtml);
            this.Controls.Add(this.btScriptParam);
            this.Controls.Add(this.btLeerValuePorID);
            this.Controls.Add(this.btNavegar);
            this.Controls.Add(this.btInsertExeScript);
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
        private System.Windows.Forms.Button btInsertExeScript;
        private System.Windows.Forms.Button btNavegar;
        private System.Windows.Forms.Button btLeerValuePorID;
        private System.Windows.Forms.Button btScriptParam;
        private System.Windows.Forms.Button btObtenerHtml;
        private System.Windows.Forms.Button btInnerTextBody;
        private System.Windows.Forms.Button btInnerHtmlBody;
        private System.Windows.Forms.Button btInnerHtmlHead;
        private System.Windows.Forms.Button btAumentar;
        private System.Windows.Forms.Button btReducir;
        private System.Windows.Forms.Button btDesactivarError;
        private System.Windows.Forms.Button btActivarError;
        private System.Windows.Forms.Button btClickear;
        private System.Windows.Forms.Button btIngresarValor;
        private System.Windows.Forms.Button btNavegarEstadisticas;
        private System.Windows.Forms.CheckBox chReintentarWS;
        private System.Windows.Forms.Button btObenerDatosWireless;
    }
}

