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
                    .Take(5)
                    .ToList();
            model.Zamowienia = ostatnieZamowienia;

            DateTime dateTime = DateTime.Now.AddDays(30);
            DateTime date = DateTime.Now;
            IEnumerable<Dostawca> dostawcy = _db.Dostawcy.ToArray().Where(x => x.DataWygasniecia < dateTime).ToList();
            model.Dostawcy = dostawcy;
            IEnumerable<Szkolenie> szkolenie = _db.Szkolenia.ToArray().Where(x => x.DataRozpoczecia > date).ToList();
            model.Szkolenia = szkolenie;
            IEnumerable<Audyt> audyt = _db.Audyty.ToArray().Where(x => x.DataRozpoczecia > date).ToList();
            model.Audyty = audyt;
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