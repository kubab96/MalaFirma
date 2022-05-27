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
            if(id == null || id == 0)
            {
                //create
                return View(obj);
            }
            else
            {
                obj.Narzedzie = _unitOfWork.Narzedzie.GetFirstOrDefault(u => u.Id == id);
                return View(obj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(NarzedzieTypVM obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Narzedzie.Id == 0)
                {
                    _unitOfWork.Narzedzie.Add(obj.Narzedzie);
                    _unitOfWork.Save();
                    TempData["success"] = "Narzędzie zostało pomyślnie dodane";
                }
                else
                {
                    _unitOfWork.Narzedzie.Update(obj.Narzedzie);
                    _unitOfWork.Save();
                    TempData["success"] = "Narzędzie zostało zedytowane";
                }
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult DeletePytanie(int? id)
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
    }
}
