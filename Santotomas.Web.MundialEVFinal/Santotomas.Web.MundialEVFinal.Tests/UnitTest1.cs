using Microsoft.VisualStudio.TestTools.UnitTesting;
using Santotomas.Web.MundialEVFinal.Patrones;

namespace Santotomas.Web.MundialEVFinal.Tests
{
    [TestClass]
    public class PatronesTests
    {
        [TestMethod]
        public void Singleton_DebeRetornarLaMismaInstancia()
        {
            var instancia1 = EstadoMundial.Instancia;
            var instancia2 = EstadoMundial.Instancia;

            Assert.AreSame(instancia1, instancia2);
        }

        [TestMethod]
        public void Adapter_DebeConvertirFahrenheitACelsius()
        {
            ServicioClimaAntiguo servicioAntiguo = new ServicioClimaAntiguo("TEMP_F: 50");
            IClimaTorneo adapter = new ClimaAdapter(servicioAntiguo);

            int resultado = adapter.ObtenerTemperaturaCelsius();

            Assert.AreEqual(10, resultado);
        }
    }
}