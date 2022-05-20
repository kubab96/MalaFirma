using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class PytanieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PytanieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            PytanieVM model = new PytanieVM();
            model.Pytania = _unitOfWork.Pytanie.GetAll();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PytanieVM obj)
        {
            _unitOfWork.Pytanie.Add(obj.Pytanie);
            _unitOfWork.Save();
            TempData["success"] = "Pytanie zostało pomyślnie dodane";
            return RedirectToAction("Index");
        }

        public IActionResult EditPytanie(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var pytanieFormDb = _unitOfWork.Pytanie.GetFirstOrDefault(x => x.Id == id);
            if (pytanieFormDb == null)
            {
                return NotFound();
            }
            return View(pytanieFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPytanie(Pytanie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pytanie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja pytania przebiegła pomyślnie";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult DeletePytanie(int? id)
        {
            var obj = _unitOfWork.Pytanie.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Pytanie.Remove(obj);
            _unitOfWork.Save();
            TempData["delete"] = "Pytanie zostało usunięte";
            return RedirectToAction("Index");

        }
    }
}
