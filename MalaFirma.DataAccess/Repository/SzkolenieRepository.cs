using MalaFirma.DataAccess.Repository.IRepository;
using MalaFirma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaFirma.DataAccess.Repository
{
    public class SzkolenieRepository : Repository<Szkolenie>, ISzkolenieRepository
    {
        private ApplicationDbContext _db;

        public SzkolenieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Szkolenie obj)
        {
            _db.Szkolenia.Update(obj);
        }
        public void AddId(Szkolenie obj)
        {
            _db.Szkolenia.Add(obj);
        }
    }
}
