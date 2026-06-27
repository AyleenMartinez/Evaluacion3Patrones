using Santotomas.Web.MundialEVFinal.Models.Mocks;
using System.Collections.Generic;
using System.Data;

namespace Santotomas.Web.MundialEVFinal.Patrones
{
    // Contrato para crear conexiones a la base de datos
    public interface IConexionFactory
    {
        IDbConnection CrearConexion();
    }

    // Contrato para crear jugadores
    public interface IJugadorFactory
    {
        JugadorMock CrearJugador();
    }

    // Contrato para recorrer jugadores
    public interface IJugadorIterator
    {
        bool TieneSiguiente();
        JugadorMock Siguiente();
    }

    // Contrato para adaptar el clima
    public interface IClimaTorneo
    {
        int ObtenerTemperaturaCelsius();
    }
}