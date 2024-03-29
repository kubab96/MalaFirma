﻿using SimpleQMS.DataAccess;
using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using SimpleQMS.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SimpleQMS.Controllers
{
    public class PracownikController : Controller
    {
        private ApplicationDbContext _application;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleMenager;
        public PracownikController(ApplicationDbContext application, RoleManager<IdentityRole> roleMenager, UserManager<ApplicationUser> userManager)
        {
            _application = application;
            _roleMenager = roleMenager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var usersWithRoles = (from roleUser in _application.UserRoles
                                  join role in _application.Roles on roleUser.RoleId equals role.Id
                                  join user in _application.Users on roleUser.UserId equals user.Id
                                  join userDetails in _application.ApplicationUsers on user.UserName equals userDetails.UserName
                                  select new
                                  {
                                      Id = user.Id,
                                      Username = user.UserName,
                                      Role = role.Name,
                                      Imie = userDetails.Imie,
                                      Nazwisko = userDetails.Nazwisko,
                                  }).ToList().Select(p => new UzytkownicyVM()

                                  {
                                      Id = p.Id,
                                      Username = p.Username,
                                      Role = p.Role,
                                      Imie = p.Imie,
                                      Nazwisko = p.Nazwisko,
                                  });
            return View(usersWithRoles);
        }

        public async Task<IActionResult> DetailsUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Użytkownik o podanym identyfikatorze nie istnieje!";
                return View();
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);


            var model = new EditUserVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Imie = user.Imie,
                Nazwisko = user.Nazwisko,
                Kraj = user.Kraj,
                Miasto = user.Miasto,
                UlicaNumer = user.UlicaNumer,
                KodPocztowy = user.KodPocztowy,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles,

            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                ViewBag.ErrorMessage = $"Użytkownik o podanym identyfikatorze nie istnieje!";
                return View();
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            

            var model = new EditUserVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Imie = user.Imie,
                Nazwisko = user.Nazwisko,
                Kraj = user.Kraj,
                Miasto = user.Miasto,
                UlicaNumer = user.UlicaNumer,
                KodPocztowy = user.KodPocztowy,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles,

            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserVM model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Użytkownik o podanym identyfikatorze nie istnieje!";
                return View();
            }
            else
            {
                user.Imie = model.Imie;
                user.Nazwisko = model.Nazwisko;
                user.Kraj = model.Kraj;
                user.Miasto = model.Miasto;
                user.UlicaNumer = model.UlicaNumer;
                user.KodPocztowy = model.KodPocztowy;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Użytkownik o podanym identyfikatorze nie istnieje!";
                return View();
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View("Index");
        }
    }
}
