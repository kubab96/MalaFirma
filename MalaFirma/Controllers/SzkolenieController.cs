using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;
namespace MalaFirma.Controllers
{
    public class SzkolenieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SzkolenieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Szkolenie> objSzkoleniaList = _unitOfWork.Szkolenie.GetAll();
            return View(objSzkoleniaList);
        }

        public IActionResult Upsert(int? id)
        {
            Szkolenie obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            else
            {
                //edit
                obj = _unitOfWork.Szkolenie.GetFirstOrDefault(u => u.Id == id);
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Szkolenie obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    obj.Status = "Otwarty";
                    _unitOfWork.Szkolenie.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Szkolenie zostało pomyślnie dodane";
                    return RedirectToAction("DetailsSzkolenie", "Szkolenie", new { obj.Id });
                }
                else
                {
                    _unitOfWork.Szkolenie.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Szkolenie zostało zedytowane";
                    return RedirectToAction("DetailsSzkolenie", "Szkolenie", new { obj.Id });
                }
            }
            return View(obj);
        }

        public IActionResult EndSzkolenie(int? id)
        {
            var obj = _unitOfWork.Szkolenie.GetFirstOrDefault(u => u.Id == id);
            obj.Status = "Zamknięty";
            _unitOfWork.Szkolenie.Update(obj);
            _unitOfWork.Save();
            return RedirectToAction("DetailsSzkolenie", "Szkolenie", new { obj.Id });
        }

        public ActionResult DetailsSzkolenie(int? id)
        {
            var szkolenie = _unitOfWork.Szkolenie.GetFirstOrDefault(x => x.Id == id);
            return View(szkolenie);
        }

        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Szkolenie.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Szkolenie.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Szkolenie został usunięte";
            return RedirectToAction("Index");
        }

    }
}
