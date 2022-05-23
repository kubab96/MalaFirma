using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
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
            TempData["delete"] = "Pytanie zostało usunięte";
            return RedirectToAction("Pytanie");

        }
        public IActionResult PrzegladZamowienia(int? idZamowienia)
        {
            PrzegladVM model = new PrzegladVM();
            model.Pytania = _unitOfWork.Pytanie.GetAll();
            //model.Odpowiedzi = _unitOfWork.Odpowiedz.GetAll();

            model.Odpowiedzi = _unitOfWork.Odpowiedz.GetAll().Where(x => x.ZamowienieId == idZamowienia);
            //IEnumerable<Odpowiedz> objOdpowiedziList = _unitOfWork.Odpowiedz.GetAll().Where(x => x.ZamowienieId == idZamowienia);
            //model.Odpowiedzi = objOdpowiedziList;
            //model.Odpowiedz = _unitOfWork.Odpowiedz.GetFirstOrDefault(x => x.ZamowienieId == idZamowienia);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
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
            TempData["success"] = "Edycja pytania przeglądowego zakończyła się powodzeniem";
            return RedirectToAction("PrzegladZamowienia", new { idZamowienia = obj.Odpowiedz.ZamowienieId });
        }
    }
}
