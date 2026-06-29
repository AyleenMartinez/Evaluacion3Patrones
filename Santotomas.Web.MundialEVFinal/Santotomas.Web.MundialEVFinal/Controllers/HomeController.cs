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
        // Instancia del repositorio con los datos simulados
        private readonly ChannelRepository _repository = new ChannelRepository();

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
        }

        #region Codigo original
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

            // Diccionario de fabricas para crear jugadores sin usar switch ni if
            var fabricasDeJugadores = new Dictionary<string, IJugadorFactory>
            {
                { "Arquero", new ArqueroFactory() },
                { "Delantero", new DelanteroFactory() }
            };

            // Se obtiene la fabrica según la llave enviada desde el formulario
            var nuevoJugador = fabricasDeJugadores[tipoPosicion].CrearJugador();

            // Se mantiene la lógica del Singleton que venía en el controlador
            EstadoMundial.Instancia.RegistrarGol();

            return RedirectToAction("MiEquipo");
        }

        public ActionResult Logistica()
        {
            // TAREA ADAPTER: Reemplazar este dummy por su Adapter real
            // que consuma la clase simulada ServicioClimaAntiguo en grados Fahrenheit.
            ViewBag.TemperaturaCelsius = 22;
            ViewBag.CondicionClima = "Soleado";

            return View();
        }
    }
}
