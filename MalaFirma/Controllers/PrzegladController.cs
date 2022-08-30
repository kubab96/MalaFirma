using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoreLinq;

namespace MalaFirma.Controllers
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pytanie(PytanieVM obj)
        {
            _unitOfWork.Pytanie.AddId(obj.Pytanie);
            _unitOfWork.Save();
            TempData["success"] = "Pytanie zostało pomyślnie dodane";
            return RedirectToAction("Pytanie");
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
                return RedirectToAction("Pytanie");
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
            TempData["success"] = "Pytanie zostało usunięte";
            return RedirectToAction("Pytanie");
        }

        public IActionResult PrzegladZamowienia(int? idZamowienia)
        {
            PrzegladVM model = new PrzegladVM();
            model.Pytania = _unitOfWork.Pytanie.GetAll();
            model.Odpowiedzi = _unitOfWork.Odpowiedz.GetAll().Where(x => x.ZamowienieId == idZamowienia);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == idZamowienia);
            IEnumerable<Przeglad> objPrzegladList = _unitOfWork.Przeglad.GetAll().Where(x => x.zamowienieId == idZamowienia);
            model.Przeglady = objPrzegladList;
            return View(model);
        }

        public IActionResult AddOdpowiedz(int? idPytania, int? idZamowienia)
        {
            PrzegladVM model = new PrzegladVM();
            model.Pytanie = _unitOfWork.Pytanie.GetFirstOrDefault(x => x.Id == idPytania);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOdpowiedz(PrzegladVM obj, int idPytania, int idZamowienia)
        {
            _unitOfWork.Odpowiedz.AddId(obj.Odpowiedz, idPytania, idZamowienia);
            _unitOfWork.Save();
            CheckStatus(idZamowienia);
            TempData["success"] = "Przegląd pytania zakończył się powodzeniem";
            return RedirectToAction("PrzegladZamowienia", new { idZamowienia = obj.Odpowiedz.ZamowienieId });
        }

        public IActionResult EditOdpowiedz(int? idOdpowiedzi, int idPytania)
        {

            if (idOdpowiedzi == null || idOdpowiedzi == 0)
            {
                return NotFound();
            }
            PrzegladVM model = new PrzegladVM();
            model.Odpowiedz = _unitOfWork.Odpowiedz.GetFirstOrDefault(x => x.Id == idOdpowiedzi);
            model.Pytanie = _unitOfWork.Pytanie.GetFirstOrDefault(x => x.Id == idPytania);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOdpowiedz(PrzegladVM obj, int idOdpowiedzi, int idPytania, int idZamowienia)
        {
            obj.Odpowiedz.Id = idOdpowiedzi;
            _unitOfWork.Odpowiedz.Update(obj.Odpowiedz, idPytania, idZamowienia);
            _unitOfWork.Save();
            CheckStatus(idZamowienia);
            TempData["success"] = "Edycja pytania przeglądowego zakończyła się powodzeniem";
            return RedirectToAction("PrzegladZamowienia", new { idZamowienia = obj.Odpowiedz.ZamowienieId });
        }
        public void CheckStatus(int? idZamowienia)
        {
            var obj2 = _unitOfWork.Odpowiedz.GetAll().Where(Odpowiedz => Odpowiedz.ZamowienieId == idZamowienia);
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

        public IActionResult WynikPrzegladu(int? idZamowienia)
        {
            PrzegladVM model = new PrzegladVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WynikPrzegladu(PrzegladVM obj, int idZamowienia)
        {
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == idZamowienia);
            foreach (var a in objWymaganiaList)
            {
                AddPrzewodnikPracy(a.ZamowienieId, a.Id);
            }
            _unitOfWork.Przeglad.AddId(obj.Przeglad, idZamowienia);
            _unitOfWork.Save();
            TempData["success"] = "Wynik przeglądu zakończył się powodzeniem";
            return RedirectToAction("PrzegladZamowienia", new { idZamowienia = obj.Przeglad.zamowienieId });
        }

        public void AddPrzewodnikPracy(int idZamowienia, int idWymagania)
        {
            PrzewodnikPracy przewodnik = new PrzewodnikPracy();
            przewodnik.ZamowienieId = idZamowienia;
            przewodnik.WymaganieId = idWymagania;
            _unitOfWork.PrzewodnikPracy.AddId(przewodnik);
            _unitOfWork.Save();
        }

        public IActionResult EditWynikPrzegladu(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var przegladFormDb = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.Id == id);
            if (przegladFormDb == null)
            {
                return NotFound();
            }
            return View(przegladFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWynikPrzegladu(Przeglad obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Przeglad.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja przeglądu przebiegła pomyślnie.";
                return RedirectToAction("PrzegladZamowienia", new { idZamowienia = obj.zamowienieId });
            }
            return View(obj);
        }
    }
}
