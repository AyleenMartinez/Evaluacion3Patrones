namespace Santotomas.Web.MundialEVFinal.Patrones
{
    public class ClimaAdapter : IClimaTorneo
    {
        private readonly ServicioClimaAntiguo _servicioAntiguo;

        public ClimaAdapter(ServicioClimaAntiguo servicioAntiguo)
        {
            _servicioAntiguo = servicioAntiguo;
        }

        public int ObtenerTemperaturaCelsius()
        {
            string texto = _servicioAntiguo.ObtenerTemperaturaFahrenheit();

            string numero = texto.Replace("TEMP_F:", "").Trim();

            int fahrenheit = int.Parse(numero);
            int celsius = (fahrenheit - 32) * 5 / 9;

            return celsius;
        }
    }
}