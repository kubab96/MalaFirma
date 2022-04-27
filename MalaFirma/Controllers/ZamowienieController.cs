using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class ZamowienieController : Controller
    {
        private readonly IZamowienieRepository _db;

        public ZamowienieController(IZamowienieRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Zamowienie> objZamowienieList = _db.GetAll();
            return View(objZamowienieList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Zamowienie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Zamówienie zostało pomyślnie dodane";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var zamowienieFormDb = _db.GetFirstOrDefault(x => x.Id == id);
            if (zamowienieFormDb == null)
            {
                return NotFound();
            }
            return View(zamowienieFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Zamowienie obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Edycja zamówienia przebiegła pomyślnie";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.GetFirstOrDefault(x=>x.Id==id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.Save();
            TempData["delete"] = "Zamówienie zostało usunięte";
            return RedirectToAction("Index");

        }
    }
}
