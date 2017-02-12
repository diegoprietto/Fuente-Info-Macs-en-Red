using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuenteMacs.Modelos
{
    //Estructura que representa al archivo de configuración de usuario
    public class ConfiguracionInicial
    {
        public String ipRouter = "192.168.1.1";                             //IP de la página de configuración del Router
        public int frecuenciaMs = 1000;                                     //Frecuencia de revisar los dispositivos conectados
        public String rutaArchivoDispositivos = "dispositivos.txt";         //Archivo que contiene las descripciones de los dispositivos según la MAC
        public String usuario = "usuario";                                  //Login del router
        public String pass = "pass";
    }
}
