using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
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
            return View(objZamowienieList);
        }

        public IActionResult Upsert(int? id)
        {
            ZamowienieProcesVM obj = new()
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
        public IActionResult Upsert(ZamowienieProcesVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Zamowienie.Id == 0)
                {
                    obj.Zamowienie.StatusZamowienia = "Nie potwierdzone";
                    _unitOfWork.Zamowienie.Add(obj.Zamowienie);
                    _unitOfWork.Save();
                    AddKartaProjektu(obj.Zamowienie.Id);
                    return RedirectToAction("CreateProces", new { id = obj.Zamowienie.Id });
                }
                else
                {
                    obj.Zamowienie.StatusZamowienia = obj.Zamowienie.StatusZamowienia;
                    obj.Zamowienie.DataZamowienia = obj.Zamowienie.DataZamowienia;
                    obj.Zamowienie.KlientId = obj.Zamowienie.KlientId;
                    _unitOfWork.Zamowienie.Update(obj.Zamowienie);
                    _unitOfWork.Save();
                    TempData["success"] = "Zamowienie zostało zedytowane";
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
            var obj2 = _unitOfWork.Odpowiedz.GetAll().Where(Odpowiedz => Odpowiedz.ZamowienieId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Zamowienie.Remove(obj);
            _unitOfWork.Odpowiedz.RemoveRange(obj2);
            _unitOfWork.Save();
            TempData["error"] = "Zamówienie zostało usunięte";
            return RedirectToAction("Index");
        }

        public ActionResult DetailsZamowienia(int? id)
        {
            ZamowienieProcesVM model = new ZamowienieProcesVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            model.Klient = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == model.Zamowienie.KlientId);
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll().Where(x => x.ZamowienieId == id);
            model.Procesy = objProcesList;
            return View(model);
        }

        #endregion

        #region Procesy
        public IActionResult CreateProces(int? id)
        {
            ZamowienieProcesVM model = new ZamowienieProcesVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            model.Klient = _unitOfWork.Klient.GetFirstOrDefault(x => x.Id == model.Zamowienie.KlientId);
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll().Where(x => x.ZamowienieId == id);
            model.Procesy = objProcesList;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProces(IFormCollection fc, ZamowienieProcesVM obj, int id)
        {
            if (fc["SubmitForm"] == "Create")
            {
                var result = _unitOfWork.Proces.GetFirstOrDefault(x => x.ZamowienieId == id);
                if (result == null)
                {
                    TempData["error"] = "Wymagane jest dodanie przynajmniej jednego procesu";
                    return CreateProces(id);
                }
                else
                {
                    var zamowienieFormDb = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
                    zamowienieFormDb.StatusZamowienia = "Nowe";
                    _unitOfWork.Zamowienie.Update(zamowienieFormDb);
                    _unitOfWork.Save();
                    TempData["success"] = "Zamówienie zostało pomyślnie dodane";
                    return RedirectToAction("DetailsZamowienia", "Zamowienie", new { id });
                }
            }

            if (fc["SubmitForm"] == "AddProces")
            {
                var kartaFormDb = _unitOfWork.KartaProjektu.GetFirstOrDefault(x => x.ZamowienieId == id);
                obj.Proces.KartaProjektuId = kartaFormDb.Id;
                _unitOfWork.Proces.AddId(obj.Proces, id);
                var zamowienieId = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
                AddPrzewodnikPracy(zamowienieId.Id, obj.Proces.Id);
                _unitOfWork.Save();
                ModelState.Clear();
                TempData["success"] = "Proces został pomyślnie dodany";
                return CreateProces(id);
            }
            return View();
        }

        public void AddPrzewodnikPracy(int idZamowienia, int idProcesu)
        {
            PrzewodnikPracy przwodnik = new PrzewodnikPracy();
            przwodnik.ZamowienieId = idZamowienia;
            przwodnik.ProcesId = idProcesu;
            _unitOfWork.PrzewodnikPracy.AddId(przwodnik);
            _unitOfWork.Save();
        }

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
