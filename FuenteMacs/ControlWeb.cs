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
        //Número de veces que se reintenta en caso de error, antes de volver a comenzar el ciclo de navegar hasta la página de estatísticas
        private int reintentos = Datos.cantidadReintentosAnteFallo;


        //Acción a realizar luego que se complete la carga del documento (DocumentCompleted)
        public FuenteMacs.FPrincipal.AccionWeb accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;

        public ControlWeb(WebBrowser control)
        {
            _web = control;
        }

        //Accede a la página principal
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
                _web.Document.GetElementById("userName").SetAttribute("value", Datos.configuracionInicial.usuario);
                _web.Document.GetElementById("pcPassword").SetAttribute("value", Datos.configuracionInicial.pass);
                _web.Document.GetElementById("loginBtn").InvokeMember("click");

                //Luego de completarse la carga de la página continuar con yendo al menú Wireless
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.MenuWireless;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;

                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "ControlWeb.cs", "loginRouter", "Error de logueo del router: " + ex.Message);
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

                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "ControlWeb.cs", "menuWireless", "Error al intentar acceder a la vista de Wireless: " + ex.Message);
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

                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "ControlWeb.cs", "menuWirelessStatistics", "Error al intentar acceder a la vista de WirelessStatistics: " + ex.Message);
            }
        }

        //Inicia el ciclo para llegar a la vista buscada (Estadísticas)
        public void iniciarNavegacion()
        {
            try
            {
                //Comenzar desde la página inicial
                navegarHome();

                //Luego de completarse la carga de la página continuar con el logueo
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.LoginRouter;
            }
            catch (Exception ex)
            {
                //Evitar un posible bucle infinito
                accionWeb = FuenteMacs.FPrincipal.AccionWeb.ninguna;

                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "ControlWeb.cs", "iniciarNavegacion", "Error al intentar reiniciar la navegación web: " + ex.Message);
            }
        }

        //Intenta obtener la lista de MACs
        public List<String> obtenerListaMac()
        {
            try
            {
                List<String> lsMac = new List<string>();

                //Buscar el frame correspondiente donde se encuentra los botones a partir del name
                HtmlWindowCollection frame = _web.Document.Window.Frames;

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

                //Reiniciar contador
                reintentos = Datos.cantidadReintentosAnteFallo;

                return lsMac;
            }
            catch (Exception ex)
            {
                //Reducir el número de reintentos
                reintentos--;
                if (reintentos == 0) {
                    //Volver a navegar desde el inicio, reiniciar contador
                    reintentos = Datos.cantidadReintentosAnteFallo;
                    iniciarNavegacion();
                }

                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "ControlWeb.cs", "obtenerListaMac", "Error al intentar leer las direcciones Macs de la web: " + ex.Message);
                return null;
            }
        }

    }
}
