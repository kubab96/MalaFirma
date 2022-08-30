using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MalaFirma.Controllers
{
    public class PrzewodnikPracyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PrzewodnikPracyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult PrzewodnikPracy(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<PrzewodnikPracy> objPrzewodnikiList = _unitOfWork.PrzewodnikPracy.GetAll().Where(x => x.ZamowienieId == id);
            model.PrzewodnikiPracy = objPrzewodnikiList;
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganiaList;

            return View(model);
        }

        public IActionResult Operacja(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == id);
            IEnumerable<Operacja> objOperacjaList = _unitOfWork.Operacja.GetAll().Where(x => x.WymaganieId == id);
            model.Operacje = objOperacjaList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Operacja(PrzewodnikPracyVM model, IFormFile file, int id, IFormCollection fc)
        {
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\rysunki");
                var extension = Path.GetExtension(file.FileName);

                if (model.PrzewodnikPracy.Rysunek != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, model.PrzewodnikPracy.Rysunek.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }


                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                model.PrzewodnikPracy.Rysunek = @"\images\rysunki\" + fileName + extension;
            }
            if (fc["SubmitForm"] == "Delete")
            {
                if (model.PrzewodnikPracy.Rysunek != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, model.PrzewodnikPracy.Rysunek.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                    model.PrzewodnikPracy.Rysunek = null;

                    _unitOfWork.PrzewodnikPracy.Update(model.PrzewodnikPracy);
                    _unitOfWork.Save();
                    TempData["success"] = "Rysunek został pomyślnie usunięty.";
                    return RedirectToAction("Operacja", new { id = model.PrzewodnikPracy.WymaganieId });
                }
            }
            model.PrzewodnikPracy.NumerRysunku = $"{model.PrzewodnikPracy.ZamowienieId}/{model.PrzewodnikPracy.WymaganieId}";
            _unitOfWork.PrzewodnikPracy.Update(model.PrzewodnikPracy);
            _unitOfWork.Save();
            TempData["success"] = "Rysunek został pomyślnie dodany.";
            return RedirectToAction("Operacja", new { id = model.PrzewodnikPracy.WymaganieId });
        }

        public IActionResult DeleteRysunek(int? id)
        {
            var obj = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (obj.Rysunek != null)
            {
                var oldImage = Path.Combine(wwwRootPath, obj.Rysunek.TrimStart('\\'));
                if (System.IO.File.Exists(oldImage))
                {
                    System.IO.File.Delete(oldImage);
                }
                obj.Rysunek = null;
                obj.NumerRysunku = null;
                _unitOfWork.PrzewodnikPracy.Update(obj);
                _unitOfWork.Save();
                ModelState.Clear();
                TempData["success"] = "Rysunek został pomyślnie usnięty.";
                return RedirectToAction("Operacja", new { id = obj.WymaganieId });
            }
            return View();
        }

        public IActionResult AddOperacja(int? idWymagania)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == idWymagania);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOperacja(PrzewodnikPracyVM obj, int idWymagania)
        {
            _unitOfWork.Operacja.AddId(obj.Operacja, idWymagania);
            _unitOfWork.Save();
            TempData["success"] = "Operacja została pomyślnie dodana";
            return RedirectToAction("Operacja", new { id = idWymagania });
        }

        public IActionResult EditOperacja(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var operacjaFormDb = _unitOfWork.Operacja.GetFirstOrDefault(x => x.Id == id);
            if (operacjaFormDb == null)
            {
                return NotFound();
            }
            return View(operacjaFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOperacja(Operacja obj, int idWymagania)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Operacja.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja operacji przebiegła pomyślnie";
                return RedirectToAction("Operacja", new { id = idWymagania });

            }
            return View(obj);
        }

        public IActionResult DeleteOperacja(int? id)
        {
            var obj = _unitOfWork.Operacja.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Operacja.Remove(obj);
            _unitOfWork.Save();
            ModelState.Clear();
            TempData["success"] = "Operacja została usunięta";
            return RedirectToAction("Operacja", new { id = obj.WymaganieId });
        }

        public IActionResult WynikPrzewodnikaPracy(int? idPrzewodnika, string? wynik)
        {
            if (idPrzewodnika == null || idPrzewodnika == 0)
            {
                return NotFound();
            }
            var przewodnikFormDb = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == idPrzewodnika);
            if (przewodnikFormDb == null)
            {
                return NotFound();
            }
            return View(przewodnikFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WynikPrzewodnikaPracy(PrzewodnikPracy obj, string? wynik)
        {
            if (ModelState.IsValid)
            {
                if (wynik == null)
                {
                    AddSwiadectwoJakosci(obj.ZamowienieId, obj.WymaganieId);
                    _unitOfWork.PrzewodnikPracy.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Przewodnik został zakończony.";
                    return RedirectToAction("PrzewodnikPracy", new { id = obj.ZamowienieId });
                }
                else
                {
                    _unitOfWork.PrzewodnikPracy.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Przewodnik został zakończony.";
                    return RedirectToAction("PrzewodnikPracy", new { id = obj.ZamowienieId });
                }
            }
            return View(obj);
        }

        public void AddSwiadectwoJakosci(int? idZamowienia, int? idWymagania)
        {
            SwiadectwoJakosci swiadectwo = new SwiadectwoJakosci();
            swiadectwo.ZamowienieId = (int)idZamowienia;
            swiadectwo.WymaganieId = idWymagania;
            _unitOfWork.SwiadectwoJakosci.AddId(swiadectwo);
            _unitOfWork.Save();
        }

    }
}
