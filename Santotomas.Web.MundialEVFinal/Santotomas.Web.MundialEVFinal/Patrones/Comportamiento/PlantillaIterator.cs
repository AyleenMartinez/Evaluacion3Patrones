using Santotomas.Web.MundialEVFinal.Models.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace Santotomas.Web.MundialEVFinal.Patrones
{
    public class PlantillaIterator : IJugadorIterator
    {
        private readonly List<JugadorMock> _jugadores;
        private int _posicion;

        public PlantillaIterator(IEnumerable<JugadorMock> jugadores)
        {
            _jugadores = jugadores.ToList();
            _posicion = 0;
        }

        public bool TieneSiguiente()
        {
            return _posicion < _jugadores.Count;
        }

        public JugadorMock Siguiente()
        {
            JugadorMock jugador = _jugadores[_posicion];
            _posicion++;

            return jugador;
        }
    }
}