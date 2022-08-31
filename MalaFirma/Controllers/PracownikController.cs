using MalaFirma.DataAccess;
using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using Microsoft.AspNetCore.Mvc;

namespace MalaFirma.Controllers
{
    public class PracownikController : Controller
    {
        private ApplicationDbContext _application;
        public PracownikController(ApplicationDbContext application)
        {
            _application = application;
        }
        public IActionResult Index()
        {
            var usersWithRoles = (from roleUser in _application.UserRoles
                                  join role in _application.Roles on roleUser.RoleId equals role.Id
                                  join user in _application.Users on roleUser.UserId equals user.Id
                                  join userDetails in _application.ApplicationUsers on user.UserName equals userDetails.UserName
                                  select new
                                  {
                                      Username = user.UserName,
                                      Role = role.Name,
                                      Imie = userDetails.Imie,
                                      Nazwisko = userDetails.Nazwisko,
                                  }).ToList().Select(p => new UzytkownicyVM()

                                  {
                                      Username = p.Username,
                                      Role = p.Role,
                                      Imie = p.Imie,
                                      Nazwisko= p.Nazwisko,
                                  });
            return View(usersWithRoles);
        }
    }
}
