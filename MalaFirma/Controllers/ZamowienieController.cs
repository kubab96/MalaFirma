using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Zamowienie> objZamowienieList = _unitOfWork.Zamowienie.GetAll();
            return View(objZamowienieList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Zamowienie obj)
        {
            if (ModelState.IsValid)
            {
                obj.StatusZamowienia = "Nie potwierdzone";
                _unitOfWork.Zamowienie.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("CreateProces", new { id = obj.Id });
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var zamowienieFormDb = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            if (zamowienieFormDb == null)
            {
                return NotFound();
            }
            return View(zamowienieFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Zamowienie obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Zamowienie.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja zamówienia przebiegła pomyślnie";
                return RedirectToAction("Index");
            }
            return View(obj);
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
            model.Zamowienia = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll().Where(x => x.ZamowienieId == id);
            model.Procesy = objProcesList;
            return View(model);
        }

        #endregion

        #region Procesy
        public IActionResult CreateProces(int? id)
        {
            ZamowienieProcesVM model = new ZamowienieProcesVM();
            model.Zamowienia = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
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
                _unitOfWork.Proces.AddId(obj.Proces, id);
                _unitOfWork.Save();
                ModelState.Clear();
                TempData["success"] = "Proces został pomyślnie dodany";
                return CreateProces(id);
            }
            return View();
        }

        #endregion
    }
}
