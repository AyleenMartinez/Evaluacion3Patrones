using Santotomas.Web.MundialEVFinal.Models.Mocks;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Santotomas.Web.MundialEVFinal.Patrones;

namespace Santotomas.Web.MundialEVFinal.Repository
{
    public class ChannelRepository
    {
        private readonly IConexionFactory _conexionFactory;

        public ChannelRepository()
        {
            _conexionFactory = new SqlMundialFactory();
        }

        /// <summary>
        /// Método que obtiene la lista de países desde la base de datos y los mapea a objetos PaisMock.
        /// </summary>
        /// <returns>Una colección de objetos PaisMock que representan los países.</returns>
        public IEnumerable<PaisMock> ObtenerPaises()
        {
            var tabla = new DataTable();

            using (var conexion = _conexionFactory.CrearConexion())
            using (var comando = new SqlCommand("SELECT Nombre, Region, GolesAnotados, CodigoIso FROM Paises", conexion))
            using (var adaptador = new SqlDataAdapter(comando))
            {
                adaptador.Fill(tabla);
            }

            return tabla.AsEnumerable().Select(row => new PaisMock
            {
                Nombre = row.Field<string>("Nombre"),
                Region = row.Field<string>("Region"),
                GolesAnotados = row.Field<int>("GolesAnotados"),
                CodigoIso = row.Field<string>("CodigoIso")
            }).ToList();
        }

        // Retorna la plantilla inicial para probar el Iterator
        // MODIFICAR ESTE MÉTODO PARA QUE OBTENGAN LOS JUGADORES DESDE LA BASE DE DATOS
        public IEnumerable<JugadorMock> ObtenerJugadores()
        {
            return new List<JugadorMock>
            {
                new JugadorMock { Numero = 1, Nombre = "C. Bravo", Rol = "Arquero" },
                new JugadorMock { Numero = 17, Nombre = "G. Medel", Rol = "Defensa" },
                new JugadorMock { Numero = 8, Nombre = "A. Vidal", Rol = "Mediocampista" },
                new JugadorMock { Numero = 10, Nombre = "A. Sánchez", Rol = "Delantero" }
            };
        }
    }
}