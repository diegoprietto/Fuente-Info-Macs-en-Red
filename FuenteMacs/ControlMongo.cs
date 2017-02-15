using FuenteMacs.Modelos;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuenteMacs
{
    //Recursos de Mongo: Install-Package mongocsharpdriver
    class ControlMongo
    {
        private MongoUrl _mu;
        private MongoClient _mc;
        private IMongoDatabase _mongo;

        private String _cadenaConexion;
        private String _nombreBaseDatos;
        private String _nombreColeccion;

        //Constructor
        public ControlMongo(String cadenaConexion, String nombreBaseDatos, String nombreColeccion)
        {
            _cadenaConexion = cadenaConexion;
            _nombreBaseDatos = nombreBaseDatos;
            _nombreColeccion = nombreColeccion;
        }

        //Inicia la conexión
        public void inicializar()
        {
            //Conectar
            _mu = new MongoUrl(_cadenaConexion);

            //Definir cliente MongoDB
            _mc = new MongoClient(_mu);

            //Acceso a la Base de Datos
            _mongo = _mc.GetDatabase(_nombreBaseDatos);
        }

        //Vaciar colección
        public void eliminarColeccion()
        {
            //Obtener colección
            var coleccionBD = _mongo.GetCollection<MacDispositivo>(_nombreColeccion);

            _mongo.DropCollection(_nombreColeccion);
        }

        //Escribir en BD
        public void InsertarDocumento(MacDispositivo documento)
        {
            //Obtener colección
            var coleccionBD = _mongo.GetCollection<MacDispositivo>(_nombreColeccion);

            coleccionBD.InsertOne(documento);
        }

        //Insertar varios items en BD
        public void InsertarMuchosDocumentos(List<MacDispositivo> documentos)
        {
            //Obtener colección
            var coleccionBD = _mongo.GetCollection<MacDispositivo>(_nombreColeccion);

            coleccionBD.InsertMany(documentos);
        }

        //Obtener un documento de la BD
        public IQueryable ObtenerDocumentosFiltradoPorUsuario(String mac)
        {
            //Obtener colección
            var coleccionBD = _mongo.GetCollection<MacDispositivo>(_nombreColeccion);

            // filtro de busqueda
            var queryBuscar = Query<MacDispositivo>.EQ(eventoQ => eventoQ.MAC, "Administrador");

            var items = coleccionBD.AsQueryable<MacDispositivo>();

            // seleccionar con Linq
            var resultados = from l in items
                      where l.MAC == mac
                      select l;

            return resultados;
        }

    }
}
