﻿using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
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
        public IActionResult KartaProjektu(int id)
        {
            KartaProjektuVM model = new KartaProjektuVM();
            model.Zamowienie = _unitOfWork.Zamowienie.GetFirstOrDefault(x => x.Id == id);
            model.Przeglad = _unitOfWork.Przeglad.GetFirstOrDefault(x => x.zamowienieId == id);
            IEnumerable<Przeglad> objPrzegladList = _unitOfWork.Przeglad.GetAll().Where(x => x.zamowienieId == id);
            model.Przeglady = objPrzegladList;
            IEnumerable<Proces> objProcesList = _unitOfWork.Proces.GetAll().Where(x => x.ZamowienieId == id);
            model.Procesy = objProcesList;
            
            return View(model);
        }
    }
}