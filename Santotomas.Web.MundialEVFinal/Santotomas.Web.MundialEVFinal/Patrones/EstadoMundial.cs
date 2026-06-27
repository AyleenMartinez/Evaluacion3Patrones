using System;

namespace Santotomas.Web.MundialEVFinal.Patrones
{
    public sealed class EstadoMundial
    {
        private static readonly Lazy<EstadoMundial> _instancia = new Lazy<EstadoMundial>(() => new EstadoMundial());

        public static EstadoMundial Instancia => _instancia.Value;

        public string FaseActual { get; private set; }
        public int TotalGoles { get; private set; }

        private EstadoMundial()
        {
            FaseActual = "Fase de Grupos";
            TotalGoles = 0;
        }

        public void RegistrarGol()
        {
            TotalGoles++;
        }
    }
}