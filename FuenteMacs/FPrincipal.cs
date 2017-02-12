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
            String msjLog;
            
            //Inicializar Log
            if (!ControlLog.Inicializar(Datos.rutaArchivoLog, out msjLog))
            {
                MessageBox.Show("No se pudo inicializar el control de Log: " + msjLog);
            }
            
            //Obtener datos de configuración del usuario
            Datos.configuracionInicial = accesoArchivos.CargarArchivoConfiguracionInicial(Datos.rutaArchivoConfiguracion);

            //Obtener datos de nombres de dispositivos
            accesoArchivos.cargarNombresDispositivos();

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
            List<String> lsMac;
            List<MacDispositivo> lsObjMac;

            //Intentar obtener lista de MACs
            lsMac = controlWeb.obtenerListaMac();

            //Mapear a objetos
            lsObjMac = mapearObjetoMacDispositivo(lsMac);

            //Actualizar ListBox
            lsConectados.Items.Clear();
            foreach (var item in lsObjMac)
            {
                lsConectados.Items.Add(item);
            }
            //Cantidad de conectados y última actualización
            lbCant.Text = lsConectados.Items.Count.ToString();
            lbUltimaAct.Text = DateTime.Now.ToLongTimeString();
        }

        private void reloj_Tick(object sender, EventArgs e)
        {
            btObenerDatosWireless_Click(null, null);
        }

        private void btConfigurar_Click(object sender, EventArgs e)
        {
            //Iniciar y referenciar los datos de configuración
            FConfigurar ventanaConfigurar = new FConfigurar();
            ventanaConfigurar.entradaDatos = Datos.configuracionInicial;

            //Mostrar ventana
            if (ventanaConfigurar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Obtener datos nuevos y guardar
                Datos.configuracionInicial = ventanaConfigurar.salidaDatos;
                accesoArchivos.GuardarArchivoConfiguracionInicial(Datos.rutaArchivoConfiguracion);

                //Actualizar reloj
                try
                {
                    reloj.Interval = Datos.configuracionInicial.frecuenciaMs;
                }
                catch (Exception ex)
                {
                    //Log
                    reloj.Interval = 1000;

                    ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "FPrincipal.cs", "btConfigurar_Click", "El valor de frecuenciano es correcto, " + Datos.configuracionInicial.frecuenciaMs.ToString() + ": " + ex.Message);
                }

            }
        }

        //Obtiene una lista de Macs y lo convierte en una lista de objetos MacDispositivos, que contiene la descripción
        private List<MacDispositivo> mapearObjetoMacDispositivo(List<String> lsMac)
        {
            List<MacDispositivo> nuevaLista = new List<MacDispositivo>();

            if (lsMac != null)
            {
                foreach (String macActual in lsMac)
                {
                    String descripcion;

                    //Buscar descripción en el diccionario, si no existe colocar el valor de Desconocido
                    if (Datos.descripcionDispositivos.ContainsKey(macActual))
                        descripcion = Datos.descripcionDispositivos[macActual];
                    else
                        descripcion = Datos.leyendaMacSinDescripcion;

                    //Agregar a la lista
                    nuevaLista.Add(new MacDispositivo(macActual, descripcion));
                }
            }

            return nuevaLista;
        }

        private void FPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cerrar Log
            ControlLog.CerrarArchivo();
        }

        //Pausar/Reanudar obtención de datos
        private void chPausar_CheckedChanged(object sender, EventArgs e)
        {
            reloj.Enabled = !reloj.Enabled;
        }
    }
}
