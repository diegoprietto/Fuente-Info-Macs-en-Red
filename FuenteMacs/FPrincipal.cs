using FuenteMacs.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuenteMacs
{
    public partial class FPrincipal : Form
    {
        //Zoom por defecto
        int valorZoom = 100;

        //Acción a realizar luego que se complete la carga del documento (DocumentCompleted)
        AccionWeb accionWeb = AccionWeb.ninguna;
        
        //Enum
        public enum AccionWeb
        {
            ninguna,
            LoginRouter,
            MenuWireless,
            MenuWirelessStatistics
        }

        public FPrincipal()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (accionWeb)
            {
                case AccionWeb.ninguna:
                    return;
                case AccionWeb.LoginRouter:
                    loginRouter();
                    return;
                case AccionWeb.MenuWireless:
                    menuWireless();
                    return;
                case AccionWeb.MenuWirelessStatistics:
                    menuWirelessStatistics();
                    return;
                default:
                    accionWeb = AccionWeb.ninguna;
                    return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            ////TEST GUARDAR
            ConfiguracionInicial baba = new ConfiguracionInicial();
            baba.frecuenciaMs = 135;
            baba.ipRouter = "192.168.1.1";

            AccesoArchivos acceso = new AccesoArchivos();
            acceso.GuardarArchivoConfiguracionInicial("SALAMIN.xml", baba);

            ////TEST CARGAR

            ConfiguracionInicial kiki  =acceso.CargarArchivoConfiguracionInicial("SALAMIN.xml");


            //Abrir URL
            /////web.Navigate("192.168.1.1");
        }

        //Insertar script al head e invocarlo
        private void btInsertExeScript_Click(object sender, EventArgs e)
        {
            //Obtener objeto document del DOM
            HtmlDocument doc = web.Document;

            //Obtener head buscando por TAG
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            //Crear un elemento HTML script
            HtmlElement s = doc.CreateElement("script");

            //Insertar código como un texto al elemento
            s.SetAttribute("text", "function mostrarAlert() { alert('Hola Mundo!'); }");

            //Insertar elemento html script al elemento head
            head.AppendChild(s);

            //Invocar Script por su nombre
            web.Document.InvokeScript("mostrarAlert");
        }

        private void btNavegar_Click(object sender, EventArgs e)
        {
            String url = String.Empty;

            try
            {
                //Obtener URI
                url = web.Url.AbsoluteUri;
            }
            catch (Exception) { }

            //InputBox
            ShowInputDialog(ref url, "Ingresar URL");

            try
            {
                //Navegar a la URL indicada
                web.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //InputBox
        private DialogResult ShowInputDialog(ref string input, String titulo)
        {
            System.Drawing.Size size = new System.Drawing.Size(500, 70);
            Form inputBox = new Form();

            //Centrar la ventana
            inputBox.StartPosition = FormStartPosition.CenterScreen;

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = titulo;

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        //A partir de un ID obtener el atributo valor
        private void btLeerValuePorID_Click(object sender, EventArgs e)
        {
            string idHtml = String.Empty;

            //InputBox
            ShowInputDialog(ref idHtml, "Ingresar ID");

            try
            {
                //Buscar elemento del DOM por ID
                HtmlElement elemento = web.Document.GetElementById(idHtml);

                //Obtener y mostrar campo value
                MessageBox.Show("Value: " + elemento.GetAttribute("value"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Crea un script, lo ejecutar pasando parámetros y obtiene la respuesta
        private void btScriptParam_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener objeto document del DOM
                HtmlDocument doc = web.Document;

                //Obtener head buscando por TAG
                HtmlElement head = doc.GetElementsByTagName("head")[0];

                //Crear un elemento HTML script
                HtmlElement s = doc.CreateElement("script");

                //Insertar código como un texto al elemento
                s.SetAttribute("text", "function sumar(a,b,mensaje) { alert(mensaje + ': ' + (a+b)); return (mensaje + ': ' + (a+b)); }");

                //Insertar elemento html script al elemento head
                head.AppendChild(s);

                //Crear varibale para parámetros
                object[] parametros = { 2, 5, "Suma" };

                //Invocar Script por su nombre
                object resultado = web.Document.InvokeScript("sumar", parametros);

                //Mostrar resultado
                MessageBox.Show(resultado.ToString(), "Mensaje de la aplicación");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Muestra el HTML y título de la página
        private void btObtenerHtml_Click(object sender, EventArgs e)
        {
            try{
                //Obtener HTML y Título
                MessageBox.Show(web.DocumentText, web.DocumentTitle);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Obtiene el InnerText del body
        private void btInnerTextBody_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener el body, luego obtener el InnerText
                string texto = web.Document.GetElementsByTagName("body")[0].InnerText;

                MessageBox.Show(texto, "Valor InnerText del body");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Obtiene el InnerHTML del body
        private void btInnerHtmlBody_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener el body, luego obtener el InnerHTML
                string texto = web.Document.GetElementsByTagName("body")[0].InnerHtml;

                MessageBox.Show(texto, "Valor InnerHTML del body");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Obtiene el InnerHTML del Head
        private void btInnerHtmlHead_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener el head, luego obtener el InnerHTML
                string texto = web.Document.GetElementsByTagName("head")[0].InnerHtml;

                MessageBox.Show(texto, "Valor InnerHTML del head");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Aumenta el zoom del body
        private void btAumentar_Click(object sender, EventArgs e)
        {
             try
            {
                //Sumar 25
                valorZoom += 25;

                //Aplicar zoom al body
                web.Document.Body.Style = "zoom:"+ valorZoom.ToString() + "%;";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Reduce el zoom del body
        private void btReducir_Click(object sender, EventArgs e)
        {
            try
            {
                //Restar 25
                valorZoom -= 25;

                //Aplicar zoom al body
                web.Document.Body.Style = "zoom:" + valorZoom.ToString() + "%;";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Desactiva los mensajes de error JavaScript
        private void btDesactivarError_Click(object sender, EventArgs e)
        {
            //Desactivar los mensajes de error JavaScript
            web.ScriptErrorsSuppressed = true;

            //Obtener objeto document del DOM
            HtmlDocument doc = web.Document;

            //Obtener head buscando por TAG
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            //Crear un elemento HTML script
            HtmlElement s = doc.CreateElement("script");

            //Insertar código como un texto al elemento
            s.SetAttribute("text", "function provocarError() {var a = null;var b = a.provocarError;}");

            //Insertar elemento html script al elemento head
            head.AppendChild(s);

            //Invocar Script por su nombre
            web.Document.InvokeScript("provocarError");
        }

        //Activa los mensajes de error JavaScript
        private void btActivarError_Click(object sender, EventArgs e)
        {
            //Activar los mensajes de error JavaScript
            web.ScriptErrorsSuppressed = false;

            //Obtener objeto document del DOM
            HtmlDocument doc = web.Document;

            //Obtener head buscando por TAG
            HtmlElement head = doc.GetElementsByTagName("head")[0];

            //Crear un elemento HTML script
            HtmlElement s = doc.CreateElement("script");

            //Insertar código como un texto al elemento
            s.SetAttribute("text", "function provocarError() {var a = null;var b = a.provocarError;}");

            //Insertar elemento html script al elemento head
            head.AppendChild(s);

            //Invocar Script por su nombre
            web.Document.InvokeScript("provocarError");
        }

        //Ejecuta el click del elemento con ID indicado
        private void btClickear_Click(object sender, EventArgs e)
        {
            try
            {
                string idHtml = "loginBtn";

                //InputBox
                ShowInputDialog(ref idHtml, "Ingresar ID del elemento a Clickear");

                //Buscar elemento del DOM por ID
                HtmlElement elemento = web.Document.GetElementById(idHtml);

                //Ejecutar click
                elemento.InvokeMember("click");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }   
        }

        //Ingresa un value a un elemento buscando por su ID, ideal para llenar formularios
        private void btIngresarValor_Click(object sender, EventArgs e)
        {
            try
            {
                string idHtml = "userName";
                string value;

                //InputBox
                ShowInputDialog(ref idHtml, "Ingresar ID del elemento a setear un value");

                //Buscar elemento del DOM por ID
                HtmlElement elemento = web.Document.GetElementById(idHtml);

                //Obtener campo value
                value = elemento.GetAttribute("value");

                //InputBox
                ShowInputDialog(ref value, "Ingresar value");

                //Setear value
                elemento.SetAttribute("value", value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        //Navega desde la página principal hasta la de Estadísticas de Wireless
        private void btNavegarEstadisticas_Click(object sender, EventArgs e)
        {
            try {
                //Desactivar las notificaciones de error de JavaScript
                web.ScriptErrorsSuppressed = true;

                //Comenzar desde la página inicial
                web.Navigate("192.168.1.1");

                //Luego de completarse la carga de la página continuar con el logueo
                accionWeb = AccionWeb.LoginRouter;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = AccionWeb.ninguna;

                //Reintentar o mostrar mensaje de error y detener
                if (chReintentarWS.Checked)
                    btNavegarEstadisticas_Click(null, null);
                else
                    MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void loginRouter()
        {
            try {
                //Llenar datos para loguearse
                web.Document.GetElementById("userName").SetAttribute("value", "dprsoft");
                web.Document.GetElementById("pcPassword").SetAttribute("value", "DPRSoft1289");
                web.Document.GetElementById("loginBtn").InvokeMember("click");

                //Luego de completarse la carga de la página continuar con yendo al menú Wireless
                accionWeb = AccionWeb.MenuWireless;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = AccionWeb.ninguna;

                //Reintentar o mostrar mensaje de error y detener
                if (chReintentarWS.Checked)
                    btNavegarEstadisticas_Click(null, null);
                else
                    MessageBox.Show("Excepción: " + ex.Message);
            }
        }


        private void menuWireless()
        {
            try {
                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = web.Document.Window.Frames;

                //Buscar el botón Wireless por ID y ejecutar el click
                frame[1].Document.GetElementById("a7").InvokeMember("click");

                //Luego de completarse la carga de la página continuar con yendo al menú Wireless Statistics
                accionWeb = AccionWeb.MenuWirelessStatistics;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = AccionWeb.ninguna;

                //Reintentar o mostrar mensaje de error y detener
                if (chReintentarWS.Checked)
                    btNavegarEstadisticas_Click(null, null);
                else
                    MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void menuWirelessStatistics()
        {
            try
            {
                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = web.Document.Window.Frames;

                //Buscar el botón Wireless por ID y ejecutar el click
                frame[1].Document.GetElementById("a12").InvokeMember("click");

                //Luego de completarse la carga de la página terminar ciclo de ejecución
                accionWeb = AccionWeb.ninguna;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = AccionWeb.ninguna;

                //Reintentar o mostrar mensaje de error y detener
                if (chReintentarWS.Checked)
                    btNavegarEstadisticas_Click(null, null);
                else
                    MessageBox.Show("Excepción: " + ex.Message);
            }
        }

        private void btObenerDatosWireless_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> lsMac = new List<string>();

                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = web.Document.Window.Frames;

                //Buscar la tabla que contiene los datos de las estadísticas
                HtmlElement tabla = frame[2].Document.GetElementsByTagName("TBODY")[1];

                //Obtener las filas
                HtmlElementCollection filas = tabla.GetElementsByTagName("tr");

                //Recorrer las filas, excepto el primero q son los títulos, y obtener cada una de las MACs
                for (int i = 1; i < filas.Count; i++)
                {
                    //Obtener la segunda columna, que es donde esta la MAC y añadir a la lista
                    lsMac.Add(filas[i].GetElementsByTagName("td")[1].InnerText);
                }

                //Mostrar lista de MACs
                String listaMostrar = string.Empty;
                foreach (String mac in lsMac)
                    listaMostrar += mac + Environment.NewLine;
                MessageBox.Show(listaMostrar, "Listado de Macs");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message);
            }
        }
    }
}
