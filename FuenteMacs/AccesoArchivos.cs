using FuenteMacs.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FuenteMacs
{
    //Contiene todos los métodos que cargar o guardan datos en archivos
    class AccesoArchivos
    {
        //Guarda el archivo de configuración inicial de la aplicación con el nombre de archivo indicado
        public void GuardarArchivoConfiguracionInicial(String nombreArchivo, ConfiguracionInicial configuracionInicial)
        {
            try
            {
                XmlSerializer serializadorXml = new XmlSerializer(typeof(ConfiguracionInicial));
                StreamWriter writer = new StreamWriter(nombreArchivo);
                serializadorXml.Serialize(writer, configuracionInicial);
                writer.Close();
            }
            catch (Exception ex)
            {
                ////LOG
            }
        }

        //Carga el archivo de configuración inicial de la aplicación con el nombre de archivo indicado
        public ConfiguracionInicial CargarArchivoConfiguracionInicial(String nombreArchivo)
        {
            ConfiguracionInicial nuevoObjeto = null;
            XmlSerializer serializadorXml = new XmlSerializer(typeof(ConfiguracionInicial));
            StreamReader reader = new StreamReader(nombreArchivo);

            try
            {
                nuevoObjeto = (ConfiguracionInicial)serializadorXml.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                ////LOG
            }

            return nuevoObjeto;
        }
    }
}
