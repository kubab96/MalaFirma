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
        private readonly ApplicationDbContext _db;

        public ZamowienieController(IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        #region Zamowienia
        public IActionResult Index()
        {
            IEnumerable<Zamowienie> objZamowienieList = _unitOfWork.Zamowienie.GetAll();
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
                    AddPrzeglad(obj.Zamowienie.Id);
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
                    return RedirectToAction("DetailsZamowienia", "Zamowienie", new { obj.Zamowienie.Id });
                }
            }
            return View(obj);
        }

        public void AddPrzeglad(int zamowienieId)
        {
            Przeglad obj = new Przeglad();
            obj.WynikPrzegladu = "Nie wykonano";
            _unitOfWork.Przeglad.AddId(obj, zamowienieId);
            _unitOfWork.Save();
        }

        public void ZakonczZamowienieMethod(int? id)
        {
            var obj = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            obj.StatusZamowienia = "Zakończono";
            _unitOfWork.Zamowienie.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Zamówienie zostało zakończone!";
            RedirectToAction("Index").ExecuteResult(this.ControllerContext);
        }

        public IActionResult ZakonczZamowienie(int? id)
        {
            var obj = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            ZakonczZamowienieMethod(id);
            return RedirectToAction("Index");
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
            var obj2 = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            foreach (var item in obj2)
            {
                var obj3 = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == item.Id);
                if (obj3 != null)
                {
                    _unitOfWork.PrzewodnikPracy.Remove(obj3);
                    _unitOfWork.Save();
                }
            }
            foreach (var item in obj2)
            {
                var obj4 = _unitOfWork.SwiadectwoJakosci.GetFirstOrDefault(x => x.WymaganieId == item.Id);
                if (obj4 != null)
                {

                    _unitOfWork.SwiadectwoJakosci.Remove(obj4);
                    _unitOfWork.Save();
                }
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
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganiaList;
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == id);
            model.ZadowolenieKlienta = _unitOfWork.ZadowolenieKlienta.GetFirstOrDefault(x => x.ZamowienieId == id);
            IEnumerable<PrzewodnikPracy> objPrzewodnikiList = _unitOfWork.PrzewodnikPracy.GetAll();
            model.PrzewodnikiPracy = objPrzewodnikiList;
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
                _unitOfWork.Wymaganie.AddId(obj.Wymaganie, id);
                var zamowienieId = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
                AddPrzewodnikPracy(obj.Wymaganie.Id);
                AddSwiadectwoJakosci(obj.Wymaganie.Id);
                _unitOfWork.Save();
                ModelState.Clear();
                TempData["success"] = "Wymaganie zostało pomyślnie dodane.";
                return RedirectToAction("CreateWymaganie", "Zamowienie", new { id });
            }
            return View();
        }

        public ActionResult Wymagania(int? id)
        {
            ZamowienieWymaganieVM model = new ZamowienieWymaganieVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Wymaganie> objWymaganieList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganieList;
            return View(model);
        }

        public IActionResult EditWymaganie(int? id, int? editId)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var wymaganieFormDb = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            ViewBag.EditId = editId;
            if (wymaganieFormDb == null)
            {
                return NotFound();
            }
            return View(wymaganieFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWymaganie(Wymaganie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Wymaganie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja wymagania przebiegła pomyślnie";
                int x = Convert.ToInt32(TempData["Data1"]);
                if (x == 0)
                {
                    return RedirectToAction("Wymagania", "Zamowienie", new { id =  obj.ZamowienieId });
                }
                else
                {
                    return RedirectToAction("CreateWymaganie", "Zamowienie", new { id = obj.ZamowienieId });
                }
            }
            return View(obj);
        }

        public IActionResult AddWymaganie(int? idZamowienia)
        {
            ZamowienieWymaganieVM model = new ZamowienieWymaganieVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWymaganie(ZamowienieWymaganieVM obj, int idZamowienia)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Wymaganie.AddId(obj.Wymaganie, idZamowienia);
                var zamowienieId = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
                AddPrzewodnikPracy(obj.Wymaganie.Id);
                _unitOfWork.Save();
                TempData["success"] = "Wymaganie zostało pomyślnie dodane.";
                return RedirectToAction("Wymagania", "Zamowienie", new { id = idZamowienia });
            }
            return View(obj);
        }

        public IActionResult DeleteWymaganie(int? id)
        {

            var obj = _unitOfWork.Wymaganie.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Wymaganie.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Wymaganie zostało usunięte";
            id = obj.ZamowienieId;
            return RedirectToAction("CreateWymaganie", "Zamowienie", new { id });
        }

        public void AddPrzewodnikPracy(int idWymagania)
        {
            PrzewodnikPracy przewodnik = new PrzewodnikPracy();
            przewodnik.WymaganieId = idWymagania;
            przewodnik.WynikPrzewodnika = "";
            _unitOfWork.PrzewodnikPracy.AddId(przewodnik);
            _unitOfWork.Save();
        }

        public void AddSwiadectwoJakosci(int idWymagania)
        {
            SwiadectwoJakosci swiadectwo = new SwiadectwoJakosci();
            swiadectwo.WymaganieId = idWymagania;
            swiadectwo.WynikSwiadectwa = "";
            _unitOfWork.SwiadectwoJakosci.AddId(swiadectwo);
            _unitOfWork.Save();
        }

        #endregion

        public IActionResult Klient()
        {
            IEnumerable<Klient> objKlientList = _unitOfWork.Klient.GetAll();
            return View(objKlientList);
        }

        public ActionResult DetailsKlient(int? id)
        {
            var klient = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == id);
            return View(klient);
        }

        public IActionResult CreateKlient()
        {
            return View();
        }

        [HttpPost]
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
            try
            {
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Nie można usunąć klienta przypisanego do zamówienia";
                return RedirectToAction("Klient");
            }
            TempData["success"] = "Klient został usunięty";
            return RedirectToAction("Klient");
        }

        public IActionResult ZadowolenieKlienta(int? idZamowienia)
        {
            ZamowienieWymaganieVM model = new ZamowienieWymaganieVM();
            model.ZadowolenieKlienta = _unitOfWork.ZadowolenieKlienta.GetFirstOrDefault(x => x.ZamowienieId == idZamowienia);
            if (model.ZadowolenieKlienta == null)
            {
                return RedirectToAction("CreateZadowolenie", "Zamowienie", new { idZamowienia });
            }
            model.Klient = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == model.ZadowolenieKlienta.KlientId);
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            return View(model);
        }

        public IActionResult CreateZadowolenie(int idZamowienia)
        {
            ZamowienieWymaganieVM model = new ZamowienieWymaganieVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateZadowolenie(ZamowienieWymaganieVM obj, int idZamowienia)
        {
            obj.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == idZamowienia);
            obj.Klient = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == obj.Zamowienie.KlientId);
            obj.ZadowolenieKlienta.ZamowienieId = idZamowienia;
            obj.ZadowolenieKlienta.Zamowienie = obj.Zamowienie;
            obj.ZadowolenieKlienta.KlientId = obj.Klient.Id;
            obj.ZadowolenieKlienta.DataZakonczeniaZadowolenia = DateTime.Now;
            if (ModelState.IsValid)
            {
                _unitOfWork.ZadowolenieKlienta.Add(obj.ZadowolenieKlienta);
                _unitOfWork.Save();
                TempData["success"] = "Zadowolenie klienta zostało pomyślnie dodane.";
                return RedirectToAction("DetailsZamowienia", "Zamowienie", new { id = idZamowienia });
            }
            return View(obj);
        }

        public IActionResult EditZadowolenie(int? id, int? zamowienieId)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var zadowolenieFormDb = _unitOfWork.ZadowolenieKlienta.GetFirstOrDefault(x => x.Id == id);
            if (zadowolenieFormDb == null)
            {
                return NotFound();
            }
            return View(zadowolenieFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditZadowolenie(ZadowolenieKlienta obj, int? zamowienieId)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Wymaganie> objWymaganieList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == zamowienieId);
                foreach(var item in objWymaganieList)
                {
                    var objPrzewodnik = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.WymaganieId == item.Id);
                    if(obj.DataZakonczeniaZadowolenia < objPrzewodnik.DataZakonczeniaPrzewodnika)
                    {
                        TempData["error"] = "Nie można wprowadzić daty dalszej niż data zakończonego przewodnika";
                        return View(obj);
                    }
                }
                
                _unitOfWork.ZadowolenieKlienta.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Zadowolenie klienta zostało pomyślnie zaktualizowane";
                return RedirectToAction("DetailsZamowienia", "Zamowienie", new { id = zamowienieId });
            }
            return View(obj);
        }

        
    }
}
