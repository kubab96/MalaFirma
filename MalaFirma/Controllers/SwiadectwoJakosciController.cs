using SimpleQMS.DataAccess;
using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace SimpleQMS.Controllers
{
    public class SwiadectwoJakosciController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _db;

        public SwiadectwoJakosciController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        public IActionResult SwiadectwoJakosci(int id)
        {
            SwiadectwoJakosciVM model = new SwiadectwoJakosciVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganiaList;
            IEnumerable<SwiadectwoJakosci> objSwiadectwaList = _unitOfWork.SwiadectwoJakosci.GetAll();
            model.SwiadectwaJakosci = objSwiadectwaList;
            IEnumerable<PrzewodnikPracy> objPrzewodnikiList = _unitOfWork.PrzewodnikPracy.GetAll();
            model.PrzewodnikiPracy = objPrzewodnikiList;
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == model.Zamowienie.Id);

            return View(model);
        }

        [Authorize(Roles = "Admin, Kierownik kontroli jakości")]
        public IActionResult WynikSwiadectwaJakosci(int? idSwiadectwa)
        {
            if (idSwiadectwa == null || idSwiadectwa == 0)
            {
                return NotFound();
            }
            var swiadectwoFormDb = _unitOfWork.SwiadectwoJakosci.GetFirstOrDefault(x => x.Id == idSwiadectwa);
            if (swiadectwoFormDb == null)
            {
                return NotFound();
            }
            return View(swiadectwoFormDb);
        }

        [Authorize(Roles = "Admin, Kierownik kontroli jakości")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WynikSwiadectwaJakosci(SwiadectwoJakosci obj, string? wynik)
        {
            if (ModelState.IsValid)
            {
                var przewodnikId = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == obj.WymaganieId);
                if (wynik == null)
                {
                    if (przewodnikId.WynikPrzewodnika == "")
                    {
                        TempData["error"] = "Konieczne jest zakończenie przewodnika pracy";
                        return RedirectToAction("PrzewodnikPracy", "PrzewodnikPracy", new { id = przewodnikId.Id });
                    }
                    else
                    {
                        if (obj.ZidentyfikowaneProblemy == null)
                        {
                            obj.ZidentyfikowaneProblemy = "N/D";
                        }
                        if (obj.PlanowaneDzialania == null)
                        {
                            obj.PlanowaneDzialania = "N/D";
                        }
                        obj.DataZakonczeniaSwiadectwa = DateTime.Now.Date;
                        _unitOfWork.SwiadectwoJakosci.Update(obj);
                        _unitOfWork.Save();
                        TempData["success"] = "Świadectwo jakości zostało zaktualizowane";
                        return RedirectToAction("SwiadectwoJakosciDetails", new { id = obj.Id });
                    }
                }

                else
                {

                    if (obj.DataZakonczeniaSwiadectwa < przewodnikId.DataZakonczeniaPrzewodnika)
                    {
                        TempData["error"] = "Nie można wprowadzić daty dalszej, niż data zakończenia przewodnika";
                        return View(obj);
                    }
                    else
                    {
                        _unitOfWork.SwiadectwoJakosci.Update(obj);
                        _unitOfWork.Save();
                        TempData["success"] = "Zakończono świadectwo jakości";
                        return RedirectToAction("SwiadectwoJakosciDetails", new { id = obj.Id });
                    }

                }
            }
            return View(obj);
        }

        public IActionResult SwiadectwoJakosciDetails(int id)
        {
            SwiadectwoJakosciVM model = new SwiadectwoJakosciVM();
            model.Wymaganie = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == model.Wymaganie.ZamowienieId);
            model.SwiadectwoJakosci = _unitOfWork.SwiadectwoJakosci.GetFirstOrDefault(x => x.WymaganieId == model.Wymaganie.Id);
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == model.Wymaganie.Id);
            IEnumerable<Operacja> objOperacjeList = _unitOfWork.Operacja.GetAll().Where(x => x.PrzewodnikPracyId == model.PrzewodnikPracy.Id);
            model.Operacje = objOperacjeList;
            IEnumerable<Przywieszka> objPrzywieszkiList = _unitOfWork.Przywieszka.GetAll().Where(x => x.SwiadectwoJakosciId == model.SwiadectwoJakosci.Id);
            model.Przywieszki = objPrzywieszkiList;
            return View(model);
        }

        [Authorize(Roles = "Admin, Kierownik kontroli jakości, Kontroler jakości")]
        [HttpPost]
        public IActionResult SwiadectwoJakosciDetails(SwiadectwoJakosciVM model, IFormFile file, int id, IFormCollection fc, string? numerRysunku, int? idRysunku)
        {
            model.SwiadectwoJakosci = _unitOfWork.SwiadectwoJakosci.GetFirstOrDefault(x => x.WymaganieId == id);
            var rysunek = _unitOfWork.Przywieszka.GetFirstOrDefault(x => x.Id == idRysunku);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\rysunki");
                var extension = Path.GetExtension(file.FileName);

                if (numerRysunku != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, rysunek.Rysunek.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }


                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                if (rysunek == null)
                {
                    model.Przywieszka.Rysunek = @"\images\rysunki\" + fileName + extension;
                }
                else
                {
                    rysunek.Rysunek = @"\images\rysunki\" + fileName + extension;
                }
            }
            if (fc["SubmitForm"] == "Delete")
            {
                DeleteRysunek(idRysunku);
                return RedirectToAction("SwiadectwoJakosciDetails", new { id = model.Przywieszka.SwiadectwoJakosciId });
            }

            if (rysunek == null)
            {
                model.Przywieszka.NumerPrzywieszki = $"/{model.SwiadectwoJakosci.WymaganieId}";
                model.Przywieszka.SwiadectwoJakosciId = id;
                _unitOfWork.Przywieszka.Update(model.Przywieszka);
                _unitOfWork.Save();
                TempData["success"] = "Przywieszka została pomyślnie dodana";
            }
            else
            {
                rysunek.NumerPrzywieszki = $"/{model.SwiadectwoJakosci.WymaganieId}";
                rysunek.SwiadectwoJakosciId = id;
                _unitOfWork.Przywieszka.Update(rysunek);
                _unitOfWork.Save();
                TempData["success"] = "Przywieszka została pomyślnie zaktualizowna";
            }
            return RedirectToAction("SwiadectwoJakosciDetails", new { id = model.SwiadectwoJakosci.WymaganieId });
        }

        [Authorize(Roles = "Admin, Kierownik kontroli jakości, Kontroler jakości")]
        public IActionResult DeleteRysunek(int? id)
        {
            var obj = _unitOfWork.Przywieszka.GetFirstOrDefault(x => x.Id == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (obj.Rysunek != null)
            {
                var oldImage = Path.Combine(wwwRootPath, obj.Rysunek.TrimStart('\\'));
                if (System.IO.File.Exists(oldImage))
                {
                    System.IO.File.Delete(oldImage);
                }
                _unitOfWork.Przywieszka.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Przywieszka została pomyślnie usnięta";
                return RedirectToAction("Operacja", new { id = obj.SwiadectwoJakosciId });
            }
            return View();
        }


    }
}
