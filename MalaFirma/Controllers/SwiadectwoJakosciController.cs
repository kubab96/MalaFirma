using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class SwiadectwoJakosciController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SwiadectwoJakosciController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult SwiadectwoJakosci(int id)
        {
            SwiadectwoJakosciVM model = new SwiadectwoJakosciVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<PrzewodnikPracy> objPrzewodnikiList = _unitOfWork.PrzewodnikPracy.GetAll().Where(x => x.ZamowienieId == id);
            model.PrzewodnikiPracy = objPrzewodnikiList;
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganiaList;
            IEnumerable<SwiadectwoJakosci> objSwiadectwaList = _unitOfWork.SwiadectwoJakosci.GetAll().Where(x => x.ZamowienieId == id);
            model.SwiadectwaJakosci = objSwiadectwaList;

            return View(model);
        }


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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult WynikSwiadectwaJakosci(SwiadectwoJakosci obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ZidentyfikowaneProblemy == null)
                {
                    obj.ZidentyfikowaneProblemy = "N/D";
                }
                if (obj.PlanowaneDzialania == null)
                {
                    obj.PlanowaneDzialania = "N/D";
                }
                _unitOfWork.SwiadectwoJakosci.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Świadectwo jakości zostało zakończone.";
                return RedirectToAction("SwiadectwoJakosci", new { id = obj.ZamowienieId });
            }
            return View(obj);
        }
    }
}
