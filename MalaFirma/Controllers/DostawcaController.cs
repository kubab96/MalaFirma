using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimpleQMS.Controllers
{
    public class DostawcaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DostawcaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Dostawca> objDostawcaList = _unitOfWork.Dostawca.GetAll();
            return View(objDostawcaList);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult Upsert(int? id)
        {
            Dostawca obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            else
            {
                //edit
                obj = _unitOfWork.Dostawca.GetFirstOrDefault(u => u.Id == id);
                return View(obj);
            }
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Dostawca obj)
        {
            if(String.IsNullOrEmpty(obj.Uwagi))
            {
                obj.Uwagi = "Brak";
            }
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    System.DateTime dataZatwierdzenia = obj.DataZatwierdzenia;
                    System.DateTime dataWygasniecia = obj.DataWygasniecia;
                    System.TimeSpan subtract = dataWygasniecia.Subtract(dataZatwierdzenia);
                    if(subtract.Days <= 731)
                    {
                        _unitOfWork.Dostawca.Add(obj);
                        _unitOfWork.Save();
                        TempData["success"] = "Dostawca został pomyślnie utworzony";
                    }
                    else
                    {
                        TempData["error"] = "Maksymalny okres zatwierdzenia nie może wynosić więcej niż 2 lata";
                        return View(obj);
                    }
                    
                }
                else
                {
                    _unitOfWork.Dostawca.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Dostawca został zaktualizowany";
                    return RedirectToAction("DetailsDostawca", "Dostawca", new { obj.Id });
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult DetailsDostawca(int? id)
        {
            var dostawca = _unitOfWork.Dostawca.GetFirstOrDefault(x => x.Id == id);
            return View(dostawca);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dostawcaFormDb = _unitOfWork.Dostawca.GetFirstOrDefault(x => x.Id == id);
            if (dostawcaFormDb == null)
            {
                return NotFound();
            }
            return PartialView(dostawcaFormDb);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dostawca obj)
        {
            if (ModelState.IsValid)
            {
                System.DateTime dataZatwierdzenia = obj.DataZatwierdzenia;
                System.DateTime dataWygasniecia = obj.DataWygasniecia;
                System.TimeSpan subtract = dataWygasniecia.Subtract(dataZatwierdzenia);
                if (subtract.Days <= 731)
                {
                    _unitOfWork.Dostawca.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Data zatwierdzenia dostawcy została zaktualizowana.";
                    return RedirectToAction("DetailsDostawca", "Dostawca", new { obj.Id });
                }
                else
                {
                    TempData["error"] = "Maksymalny okres zatwierdzenia nie może wynosić więcej niż 2 lata";
                    return RedirectToAction("DetailsDostawca", "Dostawca", new { obj.Id });
                }
            }
            return PartialView(obj);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Dostawca.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Dostawca.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Dostawca został usunięty";
            IEnumerable<Dostawca> objDostawcaList = _unitOfWork.Dostawca.GetAll();
            return RedirectToAction("Index", objDostawcaList);
        }
    }
}
