using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalaFirma.Controllers
{
    public class ZamowienieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ZamowienieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Zamowienia
        public IActionResult Index()
        {
            IEnumerable<Zamowienie> objZamowienieList = _unitOfWork.Zamowienie.GetAll(includeProperties: "Klient");
            IEnumerable<Zamowienie> objZamowienieListNotExisting = _unitOfWork.Zamowienie.GetAll().Where(x => x.StatusZamowienia == "Nie potwierdzone");
            if (objZamowienieListNotExisting.Any())
            {
                _unitOfWork.Zamowienie.RemoveRange(objZamowienieListNotExisting);
                _unitOfWork.Save();
            }   

            return View(objZamowienieList);
        }

        //[Authorize(Roles = "Prezes")]
        public IActionResult Upsert(int? id)
        {
            ZamowienieWymaganieVM obj = new()
            {
                Zamowienie = new(),
                Klienci = _unitOfWork.Klient.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.NazwaKlienta,
                    Value = u.Id.ToString()
                })
            };
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }
            else
            {
                //edit
                obj.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(u => u.Id == id);
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ZamowienieWymaganieVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Zamowienie.Id == 0)
                {
                    obj.Zamowienie.StatusZamowienia = "Nie potwierdzone";
                    _unitOfWork.Zamowienie.AddId(obj.Zamowienie);
                    _unitOfWork.Save();
                    AddKartaProjektu(obj.Zamowienie.Id);
                    return RedirectToAction("CreateWymaganie", new { id = obj.Zamowienie.Id });
                }
                else
                {
                    obj.Zamowienie.StatusZamowienia = obj.Zamowienie.StatusZamowienia;
                    obj.Zamowienie.DataZamowienia = obj.Zamowienie.DataZamowienia;
                    obj.Zamowienie.KlientId = obj.Zamowienie.KlientId;
                    _unitOfWork.Zamowienie.Update(obj.Zamowienie);
                    _unitOfWork.Save();
                    TempData["success"] = "Edycja zamowienia została wykonana.";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }

        public void AddKartaProjektu(int id)
        {
            KartaProjektu karta = new KartaProjektu();
            karta.ZamowienieId = id;
            _unitOfWork.KartaProjektu.AddId(karta);
            _unitOfWork.Save();
        }


        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Zamowienie.Remove(obj);
            _unitOfWork.Save();
            TempData["error"] = "Zamówienie zostało usunięte.";
            return RedirectToAction("Index");
        }

        public ActionResult DetailsZamowienia(int? id)
        {
            ZamowienieWymaganieVM model = new ZamowienieWymaganieVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            model.Klient = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == model.Zamowienie.KlientId);
            IEnumerable<Wymaganie> objWymaganieList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganieList;
            return View(model);
        }

        #endregion

        #region Wymagania
        public IActionResult CreateWymaganie(int? id)
        {
            ZamowienieWymaganieVM model = new ZamowienieWymaganieVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            model.Klient = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == model.Zamowienie.KlientId);
            IEnumerable<Wymaganie> objWymaganieList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganieList;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateWymaganie(IFormCollection fc, ZamowienieWymaganieVM obj, int id)
        {
            if (fc["SubmitForm"] == "Create")
            {
                var result = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.ZamowienieId == id);
                if (result == null)
                {
                    TempData["error"] = "Wymagane jest dodanie przynajmniej jednego wymagania.";
                    return CreateWymaganie(id);
                }
                else
                {
                    var zamowienieFormDb = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
                    zamowienieFormDb.StatusZamowienia = "Nowe";
                    zamowienieFormDb.UwagiZamowienia = obj.Zamowienie.UwagiZamowienia;
                    _unitOfWork.Zamowienie.Update(zamowienieFormDb);
                    _unitOfWork.Save();
                    TempData["success"] = "Zamówienie zostało pomyślnie dodane.";
                    return RedirectToAction("DetailsZamowienia", "Zamowienie", new { id });
                }
            }

            if (fc["SubmitForm"] == "AddWymaganie")
            {
                var kartaFormDb = _unitOfWork.KartaProjektu.GetFirstOrDefault(x => x.ZamowienieId == id);
                obj.Wymaganie.KartaProjektuId = kartaFormDb.Id;
                _unitOfWork.Wymaganie.AddId(obj.Wymaganie, id);
                var zamowienieId = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
                //AddPrzewodnikPracy(zamowienieId.Id, obj.Wymaganie.Id);
                //AddSwiadectwoJakosci(zamowienieId.Id, obj.Wymaganie.Id);
                _unitOfWork.Save();
                ModelState.Clear();
                TempData["success"] = "Wymaganie zostało pomyślnie dodane.";
                return RedirectToAction("CreateWymaganie", "Zamowienie", new { id });
            }
            return View();
        }

        //public void AddPrzewodnikPracy(int idZamowienia, int idWymagania)
        //{
        //    PrzewodnikPracy przewodnik = new PrzewodnikPracy();
        //    przewodnik.ZamowienieId = idZamowienia;
        //    przewodnik.WymaganieId = idWymagania;
        //    _unitOfWork.PrzewodnikPracy.AddId(przewodnik);
        //    _unitOfWork.Save();
        //}

        //public void AddSwiadectwoJakosci(int idZamowienia, int idWymagania)
        //{
        //    SwiadectwoJakosci swiadectwo = new SwiadectwoJakosci();
        //    swiadectwo.ZamowienieId = idZamowienia;
        //    swiadectwo.WymaganieId = idWymagania;
        //    _unitOfWork.SwiadectwoJakosci.AddId(swiadectwo);
        //    _unitOfWork.Save();
        //}

        #endregion

        public IActionResult Klient()
        {
            IEnumerable<Klient> objKlientList = _unitOfWork.Klient.GetAll();
            return View(objKlientList);
        }

        public IActionResult CreateKlient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateKlient(Klient obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Klient.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Klient został pomyślnie dodany.";
                return RedirectToAction("Klient");
            }
            return View(obj);
        }

        public IActionResult EditKlient(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var klientFormDb = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == id);
            if (klientFormDb == null)
            {
                return NotFound();
            }
            return View(klientFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditKlient(Klient obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Klient.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja klienta przebiegła pomyślnie";
                return RedirectToAction("Klient");
            }
            return View(obj);
        }

        public IActionResult DeleteKlient(int? id)
        {
            var obj = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Klient.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Klient został usunięty";
            return RedirectToAction("Klient");
        }
    }
}
