﻿using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQMS.DataAccess.Repository
{
    public class OperacjaRepository : Repository<Operacja>, IOperacjaRepository
    {
        private ApplicationDbContext _db;

        public OperacjaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Operacja obj)
        {
            var objFromDb = _db.Operacje.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.TrescOperacji = obj.TrescOperacji;
                objFromDb.DataWykonania = obj.DataWykonania;
            }
        }
        public void AddId(Operacja obj)
        {
            _db.Operacje.Add(obj);
        }
    }
}