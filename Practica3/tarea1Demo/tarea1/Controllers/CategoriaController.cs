using Microsoft.AspNetCore.Mvc;
using tarea1.Data;
using tarea1.Models;

namespace tarea1.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CategoriaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> Categoria = _appDbContext.tbl_Categoria;
            var objCategoria=Categoria.OrderBy(c=>c.orden).ToList();
            return View(objCategoria);
        }

        public IActionResult Create()
        {
            //IEnumerable<Casa> obj=_appDbContext.tbl_Casa;
            return View(/*obj*/);
        }

        [HttpPost]
        public IActionResult Create(Categoria obj)
        {
            _appDbContext.Add(obj);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var idCategoria = _appDbContext.tbl_Categoria.Find(id);

            if (idCategoria == null)
            {
                return NotFound();
            }

            return View(idCategoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria objCategoria)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Update(objCategoria);
                _appDbContext.SaveChanges();
                TempData["EditCategoria"] = "Se edito la categoria";
                return RedirectToAction("Index");

            }

            return View(objCategoria);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var idCategoria = _appDbContext.tbl_Categoria.Find(id);

            if (idCategoria == null)
            {
                return NotFound();
            }

            return View(idCategoria);
        }

        [HttpPost]
        public IActionResult Delete(Categoria objCategoria)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Remove(objCategoria);
                _appDbContext.SaveChanges();
                TempData["DeleteCategoria"] = "Se elimino la categoria";
                return RedirectToAction("Index");

            }

            return View(objCategoria);
        }
    }
}
