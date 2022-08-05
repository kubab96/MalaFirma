using MalaFirma.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class KartaProjektuController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public KartaProjektuController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(int? idZamowienia)
        {
            return View();
        }
    }
}
