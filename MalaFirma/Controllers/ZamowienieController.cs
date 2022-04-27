using MalaFirma.DataAccess;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class ZamowienieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ZamowienieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Zamowienie> objZamowienieList = _db.Zamowienia;
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
                _db.Zamowienia.Add(obj);
                _db.SaveChanges();
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
            var zamowienieFormDb = _db.Zamowienia.FirstOrDefault(x => x.Id == id);
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
                _db.Zamowienia.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Edycja zamówienia przebiegła pomyślnie";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _db.Zamowienia.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Zamowienia.Remove(obj);
            _db.SaveChanges();
            TempData["delete"] = "Zamówienie zostało usunięte";
            return RedirectToAction("Index");

        }
    }
}
