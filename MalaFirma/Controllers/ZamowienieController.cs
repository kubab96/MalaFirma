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
                _unitOfWork.Zamowienie.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Zamówienie zostało pomyślnie dodane";
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
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Zamowienie.Remove(obj);
            _unitOfWork.Save();
            TempData["delete"] = "Zamówienie zostało usunięte";
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
            return CreateProces(id);
        }























        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public IActionResult Createe(IFormCollection fc, ZamowienieCreateVM obj)
        //{

        //    if (fc["SubmitForm"] == "Preview")
        //    {
        //        _unitOfWork.Zamowienie.Add(obj.Zamowienia);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Zamówienie zostało pomyślnie dodane";
        //        return RedirectToAction("Index");
        //    }
        //    if (fc["SubmitForm"] == "Save")
        //    {

        //        _unitOfWork.Zamowienie.Add(obj.Zamowienia);

        //        var doc = _unitOfWork.Zamowienie.GetFirstOrDefault(d => d.Id == obj.Zamowienia.Id);
        //        if (doc == null)
        //        {
        //            _unitOfWork.Save();
        //        }
        //        else { 
        //        _unitOfWork.Proces.AddId(obj.Procesy, obj.Zamowienia.Id);
        //        _unitOfWork.Save();
        //        }
        //        return View(obj);

        //    }

        //    return View(obj);
        //}
        //public IActionResult Createe()
        //{
        //    ZamowienieCreateVM modell = new ZamowienieCreateVM();
        //    return View(modell);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Createee(ZamowienieProcesVM obj)
        //{
        //    _unitOfWork.Proces.AddId(obj.Procesy, obj.Zamowienia.Id);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Zamówienie zostało pomyślnie dodane";
        //    return RedirectToAction("Index");
        //}
    }
}
