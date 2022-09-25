using Microsoft.AspNetCore.Mvc;
using SimpleQMS.DataAccess;
using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace SimpleQMS.Controllers
{
    public class NarzedzieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NarzedzieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            IEnumerable<Narzedzie> objNarzedzieList = _unitOfWork.Narzedzie.GetAll(includeProperties: "TypNarzedzia");
            return View(objNarzedzieList);
        }

        public ActionResult DetailsNarzedzie(int? id)
        {
            NarzedzieTypVM model = new NarzedzieTypVM();
            model.Narzedzie = _unitOfWork.Narzedzie.GetFirstOrDefault(x => x.Id == id);
            model.TypNarzedzia = _unitOfWork.TypNarzedzia.GetFirstOrDefault(x => x.Id == model.Narzedzie.TypNarzedziaId);
            if(model.Narzedzie.ObslugaMetrologiczna == true)
            {
                model.ObslugaMetrologiczna = _unitOfWork.ObslugaMetrologiczna.GetFirstOrDefault(x => x.NarzedzieId == id);
            }
            return View(model);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult Upsert(int? id)
        {
            NarzedzieTypVM obj = new()
            {
                Narzedzie = new(),
                TypNarzedzi = _unitOfWork.TypNarzedzia.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.NazwaTypu,
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
                obj.Narzedzie = _unitOfWork.Narzedzie.GetFirstOrDefault(u => u.Id == id);
                obj.ObslugaMetrologiczna = _unitOfWork.ObslugaMetrologiczna.GetFirstOrDefault(x => x.NarzedzieId == id);
                return View(obj);
            }
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(NarzedzieTypVM obj)
        {

            if (obj.Narzedzie.Id == 0)
            {
                _unitOfWork.Narzedzie.Add(obj.Narzedzie);
                _unitOfWork.Save();
                if (obj.Narzedzie.ObslugaMetrologiczna == true)
                {
                    AddObsluga(obj.Narzedzie.Id, obj.ObslugaMetrologiczna.DataWaznosci);
                }
                TempData["success"] = "Narzędzie zostało pomyślnie utworzone";
                return RedirectToAction("DetailsNarzedzie", "Narzedzie", new { id = obj.Narzedzie.Id });
            }
            else
            {
                _unitOfWork.Narzedzie.Update(obj.Narzedzie);
                if (obj.Narzedzie.ObslugaMetrologiczna == true)
                {
                    var obsluga = _unitOfWork.ObslugaMetrologiczna.GetFirstOrDefault(x => x.NarzedzieId == obj.Narzedzie.Id);
                    if (obsluga == null)
                    {
                        AddObsluga(obj.Narzedzie.Id, obj.ObslugaMetrologiczna.DataWaznosci);
                    }
                    else
                    {
                        EditObsluga(obj.Narzedzie.Id, obj.ObslugaMetrologiczna.DataWaznosci);
                    }

                }
                _unitOfWork.Save();
                TempData["success"] = "Narzędzie zostało zaktualizowane";
            }
            return View(obj);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult EditDataObslugi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obslugaMetrologiczna = _unitOfWork.ObslugaMetrologiczna.GetFirstOrDefault(x => x.NarzedzieId == id);
            return PartialView(obslugaMetrologiczna);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        public IActionResult EditDataObslugi(ObslugaMetrologiczna obj)
        {
            _unitOfWork.ObslugaMetrologiczna.Update(obj);
            _unitOfWork.Save();
            TempData["success"] = "Data obsługi metrologicznej została zaktualizowana";
            return RedirectToAction("DetailsNarzedzie", "Narzedzie", new { id = obj.NarzedzieId });
        }

        public void AddObsluga(int id, DateTime dataWaznosci)
        {
            ObslugaMetrologiczna obsluga = new ObslugaMetrologiczna();
            obsluga.DataWaznosci = dataWaznosci;
            obsluga.NarzedzieId = id;
            _unitOfWork.ObslugaMetrologiczna.AddId(obsluga);
            _unitOfWork.Save();
        }

        public void EditObsluga(int id, DateTime dataWaznosci)
        {
            var obsluga = _unitOfWork.ObslugaMetrologiczna.GetFirstOrDefault(x => x.NarzedzieId == id);
            obsluga.DataWaznosci = dataWaznosci;
            _unitOfWork.ObslugaMetrologiczna.Update(obsluga);
            _unitOfWork.Save();
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Narzedzie.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Narzedzie.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Narzedzie zostało usunięte";
            return RedirectToAction("Index");
        }

        public IActionResult TypNarzedzia()
        {
            IEnumerable<TypNarzedzia> objTypNarzedziaList = _unitOfWork.TypNarzedzia.GetAll();
            return View(objTypNarzedziaList);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult CreateTypNarzedzia()
        {
            return View();
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTypNarzedzia(TypNarzedzia obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypNarzedzia.AddId(obj);
                _unitOfWork.Save();
                TempData["success"] = "Typ Narzędzia został pomyślnie utworzony";
                return RedirectToAction("TypNarzedzia");
            }
            return View(obj);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult EditTypNarzedzia(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var typNarzedziaFormDb = _unitOfWork.TypNarzedzia.GetFirstOrDefault(x => x.Id == id);
            if (typNarzedziaFormDb == null)
            {
                return NotFound();
            }
            return View(typNarzedziaFormDb);
        }

        [Authorize(Roles = "Menager, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTypNarzedzia(TypNarzedzia obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypNarzedzia.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Typu narzędzia został zaktualizowany";
                return RedirectToAction("TypNarzedzia");
            }
            return View(obj);
        }

        [Authorize(Roles = "Menager, Admin")]
        public IActionResult DeleteTypNarzedzia(int? id)
        {
            var obj = _unitOfWork.TypNarzedzia.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.TypNarzedzia.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Typ narzedzia został usunięty";
            return RedirectToAction("TypNarzedzia");
        }
    }
}
