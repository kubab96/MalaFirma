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
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll().Where(x => x.ZamowienieId == id);
            model.Procesy = objProcesList;

            return View(model);
        }
    }
}
