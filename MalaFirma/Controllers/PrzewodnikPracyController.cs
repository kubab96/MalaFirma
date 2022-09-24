using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult ListaPrzewodnikowPracy(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganiaList;
            IEnumerable<PrzewodnikPracy> objPrzewodnikiList = _unitOfWork.PrzewodnikPracy.GetAll();
            model.PrzewodnikiPracy = objPrzewodnikiList;


            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == id);

            return View(model);
        }

        public IActionResult PrzewodnikPracy(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == id);
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == model.PrzewodnikPracy.WymaganieId);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == model.Wymaganie.ZamowienieId);
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == model.Wymaganie.ZamowienieId);
            model.SwiadectwoJakosci = _unitOfWork.SwiadectwoJakosci.GetFirstOrDefault(x => x.WymaganieId == model.Wymaganie.Id);
            IEnumerable<Operacja> objOperacjaList = _unitOfWork.Operacja.GetAll().Where(x => x.PrzewodnikPracyId == model.PrzewodnikPracy.Id);
            model.Operacje = objOperacjaList;
            IEnumerable<RysunekPrzewodnika> objRysunekList = _unitOfWork.RysunekPrzewodnika.GetAll().Where(x => x.WymaganieId == id);
            model.RysunekPrzewodnikow = objRysunekList;
            return View(model);
        }

        [Authorize(Roles = "Projektant, Admin, Kierownik kontroli jakości")]
        [HttpPost]
        public IActionResult PrzewodnikPracy(PrzewodnikPracyVM model, IFormFile file, int id)
        {
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == id);
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == model.PrzewodnikPracy.WymaganieId);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == model.Wymaganie.ZamowienieId);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\rysunki");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
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
            model.PrzewodnikPracy.NumerRysunku = $"{model.Zamowienie.Id}/{model.PrzewodnikPracy.WymaganieId}";
            _unitOfWork.PrzewodnikPracy.Update(model.PrzewodnikPracy);
            _unitOfWork.Save();
            TempData["success"] = "Rysunek został pomyślnie dodany do przewodnika pracy";
            return RedirectToAction("PrzewodnikPracy", new { id = model.PrzewodnikPracy.Id });
        }

        [Authorize(Roles = "Projektant, Admin, Kierownik kontroli jakości")]
        public IActionResult Rysunek(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == model.Wymaganie.Id);
            model.RysunekPrzewodnika = _unitOfWork.RysunekPrzewodnika.GetFirstOrDefault(x => x.WymaganieId == id);
            IEnumerable<Operacja> objOperacjaList = _unitOfWork.Operacja.GetAll().Where(x => x.Id == id);
            model.Operacje = objOperacjaList;
            IEnumerable<RysunekPrzewodnika> objRysunekList = _unitOfWork.RysunekPrzewodnika.GetAll().Where(x => x.WymaganieId == id);
            model.RysunekPrzewodnikow = objRysunekList;
            return View(model);
        }

        [Authorize(Roles = "Projektant, Admin, Kierownik kontroli jakości")]
        [HttpPost]
        public IActionResult Rysunek(PrzewodnikPracyVM model, IFormFile file, int id)
        {
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\rysunki");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
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
            model.RysunekPrzewodnika.NumerRysunku = $"/{model.PrzewodnikPracy.WymaganieId}";
            model.RysunekPrzewodnika.WymaganieId = (int)model.PrzewodnikPracy.WymaganieId;
            _unitOfWork.RysunekPrzewodnika.AddId(model.RysunekPrzewodnika);
            _unitOfWork.Save();
            TempData["success"] = "Rysunek został pomyślnie dodany do przewodnika pracy";
            return RedirectToAction("Operacja", new { id = model.PrzewodnikPracy.WymaganieId });
        }

        [Authorize(Roles = "Projektant, Admin, Kierownik kontroli jakości")]
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
                TempData["success"] = "Rysunek został pomyślnie usnięty";
                return RedirectToAction("PrzewodnikPracy", new { id = obj.Id });
            }
            return View();
        }

        [Authorize(Roles = "Projektant, Admin, Operator, Kierownik kontroli jakości")]
        public IActionResult AddOperacja(int idPrzewodnika)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == idPrzewodnika);
            return View(model);
        }

        [Authorize(Roles = "Projektant, Admin, Operator, Kierownik kontroli jakości")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOperacja(PrzewodnikPracyVM obj, int idPrzewodnika)
        {
            obj.Operacja.PrzewodnikPracyId = idPrzewodnika;
            if (ModelState.IsValid)
            {
                _unitOfWork.Operacja.AddId(obj.Operacja);
                _unitOfWork.Save();
                TempData["success"] = "Operacja została pomyślnie utworzona";
                return RedirectToAction("PrzewodnikPracy", new { id = idPrzewodnika });
            }
            return RedirectToAction("AddOperacja", new { idPrzewodnika = idPrzewodnika });
        }

        [Authorize(Roles = "Projektant, Admin, Operator, Kierownik kontroli jakości")]
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

        [Authorize(Roles = "Projektant, Admin, Operator, Kierownik kontroli jakości")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOperacja(Operacja obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Operacja.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "operacji została zaktualizowana";
                return RedirectToAction("PrzewodnikPracy", new { id = obj.PrzewodnikPracyId });
            }
            return View(obj);
        }

        [Authorize(Roles = "Projektant, Admin, Operator, Kierownik kontroli jakości")]
        public IActionResult DeleteOperacja(int? id)
        {
            var obj = _unitOfWork.Operacja.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Operacja.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Operacja została usunięta";
            return RedirectToAction("PrzewodnikPracy", new { id = obj.PrzewodnikPracyId });
        }

        [Authorize(Roles = "Projektant, Admin, Kierownik kontroli jakości")]
        public IActionResult WynikPrzewodnikaPracy(PrzewodnikPracyVM obj, int? idPrzewodnika, string? wynik)
        {
            if (idPrzewodnika == null || idPrzewodnika == 0)
            {
                return NotFound();
            }
            obj.SwiadectwoJakosci = _unitOfWork.SwiadectwoJakosci.GetFirstOrDefault(x => x.WymaganieId == idPrzewodnika);
            obj.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == idPrzewodnika);
            if (obj.PrzewodnikPracy == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [Authorize(Roles = "Projektant, Admin, Kierownik kontroli jakości")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WynikPrzewodnikaPracy(PrzewodnikPracyVM obj, string? wynik)
        {
            if (ModelState.IsValid)
            {
                var operacje = _unitOfWork.Operacja.GetFirstOrDefault(x => x.PrzewodnikPracyId == obj.PrzewodnikPracy.Id);
                if (wynik == null)
                {
                    if (operacje == null)
                    {
                        TempData["error"] = "Wymagane jest wykonanie przynajmniej jednej operacji";
                        return RedirectToAction("PrzewodnikPracy", new { id = obj.PrzewodnikPracy.Id });
                    }
                    else
                    {
                        obj.PrzewodnikPracy.DataZakonczeniaPrzewodnika = DateTime.Now;
                        _unitOfWork.PrzewodnikPracy.Update(obj.PrzewodnikPracy);
                        _unitOfWork.Save();
                        TempData["success"] = "Zakończono przewodnik pracy";
                        return RedirectToAction("PrzewodnikPracy", new { id = obj.PrzewodnikPracy.Id });
                    }
                }
                else
                {
                    var lastOperacja = _db.Operacje.OrderByDescending(s => s.Id)
                         .FirstOrDefault(s => s.PrzewodnikPracy.Id == obj.PrzewodnikPracy.Id);
                    if (lastOperacja != null)
                    {
                        DateTime data = lastOperacja.DataWykonania;
                        if (obj.PrzewodnikPracy.DataZakonczeniaPrzewodnika < data)
                        {
                            TempData["error"] = "Nie można wprowadzić daty dalszej, niż data ostatnio wykonanej operacji";
                            return View(obj);
                        }
                        else
                        {
                            _unitOfWork.PrzewodnikPracy.Update(obj.PrzewodnikPracy);
                            _unitOfWork.Save();
                            TempData["success"] = "Przewodnik pracy został zaktualizowany";
                            return RedirectToAction("PrzewodnikPracy", new { id = obj.PrzewodnikPracy.Id });
                        }
                    }
                    else
                    {
                        _unitOfWork.PrzewodnikPracy.Update(obj.PrzewodnikPracy);
                        _unitOfWork.Save();
                        TempData["success"] = "Przewodnik pracy został zaktualizowany";
                        return RedirectToAction("PrzewodnikPracy", new { id = obj.PrzewodnikPracy.Id });
                    }
                }
            }
            return View(obj);
        }
    }
}
