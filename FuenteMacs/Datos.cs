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

        //Datos de App.Config
        public static String rutaArchivoConfiguracion = ConfigurationManager.AppSettings["rutaArchivoConfiguracion"];
    }
}
