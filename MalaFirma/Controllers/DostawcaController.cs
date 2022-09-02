﻿using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
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
                    if(subtract.Days <= 730)
                    {
                        _unitOfWork.Dostawca.Add(obj);
                        _unitOfWork.Save();
                        TempData["success"] = "Dostawca został pomyślnie dodany";
                    }
                    else
                    {
                        return View(obj);
                    }
                    
                }
                else
                {
                    _unitOfWork.Dostawca.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Dostawca został zedytowany";
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dostawca obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Dostawca.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Data dostawcy została zaktualizowana.";
                return RedirectToAction("DetailsDostawca", "Dostawca", new { obj.Id });
            }
            return PartialView(obj);
        }
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
