using MalaFirma.DataAccess;
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
        private readonly ApplicationDbContext _db;
        public PrzewodnikPracyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        public IActionResult PrzewodnikPracy(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<PrzewodnikPracy> objPrzewodnikiList = _unitOfWork.PrzewodnikPracy.GetAll().Where(x => x.ZamowienieId == id);
            model.PrzewodnikiPracy = objPrzewodnikiList;
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganiaList;
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == id);

            return View(model);
        }

        public IActionResult Operacja(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == id);
            IEnumerable<Operacja> objOperacjaList = _unitOfWork.Operacja.GetAll().Where(x => x.WymaganieId == id);
            model.Operacje = objOperacjaList;
            IEnumerable<RysunekPrzewodnika> objRysunekList = _unitOfWork.RysunekPrzewodnika.GetAll().Where(x => x.WymaganieId == id);
            model.RysunekPrzewodnikow = objRysunekList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Operacja(PrzewodnikPracyVM model, IFormFile file, int id, IFormCollection fc, string? numerRysunku, int? idRysunku)
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

        public IActionResult Rysunek(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == id);
            model.RysunekPrzewodnika = _unitOfWork.RysunekPrzewodnika.GetFirstOrDefault(x => x.WymaganieId == id);
            IEnumerable<Operacja> objOperacjaList = _unitOfWork.Operacja.GetAll().Where(x => x.WymaganieId == id);
            model.Operacje = objOperacjaList;
            IEnumerable<RysunekPrzewodnika> objRysunekList = _unitOfWork.RysunekPrzewodnika.GetAll().Where(x => x.WymaganieId == id);
            model.RysunekPrzewodnikow = objRysunekList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Rysunek(PrzewodnikPracyVM model, IFormFile file, int id, IFormCollection fc, string? numerRysunku, int? idRysunku)
        {
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\rysunki");
                var extension = Path.GetExtension(file.FileName);

                if (model.RysunekPrzewodnika.Rysunek != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, model.RysunekPrzewodnika.Rysunek.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }


                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                model.RysunekPrzewodnika.Rysunek = @"\images\rysunki\" + fileName + extension;
            }
            model.RysunekPrzewodnika.NumerRysunku = $"{model.PrzewodnikPracy.ZamowienieId}/{model.PrzewodnikPracy.WymaganieId}";
            model.RysunekPrzewodnika.WymaganieId = (int)model.PrzewodnikPracy.WymaganieId;
            _unitOfWork.RysunekPrzewodnika.AddId(model.RysunekPrzewodnika);
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

        public IActionResult EditOperacja(int? id, int idWymagania)
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
                //var lastOperacja = _db.Operacje.LastOrDefault(s => s.WymaganieId == idWymagania);
                var lastOperacja = _db.Operacje.OrderByDescending(s => s.Id)
                         .FirstOrDefault(s => s.WymaganieId == idWymagania);
                if (lastOperacja != null) { 
                DateTime data = lastOperacja.DataWykonania;
                if (obj.DataWykonania < data)
                {
                    TempData["error"] = "Nie można wprowadzić daty dalszej niż data ostatniej operacji.";
                    return View(obj);
                }
                else
                {
                    _unitOfWork.Operacja.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Edycja operacji przebiegła pomyślnie";
                    return RedirectToAction("Operacja", new { id = idWymagania });
                }
                }
                else
                {
                    _unitOfWork.Operacja.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Edycja operacji przebiegła pomyślnie";
                    return RedirectToAction("Operacja", new { id = idWymagania });
                }
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
                    var operacje = _unitOfWork.Operacja.GetFirstOrDefault(x => x.WymaganieId == obj.WymaganieId);
                    if(operacje == null)
                    {
                        TempData["error"] = "Konieczne jest wykonanie przynajmniej jednej operacji przed zakończeniem przewodnika.";
                        return View(obj);
                    }
                    else { 
                    AddSwiadectwoJakosci(obj.ZamowienieId, obj.WymaganieId);
                    obj.DataZakonczeniaPrzewodnika = DateTime.Now;
                    _unitOfWork.PrzewodnikPracy.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "Przewodnik został zakończony.";
                    return RedirectToAction("PrzewodnikPracy", new { id = obj.ZamowienieId });
                    }
                }
                else
                {
                    var lastOperacja = _db.Operacje.OrderByDescending(s => s.Id)
                         .FirstOrDefault(s => s.WymaganieId == obj.WymaganieId);
                    if (lastOperacja != null)
                    {
                        DateTime data = lastOperacja.DataWykonania;
                        if (obj.DataZakonczeniaPrzewodnika < data)
                        {
                            TempData["error"] = "Nie można wprowadzić daty dalszej niż data ostatnio wykonanej operacji.";
                            return View(obj);
                        }
                        else
                        {
                            _unitOfWork.PrzewodnikPracy.Update(obj);
                            _unitOfWork.Save();
                            TempData["success"] = "Przewodnik został zaktualizowany.";
                            return RedirectToAction("PrzewodnikPracy", new { id = obj.ZamowienieId });
                        }
                    }
                    else
                    {
                        _unitOfWork.PrzewodnikPracy.Update(obj);
                        _unitOfWork.Save();
                        TempData["success"] = "Przewodnik został zaktualizowany.";
                        return RedirectToAction("PrzewodnikPracy", new { id = obj.ZamowienieId });
                    }
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
