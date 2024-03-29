﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleQMS.DataAccess.Repository.IRepository;
using SimpleQMS.Models;

namespace SimpleQMS.DataAccess.Repository
{
    public class TypNarzedziaRepository : Repository<TypNarzedzia>, ITypNarzedziaRepository
    {
        private ApplicationDbContext _db;

        public TypNarzedziaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TypNarzedzia obj)
        {
            _db.TypNarzedzia.Update(obj);
        }
        public void AddId(TypNarzedzia obj)
        {

            _db.TypNarzedzia.Add(obj);
        }
    }
}
