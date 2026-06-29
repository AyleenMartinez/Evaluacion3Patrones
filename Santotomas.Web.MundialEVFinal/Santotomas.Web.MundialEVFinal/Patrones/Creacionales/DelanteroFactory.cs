using Santotomas.Web.MundialEVFinal.Models.Mocks;

namespace Santotomas.Web.MundialEVFinal.Patrones
{
    // Factory concreta para crear un delantero
    public class DelanteroFactory : IJugadorFactory
    {
        public JugadorMock CrearJugador()
        {
            return new JugadorMock
            {
                Numero = 9,
                Nombre = "Delantero convocado",
                Rol = "Delantero"
            };
        }
    }
}