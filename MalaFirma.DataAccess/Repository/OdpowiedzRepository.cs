﻿using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
{
    public class OdpowiedzRepository : Repository<Odpowiedz>, IOdpowiedzRepository
    {
        private ApplicationDbContext _db;

        public OdpowiedzRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Odpowiedz obj, int idPytania, int idPrzegladu)
        {
            obj.PytanieId = idPytania;
            obj.PrzegladId = idPrzegladu;
            if (obj.Wartosc == false)
            {
                obj.Status = "Nie";
            }
            else
            {
                obj.Status = "Tak";
            }
            _db.Odpowiedzi.Update(obj);
        }
        public void AddId(Odpowiedz obj, int idPytania, int idPrzegladu)
        {
            obj.PytanieId = idPytania;
            obj.PrzegladId = idPrzegladu;
            if (obj.Wartosc == false)
            {
                obj.Status = "Nie";
            }
            else
            {
                obj.Status = "Tak";
            }
            _db.Odpowiedzi.Add(obj);
        }
    }
}
