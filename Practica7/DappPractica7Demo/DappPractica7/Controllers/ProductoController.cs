using DappPractica7.Models;
using DappPractica7.Repositories.Producto;
using Microsoft.AspNetCore.Mvc;

namespace DappPractica7.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IProductoRepository _iproductoRepository;
        public ProductoController(IProductoRepository iproductoRepository)
        {
            _iproductoRepository = iproductoRepository;
        }

        public IActionResult Index()
        {
            var producto = _iproductoRepository.ObtenerProductos();
            return View(producto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductoModel productoModel) 
        {
            _iproductoRepository.InsertProducto(productoModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int idProducto)
        {
            var producto = _iproductoRepository.ObtenerProductoPorId(idProducto);
            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(ProductoModel productoModel)
        {
            _iproductoRepository.ActualizarProducto(productoModel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int idProducto)
        {
            var producto = _iproductoRepository.ObtenerProductoPorId(idProducto);
            if (producto==null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        public IActionResult DeletePost(int idProducto)
        {
            _iproductoRepository.EliminarProducto(idProducto);
            return RedirectToAction(nameof(Index));
        }
    }
}
