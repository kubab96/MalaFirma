using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class WymaganieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WymaganieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll();
            return View(objWymaganiaList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Wymaganie obj, int id)
        {
            _unitOfWork.Wymaganie.AddId(obj, id);
            _unitOfWork.Save();
            TempData["success"] = "Wymaganie zostało pomyślnie dodane.";
            return RedirectToAction("SzczegolyZamowienia", "Zamowienie", new { id });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var wymaganieFormDb = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            if (wymaganieFormDb == null)
            {
                return NotFound();
            }
            return View(wymaganieFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Wymaganie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Wymaganie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja Wymagania przebiegła pomyślnie.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Wymaganie.Remove(obj);
            _unitOfWork.Save();
            TempData["delete"] = "Wymaganie zostało usunięte.";
            return RedirectToAction("Index");

        }
    }
}
