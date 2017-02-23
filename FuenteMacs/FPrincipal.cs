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
using System.Runtime.InteropServices;

namespace FuenteMacs
{
    public partial class FPrincipal : Form
    {
        #region Bloque Código Silenciar WebBrowser
        //Constantes
        private const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        private const int SET_FEATURE_ON_THREAD = 0x00000001;
        private const int SET_FEATURE_ON_PROCESS = 0x00000002;
        private const int SET_FEATURE_IN_REGISTRY = 0x00000004;
        private const int SET_FEATURE_ON_THREAD_LOCALMACHINE = 0x00000008;
        private const int SET_FEATURE_ON_THREAD_INTRANET = 0x00000010;
        private const int SET_FEATURE_ON_THREAD_TRUSTED = 0x00000020;
        private const int SET_FEATURE_ON_THREAD_INTERNET = 0x00000040;
        private const int SET_FEATURE_ON_THREAD_RESTRICTED = 0x00000080;

        // Necessary dll import
        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return:MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(
        int FeatureEntry,
        [MarshalAs(UnmanagedType.U4)] int dwFlags,
        bool fEnable);

        #endregion

        AccesoArchivos accesoArchivos = new AccesoArchivos();
        ControlWeb controlWeb;
        MemoriaCompartida memoriaCompartida;
        ControlMongo controlMongo;

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
            //Silenciar aplicación
            try
            {
                CoInternetSetFeatureEnabled(FEATURE_DISABLE_NAVIGATION_SOUNDS, SET_FEATURE_ON_PROCESS, true);
            }
            catch (Exception) { }

            String msjLog;
            
            //Inicializar Log
            if (!ControlLog.Inicializar(Datos.rutaArchivoLog, out msjLog))
            {
                MessageBox.Show("No se pudo inicializar el control de Log: " + msjLog);
            }

            //Inicializar memoria compartida
            memoriaCompartida = new MemoriaCompartida(Datos.nombreMemoriaCompartida, Datos.nombreMutexCompartido, Datos.capacidadMemoriaCompartida);
            if (!memoriaCompartida.IniciarConexion(ref msjLog))
            {
                //Error
                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "FPrincipal.cs", "Form1_Load", "Error al inicializar la memoria compartida: " + msjLog);
                MessageBox.Show("Error al inicializar la memoria compartida: " + msjLog);
            }

            //Inicalizar control de acceso a MongoDB
            controlMongo = new ControlMongo(Datos.mongoUrlConexion,Datos.mongoNombreBaseDatos,Datos.mongoNombreColeccion);
            try
            {
                controlMongo.inicializar();
            }
            catch (Exception ex)
            {
                //Error
                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "FPrincipal.cs", "Form1_Load", "Error al inicializar la conexión con la Base de Datos Mongo: " + ex.Message);
                MessageBox.Show("Error al inicializar la conexión con la Base de Datos de Mongo " + ex.Message);
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
            String cadenaMemoria;
            String msjLog = String.Empty;

            //Intentar obtener lista de MACs
            lsMac = controlWeb.obtenerListaMac();

            if (lsMac != null)
            {
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

                //Formatear para guardar en memoria
                cadenaMemoria = FormatearCadenaParaMemoria(lsMac);

                //Actualizar archivo en memoria
                if (!memoriaCompartida.EscribirEnMemoria(cadenaMemoria, ref msjLog))
                {
                    //Error
                    ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "FPrincipal.cs", "btObenerDatosWireless_Click", "Error al actualizar la memoria compartida: " + msjLog);
                }

                //Actualizar Base de Datos MongoDB
                ActualizarBaseDatosMongo(lsObjMac);
            }
        }

        //Convertir a una sola cadena y agregar fecha
        private String FormatearCadenaParaMemoria(List<String> listaMac)
        {
            String hora = DateTime.Now.ToString("yyyyMMddHHmmss");

            //Si no hay items solo enviar la hora
            if (listaMac.Count == 0)
                return hora;
            else
                return (hora + "&" + String.Join("&", listaMac));
        }

        //Actualiza la colección para que muestre solo los dispositivos conectados, con la MAC y Descripción
        private void ActualizarBaseDatosMongo(List<MacDispositivo> lsDispositivos)
        {
            try
            {
                controlMongo.eliminarColeccion();
                controlMongo.InsertarMuchosDocumentos(lsDispositivos);
            }
            catch (Exception ex)
            {
                //Error
                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "FPrincipal.cs", "ActualizarBaseDatosMongo", "Error al intentar insertar documentos a la Base de Datos Mongo: " + ex.Message);
            }
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
