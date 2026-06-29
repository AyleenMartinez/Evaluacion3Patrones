namespace Santotomas.Web.MundialEVFinal.Patrones
{
    public class ServicioClimaAntiguo
    {
        private readonly string _temperatura;

        public ServicioClimaAntiguo()
        {
            _temperatura = "TEMP_F: 86";
        }

        public ServicioClimaAntiguo(string temperatura)
        {
            _temperatura = temperatura;
        }

        public string ObtenerTemperaturaFahrenheit()
        {
            return _temperatura;
        }
    }
}