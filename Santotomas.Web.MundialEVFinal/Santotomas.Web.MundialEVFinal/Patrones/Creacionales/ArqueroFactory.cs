using Santotomas.Web.MundialEVFinal.Models.Mocks;

namespace Santotomas.Web.MundialEVFinal.Patrones
{
    // Factory concreta para crear un arquero
    public class ArqueroFactory : IJugadorFactory
    {
        public JugadorMock CrearJugador()
        {
            return new JugadorMock
            {
                Numero = 12,
                Nombre = "Arquero convocado",
                Rol = "Arquero"
            };
        }
    }
}