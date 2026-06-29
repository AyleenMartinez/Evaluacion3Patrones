using Santotomas.Web.MundialEVFinal.Models.Mocks;
using Santotomas.Web.MundialEVFinal.Patrones;
using System;
using System.Collections.Generic;

namespace Santotomas.Web.MundialEVFinal.Repository
{
    public class ChannelRepository
    {
        private readonly IConexionFactory _conexionFactory;

        public ChannelRepository()
        {
            _conexionFactory = new SqlMundialFactory();
        }

        #region Codigo original 

        /*
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
        */

        #endregion

        // Obtiene los paises desde la base de datos usando la factory
        public IEnumerable<PaisMock> ObtenerPaises()
        {
            var paises = new List<PaisMock>();

            using (var conexion = _conexionFactory.CrearConexion())
            {
                conexion.Open();

                using (var comando = conexion.CreateCommand())
                {
                    comando.CommandText = "SELECT Nombre, Region, GolesAnotados, CodigoIso FROM Paises";

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            paises.Add(new PaisMock
                            {
                                Nombre = lector["Nombre"].ToString(),
                                Region = lector["Region"].ToString(),
                                GolesAnotados = Convert.ToInt32(lector["GolesAnotados"]),
                                CodigoIso = lector["CodigoIso"].ToString()
                            });
                        }
                    }
                }
            }

            return paises;
        }

        // Obtiene los jugadores desde la base de datos usando la factory
        public IEnumerable<JugadorMock> ObtenerJugadores()
        {
            var jugadores = new List<JugadorMock>();

            using (var conexion = _conexionFactory.CrearConexion())
            {
                conexion.Open();

                using (var comando = conexion.CreateCommand())
                {
                    comando.CommandText = "SELECT Numero, Nombre, Rol FROM Jugadores WHERE IdPais = 3 ORDER BY Numero";

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            jugadores.Add(new JugadorMock
                            {
                                Numero = Convert.ToInt32(lector["Numero"]),
                                Nombre = lector["Nombre"].ToString(),
                                Rol = lector["Rol"].ToString()
                            });
                        }
                    }
                }
            }

            return jugadores;
        }

        // Obtiene la suma total de goles desde la base de datos
        public int ObtenerTotalGolesHistoricos()
        {
            using (var conexion = _conexionFactory.CrearConexion())
            {
                conexion.Open();

                using (var comando = conexion.CreateCommand())
                {
                    comando.CommandText = "SELECT ISNULL(SUM(GolesAnotados), 0) FROM Paises";

                    return Convert.ToInt32(comando.ExecuteScalar());
                }
            }
        }
    }
}