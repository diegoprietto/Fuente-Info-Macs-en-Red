using FuenteMacs.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuenteMacs
{
    public partial class FConfigurar : Form
    {
        //Objetos de datos
        public ConfiguracionInicial entradaDatos = null;
        public ConfiguracionInicial salidaDatos = new ConfiguracionInicial();

        public FConfigurar()
        {
            InitializeComponent();
        }

        private void FConfigurar_Load(object sender, EventArgs e)
        {
            //Colocar datos en los controles
            if (entradaDatos != null)
            {
                txIpRouter.Text = entradaDatos.ipRouter.Trim();
                txFrecuenciaMs.Text = entradaDatos.frecuenciaMs.ToString();
                txRutaArchivoDispositivos.Text = entradaDatos.rutaArchivoDispositivos.Trim();
                txUsuario.Text = entradaDatos.usuario.Trim();
                txPass.Text = entradaDatos.pass.Trim();
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            //Validar
            int valorFrecuencia;

            if (!int.TryParse(txFrecuenciaMs.Text, out valorFrecuencia))
                valorFrecuencia = 1000;

            //Actualizar datos
            salidaDatos.ipRouter = txIpRouter.Text.Trim();
            salidaDatos.frecuenciaMs = valorFrecuencia;
            salidaDatos.rutaArchivoDispositivos = txRutaArchivoDispositivos.Text.Trim();
            salidaDatos.usuario = txUsuario.Text.Trim();
            salidaDatos.pass = txPass.Text.Trim();
        }
    }
}
