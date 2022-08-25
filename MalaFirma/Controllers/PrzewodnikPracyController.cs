using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Operacja(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Proces = _unitOfWork.Proces.GetFirstOrDefault(x => x.Id == id);
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Operacja> objOperacjaList = _unitOfWork.Operacja.GetAll().Where(x => x.ProcesId == id);
            model.Operacje = objOperacjaList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Operacja(PrzewodnikPracyVM model, IFormFile file, int id, IFormCollection fc)
        {
            model.PrzewodnikPracy = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\rysunki");
                var extension = Path.GetExtension(file.FileName);

                if(model.PrzewodnikPracy.Rysunek != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, model.PrzewodnikPracy.Rysunek.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }
                

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                model.PrzewodnikPracy.Rysunek = @"\images\rysunki\" + fileName + extension;
            }
            if (fc["SubmitForm"] == "Delete")
            {
                if (model.PrzewodnikPracy.Rysunek != null)
                {
                    var oldImage = Path.Combine(wwwRootPath, model.PrzewodnikPracy.Rysunek.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                    model.PrzewodnikPracy.Rysunek = null;
                    _unitOfWork.PrzewodnikPracy.Update(model.PrzewodnikPracy);
                    _unitOfWork.Save();
                    TempData["success"] = "Rysunek został pomyślnie dodany.";
                    return RedirectToAction("Operacja", new { id = model.PrzewodnikPracy.Id });
                }
            }
            _unitOfWork.PrzewodnikPracy.Update(model.PrzewodnikPracy);
            _unitOfWork.Save();
            TempData["success"] = "Rysunek został pomyślnie dodany.";
            return RedirectToAction("Operacja", new { id = model.PrzewodnikPracy.Id });
        }

        public IActionResult DeleteRysunek(int? id)
        {
            var obj = _unitOfWork.PrzewodnikPracy.GetFirstOrDefault(x => x.Id == id);
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            if (obj.Rysunek != null)
            {
                var oldImage = Path.Combine(wwwRootPath, obj.Rysunek.TrimStart('\\'));
                if (System.IO.File.Exists(oldImage))
                {
                    System.IO.File.Delete(oldImage);
                }
                obj.Rysunek = null;
                _unitOfWork.PrzewodnikPracy.Update(obj);
                _unitOfWork.Save();
                ModelState.Clear();
                TempData["success"] = "Rysunek został pomyślnie dodany.";
                return RedirectToAction("Operacja", new { id = obj.Id });
            }
            return View();
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
            ModelState.Clear();
            TempData["success"] = "Operacja została usunięta";
            return RedirectToAction("Operacja", new { id = obj.ProcesId });
        }


    }
}
