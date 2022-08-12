﻿using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class ObslugaMetrologicznaRepository : Repository<ObslugaMetrologiczna>, IObslugaMetrologicznaRepository
    {
        private ApplicationDbContext _db;

        public ObslugaMetrologicznaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ObslugaMetrologiczna obj)
        {
            _db.ObslugaMetrologiczna.Update(obj);
        }
        public void AddId(ObslugaMetrologiczna obj)
        {

            _db.ObslugaMetrologiczna.Add(obj);
        }
    }
}
