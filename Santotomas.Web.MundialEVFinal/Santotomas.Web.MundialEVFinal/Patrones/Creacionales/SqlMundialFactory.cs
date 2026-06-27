using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Santotomas.Web.MundialEVFinal.Patrones
{
    // Factory para crear la conexion a la base de datos
    public class SqlMundialFactory : IConexionFactory
    {
        public IDbConnection CrearConexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["MundialConnection"].ConnectionString;
            return new SqlConnection(cadena);
        }
    }
}