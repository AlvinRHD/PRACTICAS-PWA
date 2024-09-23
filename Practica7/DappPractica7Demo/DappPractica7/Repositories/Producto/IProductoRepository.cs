using DappPractica7.Models;

namespace DappPractica7.Repositories.Producto
{
    public interface IProductoRepository
    {
        ProductoModel ObtenerProductoPorId(int idProducto);

        IEnumerable<ProductoModel> ObtenerProductos();

        void InsertProducto(ProductoModel producto);

        void ActualizarProducto (ProductoModel producto);

        void EliminarProducto (int idProducto);




    }
}
