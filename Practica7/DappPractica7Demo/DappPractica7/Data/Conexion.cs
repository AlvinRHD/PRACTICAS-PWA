using System.Data.SqlClient;

namespace DappPractica7.Data
{
    public class Conexion
    {
        private readonly string _conexionString;

        public Conexion(string valor)
        {
            _conexionString = valor;
        }

        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_conexionString);
            conexion.Open();    
            return conexion;
        }
    }
}
