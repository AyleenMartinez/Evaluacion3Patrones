using Santotomas.Web.MundialEVFinal.Models;
using Santotomas.Web.MundialEVFinal.Patrones;
using Santotomas.Web.MundialEVFinal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Santotomas.Web.MundialEVFinal.Controllers
{
    public class HomeController : Controller
    {
        // Instancia del repositorio para acceeder a los datos
        private readonly ChannelRepository _repository = new ChannelRepository();

        private readonly Dictionary<string, IJugadorFactory> _fabricasDeJugadores =
            new Dictionary<string, IJugadorFactory>
            {
                { "Arquero", new ArqueroFactory() },
                { "Delantero", new DelanteroFactory() }
            };

        public ActionResult Index()
        {
            ViewBag.FaseActual = EstadoMundial.Instancia.FaseActual;
            ViewBag.GolesMundial = EstadoMundial.Instancia.TotalGoles;

            // Inyección de la URL de la bandera directamente en la proyección funcional
            var selecciones = _repository.ObtenerPaises().Select(p => new SeleccionViewModel
            {
                Pais = p.Nombre,
                Continente = p.Region,
                GolesTotales = p.GolesAnotados,
                UrlBandera = $"https://flagcdn.com/w80/{p.CodigoIso.ToLower()}.png"
            });

            return View(selecciones);
        }

        #region codigo anterior MiEquipo
        /*
        public ActionResult MiEquipo()
        {
            // TAREA ITERATOR: reemplazar la lectura directa
            // del repositorio por su propia implementación del patrón Iterator.
            var plantilla = _repository.ObtenerJugadores().Select(j => new JugadorViewModel
            {
                Dorsal = j.Numero,
                Nombre = j.Nombre,
                Posicion = j.Rol
            });

            return View(plantilla);
        } */
        #endregion

        public ActionResult MiEquipo()
        {
            // TAREA ITERATOR: se recorre la plantilla usando TieneSiguiente() y Siguiente()
            var iterator = new PlantillaIterator(_repository.ObtenerJugadores());
            var plantilla = new List<JugadorViewModel>();

            while (iterator.TieneSiguiente())
            {
                var jugador = iterator.Siguiente();

                plantilla.Add(new JugadorViewModel
                {
                    Dorsal = jugador.Numero,
                    Nombre = jugador.Nombre,
                    Posicion = jugador.Rol
                });
            }

            return View(plantilla);
        }

        #region Codigo original ConvocarJugador
        /*
        [HttpPost]
        public ActionResult ConvocarJugador(string tipoPosicion)
        {
            //TAREA FACTORY METHOD: Resolución de objetos sin usar 'switch' ni 'if'.
            //Reemplazar el valor "null" por el llamado a sus propias fábricas.
            var fabricasDeJugadores = new Dictionary<string, Func<object>>
            {
                { "Arquero", () =>  null },
                { "Delantero", () =>  null }
            };

            // Ejecución polimórfica directa (la llave "tipoPosicion" viene del formulario HTML)
            var nuevoJugador = fabricasDeJugadores[tipoPosicion].Invoke();

            // Simulamos que al convocar un jugador se anota un gol en el entrenamiento
            // para que los alumnos vean el patrón Singleton actualizando el Dashboard en vivo.
            EstadoMundial.Instancia.RegistrarGol();

            return RedirectToAction("MiEquipo");
        }
        */
        #endregion

        [HttpPost]
        public ActionResult ConvocarJugador(string tipoPosicion)
        {
            // Se obtiene la fabrica según la llave enviada desde el formulario
            var nuevoJugador = _fabricasDeJugadores[tipoPosicion].CrearJugador();

            // Se guarda el jugador creado para que aparezca en la plantilla
            _repository.AgregarJugador(nuevoJugador);

            // Se mantiene la lógica del Singleton que venía en el controlador
            EstadoMundial.Instancia.RegistrarGol();

            return RedirectToAction("MiEquipo");
        }

        #region Codigo original Logistica

        /*
        public ActionResult Logistica()
        {
            // TAREA ADAPTER: Reemplazar este dummy por su Adapter real
            // que consuma la clase simulada ServicioClimaAntiguo en grados Fahrenheit.
            ViewBag.TemperaturaCelsius = 22;
            ViewBag.CondicionClima = "Soleado";

            return View();
        }
        */

        #endregion

        public ActionResult Logistica()
        {
            // TAREA ADAPTER: se usa el adaptador para convertir Fahrenheit a Celsius
            ServicioClimaAntiguo servicioAntiguo = new ServicioClimaAntiguo();
            IClimaTorneo clima = new ClimaAdapter(servicioAntiguo);

            ViewBag.TemperaturaCelsius = clima.ObtenerTemperaturaCelsius();
            ViewBag.CondicionClima = "Soleado";

            return View();
        }
    }
}
