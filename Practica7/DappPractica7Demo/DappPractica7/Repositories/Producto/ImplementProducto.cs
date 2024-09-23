using Dapper;
using DappPractica7.Data;
using DappPractica7.Models;
using System.Data;

namespace DappPractica7.Repositories.Producto
{
    public class ImplementProducto : IProductoRepository
    {

        private readonly Conexion _conexion;

        public ImplementProducto(Conexion conexion)
        {
            _conexion = conexion;
        }

        public IEnumerable<ProductoModel> ObtenerProductos()
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                return conexion.Query<ProductoModel>("sp_obtener_product", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void ActualizarProducto(ProductoModel producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idProducto", producto.idProducto, DbType.Int32);
                parametros.Add("@nombre", producto.nombre, DbType.String);
                parametros.Add("@precio", producto.precio, DbType.Decimal);
                conexion.Execute("sp_actualizar_product", parametros, commandType: CommandType.StoredProcedure);

            }
        }

        public void EliminarProducto(int idProducto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idProducto", idProducto, DbType.Int32);
                conexion.Execute("sp_eliminar_product", parametros, commandType: CommandType.StoredProcedure);

            }
        }

        public void InsertProducto(ProductoModel producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@nombre", producto.nombre, DbType.String);
                parametros.Add("@precio", producto.precio, DbType.Decimal);
                conexion.Execute("sp_insert_product", parametros, commandType: CommandType.StoredProcedure);

            }
        }

        ProductoModel IProductoRepository.ObtenerProductoPorId(int idProducto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@idProducto", idProducto, DbType.Int32);
                return conexion.QueryFirstOrDefault<ProductoModel>("sp_obtener_productId", parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
