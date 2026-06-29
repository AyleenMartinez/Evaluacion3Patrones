using Santotomas.Web.MundialEVFinal.Repository;
using System;

namespace Santotomas.Web.MundialEVFinal.Patrones
{
    public sealed class EstadoMundial
    {
        private static readonly Lazy<EstadoMundial> _instancia = new Lazy<EstadoMundial>(() => new EstadoMundial());

        private static readonly object _bloqueo = new object();

        public static EstadoMundial Instancia => _instancia.Value;

        public string FaseActual { get; private set; }
        public int TotalGoles { get; private set; }

        #region Codigo original

        /*
        private EstadoMundial()
        {
            FaseActual = "Fase de Grupos";
            TotalGoles = 0;
        }

        public void RegistrarGol()
        {
            TotalGoles++;
        }
        */

        #endregion

        // Constructor privado: evita crear objetos EstadoMundial con new desde otras clases
        private EstadoMundial()
        {
            FaseActual = "Fase de Grupos";

            ChannelRepository repositorio = new ChannelRepository();
            TotalGoles = repositorio.ObtenerTotalGolesHistoricos();
        }

        // Se usa lock para evitar problemas si varias peticiones registran goles al mismo tiempo
        public void RegistrarGol()
        {
            lock (_bloqueo)
            {
                TotalGoles++;
            }
        }
    }
}