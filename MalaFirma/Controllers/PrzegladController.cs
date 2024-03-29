﻿using SimpleQMS.DataAccess;
using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;

namespace SimpleQMS.Controllers
{
    public class PrzegladController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrzegladController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Pytanie()
        {
            PytanieVM model = new PytanieVM();
            model.Pytania = _unitOfWork.Pytanie.GetAll();
            return View(model);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pytanie(PytanieVM obj)
        {
            try
            {
                _unitOfWork.Pytanie.AddId(obj.Pytanie);
                _unitOfWork.Save();
                TempData["success"] = "Pytanie zostało pomyślnie utworzone";
            }
            catch
            {
                TempData["error"] = "Należy podać nazwę pytania";
            }
            return RedirectToAction("Pytanie");
        }

        [Authorize(Roles = "Menager, Admin")]
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

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPytanie(Pytanie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pytanie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Pytanie zostało zaktualizowane";
                return RedirectToAction("Pytanie");
            }
            return View(obj);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult DeletePytanie(int? id)
        {
            var obj = _unitOfWork.Pytanie.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Pytanie.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Pytanie zostało usunięte";
            return RedirectToAction("Pytanie");
        }

        public IActionResult PrzegladZamowienia(int? idZamowienia)
        {
            PrzegladVM model = new PrzegladVM();
            model.Pytania = _unitOfWork.Pytanie.GetAll();
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == idZamowienia);
            model.Odpowiedzi = _unitOfWork.Odpowiedz.GetAll().Where(x => x.PrzegladId == model.Przeglad.Id);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            IEnumerable<Przeglad> objPrzegladList = _unitOfWork.Przeglad.GetAll().Where(x => x.zamowienieId == idZamowienia);
            model.Przeglady = objPrzegladList;
            return View(model);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult AddOdpowiedz(int? idPytania, int? idZamowienia)
        {
            PrzegladVM model = new PrzegladVM();
            model.Pytanie = _unitOfWork.Pytanie.GetFirstOrDefault(x => x.Id == idPytania);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            return View(model);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOdpowiedz(PrzegladVM obj, int idPytania, int idZamowienia)
        {
            int idzam = idZamowienia;
            var obj2 = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == idZamowienia);
            _unitOfWork.Odpowiedz.AddId(obj.Odpowiedz, idPytania, obj2.Id);
            _unitOfWork.Save();
            CheckStatus(idZamowienia);
            TempData["success"] = "Udzielono odpowiedzi na pytanie kontrolne";
            return RedirectToAction("PrzegladZamowienia", new { idZamowienia = idzam });
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult EditOdpowiedz(int? idOdpowiedzi, int idPytania, int idZamowienia)
        {

            if (idOdpowiedzi == null || idOdpowiedzi == 0)
            {
                return NotFound();
            }
            PrzegladVM model = new PrzegladVM();
            model.Odpowiedz = _unitOfWork.Odpowiedz.GetFirstOrDefault(x => x.Id == idOdpowiedzi);
            model.Pytanie = _unitOfWork.Pytanie.GetFirstOrDefault(x => x.Id == idPytania);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            return View(model);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOdpowiedz(PrzegladVM obj, int idOdpowiedzi, int idPytania, int idZamowienia)
        {
            obj.Odpowiedz.Id = idOdpowiedzi;
            var obj2 = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == idZamowienia);
            _unitOfWork.Odpowiedz.Update(obj.Odpowiedz, idPytania, obj2.Id);
            _unitOfWork.Save();
            CheckStatus(idZamowienia);
            TempData["success"] = "Odpowiedź na pytanie zostało zaktualizowane";
            return RedirectToAction("PrzegladZamowienia", new { idZamowienia = idZamowienia });
        }
        public void CheckStatus(int? idZamowienia)
        {
            var obj = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == idZamowienia);
            var obj2 = _unitOfWork.Odpowiedz.GetAll().Where(Odpowiedz => Odpowiedz.PrzegladId == obj.Id);
            var obj3 = _unitOfWork.Pytanie.GetAll();
            var obj4 = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            int licznik = 0;
            if (obj2.Count() == obj3.Count())
            {
                foreach (var item in obj2)
                {
                    if (item.Wartosc == true)
                    {
                        licznik++;
                    }
                    else { }
                }
                if (licznik == obj2.Count())
                {
                    obj4.StatusZamowienia = "Zatwierdzone";
                    _unitOfWork.Save();
                }
                else { }
            }
            else { }
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult AddWynikPrzegladu(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var przegladFormDb = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.Id == id);
            if (przegladFormDb.WynikPrzegladu == "Nie wykonano")
            {
                przegladFormDb.WynikPrzegladu = "";
                przegladFormDb.DataPrzegladu = DateTime.Now.Date;
            }
            if (przegladFormDb == null)
            {
                return NotFound();
            }
            return View(przegladFormDb);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWynikPrzegladu(Przeglad obj)
        {
            if (ModelState.IsValid)
            {
                obj.DataPrzegladu = DateTime.Now.Date;
                _unitOfWork.Przeglad.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Zakończono przegląd zamówienia";
                return RedirectToAction("PrzegladZamowienia", new { idZamowienia = obj.zamowienieId });
            }
            return View(obj);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult EditWynikPrzegladu(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var przegladFormDb = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.Id == id);
            if (przegladFormDb.WynikPrzegladu == "Nie wykonano")
            {
                przegladFormDb.WynikPrzegladu = "";
            }
            if (przegladFormDb == null)
            {
                return NotFound();
            }
            return View(przegladFormDb);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWynikPrzegladu(Przeglad obj)
        {
            if (ModelState.IsValid)
            {
                var zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == obj.zamowienieId);
                if (obj.DataPrzegladu < zamowienie.DataZamowienia)
                {
                    TempData["error"] = "Nie można wprowadzić daty dalszej, niż data złożenia zamówienia";
                    return View(obj);
                }
                else
                {
                    _unitOfWork.Przeglad.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Przegląd zamówienia został zaktualizowany";
                    return RedirectToAction("PrzegladZamowienia", new { idZamowienia = obj.zamowienieId });
                }
            }
            return View(obj);
        }
    }
}
