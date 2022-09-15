using MalaFirma.DataAccess;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MalaFirma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            DaneVM model = new DaneVM();
            IEnumerable<Zamowienie> ostatnieZamowienia = _db.Zamowienia.ToArray().Where(x => x.StatusZamowienia != "Nie potwierdzone")
                    .Reverse()
                    .Take(8)
                    .ToList();
            model.Zamowienia = ostatnieZamowienia;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IViewComponentResult OstatnieZamowienia()
        //{
        //    IEnumerable<Zamowienie> zamowienia = _db.Zamowienia.ToArray()
        //            .Reverse()
        //            .Take(8)
        //            .ToList();
        //    return (IViewComponentResult)View(zamowienia);
        //}
    }
}