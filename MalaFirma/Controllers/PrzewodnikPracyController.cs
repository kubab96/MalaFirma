using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class PrzewodnikPracyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PrzewodnikPracyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult PrzewodnikPracy(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll().Where(x => x.ZamowienieId == id);
            model.Procesy = objProcesList;

            return View(model);
        }

        [HttpPost]
        public IActionResult PrzewodnikPracy(PrzewodnikPracyVM model)
        {
            


            return View(model);
        }

        

        public IActionResult Operacja(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Proces = _unitOfWork.Proces.GetFirstOrDefault(x => x.Id == id);
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Operacja> objOperacjaList = _unitOfWork.Operacja.GetAll().Where(x => x.ProcesId == id);
            model.Operacje = objOperacjaList;
            return View(model);
        }

        public IActionResult AddOperacja(int? idProcesu)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Proces = _unitOfWork.Proces.GetFirstOrDefault(x => x.Id == idProcesu);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOperacja(PrzewodnikPracyVM obj, int idProcesu)
        {
            _unitOfWork.Operacja.AddId(obj.Operacja, idProcesu);
            _unitOfWork.Save();
            TempData["success"] = "Operacja została pomyślnie dodana";
            return RedirectToAction("Operacja", new { id = idProcesu });
        }

        public IActionResult EditOperacja(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var operacjaFormDb = _unitOfWork.Operacja.GetFirstOrDefault(x => x.Id == id);
            if (operacjaFormDb == null)
            {
                return NotFound();
            }
            return View(operacjaFormDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditOperacja(Operacja obj, int idProcesu)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Operacja.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Edycja operacji przebiegła pomyślnie";
                return RedirectToAction("Operacja", new { id = idProcesu });

            }
            return View(obj);
        }

        public IActionResult DeleteOperacja(int? id)
        {
            var obj = _unitOfWork.Operacja.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Operacja.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Operacja została usunięta";
            return RedirectToAction("Operacja", new { id = obj.ProcesId });
        }


    }
}
