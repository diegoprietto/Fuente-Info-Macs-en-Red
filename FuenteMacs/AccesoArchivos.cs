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
        public void GuardarArchivoConfiguracionInicial(String nombreArchivo)
        {
            try
            {
                XmlSerializer serializadorXml = new XmlSerializer(typeof(ConfiguracionInicial));
                StreamWriter writer = new StreamWriter(nombreArchivo);
                serializadorXml.Serialize(writer, Datos.configuracionInicial);
                writer.Close();
            }
            catch (Exception ex)
            {
                //Log
                ControlLog.EscribirLog(ControlLog.TipoGravedad.ERROR, "AccesoArchivos.cs", "GuardarArchivoConfiguracionInicial", "Error al intentar guardar el archivo de configuración en '" + nombreArchivo + "': " + ex.Message);
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
                //Log
                ControlLog.EscribirLog(ControlLog.TipoGravedad.ERROR, "AccesoArchivos.cs", "CargarArchivoConfiguracionInicial", "Error al intentar cargar el archivo de configuración '" + nombreArchivo + "': " + ex.Message);
            }

            return nuevoObjeto;
        }

        //Carga del archivo la lista de MACs junto a descripciones de que equipo se trata
        public void cargarNombresDispositivos()
        {
            string[] lineas = new string[0];
            string ruta = Datos.configuracionInicial.rutaArchivoDispositivos;

            //Cargar archivo
            try
            {
                if (!(File.Exists(ruta)))
                {
                    //No se encontró el archivo
                    ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "AccesoArchivos.cs", "cargarNombresDispositivos", "No se encontró el archivo de dispositivos '" + ruta);
                    return;
                }

                lineas = System.IO.File.ReadAllLines(ruta);
            }
            catch (Exception ex)
            {
                ControlLog.EscribirLog(ControlLog.TipoGravedad.WARNING, "AccesoArchivos.cs", "cargarNombresDispositivos", "Se produjo un error en la lectura del archivo de dispositivos: " + ex.Message);
                return;
            }

            //Recorrer los registros
            foreach (string registro in lineas)
            {
                string registroAct = registro.Trim();
                string[] registroArr;

                //Registro no vacio
                if (registroAct != string.Empty)
                {
                    registroArr = registroAct.Split('\t');

                    //Valores no vacios
                    if (registroArr.Length > 1 && registroArr[0].Trim() != string.Empty && registroArr[0].Trim() != string.Empty)
                    {
                        //Añadir a la lista
                        Datos.descripcionDispositivos.Add(registroArr[0].Trim(), registroArr[1].Trim());
                    }
                }
            }
        }
    }
}
