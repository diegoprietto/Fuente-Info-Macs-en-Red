using FuenteMacs.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteMacs
{
    //(Static) Referencia a los datos usados de forma global en la aplicación
    public class Datos
    {
        //Datos del archivo de configuración
        public static ConfiguracionInicial configuracionInicial;
        //Diccionario que relaciona las MACs con las descripciones de dispositivos que se leyó del archivo de dispositivos
        public static Dictionary<String,String> descripcionDispositivos = new Dictionary<string,string>();

        //Datos de App.Config
        public static String rutaArchivoConfiguracion = ConfigurationManager.AppSettings["rutaArchivoConfiguracion"];
        public static String rutaArchivoLog = ConfigurationManager.AppSettings["rutaArchivoLog"];
        public static String nombreMemoriaCompartida = ConfigurationManager.AppSettings["nombreMemoriaCompartida"];
        public static String nombreMutexCompartido = ConfigurationManager.AppSettings["nombreMutexCompartido"];
        public static long capacidadMemoriaCompartida = long .Parse(ConfigurationManager.AppSettings["capacidadMemoriaCompartida"]);
        public static int cantidadReintentosAnteFallo = int.Parse(ConfigurationManager.AppSettings["cantidadReintentosAnteFallo"]);
        public static String leyendaMacSinDescripcion = ConfigurationManager.AppSettings["leyendaMacSinDescripcion"];

    }
}
