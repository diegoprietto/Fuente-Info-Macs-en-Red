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
using System.Configuration;
using FuenteMacs.Modelos;

namespace FuenteMacs
{
    public partial class FPrincipal : Form
    {
        AccesoArchivos accesoArchivos = new AccesoArchivos();
        ControlWeb controlWeb;


        
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

        //Evento del control web, llama al método correspondiente hasta llegar a la vista final
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            switch (controlWeb.accionWeb)
            {
                case AccionWeb.ninguna:
                    return;
                case AccionWeb.LoginRouter:
                    controlWeb.loginRouter();
                    return;
                case AccionWeb.MenuWireless:
                    controlWeb.menuWireless();
                    return;
                case AccionWeb.MenuWirelessStatistics:
                    controlWeb.menuWirelessStatistics();
                    return;
                default:
                    controlWeb.accionWeb = AccionWeb.ninguna;
                    return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Obtener datos de configuración del usuario
            Datos.configuracionInicial = accesoArchivos.CargarArchivoConfiguracionInicial(Datos.rutaArchivoConfiguracion);

            //Inicializar objeto que accede al control WebBrowser
            controlWeb = new ControlWeb(web);

            //Ir a página principal
            controlWeb.navegarHome();
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
                controlWeb.accionWeb = AccionWeb.LoginRouter;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                controlWeb.accionWeb = AccionWeb.ninguna;

                //Reintentar o mostrar mensaje de error y detener
                ////btNavegarEstadisticas_Click(null, null);
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
