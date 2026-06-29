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

        // Agrega un jugador nuevo a la base de datos usando la factory de conexión
        public void AgregarJugador(JugadorMock jugador)
        {
            using (var conexion = _conexionFactory.CrearConexion())
            {
                conexion.Open();

                using (var comando = conexion.CreateCommand())
                {
                    comando.CommandText = "INSERT INTO Jugadores (Numero, Nombre, Rol, IdPais) VALUES (@Numero, @Nombre, @Rol, 3)";

                    var parametroNumero = comando.CreateParameter();
                    parametroNumero.ParameterName = "@Numero";
                    parametroNumero.Value = jugador.Numero;
                    comando.Parameters.Add(parametroNumero);

                    var parametroNombre = comando.CreateParameter();
                    parametroNombre.ParameterName = "@Nombre";
                    parametroNombre.Value = jugador.Nombre;
                    comando.Parameters.Add(parametroNombre);

                    var parametroRol = comando.CreateParameter();
                    parametroRol.ParameterName = "@Rol";
                    parametroRol.Value = jugador.Rol;
                    comando.Parameters.Add(parametroRol);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}