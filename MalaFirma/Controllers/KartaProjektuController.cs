using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace SimpleQMS.Controllers
{
    public class KartaProjektuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public KartaProjektuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult KartaProjektu(int id)
        {
            KartaProjektuVM model = new KartaProjektuVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == id);
            IEnumerable<Przeglad> objPrzegladList = _unitOfWork.Przeglad.GetAll().Where(x => x.zamowienieId == id);
            model.Przeglady = objPrzegladList;
            IEnumerable<Wymaganie> objWymaganiaList = _unitOfWork.Wymaganie.GetAll().Where(x => x.ZamowienieId == id);
            model.Wymagania = objWymaganiaList;
            IEnumerable<PrzewodnikPracy> objPrzewodnikiList = _unitOfWork.PrzewodnikPracy.GetAll();
            model.Przewodniki = objPrzewodnikiList;
            IEnumerable<SwiadectwoJakosci> objSwiadectwaList = _unitOfWork.SwiadectwoJakosci.GetAll();
            model.Swiadectwa = objSwiadectwaList;
            model.ZadowolenieKlienta = _unitOfWork.ZadowolenieKlienta.GetFirstOrDefault(x => x.ZamowienieId == id);

            return View(model);
        }
    }
}
