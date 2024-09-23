using Microsoft.AspNetCore.Mvc;
using tarea1.Data;
using tarea1.Models;

namespace tarea1.Controllers
{
    public class CasaController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CasaController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Casa> modelCasa = _appDbContext.tbl_Casa;

            return View(modelCasa);
        }


        public IActionResult Create()
        {
            //IEnumerable<Casa> obj=_appDbContext.tbl_Casa;
            return View(/*obj*/);
        }

        [HttpPost]
        public IActionResult Create(Casa obj)
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

            var idCasa = _appDbContext.tbl_Casa.Find(id);

            if (idCasa == null)
            {
                return NotFound();
            }

            return View(idCasa);
        }

        [HttpPost]
        public IActionResult Edit(Casa objCasa)
        {
            if(ModelState.IsValid)
            {
                _appDbContext.Update(objCasa);
                _appDbContext.SaveChanges();
                TempData["EditCasa"] = "Se edito la consola";
                return RedirectToAction("Index");

            }

            return View(objCasa);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            var idCasa = _appDbContext.tbl_Casa.Find(id);

            if (idCasa == null)
            {
                return NotFound();
            }

            return View(idCasa);
        }

        [HttpPost]
        public IActionResult Delete(Casa objCasa)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Remove(objCasa);
                _appDbContext.SaveChanges();
                TempData["DeleteCasa"] = "Se elimino la consola";
                return RedirectToAction("Index");

            }

            return View(objCasa);
        }

    }
}
