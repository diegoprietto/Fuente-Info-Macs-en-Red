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

            //Actualizar frecuencia del reloj
            reloj.Interval = Datos.configuracionInicial.frecuenciaMs;

            //Ir a página principal
            controlWeb.navegarHome();

            //Iniciar reloj
            reloj.Start();
        }


        //Navega desde la página principal hasta la de Estadísticas de Wireless
        private void btNavegarEstadisticas_Click(object sender, EventArgs e)
        {
            //Iniciar navegación
            controlWeb.iniciarNavegacion();
        }


        private void btObenerDatosWireless_Click(object sender, EventArgs e)
        {
            //Intentar obtener lista de MACs
            textBox1.Text = controlWeb.obtenerListaMac();
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            //Intentar obtener lista de MACs
            textBox1.Text = DateTime.Now.ToLongTimeString() + Environment.NewLine + controlWeb.obtenerListaMac();
        }
    }
}
