using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class PrzewodnikPracyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PrzewodnikPracyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult PrzewodnikPracy(int id)
        {
            PrzewodnikPracyVM model = new PrzewodnikPracyVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll().Where(x => x.ZamowienieId == id);
            model.Procesy = objProcesList;

            return View(model);
        }

    }
}
