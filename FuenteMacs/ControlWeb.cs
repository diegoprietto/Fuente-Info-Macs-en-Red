using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuenteMacs
{
    //Realiza toda la lógica necesaria con el control WebBrowser
    class ControlWeb
    {
        //Referencia al control
        private WebBrowser _web;

        //Acción a realizar luego que se complete la carga del documento (DocumentCompleted)
        public FuenteMacs.FPrincipal.AccionWeb accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;

        public ControlWeb(WebBrowser control)
        {
            _web = control;
        }

        //Accede a la página principal, 
        public void navegarHome()
        {
            //Ir a IP del Router
            _web.Navigate(Datos.configuracionInicial.ipRouter);

            //Desactivar los mensajes de error JavaScript
            _web.ScriptErrorsSuppressed = true;
        }

        //Loguear
        public void loginRouter()
        {
            try
            {
                //Llenar datos para loguearse
                _web.Document.GetElementById("userName").SetAttribute("value", "dprsoft");
                _web.Document.GetElementById("pcPassword").SetAttribute("value", "DPRSoft1289");
                _web.Document.GetElementById("loginBtn").InvokeMember("click");

                //Luego de completarse la carga de la página continuar con yendo al menú Wireless
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.MenuWireless;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;

                //Reintentar
                ////btNavegarEstadisticas_Click(null, null);
            }
        }


        public void menuWireless()
        {
            try
            {
                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = _web.Document.Window.Frames;

                //Buscar el botón Wireless por ID y ejecutar el click
                frame[1].Document.GetElementById("a7").InvokeMember("click");

                //Luego de completarse la carga de la página continuar con yendo al menú Wireless Statistics
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.MenuWirelessStatistics;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;

                //Reintentar
                ////btNavegarEstadisticas_Click(null, null);
            }
        }

        public void menuWirelessStatistics()
        {
            try
            {
                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = _web.Document.Window.Frames;

                //Buscar el botón Wireless por ID y ejecutar el click
                frame[1].Document.GetElementById("a12").InvokeMember("click");

                //Luego de completarse la carga de la página terminar ciclo de ejecución
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;

                //Reintentar o mostrar mensaje de error y detener
                ////btNavegarEstadisticas_Click(null, null);
            }
        }

    }
}
