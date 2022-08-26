using Microsoft.AspNetCore.Mvc;
using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MalaFirma.Controllers
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(NarzedzieTypVM obj)
        {

            if (obj.Narzedzie.Id == 0)
            {
                int numer = 1;
                var liczbaNarzedzi = _unitOfWork.Narzedzie.GetAll().Count();
                int numerIdentyfikacyjny = numer + liczbaNarzedzi;
                obj.Narzedzie.NumerIdentyfikacyjny = "FM/" + numerIdentyfikacyjny;
                _unitOfWork.Narzedzie.Add(obj.Narzedzie);
                _unitOfWork.Save();
                if (obj.Narzedzie.ObslugaMetrologiczna == true)
                {
                    AddObsluga(obj.Narzedzie.Id, obj.ObslugaMetrologiczna.DataWaznosci);
                }
                TempData["success"] = "Narzędzie zostało pomyślnie dodane";
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
                TempData["success"] = "Narzędzie zostało zedytowane";
            }
            return RedirectToAction("Index");
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

        public IActionResult CreateTypNarzedzia()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTypNarzedzia(TypNarzedzia obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypNarzedzia.AddId(obj);
                _unitOfWork.Save();
                TempData["success"] = "Typ Narzędzia został pomyślnie dodany";
                return RedirectToAction("TypNarzedzia");
            }
            return View(obj);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTypNarzedzia(TypNarzedzia obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypNarzedzia.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja typu narzędzia przebiegła pomyślnie";
                return RedirectToAction("TypNarzedzia");
            }
            return View(obj);
        }

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
