using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class ProcesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProcesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll();
            return View(objProcesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proces obj, int id)
        {
            _unitOfWork.Proces.AddId(obj, id);
            _unitOfWork.Save();
            TempData["success"] = "Proces został pomyślnie dodany";
            return RedirectToAction("SzczegolyZamowienia", "Zamowienie", new { id });
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var procesFormDb = _unitOfWork.Proces.GetFirstOrDefault(x => x.Id == id);
            if (procesFormDb == null)
            {
                return NotFound();
            }
            return View(procesFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Proces obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Proces.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja procesu przebiegła pomyślnie";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Proces.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Proces.Remove(obj);
            _unitOfWork.Save();
            TempData["delete"] = "Proces został usunięty";
            return RedirectToAction("Index");

        }
    }
}
