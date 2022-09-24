using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MalaFirma.Controllers
{
    public class AudytController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AudytController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Audyt> objAudytyList = _unitOfWork.Audyt.GetAll();
            return View(objAudytyList);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult Upsert(int? id)
        {
            Audyt obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            else
            {
                //edit
                obj = _unitOfWork.Audyt.GetFirstOrDefault(u => u.Id == id);
                return View(obj);
            }
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Audyt obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    obj.Status = "Otwarty";
                    _unitOfWork.Audyt.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Audyt został pomyślnie utworzony";
                    return RedirectToAction("DetailsAudyt", "Audyt", new { obj.Id });
                }
                else
                {
                    obj.Status = "Otwarty";
                    _unitOfWork.Audyt.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Audyt został zaktualizowany";
                    return RedirectToAction("DetailsAudyt", "Audyt", new { obj.Id });
                }
            }
            return View(obj);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult EndAudyt(int? id)
        {
            var obj = _unitOfWork.Audyt.GetFirstOrDefault(u => u.Id == id);
            obj.Status = "Zamknięty";
            if(obj.Opis != null)
            {
                obj.TerminUsuniecia = DateTime.Now;
            }
            _unitOfWork.Audyt.Update(obj);
            _unitOfWork.Save();
            return RedirectToAction("DetailsAudyt", "Audyt", new { obj.Id });
        }

        public ActionResult DetailsAudyt(int? id)
        {
            var audyt = _unitOfWork.Audyt.GetFirstOrDefault(x => x.Id == id);
            return View(audyt);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Audyt.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Audyt.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Audyt został usunięty";
            return RedirectToAction("Index");
        }

    }
}
